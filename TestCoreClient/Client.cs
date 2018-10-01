using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestCoreClient
{


    class Client
    {
        private TcpClient _client;




        private IEnumerator _Connect(Host server)
        {
            _client = new TcpClient();
            IAsyncResult async = _client.BeginConnect(
                IPAddress.Parse(server.ip),
                int.Parse( server.port),
                null, null);
            while(!async.IsCompleted)
            {
                //Debug.Log("connect server...");
                Console.WriteLine("connect server");
                yield return null;
            }

            try
            {
                _client.EndConnect(async);
            }
            catch(Exception e)
            {
                
            }


            

        }

        void _Send()
        {

        }

    }
}
