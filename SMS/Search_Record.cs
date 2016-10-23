using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SMS
{
    public partial class Search_Record : Form
    {
     
        MySqlConnection cn;
        MySqlCommandBuilder cmdb;
        DataSet ds;
        MySqlDataAdapter ad;
        MySqlCommand cmd;
        public static string search_record_report;
      
        public Search_Record()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            dataGridView1.Columns[0].ReadOnly =true;          
        }
        void fill_grid()
        {
           
             cn = new MySqlConnection();
            cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            cmd = new MySqlCommand("select  uid,email,fname AS name,cno As contact_No,college,course,branch,sem,doe,dob from users where fname like'%" + textBox1.Text + "%' and utype='" + comboBox1.SelectedItem.ToString() + "'", cn);
            ad = new MySqlDataAdapter(cmd);

            cmdb = new MySqlCommandBuilder(ad);
            ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            cn.Close();
              
             
        }

        private void change_me(object sender, EventArgs e)
        {
            fill_grid();
        }

        private void click_combo(object sender, EventArgs e)
        {
            fill_grid();
            textBox1.Text = "";
            if (comboBox1.SelectedIndex == 0)
            {


                dataGridView1.Enabled = true;
               

            }
            else
            {

                dataGridView1.Enabled = false;
                




            }

        }

        private void tableclick(object sender, DataGridViewCellMouseEventArgs e)
        {


            search_record_report = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " - " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            SearchList list = new SearchList();
            list.ShowDialog();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ad.Update(ds);
            MessageBox.Show("Success");
        }

     

    }
}
