using System;

namespace HOME
{
    class Program
    {
        static void Main(string[] args)
        {
            serversettings.serverayar("192.168.1.115", 8585);
            client.Start();
            Console.ReadKey();
        }
    }
}