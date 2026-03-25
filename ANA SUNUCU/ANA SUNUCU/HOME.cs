using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ANA_SUNUCU
{
    public partial class HOME : Form
    {
        private Process serverProcess; // Sunucu exe işlemi

        public HOME()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        // Başlat butonu
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serverProcess = new Process();
                serverProcess.StartInfo.FileName = @"C:\Users\DELL\OneDrive\Masaüstü\SUNUCU\HOME\HOME\HOME\bin\Debug\net10.0\HOME.exe";
                serverProcess.StartInfo.Arguments = "127.0.0.1 8585";
                serverProcess.StartInfo.UseShellExecute = true;
                serverProcess.StartInfo.Verb = "runas"; // Yönetici olarak çalıştır
                serverProcess.Start();

                label1.Text="Sunucu başlatıldı!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sunucu başlatılamadı: " + ex.Message);
            }
        }

        // Durdur butonu
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Burada exe ismini doğru yazmak kritik!
                Process[] processes = Process.GetProcessesByName("HOME"); // HOME.exe için
                if (processes.Length == 0)
                {
                    MessageBox.Show("Sunucu zaten çalışmıyor!","Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (var p in processes)
                {
                    p.Kill();
                    p.WaitForExit();
                }

                label2.Text="Sunucu durduruldu!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sunucu durdurulamadı: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Önce durdur
                Process[] processes = Process.GetProcessesByName("HOME");
                foreach (var p in processes)
                {
                    p.Kill();
                    p.WaitForExit();
                }

                // Sonra başlat
                serverProcess = new Process();
                serverProcess.StartInfo.FileName = @"C:\Users\DELL\OneDrive\Masaüstü\SUNUCU\HOME\HOME\HOME\bin\Debug\net10.0\HOME.exe";
                serverProcess.StartInfo.Arguments = "127.0.0.1 8585";
                serverProcess.StartInfo.UseShellExecute = true;
                serverProcess.StartInfo.Verb = "runas";
                serverProcess.Start();

                label3.Text="Sunucu yeniden başlatıldı!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yeniden başlatılamadı: " + ex.Message);
            }
        }
    }
}