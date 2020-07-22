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
    public partial class Form6 : Form
    {
        String userID;
        public Form6(String userID)
        {
            InitializeComponent();

            this.userID = userID;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //Initialization:
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("select * from svcar", con);

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
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;database = mydatabase;integrated security = SSPI";

            //Generating SQL Query
            string sql = "INSERT svreq(Brand,Model,Numberplate,Color,Driver,Drivercont,Deparature,Destination,Startdt,Enddt,Usernmame) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@param11)";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                //Opening the connection:
                con.Open();


                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = textBox1.Text;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = textBox2.Text;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = textBox3.Text;

                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = textBox4.Text;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = textBox5.Text;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = textBox6.Text;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = textBox7.Text;
                cmd.Parameters.Add("@param8", SqlDbType.VarChar, 50).Value = textBox8.Text;
                cmd.Parameters.Add("@param9", SqlDbType.DateTime).Value = dateTimePicker1.Value.Date;
                cmd.Parameters.Add("@param10", SqlDbType.DateTime).Value = dateTimePicker2.Value.Date;
                cmd.Parameters.Add("@param11", SqlDbType.VarChar, 50).Value =  userID;

                cmd.CommandType = CommandType.Text;






                cmd.ExecuteNonQuery();



                //Disconnect
                con.Close();
            }

            MessageBox.Show("Thank you for your Request .you will be Notified in the my requests tab when the car will be available");
        }

       


        
    }
}
