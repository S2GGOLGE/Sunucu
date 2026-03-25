using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ANA_SUNUCU
{
    public partial class Login : Form
    {
        public Login()
        {

            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        SqlConnection bağlantı = new SqlConnection("Data Source=EMREE\\SQLEXPRESS;Initial Catalog=Sunucu;Integrated Security=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {
       
            bağlantı.Open();
            string komut = "Select * From Admın where(Username='" + usernametxt.Text + "')AND pass='" + passtxt.Text + "'";
            SqlCommand işlem = new SqlCommand(komut, bağlantı);
            SqlDataReader oku = işlem.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Hoşgeldiniz " + usernametxt.Text + " Efendim", "Sistem");
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre Yada Kullanıcı Adı Hatalı Lutfen Tekrar Deneyiniz", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Question);
                passtxt.Clear();
            }

            
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kapatmak istedğinize emin misiniz","SİSTEM",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            Application.Exit();
        }
    }
}
