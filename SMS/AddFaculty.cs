using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class AddFaculty : Form
    {
        public AddFaculty()
        {
            InitializeComponent();
        }

     
        private void button1_Click_1(object sender, EventArgs e){
          Logic._validation_ v = new Logic._validation_();
           
          
           
            if (textBox2.Text.Length!=0&&textBox3.Text.Length!=0)
            {
                int emai_validation = 0;
                if (textBox1.Text.Length > 0)
                {
                     emai_validation = v.validate_email_mobile(1, textBox1.Text);
                }

        
                if (emai_validation == 0 )
                {

                    Logic.MyData m = new Logic.MyData();

                    Logic.User u = new Logic.User(null, textBox1.Text, null, textBox2.Text.ToUpper(), textBox3.Text, null, null, null,null, null, dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm"), "Faculty");

                    string str = m.Save(u);
                    MessageBox.Show(str);
                
                  
                    clear();
                }
             
            }
            else
            {
                MessageBox.Show("Empty Fields");
            }
        }







     

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear() {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
       
    }
}
