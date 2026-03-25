using PROJE;
using System;
using System.Threading.Tasks;

namespace PROJE
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Sunucu ayarlarını belirle
            serverayar.serversettings("127.0.0.1", 8585);

            // Peer sistemini başlat
            await Peer.StartAsync();

            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}