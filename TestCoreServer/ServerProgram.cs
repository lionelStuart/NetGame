using System;



namespace TestCoreServer
{
    class ServerProgram
    {
        static private Server _server;

        static void Main(string[] args)
        {
            _server = new Server();

            Host serverHost = new Host();
            serverHost.ip = NetworkUtils.GetLocalIPv4();
            serverHost.port = "8848";

            Console.WriteLine("Server Host:{0}:{1}", serverHost.ip, serverHost.port);

            _server.Start(serverHost);

            Console.WriteLine("Hello World!");
            Console.ReadKey();

        }
    }
}
