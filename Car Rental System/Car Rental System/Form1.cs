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


namespace Car_Rental_System
{
    public partial class Form1 : Form
    {

        private SqlConnection con = new SqlConnection();
    
        public Form1()
        {
            InitializeComponent();

            con.ConnectionString = "data source = localhost;" +
                       "database = mydatabase;" +
                       "integrated security = SSPI";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "Admin" || textBox1.Text == "admin")
            {
                //Opening the connection:
                con.Open();

                //Execute SQL Query:

                SqlCommand command = new SqlCommand("select * from uinfo where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "' ", con);

                SqlDataReader DR = command.ExecuteReader();

                int count = 0;

                while (DR.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("Login Successful");


                    Form9 f1 = new Form9();
                    f1.ShowDialog();
                    this.Hide();
                }

                if (count == 0)
                {
                    MessageBox.Show("Please Enter Username and password correctly");
                }




                //Disconnect
                con.Close();
            }

            else {
                //Opening the connection:
                con.Open();

                //Execute SQL Query:

                SqlCommand command = new SqlCommand("select * from uinfo where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "' ", con);

                SqlDataReader DR = command.ExecuteReader();

                int count = 0;

                while (DR.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("Login Successful");


                    Form3 f1 = new Form3(textBox1.Text);
                    f1.ShowDialog();
                    this.Hide();
                }

                if (count == 0)
                {
                    MessageBox.Show("Please Enter Username and password correctly");
                }




                //Disconnect
                con.Close();
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form2 f1 = new Form2();
            f1.Show();
            this.Hide();
        }
    }
}
