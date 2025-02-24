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
    public partial class FASTCASH : Form
    {
        public FASTCASH()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;
        int bal;
        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance from AccountTbl where AccNum='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "Stan konta: " + dt.Rows[0][0].ToString() + " zł";
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }

        private void FASTCASH_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bal < 100)
            {
                MessageBox.Show("Kwota wypłaty nie może być większa niż stan konta");
            }
            else
            {
                int newbalance = bal - 100;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTbl set Balance=" + newbalance + "WHERE Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Wypłata udana!");
                    Con.Close();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 500)
            {
                MessageBox.Show("Kwota wypłaty nie może być większa niż stan konta");
            }
            else
            {
                int newbalance = bal - 500;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTbl set Balance=" + newbalance + "WHERE Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Wypłata udana!");
                    Con.Close();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Kwota wypłaty nie może być większa niż stan konta");
            }
            else
            {
                int newbalance = bal - 1000;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTbl set Balance=" + newbalance + "WHERE Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Wypłata udana!");
                    Con.Close();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bal < 2000)
            {
                MessageBox.Show("Kwota wypłaty nie może być większa niż stan konta");
            }
            else
            {
                int newbalance = bal - 2000;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTbl set Balance=" + newbalance + "WHERE Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Wypłata udana!");
                    Con.Close();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bal < 5000)
            {
                MessageBox.Show("Kwota wypłaty nie może być większa niż stan konta");
            }
            else
            {
                int newbalance = bal - 5000;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTbl set Balance=" + newbalance + "WHERE Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Wypłata udana!");
                    Con.Close();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bal < 10000)
            {
                MessageBox.Show("Kwota wypłaty nie może być większa niż stan konta");
            }
            else
            {
                int newbalance = bal - 10000;
                try
                {
                    Con.Open();
                    string query = "UPDATE AccountTbl set Balance=" + newbalance + "WHERE Accnum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Wypłata udana!");
                    Con.Close();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
