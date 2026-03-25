using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace ANA_SUNUCU
{
    internal class SUNUCU
    { 
        //ANA SUNUCU KODLARI
        public static int maxPlayer { get; set; }
        public  static int port { get; set; }
        public static TcpListener ServerListiner;
        public static void Setup_Server(int _maxpalayer,int _port)
        {
            maxPlayer = _maxpalayer;
            port = _port;
            ServerListiner = new TcpListener(IPAddress.Any, port);
            MessageBox.Show("Server Kuruldu","Sistem",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public static void Start_Server()
        { 
            ServerListiner.Start();
            MessageBox.Show("Server Başlatıldı", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ServerListiner.BeginAcceptTcpClient(AcceptClientCalback,null);
            MessageBox.Show("Sunucular Bekleniyor","Sistem",MessageBoxButtons.OK,MessageBoxIcon.Question);
            
        }
        public static void AcceptClientCalback(IAsyncResult asyncResult)
        {
           TcpClient clinet= ServerListiner.EndAcceptTcpClient(asyncResult);
            MessageBox.Show("Bağlantı Var","Sistem",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }
    }
}