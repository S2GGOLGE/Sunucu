using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ANA_SUNUCU
{
    public partial class Başlangıc : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Başlangıc()
        {
            InitializeComponent();

            // Üst çubuğu kaldır
            this.FormBorderStyle = FormBorderStyle.None;

            // İstersen tam ekran
            this.WindowState = FormWindowState.Maximized;
        }

        private void Başlangıc_Load(object sender, EventArgs e)
        {
            // 10 saniye bekle
            timer.Interval = 10000;

            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            Login login = new Login();
            login.Show();

            this.Hide();
        }
    }
}