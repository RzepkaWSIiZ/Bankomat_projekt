using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM
{
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void button1_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNametb.Text == "" || AccNumTb.Text == "" || FanameTb.Text == "" || PhoneTb.Text == "" || Addresstb.Text == "" || occupationtb.Text == "" || pintb.Text == "")
            {
                MessageBox.Show("Brakujące informacje");
            }
            else
            {
                try
                {
                    Con.Open();

                    string query = @"INSERT INTO AccountTbl 
                    (AccNum, Name, FaName, Dob, Phone, Address, Education, Occupation, PIN, Balance) 
                    VALUES 
                    (@AccNum, @Name, @FaName, @Dob, @Phone, @Address, @Education, @Occupation, @PIN, @Balance)";

                    SqlCommand cmd = new SqlCommand(query, Con);

                    cmd.Parameters.AddWithValue("@AccNum", AccNumTb.Text);
                    cmd.Parameters.AddWithValue("@Name", AccNametb.Text);
                    cmd.Parameters.AddWithValue("@FaName", FanameTb.Text);
                    cmd.Parameters.AddWithValue("@Dob", dobdate.Value.Date); 
                    cmd.Parameters.AddWithValue("@Phone", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Address", Addresstb.Text);
                    cmd.Parameters.AddWithValue("@Education", educationcb.SelectedItem?.ToString() ?? ""); 
                    cmd.Parameters.AddWithValue("@Occupation", occupationtb.Text);
                    cmd.Parameters.AddWithValue("@PIN", Convert.ToInt32(pintb.Text));
                    cmd.Parameters.AddWithValue("@Balance", bal);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Nowe konto zostało utworzone");

                    Con.Close();

                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
