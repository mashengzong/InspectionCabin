using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SampleProcessingSystem.Utils
{
    public class NSocketLocalServeret
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private Socket listenerSocket;//Socket对象
        private Dictionary<string, Socket> connectedSocket;//已连接上的Socket客户端对象
        private Dictionary<string, int> SocketStatus;//连接状态
        private List<string> ClientIps;//连接上来的客户端的端口
        private bool bstop = false;
        private IPAddress ipAddress;//IP地址
        private int hostPORT;//监听的端口
        private Thread ListenThread;//监听线程

        public delegate void ConnectSuccess<IPEndPoint>(IPEndPoint boject1);
        public event ConnectSuccess<IPEndPoint> serverConnectSuccess;

        public virtual void ConnectComplete(IPEndPoint ipEndPoint)//完成连接事件信号量触发判断
        {
            if (serverConnectSuccess != null)
                serverConnectSuccess(ipEndPoint);
        }

        public delegate void receiveSuccess<T1>(T1 str);  //接收数据委托
        public event receiveSuccess<string> serverReceiveSuccess;

        public virtual void ReceiveComplete(string str)//接收数据信号事件
        {
            if (serverReceiveSuccess != null)
                serverReceiveSuccess(str);
        }

        public void Connnect(string ip)
        {
            ipAddress = IPAddress.Parse(ip);//监听本地的IP           
            hostPORT = 8087;//监听的端口
            connectedSocket = new Dictionary<string, Socket>();
            SocketStatus = new Dictionary<string, int>();
            ClientIps = new List<string>();
            ListenThread = new Thread(StartListeningLocal);//监听的线程初始化
            ListenThread.Start();//监听线程启动
        }

        private void StartListeningLocal()
        {
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, hostPORT);//网络终结点
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//重新初始化
            listenerSocket.Bind(localEndPoint);//实例化
            listenerSocket.Listen(100);//开始侦听
            while (!bstop)
            {
                try
                {
                    allDone.Reset();//重置
                    listenerSocket.BeginAccept(new AsyncCallback(AcceptCallback), listenerSocket);//开始异步接收一个传入的链接,同时声明阻塞回调函数
                    allDone.WaitOne();//等待客户端主动来连
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    //allDone.Set();
                }
                Thread.Sleep(1);
            }
        }


        private void AcceptCallback(IAsyncResult ar)//异步操作状态的接口
        {
            try
            {
                if (bstop) return;
                allDone.Set();//将事件状态终止，允许一个或者多个等待的线程继续
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                IPEndPoint iep = (IPEndPoint)handler.RemoteEndPoint;
                string ip = iep.Address.ToString();
                Console.WriteLine(ip + ":" + iep.Port.ToString());
                lock (this.connectedSocket)
                {
                    if (connectedSocket.ContainsKey(ip) == false)//不在连接的队列中
                    {
                        try
                        {
                            connectedSocket.Add(ip, handler);//记录这个ip socket到字典中
                            if (!SocketStatus.ContainsKey(ip))
                                SocketStatus.Add(ip, 0);//没有连接上的状态为0
                            StateObject state = new StateObject();//类
                            state.workSocket = handler;//工作的socket用当前的
                            ClientIps.Add(ip);//已连接上的ip添加
                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), state);
                            Console.WriteLine("检测到" + ip + "的连接...");
                            ConnectComplete(iep);//连接成功后，触发事件信号量
                        }
                        catch (Exception)
                        {
                            StateObject state = new StateObject();
                            state.workSocket = handler;
                            //handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), state);
                        }
                    }
                    else
                    {
                        try
                        {
                            connectedSocket.Remove(ip);
                            ClientIps.Remove(ip);
                            connectedSocket.Add(ip, handler);
                            if (!SocketStatus.ContainsKey(ip))
                                SocketStatus.Add(ip, 0);
                            StateObject state = new StateObject();
                            state.workSocket = handler;
                            ClientIps.Add(ip);
                            //每四个字节一个整数，第一个整数1表示启用，第二个整数0x1388表示设置以后过5000毫秒开始发送心跳，第三个整数0x07d0表示每2000毫秒发送一次心跳。
                            byte[] inValue = new byte[] { 1, 0, 0, 0, 0x88, 0x13, 0, 0, 0xd0, 0x07, 0, 0 };
                            //在接受方接受连接或者发起方连接成功之后，对该连接的套接字设置iocontrol
                            handler.IOControl(IOControlCode.KeepAliveValues, inValue, null);
                            //接收时间 
                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                            Console.WriteLine("检测到" + ip + "的连接...");
                            ConnectComplete(iep);//连接成功后，触发事件信号量
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public IPEndPoint iep = null;//用于客户端的IP和端口
        /// <summary>
        /// 接受回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;
                iep = (IPEndPoint)handler.RemoteEndPoint;
                string ip = iep.Address.ToString();
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    ConvertMsg(ip, state.buffer, bytesRead);//接受到的数据处理，需要的逻辑处理都可以集成到此方法里面去完成
                }


                if (!bstop)
                {
                    lock (this.connectedSocket)
                    {
                        if (bytesRead == 0)
                        {
                            state.workSocket.Close();
                            connectedSocket.Remove(ip);
                            SocketStatus.Remove(ip);
                            ClientIps.Remove(ip);
                        }
                        if (state.workSocket.Connected == true)
                        {
                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                        }
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    lock (this.connectedSocket)
                    {
                        StateObject state = (StateObject)ar.AsyncState;
                        Socket handler = state.workSocket;
                        IPEndPoint iep = (IPEndPoint)handler.RemoteEndPoint;
                        string ip = iep.Address.ToString();
                        if (connectedSocket.ContainsKey(ip))
                        {
                            state.workSocket.Close();
                            this.connectedSocket.Remove(ip);
                            this.SocketStatus.Remove(ip);
                            this.ClientIps.Remove(ip); //Keepalive检测网线断开引发的异常在这里捕获
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return;
            }
        }


        /// <summary>
        /// 数据接收处理 
        /// EA 00 00  提取初始化              EB 00 00  提取初始化完成
        /// EA 01 01  夹取深孔板1到抓手位1     EB 01 01  深孔板1已夹取到抓手位1
        /// EA 01 02  夹取深孔板2到抓手位2     EB 01 02  深孔板2已夹取到抓手位2
        /// EA 02 01  深孔板1运动到抓手位1     EB 02 01  深孔板1已抓走提取
        /// EA 02 02  深孔板2运动到抓手位2     EB 02 02  深孔板2已抓走提取
        /// </summary>
        void DataReceiveHandle(string data)
        {
            ReceiveComplete(data);
        }

        /// <summary>
        /// 字节数组转换十六进制
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ByteArrayToHexString(byte[] data, int lengths)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            for (int i = 0; i < lengths; i++)
            {
                sb.Append(Convert.ToString(data[i], 16).PadLeft(2, '0'));
            }
            return sb.ToString().ToUpper();
        }

        private void ConvertMsg(string ipAddress, byte[] byteIn, int byteLength)
        {
            try
            {
                string s1 = ByteArrayToHexString(byteIn, byteLength);
                Console.WriteLine("接收数据<-- " + s1);

                DataReceiveHandle(s1);//处理数据
                //在此进行数据解析以及需要的逻辑处理
                //SendDefault(s1, ipAddress);
                //需要返回客户端的字符串内容和IP直接调用次方法
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
        /// Socket Server发送函数
        /// </summary>
        /// <param name="sendMessage"></param>
        /// <param name="ip"></param>        
        public bool SendDefault(string sendMessage, string ip)
        {
            bool rt = true;
            string senddData = sendMessage.Replace(" ", "");
            byte[] byteData = HexStringToByteArray(senddData);
            try
            {
                if (connectedSocket.ContainsKey(ip))
                {
                    int intTemp = connectedSocket[ip].Send(byteData);
                    if (intTemp == byteData.Length)
                    {
                        rt = true;
                    }
                    else
                    {
                        rt = false;
                    }
                }
                else
                {
                    rt = false;
                }
            }
            catch (Exception)
            {
                rt = false;
            }
            return rt;
        }
    }

    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 1024;//定义发送到缓存区的字节数组大小
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }
}
