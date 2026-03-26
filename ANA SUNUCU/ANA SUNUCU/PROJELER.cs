using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;

namespace ANA_SUNUCU
{
    public partial class PROJELER : Form
    {
        private Process serverprorcess; //exe için  

        public PROJELER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BAŞLATMA
            try
            {
                serverprorcess = new Process();
                serverprorcess.StartInfo.FileName = @"""C:\Users\DELL\OneDrive\Masaüstü\SUNUCU\PROJE\PROJE\PROJE\bin\Debug\net10.0\PROJE.exe""";
                serverprorcess.StartInfo.Arguments = "192.168.1.115 8585";
                serverprorcess.StartInfo.UseShellExecute = true;
                serverprorcess.StartInfo.Verb = "runas";//yonetici olarak çalışmasını sağlar
                serverprorcess.Start();
                label1.Text = "SUNUCU AÇIK";

            }
            catch(Exception EX)
            {
            }
        } 

        private void button3_Click(object sender, EventArgs e)
        {
            //YENİDEN BAŞLATMA
            try
            {
                // Önce durdur
                Process[] processes = Process.GetProcessesByName("PROJE");
                foreach (var p in processes)
                {
                    p.Kill();
                    p.WaitForExit();
                }

                // Sonra başlat
                serverprorcess = new Process();
                serverprorcess.StartInfo.FileName = @"""C:\Users\DELL\OneDrive\Masaüstü\SUNUCU\PROJE\PROJE\PROJE\bin\Debug\net10.0\PROJE.exe""";
                serverprorcess.StartInfo.Arguments = "192.168.1.115 8585";
                serverprorcess.StartInfo.UseShellExecute = true;
                serverprorcess.StartInfo.Verb = "runas";
                serverprorcess.Start();

                label3.Text = "Sunucu yeniden başlatıldı!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yeniden başlatılamadı: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //KAPAMA
            try
            {
                // Burada exe ismini doğru yazmak kritik!
                Process[] processes = Process.GetProcessesByName("PROJE"); // PROJE.exe için
                if (processes.Length == 0)
                {
                    MessageBox.Show("Sunucu zaten çalışmıyor!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (var p in processes)
                {
                    p.Kill();
                    p.WaitForExit();
                }

                label2.Text = "Sunucu durduruldu!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sunucu durdurulamadı: " + ex.Message);
            }
        }
    }
}
