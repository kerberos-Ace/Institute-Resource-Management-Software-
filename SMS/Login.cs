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
    public partial class Login : Form
    {
      public  static string login_id_;
        public Login()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Logic.User u = new Logic.User(null, textBox1.Text, textBox2.Text, null, null, null, null, null, null, null, null, comboBox1.SelectedItem.ToString());
            Logic.MyData d = new Logic.MyData();
            string str = d.IsValidUser(u);
            if (str == "Cashier")
            {
                login_id_ = textBox1.Text;
                MDIForm a = new MDIForm();
                a.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show(str);
            }
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
          
        }

      
    }
}
