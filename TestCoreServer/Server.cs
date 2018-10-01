using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TestCoreGlobal;

namespace TestCoreServer
{


    interface ICallback
    {

    }


    class Server
    {
        private ConcurrentQueue<ICallback> _callbackQueue;

        private Socket _serverSocket;

        public void _Receive(object obj)
        {


        }

        public void _Callback()
        {

        }

        public void _Await()
        {
            Socket client = null;

            while(true)
            {
                try
                {
                    client = _serverSocket.Accept();

                    string endPoint = client.RemoteEndPoint.ToString();

                    Console.WriteLine(string.Format("Accept Remote: {0}", endPoint));

                    //need obj

                    ParameterizedThreadStart receiveThreadStart = new ParameterizedThreadStart(_Receive);
                    Thread receiveThread = new Thread(receiveThreadStart) { IsBackground =true};
                    receiveThread.Start();

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


         public void Start(Host host)
        {

            try
            {
                _callbackQueue = new ConcurrentQueue<ICallback>();

                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint point = new IPEndPoint(IPAddress.Parse(host.ip), int.Parse(host.port));
                _serverSocket.Bind(point);
                _serverSocket.Listen(0);


                Thread threadAwait = new Thread(_Await) { IsBackground = true };
                threadAwait.Start();

                Thread threadCallback = new Thread(_Callback) { IsBackground = true };
                threadCallback.Start();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                //?MessageBox.Show(e.Message);
            }


        }


        

    }
}
