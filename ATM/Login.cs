using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static string AccNumber;
        private readonly SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label5_Click(object sender, EventArgs e)
        {
            account acc = new account();
            acc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AccNumTb.Text) || string.IsNullOrWhiteSpace(PinTb.Text))
            {
                MessageBox.Show("Proszę wprowadzić numer konta i PIN.");
                return;
            }

            if (!int.TryParse(PinTb.Text, out int pin))
            {
                MessageBox.Show("PIN musi być liczbą.");
                return;
            }

            try
            {
                Con.Open();
                string query = "SELECT COUNT(*) FROM AccountTbl WHERE AccNum = @AccNum AND Pin = @Pin";
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@AccNum", AccNumTb.Text);
                    cmd.Parameters.AddWithValue("@Pin", pin);

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 1)
                    {
                        AccNumber = AccNumTb.Text;
                        HOME home = new HOME();
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Nieprawidłowy numer konta lub PIN.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
