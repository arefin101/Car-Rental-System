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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox3.Text) && String.IsNullOrEmpty(textBox4.Text) && String.IsNullOrEmpty(textBox5.Text))

            { MessageBox.Show("Please Enter all the details first"); }
            
            else{
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;database = mydatabase;integrated security = SSPI";

            //Generating SQL Query
            string sql = "INSERT uinfo(Fullname,Username,Gender,Dateofbirth,Address,Email,Password) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                //Opening the connection:
                con.Open();


                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = textBox1.Text;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = textBox2.Text;
                if (radioButton1.Checked)
                {
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar,50).Value = "male";
                }
                else
                {
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "female";
                }
                cmd.Parameters.Add("@param4", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = textBox3.Text;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = textBox4.Text;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = textBox5.Text;

                cmd.CommandType = CommandType.Text;
                

                

                

                int i =    cmd.ExecuteNonQuery();

                if (i >= 1)
                { MessageBox.Show("Registration Successful"); }

                else { MessageBox.Show("Registration unuccessful");  }



               
                //Disconnect
                con.Close();

                
}            }

            


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }


    }
}
