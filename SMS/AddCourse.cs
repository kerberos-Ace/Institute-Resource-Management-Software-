using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SMS
{
    public partial class AddCourse : Form
    {
        int ID;
        public AddCourse()
        {
            InitializeComponent();



            this.BindGrid();
        }

        void cleardata() {

            ID = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void BindGrid()
        {
            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123"; 
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM courses", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void press(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Logic._validation_ v = new Logic._validation_();
       int temp_count_validation=     v.validation_all_(panel1);
       if (temp_count_validation == 0)
       {

           Logic.MyData m = new Logic.MyData();

           Logic.Course u = new Logic.Course(0, textBox1.Text.ToUpper(), textBox2.Text, Int32.Parse(textBox3.Text));

           string str = m.Save_Course(u);
           MessageBox.Show(str);
           BindGrid();
           cleardata();
       }
        }

        private void button2_Click_1(object sender, EventArgs e)

        {
            string conString1 = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            MySqlConnection con = new MySqlConnection(conString1);


            if (ID != 0)
            {
                MySqlCommand cmd = new MySqlCommand("delete from courses where cid=@cid", con);
                con.Open();
                cmd.Parameters.AddWithValue("@cid", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                BindGrid();
                cleardata();
               
            }
            else
            {
                MessageBox.Show("Please Select Record To Delete");
            }  
        }





        private void cellclick(object sender, DataGridViewCellMouseEventArgs e)
        {

            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
           textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
          textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
          textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string conString1 = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
                MySqlConnection con = new MySqlConnection(conString1);
                MySqlCommand cmd = new MySqlCommand("update courses set cname=@cname,cduration=@cduration,cfee=@cfee where cid=@cid", con);
                con.Open();
                cmd.Parameters.AddWithValue("@cid", ID);
                cmd.Parameters.AddWithValue("@cname", textBox1.Text);
                cmd.Parameters.AddWithValue("@cduration", textBox2.Text);
                cmd.Parameters.AddWithValue("@cfee", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
             BindGrid();

             cleardata();
            }
            else { MessageBox.Show("Please Select Record To Update"); }
        }

        }
    }
