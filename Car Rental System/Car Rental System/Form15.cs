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
    public partial class Form15 : Form
    {
        String userID;
    
        public Form15(String userID)
        {
            InitializeComponent();

            this.userID = userID;
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            try
            {
                

                //Initialization:
                //Initiating SQL Connection:
                SqlConnection con = new SqlConnection();


                
                //ConnectionString:
                con.ConnectionString = "data source = localhost;" +
                                       "database = mydatabase;" +
                                       "integrated security = SSPI";

                //Generating SQL Query
                SqlCommand command = new SqlCommand("select * from sdreq where Username = '" + userID + "' ", con);


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

            catch (Exception ae)
            {
                MessageBox.Show("you dont have an request yet" +ae);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14(userID);
            f.Show();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f1 = new Form3(userID);

            f1.Show();

            this.Close();
        }
    }
}
