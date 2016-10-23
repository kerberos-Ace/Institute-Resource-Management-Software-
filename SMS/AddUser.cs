using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace SMS
{
    public partial class AddUser : Form
    { static MySqlConnection cn;
  public static string temp_value_;
        public AddUser()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg";
             cn = new MySqlConnection();
                cn.ConnectionString = GetConnectionString();
                cn.Open();
                fill_college();
                fill_course();
           
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                
        }
         public string GetConnectionString()
        {
            return "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
        }
         void fill_course() {

             comboBox6.Items.Clear();
             try
             {
                 string q = "select * from  courses";
                 MySqlCommand cmd = new MySqlCommand(q, cn);
                 int temp = 0;
                 MySqlDataReader dr = cmd.ExecuteReader();
                 while (dr.Read())
                 {
                     temp++;
                     comboBox6.Items.Add(dr[0].ToString()+" - "+dr[1].ToString());

                 } dr.Close();
                 cmd.Dispose();
                 if (temp != 0) {

                     comboBox6.SelectedIndex = 0;
                 }
             }
             catch { }
         
         }
        void fill_college() { 
        
       comboBox4.Items.Clear();
       try
       {
           string q = "select * from  college";
           MySqlCommand cmd = new MySqlCommand(q, cn);
           int te = 0;
           MySqlDataReader dr = cmd.ExecuteReader();
           while (dr.Read())
           {
               te++;
               comboBox4.Items.Add(dr[1].ToString());

           } dr.Close();
           cmd.Dispose();
           if (te != 0) {

               comboBox4.SelectedIndex = 0;
           
           }
       }
       catch { }
               
               
                
        
        
        
        
        
        }


        void clear() {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox4.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg";
        
        
        }
      

        private void button1_Click(object sender, EventArgs e)
        {


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

                    Logic.User u = new Logic.User(null, textBox1.Text, null, textBox2.Text.ToUpper(), textBox3.Text, comboBox4.SelectedItem.ToString(), comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"), dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm"), "Student");

                    string str = m.Save(u);
                    MessageBox.Show(str);
                    Logic.return_unique_no retu = new Logic.return_unique_no();
                    inset_course_mapping(retu.count_("users") - 1);
                    if (pictureBox1.ImageLocation!= AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg"&&  str.Equals("Data Saved Successfully"))
                    {
                        File.Copy(pictureBox1.ImageLocation, AppDomain.CurrentDomain.BaseDirectory + "images\\" + (retu.count_("users") - 1).ToString() + ".jpg");
                       
                    }
                    clear();
                }
             
            }
            else
            {
                MessageBox.Show("Empty Fields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
       
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.ImageLocation = openFileDialog1.FileName;
             
            }
   
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            temp_value_ = "15";

            AddCollege au = new AddCollege();

            au.ShowDialog();
            if (!temp_value_.Equals("15"))
            {
                comboBox4.Items.Add(temp_value_.ToUpper());
            }
          




        }


        void inset_course_mapping(int userid) {

            try
            {
                var cid_tem = comboBox6.SelectedItem.ToString().Split('-');

                String q = "insert into courseusermapping(userid,cid,dor) values(?userid,?cid,?dor) ";
                MySqlCommand cmd = new MySqlCommand(q, cn);
                MySqlParameter p1 = new MySqlParameter("userid", userid);
                MySqlParameter p2 = new MySqlParameter("cid", cid_tem.First());
                MySqlParameter p3 = new MySqlParameter("dor", dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm"));


                cmd.Parameters.Add(p1);

                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }   catch(Exception www)
            {



            }
        
        
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
