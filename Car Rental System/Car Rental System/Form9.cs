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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            //Initialization:
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("select * from uinfo", con);

            //Opening the connection:
            con.Open();

            //Execute SQL Query:
            SqlDataReader DR = command.ExecuteReader();

            //Binding reader to binding source
            BindingSource source = new BindingSource();
            source.DataSource = DR;

            //Binding gridview or control datacsource to binding source:
            dataGridView1.DataSource = source;

            //Disconnect
            con.Close();

            //int totalRowHeight = dataGridView1.ColumnHeadersHeight;

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //    totalRowHeight += row.Height;

            //dataGridView1.Height = totalRowHeight;
            //this.Height = dataGridView1.Height + 100;

            SqlConnection conn = new SqlConnection();

            //ConnectionString:
            conn.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand commanddd = new SqlCommand("select * from sdreq", conn);

            //Opening the connection:
            conn.Open();

            //Execute SQL Query:
            SqlDataReader D = commanddd.ExecuteReader();

            //Binding reader to binding source
            BindingSource sourc = new BindingSource();
            sourc.DataSource = D;

            //Binding gridview or control datacsource to binding source:
            //dataGridView2.DataSource = sourc;
            //source.DataSource = DR;

            var hasItem = D.HasRows;

            if (hasItem)
            {

                //Binding gridview or control datacsource to binding source:
                dataGridView2.DataSource = sourc;
            }
                
            //Disconnect
            conn.Close();


            SqlConnection co = new SqlConnection();

            //ConnectionString:
            co.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand commandd = new SqlCommand("select * from svreq", co);

            //Opening the connection:
            co.Open();

            //Execute SQL Query:
            SqlDataReader DRR = commandd.ExecuteReader();

            //Binding reader to binding source
            BindingSource sourcee = new BindingSource();
            sourcee.DataSource = DRR;

            var hasItemm = DRR.HasRows;

            if (hasItemm)
            {

                //Binding gridview or control datacsource to binding source:
                dataGridView3.DataSource = sourcee;
            }

            //Binding gridview or control datacsource to binding source:
            //dataGridView3.DataSource = sourcee;

            //Disconnect
            co.Close();

            //int totalRowHeight = dataGridView1.ColumnHeadersHeight;

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //    totalRowHeight += row.Height;

            //dataGridView1.Height = totalRowHeight;
            //this.Height = dataGridView1.Height + 100;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            //textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();


            //        DataGridView grid = new DataGridView();
            //grid.ShowDialog(); 
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value.ToString());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            //textBox3.Text = "";

            //textBox4.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "male";
                }
                else
                {
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "female";
                }
                cmd.Parameters.Add("@param4", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = textBox5.Text;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = textBox6.Text;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = textBox7.Text;

                cmd.CommandType = CommandType.Text;






                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                { MessageBox.Show("Registration Successful"); }

                else { MessageBox.Show("Registration unuccessful"); }




                //Disconnect
                con.Close();

                dataGridView1.DataSource = "data source = localhost;database = mydatabase;integrated security = SSPI";
                dataGridView1.Refresh();
                SqlCommand command = new SqlCommand("select * from uinfo", con);


                con.Open();

                SqlDataReader DR = command.ExecuteReader();


                BindingSource source = new BindingSource();
                source.DataSource = DR;


                dataGridView1.DataSource = source;


                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;database = mydatabase;integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("delete uinfo where username = '" + textBox2.Text + "' ", con);
            //using (SqlCommand cmd = new SqlCommand(sql, con))
            //{
                //Opening the connection:
                con.Open();


                //cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = textBox1.Text;
                //cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = textBox2.Text;
                //if (radioButton1.Checked)
                //{
                //    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "male";
                //}
                //else
                //{
                //    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "female";
                //}
                //cmd.Parameters.Add("@param4", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                //cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = textBox5.Text;
                //cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = textBox6.Text;
                //cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = textBox7.Text;

                command.CommandType = CommandType.Text;






                int i = command.ExecuteNonQuery();

                if (i >= 1)
                { MessageBox.Show("Delete Successfull"); }

                else { MessageBox.Show("Delete unuccessful"); }




                //Disconnect
                con.Close();

                dataGridView1.DataSource = "data source = localhost;database = mydatabase;integrated security = SSPI";
                dataGridView1.Refresh();
                SqlCommand commandd = new SqlCommand("select * from uinfo", con);


                con.Open();

                SqlDataReader DR = commandd.ExecuteReader();


                BindingSource source = new BindingSource();
                source.DataSource = DR;


                dataGridView1.DataSource = source;


                con.Close();
            }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry still in development");
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            
        }

        


        }
    }
