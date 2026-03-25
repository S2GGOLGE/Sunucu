using System;

namespace HOME
{
    class Program
    {
        static void Main(string[] args)
        {
            serversettings.serverayar("127.0.0.1", 8585);
            client.Start();
            Console.ReadKey();
        }
    }
}