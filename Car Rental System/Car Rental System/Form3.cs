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
    public partial class Form3 : Form
    {
        String userID;
        //string fullname;
        public Form3(String userID)
        {
            InitializeComponent();
            this.userID = userID;
            label2.Text = "Welcome ," + userID;
        }



        //    {    int userID;
        //Form1 f;
        //public Form7(Form1 f,int userID)
        //{
        //    InitializeComponent();
        //    //this.f6 = f6;
        //    this.f = f;
        //    this.userID = userID;
        //}

        

        private void Form3_Load(object sender, EventArgs e)
        {
            //Initialization:
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                       "database = mydatabase;" +
                       "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("select * from uinfo",con);


            con.Open();

            

            //Execute SQL Query:
            SqlDataReader DR = command.ExecuteReader();

            


            DR.Read();

            //this.fullname = DR["username"].ToString();



            //label2.Text = ("Welcome" + fullname);


            //label2.Text = "test";
            //if (Request.QueryString["Username"] != null)
            //{

            //    string test = Request.QueryString["Username"];
            //    label2.Text = "Du har nu lånat filmen:" + test;
            //}


            //DR.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(userID);
            f4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(userID);
            f7.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10(userID);

            f.Show();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form13 f7 = new Form13(userID);
            f7.Show();

            this.Close();
        }
    }
}
