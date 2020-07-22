using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_System
{
    public partial class Form4 : Form
    {
        String userID ;
        public Form4(String userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form5 f1 = new Form5(userID);

                f1.Show();
            }
            else
            {
                Form6 f2 = new Form6(userID);

                f2.Show();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(userID);
            f.Show();
            this.Close();
        }
    }
}
