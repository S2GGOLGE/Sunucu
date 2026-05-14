using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ANA_SUNUCU
{
    public partial class Menu : Form
    {
        private Process serverProcess;

        public Menu()
        {
            InitializeComponent();
        }

        // ORTAK EXE BAŞLATMA METODU
        private void ProgramBaslat(string path, string mesaj, bool admin = false, string arguments = "")
        {
            try
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show("Dosya bulunamadı:\n" + path,
                        "HATA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                serverProcess = new Process();

                serverProcess.StartInfo = new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = arguments,
                    WorkingDirectory = Path.GetDirectoryName(path),
                    UseShellExecute = true,
                    Verb = admin ? "runas" : "",
                    CreateNoWindow = false
                };

                serverProcess.Start();

                MessageBox.Show(
                    mesaj,
                    "Sistem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "HATA:\n" + ex.Message,
                    "Sistem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // HOME
        private void button2_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }

        // PROJELER
        private void button3_Click(object sender, EventArgs e)
        {
            PROJELER proje = new PROJELER();
            proje.Show();
            this.Hide();
        }

        // ÇIKIŞ
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Çıkış yapmak istediğinize emin misiniz?",
                "Sistem",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        // JARVIS
        private void button4_Click(object sender, EventArgs e)
        {
            string path =
                @"C:\Users\DELL\OneDrive\Masaüstü\Projeler\JARVİS\JARVİS\bin\Debug\net10.0-windows\JARVİS.exe";

            ProgramBaslat(
                path,
                "Jarvis Başlatıldı!",
                true,
                "127.0.0.1 8586");
        }

        // TAKSİT TAKİP
        private void button5_Click(object sender, EventArgs e)
        {
            string path =
                @"Y:\TAKSİT TAKİP\TAKSİT TAKİP\bin\Debug\net10.0-windows\TAKSİT TAKİP.exe";

            ProgramBaslat(
                path,
                "TAKSİT TAKİP Açıldı",
                true,
                "127.0.0.1 8585");
        }

        // GYM PRO BACKEND
        private void button6_Click(object sender, EventArgs e)
        {
            string path =
                @"Y:\GYM-PRO\Backend\SeneOdev\bin\Debug\net8.0\SeneOdev.exe";

            ProgramBaslat(
                path,
                "Sene Ödev Backend Aktif");
        }

        // AI
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                serverProcess = new Process();

                serverProcess.StartInfo = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = "\"C:\\Users\\cetin\\Desktop\\JARVIS 2\\jarvis\\jarvis\\main.py\"",
                    WorkingDirectory = @"C:\Users\cetin\Desktop\JARVIS 2\jarvis\jarvis",
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                serverProcess.Start();

                MessageBox.Show("Python Jarvis Açıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA: " + ex.Message);
            }
        }
    }
}