using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HOME
{
    internal static class HomeClient
    {
        // =========================
        // MAIN SERVER CLIENT
        // =========================

        private static TcpClient _client;
        private static NetworkStream _serverStream;

        // =========================
        // LOCAL LISTENER
        // =========================

        private static TcpListener _listener;

        // =========================
        // SETTINGS
        // =========================

        private const int LISTENER_PORT = 8586;

        private static bool _running = false;

        // =========================
        // START
        // =========================

        public static void Start()
        {
            if (_running)
                return;

            _running = true;

            StartListener();

            _ = Task.Run(ConnectionLoop);
        }

        // =========================
        // CONNECTION LOOP
        // =========================

        private static async Task ConnectionLoop()
        {
            while (_running)
            {
                try
                {
                    if (_client == null || !_client.Connected)
                    {
                        await ConnectMainServer();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[CONNECT LOOP ERROR] {ex.Message}");
                }

                await Task.Delay(5000);
            }
        }

        // =========================
        // CONNECT MAIN SERVER
        // =========================

        private static async Task ConnectMainServer()
        {
            try
            {
                CleanupClient();

                _client = new TcpClient();

                Console.WriteLine();
                Console.WriteLine("ANA SUNUCUYA BAGLANILIYOR...");
                Console.WriteLine($"HOST : {serversettings.HOST}");
                Console.WriteLine($"PORT : {serversettings.PORT}");

                await _client.ConnectAsync(
                    serversettings.HOST,
                    serversettings.PORT
                );

                if (!_client.Connected)
                {
                    Console.WriteLine("BAGLANTI BASARISIZ");
                    return;
                }

                _serverStream = _client.GetStream();

                Console.WriteLine("ANA SUNUCUYA BAGLANDI");

                // TANITIM MESAJI
                SendToMainServer("HOME_SERVER");

                // SERVER DINLE
                _ = Task.Run(ListenMainServer);
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"[SOCKET ERROR] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CONNECT ERROR] {ex.Message}");
            }
        }

        // =========================
        // LISTEN MAIN SERVER
        // =========================

        private static async Task ListenMainServer()
        {
            byte[] buffer = new byte[4096];

            while (_client != null && _client.Connected)
            {
                try
                {
                    int bytesRead = await _serverStream.ReadAsync(
                        buffer,
                        0,
                        buffer.Length
                    );

                    if (bytesRead <= 0)
                    {
                        Console.WriteLine("ANA SUNUCU BAGLANTISI KOPTU");
                        break;
                    }

                    string message = Encoding.UTF8.GetString(
                        buffer,
                        0,
                        bytesRead
                    );

                    Console.WriteLine($"[ANA SUNUCU] {message}");

                    HandleMainServerMessage(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LISTEN ERROR] {ex.Message}");
                    break;
                }
            }

            CleanupClient();
        }

        // =========================
        // HANDLE SERVER MESSAGE
        // =========================

        private static void HandleMainServerMessage(string message)
        {
            switch (message.ToLower())
            {
                case "ping":
                    SendToMainServer("pong");
                    break;

                default:
                    Console.WriteLine($"KOMUT : {message}");
                    break;
            }
        }

        // =========================
        // SEND DATA
        // =========================

        public static void SendToMainServer(string message)
        {
            try
            {
                if (_client == null)
                    return;

                if (!_client.Connected)
                    return;

                if (_serverStream == null)
                    return;

                byte[] data = Encoding.UTF8.GetBytes(message);

                _serverStream.Write(data, 0, data.Length);

                Console.WriteLine($"[GONDERILDI] {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SEND ERROR] {ex.Message}");
            }
        }

        // =========================
        // START LISTENER
        // =========================

        private static void StartListener()
        {
            try
            {
                _listener = new TcpListener(
                    IPAddress.Any,
                    LISTENER_PORT
                );

                _listener.Start();

                Console.WriteLine();
                Console.WriteLine("====================================");
                Console.WriteLine("LISTENER AKTIF");
                Console.WriteLine($"PORT : {LISTENER_PORT}");
                Console.WriteLine("====================================");

                _ = Task.Run(ListenIncomingClients);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LISTENER ERROR] {ex.Message}");
            }
        }

        // =========================
        // ACCEPT CLIENTS
        // =========================

        private static async Task ListenIncomingClients()
        {
            while (_running)
            {
                TcpClient incomingClient = null;

                try
                {
                    incomingClient =
                        await _listener.AcceptTcpClientAsync();

                    Console.WriteLine();
                    Console.WriteLine("YENI CLIENT BAGLANDI");

                    _ = Task.Run(() =>
                        HandleIncomingClient(incomingClient));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ACCEPT ERROR] {ex.Message}");

                    incomingClient?.Close();
                }
            }
        }

        // =========================
        // HANDLE CLIENT
        // =========================

        private static async Task HandleIncomingClient(
            TcpClient client)
        {
            NetworkStream stream = null;

            try
            {
                stream = client.GetStream();

                stream.ReadTimeout = 5000;

                byte[] buffer = new byte[4096];

                int bytesRead = await stream.ReadAsync(
                    buffer,
                    0,
                    buffer.Length
                );

                if (bytesRead <= 0)
                {
                    Console.WriteLine("BOS BAGLANTI");
                    return;
                }

                string message = Encoding.UTF8.GetString(
                    buffer,
                    0,
                    bytesRead
                );

                Console.WriteLine($"[GELEN] {message}");

                string response = "HOME_OK";

                byte[] responseData =
                    Encoding.UTF8.GetBytes(response);

                await stream.WriteAsync(
                    responseData,
                    0,
                    responseData.Length
                );

                Console.WriteLine($"[CEVAP] {response}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CLIENT ERROR] {ex.Message}");
            }
            finally
            {
                stream?.Close();
                client?.Close();
            }
        }

        // =========================
        // CLEANUP
        // =========================

        private static void CleanupClient()
        {
            try
            {
                _serverStream?.Close();
            }
            catch
            {
            }

            try
            {
                _client?.Close();
            }
            catch
            {
            }

            _serverStream = null;
            _client = null;
        }

        // =========================
        // STOP
        // =========================

        public static void Stop()
        {
            try
            {
                _running = false;

                CleanupClient();

                _listener?.Stop();

                Console.WriteLine("HOME SERVER DURDURULDU");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[STOP ERROR] {ex.Message}");
            }
        }
    }
}