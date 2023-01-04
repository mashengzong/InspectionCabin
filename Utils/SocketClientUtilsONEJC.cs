using SampleProcessingSystem.Model;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SampleProcessingSystem.Utils
{
    public class SocketClientUtilsONEJC
    {
        #region 完成连接事件信号触发及函数
        public delegate void ConnectSuccess<Q1>(Q1 boject);
        public static event ConnectSuccess<string> ClientConnectSuccess;
        public static bool IsConnect_ONEJC = false;

        public virtual void ConnectComplete(string ipEndPoint)//完成连接事件信号量触发判断
        {
            if (ClientConnectSuccess != null)
                ClientConnectSuccess(ipEndPoint);
        }
        #endregion

        public void AddMethod(Action<ReceiveData> Method)
        {
            ServerReceiveSuccess = new SocketClientUtilsONEJC.receiveSuccess<ReceiveData>(Method);
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
        public void DisConnect_ONEJC()
        {
            if (client_ONEJC == null)
                return;

            if (!client_ONEJC.Connected)
                return;

            try
            {
                client_ONEJC.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }

            try
            {
                client_ONEJC.Close();
            }
            catch
            {
            }
            IsConnect_ONEJC = false;
        }



        /// <summary>
        ///连接状态
        /// </summary>
        public bool IsConnectSocket_ONEJC()
        {
            if (client_ONEJC == null)
            {
                return false;
            }
            return client_ONEJC.Connected;
        }

        public byte[] buffer = new byte[1024 * 1024 * 3];
        private static Socket client_ONEJC = null;

        public void StartClient()
        {
            try
            {
                DisConnect_ONEJC();
                IPAddress ipAddress = IPAddress.Parse(GetDataUtils.ONEServerIP);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, GetDataUtils.ONEServerPort);
                client_ONEJC = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client_ONEJC.SendTimeout = 10000;
                //client_TQ.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, true);

                var tcpKeepalive = new byte[12];
                client_ONEJC.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true); // enable keep-alive
                BitConverter.GetBytes((uint)1).CopyTo(tcpKeepalive, 0); // switch on
                BitConverter.GetBytes(5000).CopyTo(tcpKeepalive, 4);  // wait time(ms)
                BitConverter.GetBytes(10000).CopyTo(tcpKeepalive, 8);// interval(ms)
                client_ONEJC.IOControl(IOControlCode.KeepAliveValues, tcpKeepalive, null); // set keep-alive parameter

                client_ONEJC.BeginConnect(remoteEP, new AsyncCallback(ConnectCallBack), client_ONEJC);
            }
            catch (Exception ee)
            {
                IsConnect_ONEJC = false;
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
                IsConnect_ONEJC = true;
                ConnectComplete("已联机");//连接成功信号量 
            }
            catch (Exception e)
            {
                IsConnect_ONEJC = false;
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
                if (client_ONEJC.Connected)
                {
                    //Socket socket = (Socket)ar.AsyncState;
                    int bytesRead = client_ONEJC.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        byte[] haveDate = ByteToByte(buffer, bytesRead, 0);//取出有效的字节数据,得到实际的数据haveDate
                        Array.Clear(buffer, 0, buffer.Length);//情况缓冲数组

                        string s1 = ByteArrayToHexString(haveDate);

                        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " 接收<-- " + s1);
                        log4netHelper.Info("接收<-- " + s1);
                        DataReceiveHandle(s1);//处理数据
                        client_ONEJC.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);//接收剩余的数据或者继续接收数据
                    }
                    else //如果接收到数据字符为0，代表接收完了
                    {
                        client_ONEJC.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);//继续接收数据
                    }
                }
                else
                {
                    ConnectComplete("未联机");//连接成功信号量 
                    IsConnect_ONEJC = false;
                    client_ONEJC = null;
                }
            }
            catch (Exception ee)
            {
                //服务器断开连接后在此处
                log4netHelper.Info(ee.ToString());
                log4netHelper.Error(ee.ToString());
                ConnectComplete("未联机");//连接成功信号量 
                IsConnect_ONEJC = false;
                client_ONEJC = null;
                Console.WriteLine(ee.ToString());
            }
        }

        #endregion

        /// <summary>
        /// 数据接收处理 
        /// </summary>
        void DataReceiveHandle(string data)
        {
            string recID = data.Substring(0, 2);
            switch (data.Substring(0, 8))
            {
                case "1064FE01":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FE01")); })).Start();
                    break;
                case "1064FE02":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FE02")); })).Start();
                    break;
                case "1064FE03":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FE03")); })).Start();
                    break;
                case "1064FE04":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FE04")); })).Start();
                    break;
                case "1064FE05":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FE05")); })).Start();
                    break;
                case "1064FE06":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FE06")); })).Start();
                    break;
                case "1064FF01":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FF01", data.Substring(8, 8))); })).Start();
                    break;
                case "1064FF02":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FF02", data.Substring(8, 8))); })).Start();
                    break;
                case "1064FF03":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FF03", data.Substring(8, 8))); })).Start();
                    break;
                case "1064FF04":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FF04", data.Substring(8, 8))); })).Start();
                    break;
                case "1064FF05":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FF05", data.Substring(8, 8))); })).Start();
                    break;
                case "1064FF06":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_64FF06", data.Substring(8, 8))); })).Start();
                    break;
                case "10640100":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_640100")); })).Start();
                    break;
                case "10642000":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642000")); })).Start();
                    break;
                case "10642001":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642001")); })).Start();
                    break;
                case "10642002":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642002")); })).Start();
                    break;
                case "10642100":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642100")); })).Start();
                    break;
                case "10642101":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642101")); })).Start();
                    break;
                case "10642102":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642102")); })).Start();
                    break;
                case "10642200":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642200")); })).Start();
                    break;
                case "10642201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642201")); })).Start();
                    break;
                case "10642202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642202")); })).Start();
                    break;
                case "10642301":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642301")); })).Start();
                    break;
                case "10642401":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642401", data.Substring(14, 2))); })).Start();
                    break;
                case "10642402":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "10_642402", data.Substring(14, 2))); })).Start();
                    break;



                case "65646000":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646000")); })).Start();
                    break;
                case "65646100":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646100")); })).Start();
                    break;
                case "65646101":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646101")); })).Start();
                    break;
                case "65646102":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646102")); })).Start();
                    break;
                case "65646200":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646200")); })).Start();
                    break;
                case "65646201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646201")); })).Start();
                    break;
                case "65646202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646202")); })).Start();
                    break;
                case "65646301":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646301")); })).Start();
                    break;
                case "65646302":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646302", data.Substring(8, 2))); })).Start();
                    break;
                case "65646303":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646303")); })).Start();
                    break;
                case "6564FE01":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FE01")); })).Start();
                    break;
                case "6564FE02":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FE02")); })).Start();
                    break;
                case "6564FF00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF00")); })).Start();
                    break;
                case "6564FF01":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF01", data.Substring(8, 8))); })).Start();
                    break;
                case "6564FF02":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF02", data.Substring(8, 8))); })).Start();
                    break;
                case "6564FF03":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF03", data.Substring(12, 2))); })).Start();
                    break;
                case "6564FF04":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF04", data.Substring(12, 2))); })).Start();
                    break;




                case "12642200":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642200")); })).Start();
                    break;
                case "12642201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642201")); })).Start();
                    break;
                case "12642202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642202")); })).Start();
                    break;
                case "12642300":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642300")); })).Start();
                    break;
                case "12642301":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642301")); })).Start();
                    break;
                case "12642302":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642302")); })).Start();
                    break;
                case "12642503":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642503")); })).Start();
                    break;
                case "12642504":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642504")); })).Start();
                    break;
                case "12642505":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642505")); })).Start();
                    break;
                case "12642506":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642506")); })).Start();
                    break;
                case "12642703":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642703")); })).Start();
                    break;
                case "12642704":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642704")); })).Start();
                    break;
                case "12642705":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642705")); })).Start();
                    break;
                case "12642706":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642706")); })).Start();
                    break;
                case "12642707":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642707")); })).Start();
                    break;
                case "12642708":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642708")); })).Start();
                    break;
                case "12642709":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642709")); })).Start();
                    break;
                case "1264270a":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_64270a")); })).Start();
                    break;
                case "12642400":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642400")); })).Start();
                    break;
                case "12642401":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642401")); })).Start();
                    break;
                case "12642402":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642402")); })).Start();
                    break;
                case "12642403":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642403")); })).Start();
                    break;
                case "12642404":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_642404")); })).Start();
                    break;
                case "1264FE25":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_64FE25")); })).Start();
                    break;
                case "1264FF25":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_64FF25", data.Substring(12, 4))); })).Start();
                    break;
                case "1264FF00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "12_64FF00", data.Substring(10, 6))); })).Start();
                    break;


                case "53642001":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_642001")); })).Start();
                    break;
                case "53642002":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_642002")); })).Start();
                    break;
                case "53642100":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_642100")); })).Start();
                    break;
                case "53642101":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_642101")); })).Start();
                    break;
                case "53642102":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_642102")); })).Start();
                    break;
                case "53642200":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_642200")); })).Start();
                    break;
                case "53642201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_642201")); })).Start();
                    break;
                case "53642202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_642202")); })).Start();
                    break;
                case "5364FE00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_64FE00")); })).Start();
                    break;
                case "5364FF00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "53_64FF00", data.Substring(10, 6))); })).Start();
                    break;



                case "55642001":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_642001")); })).Start();
                    break;
                case "55642002":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_642002")); })).Start();
                    break;
                case "55642100":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_642100")); })).Start();
                    break;
                case "55642101":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_642101")); })).Start();
                    break;
                case "55642102":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_642102")); })).Start();
                    break;
                case "55642200":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_642100")); })).Start();
                    break;
                case "55642201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_642101")); })).Start();
                    break;
                case "55642202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_642102")); })).Start();
                    break;
                case "5564FE00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_64FE00")); })).Start();
                    break;
                case "5564FF00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "55_64FF00", data.Substring(10, 6))); })).Start();
                    break;

                case "13642200":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642200")); })).Start();
                    break;
                case "13642201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642201")); })).Start();
                    break;
                case "13642202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642202")); })).Start();
                    break;
                case "13642300":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642300")); })).Start();
                    break;
                case "13642301":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642301")); })).Start();
                    break;
                case "13642302":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642302")); })).Start();
                    break;
                case "13642503":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642503")); })).Start();
                    break;
                case "13642504":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642504")); })).Start();
                    break;
                case "13642505":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642505")); })).Start();
                    break;
                case "13642506":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642506")); })).Start();
                    break;
                case "13642507":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642507")); })).Start();
                    break;
                case "13642703":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642703")); })).Start();
                    break;
                case "13642704":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642704")); })).Start();
                    break;
                case "13642705":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642705")); })).Start();
                    break;
                case "13642706":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642706")); })).Start();
                    break;
                case "13642707":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642707")); })).Start();
                    break;
                case "13642708":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642708")); })).Start();
                    break;
                case "13642709":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642709")); })).Start();
                    break;
                case "1364270a":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_64270a")); })).Start();
                    break;
                case "1364270b":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_64270b")); })).Start();
                    break;
                case "1364270c":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_64270c")); })).Start();
                    break;
                case "13642400":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642400")); })).Start();
                    break;
                case "13642401":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642401")); })).Start();
                    break;
                case "13642402":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642402")); })).Start();
                    break;
                case "13642403":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642403")); })).Start();
                    break;
                case "13642404":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642404")); })).Start();
                    break;
                case "13642405":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642405")); })).Start();
                    break;
                case "13642406":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_642406")); })).Start();
                    break;
                case "1364FE25":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_64FE25")); })).Start();
                    break;
                case "1364FF00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_64FF00", data.Substring(10, 6))); })).Start();
                    break;
                case "1364FF25":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "13_64FF25", data.Substring(12, 4))); })).Start();
                    break;



                case "66646000":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646000")); })).Start();
                    break;
                case "66646100":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646100")); })).Start();
                    break;
                case "66646101":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646101")); })).Start();
                    break;
                case "66646102":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646102")); })).Start();
                    break;
                case "66646200":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646200")); })).Start();
                    break;
                case "66646201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646201")); })).Start();
                    break;
                case "66646202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646202")); })).Start();
                    break;
                case "66646301":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646301")); })).Start();
                    break;
                case "66646302":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646302")); })).Start();
                    break;
                case "66646303":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_646303")); })).Start();
                    break;
                case "6664FE01":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FE01")); })).Start();
                    break;
                case "6664FE02":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FE02")); })).Start();
                    break;
                case "6664FF00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF00")); })).Start();
                    break;
                case "6664FF01":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF01", data.Substring(8, 8))); })).Start();
                    break;
                case "6664FF02":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF02", data.Substring(8, 8))); })).Start();
                    break;
                case "6664FF03":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF03", data.Substring(12, 2))); })).Start();
                    break;
                case "6664FF04":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "65_64FF04", data.Substring(12, 2))); })).Start();
                    break;


                case "73645100":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645100")); })).Start();
                    break;
                case "73645101":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645101")); })).Start();
                    break;
                case "73645200":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645200")); })).Start();
                    break;
                case "73645201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645201")); })).Start();
                    break;
                case "73645202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645202")); })).Start();
                    break;
                case "73645203":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645203")); })).Start();
                    break;
                case "73645204":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645204")); })).Start();
                    break;
                case "73645205":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645205")); })).Start();
                    break;
                case "73645206":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645206")); })).Start();
                    break;
                case "73645207":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645207")); })).Start();
                    break;
                case "73645300":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645300")); })).Start();
                    break;
                case "73645301":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645301")); })).Start();
                    break;
                case "73645400":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645400")); })).Start();
                    break;
                case "73645401":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645401")); })).Start();
                    break;
                case "73645500":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645500")); })).Start();
                    break;
                case "73645501":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645501")); })).Start();
                    break;
                case "73645700":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645700")); })).Start();
                    break;
                case "73645701":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645701")); })).Start();
                    break;
                case "7364FE03":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_64FE03")); })).Start();
                    break;
                case "7364FE04":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_64FE04")); })).Start();
                    break;
                case "7364FF00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_64FF00", data.Substring(10, 6))); })).Start();
                    break;
                case "7364FF02":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_64FF02", data.Substring(14, 2))); })).Start();
                    break;
                case "7364FF03":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_64FF03", data.Substring(8, 8))); })).Start();
                    break;
                case "7364FF04":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_64FF04", data.Substring(8, 8))); })).Start();
                    break;
                case "73645800":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "73_645800")); })).Start();
                    break;



                case "74645100":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645100")); })).Start();
                    break;
                case "74645101":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645101")); })).Start();
                    break;
                case "74645200":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645200")); })).Start();
                    break;
                case "74645201":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645201")); })).Start();
                    break;
                case "74645202":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645202")); })).Start();
                    break;
                case "74645203":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645203")); })).Start();
                    break;
                case "74645204":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645204")); })).Start();
                    break;
                case "74645205":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645205")); })).Start();
                    break;
                case "74645206":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645206")); })).Start();
                    break;
                case "74645207":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645207")); })).Start();
                    break;
                case "74645300":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645300")); })).Start();
                    break;
                case "74645301":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645301")); })).Start();
                    break;
                case "74645400":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645400")); })).Start();
                    break;
                case "74645401":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645401")); })).Start();
                    break;
                case "74645500":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645500")); })).Start();
                    break;
                case "74645501":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645501")); })).Start();
                    break;
                case "74645700":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645700")); })).Start();
                    break;
                case "74645701":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645701")); })).Start();
                    break;
                case "7464FE03":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_64FE03")); })).Start();
                    break;
                case "7464FE04":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_64FE04")); })).Start();
                    break;
                case "7464FF00":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_64FF00", data.Substring(10, 6))); })).Start();
                    break;
                case "7464FF02":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_64FF02", data.Substring(14, 2))); })).Start();
                    break;
                case "7464FF03":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_64FF03", data.Substring(8, 8))); })).Start();
                    break;
                case "7464FF04":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_64FF04", data.Substring(8, 8))); })).Start();
                    break;
                case "74645800":
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData(recID, "74_645800")); })).Start();
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
                client_ONEJC.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallBack), this);
            }
            catch (Exception e)
            {
                IsConnect_ONEJC = false;
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
                int bytesSend = client_ONEJC.EndSend(ar);
                //Console.WriteLine("Send {0} bytes to server", bytesSend);
            }
            catch (Exception e)
            {
                IsConnect_ONEJC = false;
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
