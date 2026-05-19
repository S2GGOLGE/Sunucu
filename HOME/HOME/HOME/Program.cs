using System;

namespace HOME
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "HOME SERVER";

                Console.WriteLine("====================================");
                Console.WriteLine("HOME SERVER BASLATILIYOR");
                Console.WriteLine("====================================");

                // ANA SUNUCU AYARLARI
                serversettings.serverayar(
                    "127.0.0.1", // ANA SUNUCU IP
                    8585         // ANA SUNUCU PORT
                );

                // SISTEMI BASLAT
                HomeClient.Start();

                Console.WriteLine();
                Console.WriteLine("Sistem aktif.");
                Console.WriteLine("Cikmak icin ESC bas.");

                // ESC ILE KAPAT
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                        break;
                }

                // SISTEMI DURDUR
                HomeClient.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("KRITIK HATA");
                Console.WriteLine(ex.Message);
            }
        }
    }
}