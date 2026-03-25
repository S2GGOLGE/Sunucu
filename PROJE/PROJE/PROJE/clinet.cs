using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PROJE
{
    internal class Peer
    {
        public static TcpClient ClientInstance = new TcpClient();
        private static NetworkStream clientStream;

        private static TcpListener Listener;
        private static int ListenPort = 8587 ; // Kendi portun, diğer client'lar bağlanacak

        public static async Task StartAsync()
        {
            // 1️⃣ Sunucu gibi dinlemeye başla
            _ = StartListeningAsync();

            // 2️⃣ Başka bir sunucuya bağlan
            await ConnectToServerAsync(serverayar.HOST, serverayar.PORT);
        }

        private static async Task ConnectToServerAsync(string host, int port)
        {
            try
            {
                await ClientInstance.ConnectAsync(host, port);
                Console.WriteLine("ANA SUNUCUYA BAĞLANDI");

                clientStream = ClientInstance.GetStream();

                // Sunucudan veri dinlemeye başla
                _ = ReceiveDataAsync(clientStream);

                // Örnek mesaj gönder
                await SendMessageAsync(clientStream, "Merhaba Sunucu!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bağlantı hatası: " + ex.Message);
            }
        }

        private static async Task StartListeningAsync()
        {
            try
            {
                Listener = new TcpListener(IPAddress.Any, ListenPort);
                Listener.Start();
                Console.WriteLine($"Kendi portumda dinleniyor: {ListenPort}");

                while (true)
                {
                    TcpClient incoming = await Listener.AcceptTcpClientAsync();
                    Console.WriteLine("Yeni bir kullanıcı bağlandı!");

                    // Bağlanan client ile veri alışverişi
                    _ = HandleIncomingClientAsync(incoming);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dinleme hatası: " + ex.Message);
            }
        }

        private static async Task HandleIncomingClientAsync(TcpClient incoming)
        {
            NetworkStream stream = incoming.GetStream();
            await ReceiveDataAsync(stream);

            // İsteğe bağlı: karşıya mesaj gönderebilirsin
            await SendMessageAsync(stream, "Hoşgeldin!");
        }

        private static async Task ReceiveDataAsync(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            try
            {
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine("Gelen mesaj: " + message);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Bağlantı kapandı veya hata oluştu.");
            }
        }

        private static async Task SendMessageAsync(NetworkStream stream, string message)
        {
            if (stream.CanWrite)
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);
            }
        }
    }
}