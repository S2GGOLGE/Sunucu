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
        SqlConnection bağlantı = new SqlConnection(
            "Data Source=Emree;Initial Catalog=Sunucu;Integrated Security=True;Multiple Active Result Sets=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                bağlantı.Open();

                string komut = "SELECT * FROM Kullanicilar WHERE Email=@email AND Sifre=@sifre";

                SqlCommand işlem = new SqlCommand(komut, bağlantı);

                işlem.Parameters.AddWithValue("@email", usernametxt.Text);
                işlem.Parameters.AddWithValue("@sifre", passtxt.Text);

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
                    MessageBox.Show(
                        "Şifre ya da kullanıcı adı hatalı!",
                        "Sistem",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    passtxt.Clear();
                    usernametxt.Focus();
                }

                oku.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                bağlantı.Close();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Kapatmak istediğinize emin misiniz?",
                "SİSTEM",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
