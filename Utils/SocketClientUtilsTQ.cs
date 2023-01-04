using SampleProcessingSystem.Model;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SampleProcessingSystem.Utils
{
    public class SocketClientUtilsTQ
    {
        #region 完成连接事件信号触发及函数
        public delegate void ConnectSuccess<Q1>(Q1 boject);
        public static event ConnectSuccess<string> ClientConnectSuccess;
        public static bool IsConnect_TQ = false;

        public virtual void ConnectComplete(string ipEndPoint)//完成连接事件信号量触发判断
        {
            if (ClientConnectSuccess != null)
                ClientConnectSuccess(ipEndPoint);
        }
        #endregion

        public void AddMethod(Action<ReceiveData> Method)
        {
            ServerReceiveSuccess = new SocketClientUtilsTQ.receiveSuccess<ReceiveData>(Method);
        }

        public void DeleteMethod()
        {
            if (ServerReceiveSuccess != null)
            {
                Delegate[] dels = ServerReceiveSuccess.GetInvocationList();
                foreach (Delegate d in dels)
                {
                    //得到方法名  
                    object delObj = d.GetType().GetProperty("Method").GetValue(d, null);
                    string funcName = (string)delObj.GetType().GetProperty("Name").GetValue(delObj, null);
                    Console.WriteLine("取消注册" + funcName);
                    ServerReceiveSuccess -= d as receiveSuccess<ReceiveData>;
                }
            }
        }

        #region 接收数据以后信号事件触发及触发函数
        public delegate void receiveSuccess<ReceiveData>(ReceiveData str);   //接收数据委托
        public static event receiveSuccess<ReceiveData> ServerReceiveSuccess;

        public virtual void ReceiveComplete(ReceiveData data)//接收数据信号触发函数
        {
            if (ServerReceiveSuccess != null)
                ServerReceiveSuccess(data);
        }
        #endregion


        public void DeleteMethodByName(string name)
        {
            if (ServerReceiveSuccess != null)
            {
                Delegate[] dels = ServerReceiveSuccess.GetInvocationList();
                foreach (Delegate d in dels)
                {
                    //得到方法名  
                    object delObj = d.GetType().GetProperty("Method").GetValue(d, null);
                    string funcName = (string)delObj.GetType().GetProperty("Name").GetValue(delObj, null);
                    if (funcName == name)
                    {
                        Console.WriteLine("取消注册" + funcName);
                        ServerReceiveSuccess -= d as receiveSuccess<ReceiveData>;
                    }
                }
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnect_TQ()
        {
            if (client_TQ == null)
                return;

            if (!client_TQ.Connected)
                return;

            try
            {
                client_TQ.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }

            try
            {
                client_TQ.Close();
            }
            catch
            {
            }
            IsConnect_TQ = false;
        }



        /// <summary>
        ///连接状态
        /// </summary>
        public bool IsConnectSocket_TQ()
        {
            if (client_TQ == null)
            {
                return false;
            }
            return client_TQ.Connected;
        }

        public byte[] buffer = new byte[1024 * 1024 * 3];
        private static Socket client_TQ = null;

        public void StartClient()
        {
            try
            {
                DisConnect_TQ();
                IPAddress ipAddress = IPAddress.Parse(GetDataUtils.TQServerIP);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, GetDataUtils.TQServerPort);
                client_TQ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client_TQ.SendTimeout = 10000;
                //client_TQ.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, true);

                var tcpKeepalive = new byte[12];
                client_TQ.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true); // enable keep-alive
                BitConverter.GetBytes((uint)1).CopyTo(tcpKeepalive, 0); // switch on
                BitConverter.GetBytes(5000).CopyTo(tcpKeepalive, 4);  // wait time(ms)
                BitConverter.GetBytes(10000).CopyTo(tcpKeepalive, 8);// interval(ms)
                client_TQ.IOControl(IOControlCode.KeepAliveValues, tcpKeepalive, null); // set keep-alive parameter

                client_TQ.BeginConnect(remoteEP, new AsyncCallback(ConnectCallBack), client_TQ);
            }
            catch (Exception ee)
            {
                IsConnect_TQ = false;
                //client_TQ = null;
                ConnectComplete("未联机");//连接成功信号量 
                Console.WriteLine(ee.ToString());
            }
        }

        private void ConnectCallBack(IAsyncResult ar)//连接回调函数
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);

                client.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);
                Console.WriteLine("Socket connect to {0}", client.RemoteEndPoint.ToString());
                log4netHelper.Info(string.Format("Socket connect to {0}", client.RemoteEndPoint.ToString()));
                IsConnect_TQ = true;
                ConnectComplete("已联机");//连接成功信号量 
            }
            catch (Exception e)
            {
                IsConnect_TQ = false;
                //client_TQ = null;
                ConnectComplete("未联机");//连接成功信号量 
                log4netHelper.Error(e.ToString());
            }
        }

        #region   接收数据
        /// <summary>
        /// 接收数据部分
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                if (client_TQ.Connected)
                {
                    //Socket socket = (Socket)ar.AsyncState;
                    int bytesRead = client_TQ.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        byte[] haveDate = ByteToByte(buffer, bytesRead, 0);//取出有效的字节数据,得到实际的数据haveDate
                        Array.Clear(buffer, 0, buffer.Length);//情况缓冲数组

                        string s1 = ByteArrayToHexString(haveDate);

                        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " 接收<-- " + s1);
                        log4netHelper.Info("接收<-- " + s1);
                        DataReceiveHandle(s1);//处理数据
                        client_TQ.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);//接收剩余的数据或者继续接收数据
                    }
                    else //如果接收到数据字符为0，代表接收完了
                    {
                        client_TQ.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);//继续接收数据
                    }
                }
                else
                {
                    ConnectComplete("未联机");//连接成功信号量 
                    IsConnect_TQ = false;
                    client_TQ = null;
                }
            }
            catch (Exception ee)
            {
                //服务器断开连接后在此处
                log4netHelper.Info(ee.ToString());
                log4netHelper.Error(ee.ToString());
                ConnectComplete("未联机");//连接成功信号量 
                IsConnect_TQ = false;
                client_TQ = null;
                Console.WriteLine(ee.ToString());
            }
        }

        #endregion

        /// <summary>
        /// 数据接收处理 
        /// </summary>
        void DataReceiveHandle(string data)
        {
            switch (data)
            {
                case "EA0000":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "EA0000")); })).Start();
                    break;
                case "EA0101":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "EA0101")); })).Start();
                    break;
                case "EA0102":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "EA0102")); })).Start();
                    break;
                case "EA0201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "EA0201")); })).Start();
                    break;
                case "EA0202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "EA0202")); })).Start();
                    break;
                case "EA0300":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "EA0300")); })).Start();
                    break;

                default:
                    break;
            }
        }

        #region 发送数据
        /// <summary>
        /// 发送数据给服务器
        /// </summary>
        /// <param name="data"></param>
        public void SendMessage(string DataBody)
        {
            try
            {
                string senddData = DataBody.Replace(" ", "");
                byte[] byteData = HexStringToByteArray(senddData);
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " 发送--> " + senddData);
                log4netHelper.Info(senddData);
                client_TQ.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallBack), this);
            }
            catch (Exception e)
            {
                IsConnect_TQ = false;
                //client_TQ = null;
                log4netHelper.Info(DataBody.Replace(" ", "") + " 向提取舱发送指令失败--" + e.ToString());
                ConnectComplete("未联机");//连接成功信号量        
            }
        }

        /// <summary>
        /// 十六进制转换字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// 字节数组转换十六进制
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                //Socket socket1 = (Socket)ar.AsyncState;
                int bytesSend = client_TQ.EndSend(ar);
                //Console.WriteLine("Send {0} bytes to server", bytesSend);
            }
            catch (Exception e)
            {
                IsConnect_TQ = false;
                //client_TQ = null;
                ConnectComplete("未联机");//连接成功信号量 
                log4netHelper.Info("向提取舱发送指令失败--" + e.ToString());
            }
        }
        #endregion

        #region 把一个数组取出指定的长度
        /// <summary>
        /// 把一个数组取出指定的长度
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        internal static byte[] ByteToByte(byte[] a, int b, int index)
        {
            byte[] haveDate = new byte[b];
            Array.Copy(a, index, haveDate, 0, b);
            return haveDate;
        }
        #endregion
    }
}
