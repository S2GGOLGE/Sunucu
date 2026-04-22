using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HOME
{
    internal class client
    {
        public static TcpClient Client = new TcpClient();
        public static TcpListener Listener;

        public static void Start()
        {
            StartListener();
            Connect();
        }

        // BAŞKA SUNUCUYA BAĞLANIR
        public static void Connect()
        {
            try
            {
                Client.BeginConnect(serversettings.HOST, serversettings.PORT, ConnectCallback, null);
                Console.WriteLine("ANA SUNUCUYA BAĞLANMAYA ÇALIŞIYOR");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bağlantı başlatılamadı: " + ex.Message);
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Client.EndConnect(ar);

                if (Client.Connected)
                    Console.WriteLine("Home Sunucuya  BAĞLANDI");
                else
                    Console.WriteLine("ANA SUNUCUYA BAĞLANILAMADI");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bağlantı hatası: " + ex.Message);
            }
        }

        // BAĞLANTI KABUL EDER
        public static void StartListener()
        {
            try
            {
                Listener = new TcpListener(IPAddress.Any, 8586);
                Listener.Start();

                Listener.BeginAcceptTcpClient(AcceptCallback, null);

                Console.WriteLine("BAĞLANTI BEKLENİYOR...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Listener başlatılamadı: " + ex.Message);
            }
        }
        private static void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                TcpClient incoming = Listener.EndAcceptTcpClient(ar);

                // Tanıtım mesajını oku
                NetworkStream stream = incoming.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string mesaj = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine($"{mesaj} BAĞLANDI ");

                Listener.BeginAcceptTcpClient(AcceptCallback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bağlantı kabul hatası: " + ex.Message);
            }
        }
    }
}