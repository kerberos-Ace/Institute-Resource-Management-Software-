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
    public partial class Batch_details : Form
    {

        MySqlConnection cn;
        MySqlCommandBuilder cmdb;
        DataSet ds;
        MySqlDataAdapter ad;
        MySqlCommand cmd;
        public Batch_details()
        {
            InitializeComponent();
             
            cn = new MySqlConnection();
            cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            cmd = new MySqlCommand("Select * from batches", cn);
            ad = new MySqlDataAdapter(cmd);

            cmdb = new MySqlCommandBuilder(ad);
            ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].ReadOnly = true; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ad.Update(ds);
            MessageBox.Show("Success");
        }

        private void change_me(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "bname like '%" + textBox1.Text + "%'  "; // sql command
            dataGridView1.DataSource = bs;



        }
    }
}
