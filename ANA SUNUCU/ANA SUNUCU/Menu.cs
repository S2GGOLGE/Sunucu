using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ANA_SUNUCU
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private Process serverProcess;
        private void button2_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PROJELER proje = new PROJELER();
            proje.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış Yapmak İstedğinize Emin Misiniz", "Sistem", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\Users\DELL\OneDrive\Masaüstü\Projeler\JARVİS\JARVİS\bin\Debug\net10.0-windows\JARVİS.exe";

                serverProcess = new Process();
                serverProcess.StartInfo.FileName = path;
                serverProcess.StartInfo.Arguments = "127.0.0.1 8586";
                serverProcess.StartInfo.UseShellExecute = true;
                serverProcess.StartInfo.Verb = "runas";

                serverProcess.Start();

                MessageBox.Show("Jarvis Başlatıldı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sunucu başlatılamadı: " + ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\Users\DELL\OneDrive\Masaüstü\Projeler\EV TAKSİT\EV TAKSİT\bin\Debug\EV TAKSİT.exe";
                serverProcess = new Process();
                serverProcess.StartInfo.FileName = path;
                serverProcess.StartInfo.Arguments = "127.0.0.1 8585";
                serverProcess.StartInfo.UseShellExecute = true;
                serverProcess.StartInfo.Verb = "runas";
                serverProcess.Start();
                MessageBox.Show("KAYIT AÇILDI");

            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA:" + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\Users\DELL\OneDrive\Masaüstü\Projeler\Sene Odevi\Sene Odevi Backend\SeneOdev\bin\Debug\net8.0\SeneOdev.exe";
                serverProcess = new Process();
                serverProcess.StartInfo.FileName = path;
                serverProcess.StartInfo.UseShellExecute = true;
                serverProcess.Start();
                MessageBox.Show("Sene Odev Backend Aktif");
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA:" + ex.Message);
            }
        }
    }
}