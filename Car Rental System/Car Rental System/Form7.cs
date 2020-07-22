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
    public partial class Form7 : Form
    {
        String userID;
        
        public Form7(String userID)
        {
            InitializeComponent();

            this.userID = userID;
        }


        private void Form7_Load(object sender, EventArgs e)
        {
            //Initialization:
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("select * from uinfo where Username = '" + userID + "'", con);

            //Opening the connection:
            con.Open();

            //Execute SQL Query:
            SqlDataReader DR = command.ExecuteReader();


            while (DR.Read())
            {
                textBox1.Text = (DR["Fullname"].ToString());
                textBox2.Text = (DR["Username"].ToString());

                textBox3.Text = (DR["Gender"].ToString());
                textBox4.Text = (DR["Dateofbirth"].ToString());
                textBox5.Text = (DR["Address"].ToString());
                textBox6.Text = (DR["Email"].ToString());
                textBox7.Text = (DR["Password"].ToString());
                
                
                
            }

            ////Binding reader to binding source
            //BindingSource source = new BindingSource();
            //source.DataSource = DR;

            ////Binding gridview or control datacsource to binding source:
            //dataGridView1.DataSource = source;

            //Disconnect
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("update uinfo set Fullname=@param1,Username=@param2,Gender=@param3,Dateofbirth=@param4,Address=@param5,Email=@param6,Password=@param7 where Username = '" + userID + "'", con);    
               
               con.Open();  
                //cmd.Parameters.AddWithValue("@id", ID);  
                cmd.Parameters.AddWithValue("@param1", textBox1.Text);  
                cmd.Parameters.AddWithValue("@param2", textBox2.Text);  
                cmd.Parameters.AddWithValue("@param3", textBox3.Text);  
                cmd.Parameters.AddWithValue("@param4", textBox4.Text);  
                cmd.Parameters.AddWithValue("@param5", textBox5.Text);  
                cmd.Parameters.AddWithValue("@param6", textBox6.Text);  
                cmd.Parameters.AddWithValue("@param7", textBox7.Text);  
                cmd.ExecuteNonQuery();  
                MessageBox.Show("Record Updated Successfully");  
                con.Close();  

                //DisplayData();  
                //ClearData();  
         
                //MessageBox.Show("Please Select Record to Update");  
            }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(userID);
            f.Show();
            this.Close();
        }

    }
}
