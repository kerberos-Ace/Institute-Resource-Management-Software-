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
    public partial class AddCollege : Form
    {
        int ID;
        public AddCollege()
        {
            InitializeComponent();

            this.BindGrid();
        }

        void cleardata()
        {

            ID = 0;
            textBox1.Text = "";
          
        }
        private void BindGrid()
        {
            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM college", con))
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                Logic.MyData m = new Logic.MyData();
                string str = m.Save_College(textBox1.Text.ToUpper());
                MessageBox.Show(str);
                BindGrid();

                if (str.Equals("Data Saved Successfully")&&AddUser.temp_value_ == "15")
                {

                    AddUser.temp_value_ = textBox1.Text;
                    this.Dispose();
               
                
                   
                }
                        cleardata();
            }
            else {

                MessageBox.Show("Enter College Name");
            
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" )
            {
                string conString1 = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
                MySqlConnection con = new MySqlConnection(conString1);
                MySqlCommand cmd = new MySqlCommand("update college set collegename=@collegename where idcollege=@idcollege", con);
                con.Open();
                cmd.Parameters.AddWithValue("@idcollege", ID);
                cmd.Parameters.AddWithValue("@collegename", textBox1.Text);
               ;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                BindGrid();

                cleardata();
            }
            else { MessageBox.Show("Please Select Record to Update"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
string conString1 = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            MySqlConnection con = new MySqlConnection(conString1);


            if (ID != 0)
            {
                MySqlCommand cmd = new MySqlCommand("delete from college where idcollege=@idcollege", con);
                con.Open();
                cmd.Parameters.AddWithValue("@idcollege", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                BindGrid();
                cleardata();
               
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }  
        }

        private void click_on_cell(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }




      
    }
}
