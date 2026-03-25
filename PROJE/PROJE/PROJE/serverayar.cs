using System;
using System.Collections.Generic;
using System.Text;

namespace PROJE
{
    internal class serverayar
    {
        public static string HOST { get; private set; }
        public static int PORT { get; private set; }
        public static void serversettings(string host, int port)
        {
            HOST = host;
            PORT = port;
        }
    }
}
