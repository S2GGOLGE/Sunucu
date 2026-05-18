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

        // =========================
        // ORTAK ÇALIŞTIRMA MOTORU
        // =========================
        private void ProgramBaslat(
            string path,
            string mesaj,
            bool admin = false,
            string arguments = "",
            bool isPython = false)
        {
            try
            {
                // Python değilse dosya kontrolü yap
                if (!isPython && !File.Exists(path))
                {
                    MessageBox.Show(
                        $"Dosya bulunamadı:\n{path}",
                        "HATA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                serverProcess = new Process();

                string fileName;
                string args = arguments;

                // PYTHON MODU
                if (isPython)
                {
                    fileName = "python";
                    args = $"\"{path}\" {arguments}";
                }
                else
                {
                    fileName = path;
                }

                serverProcess.StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = args,
                    WorkingDirectory = Path.GetDirectoryName(path),
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    Verb = admin ? "runas" : null
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

        // =========================
        // NAVIGATION
        // =========================
        private void button2_Click(object sender, EventArgs e)
        {
            new HOME().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new PROJELER().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istiyor musunuz?",
                "Sistem",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new Login().Show();
                this.Close();
            }
        }

        // =========================
        // JARVIS (PYTHON)
        // =========================
        private void button4_Click(object sender, EventArgs e)
        {
            ProgramBaslat(
                @"Y:\Sesli Asistan\Jarvis\jarvis\jarvis\main.py",
                "Jarvis Başlatıldı!",
                true,
                "127.0.0.1 8586",
                true
            );
        }

        // =========================
        // TAKSİT TAKİP (EXE)
        // =========================
        private void button5_Click(object sender, EventArgs e)
        {
            ProgramBaslat(
                @"Y:\TAKSİT TAKİP\TAKSİT TAKİP\bin\Debug\net10.0-windows\TAKSİT TAKİP.exe",
                "TAKSİT TAKİP Açıldı",
                true
            );
        }

        // =========================
        // GYM BACKEND (EXE)
        // =========================
        private void button6_Click(object sender, EventArgs e)
        {
            ProgramBaslat(
                @"Y:\GYM-PRO\Backend\SeneOdev\bin\Debug\net8.0\SeneOdev.exe",
                "Backend Aktif"
            );
        }

        // =========================
        // AI (PYTHON - DUPLICATE FIXED)
        // =========================
        private void button4_Click_1(object sender, EventArgs e)
        {
            ProgramBaslat(
                @"Y:\Sesli Asistan\jarvis\jarvis\jarvis\main.py",
                "AI Açıldı",
                false,
                "",
                true
            );
        }
    }
}