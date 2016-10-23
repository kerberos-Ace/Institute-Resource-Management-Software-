using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using System.IO;
using System.Web.UI.Design;
namespace SMS
{
    public partial class Form1 : Form{
         MySqlConnection cn;
            MySqlCommandBuilder cmdb;
            DataSet ds;
            MySqlDataAdapter ad;
            MySqlCommand cmd;
       // Content item for the combo box
        private class Item
        {
           
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }
        public Form1()
        {
            InitializeComponent();
          cn=new MySqlConnection();
            cn.ConnectionString="Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            cmd=new MySqlCommand("Select * from courses",cn);
            ad=new MySqlDataAdapter(cmd);
         
            cmdb=new MySqlCommandBuilder(ad);
            ds=new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource=ds.Tables[0];

            this.Text = "hello";
            this.textBox1.LostFocus += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.GotFocus += new System.EventHandler(this.textBox1_Enter);
            this.textBox2.LostFocus += new System.EventHandler(this.textBox1_Leave);
            this.textBox2.GotFocus += new System.EventHandler(this.textBox1_Enter);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0  )
            {
                textBox1.Text = "Please Enter Your Name";
                textBox1.ForeColor = SystemColors.GrayText;}

            else if(textBox2.Text.Length == 0){
                textBox2.Text = "Please Enter Your Name";
                textBox2.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Please Enter Your Name"  )
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
            else if(textBox2.Text == "Please Enter Your Name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.WindowText;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(new Item("Blue", 1));
            comboBox1.Items.Add(new Item("Red", 2));
            comboBox1.Items.Add(new Item("Nobugz", 666));
           
        }
     
        private void ans(object sender, EventArgs e)
        {
            Item itm = (Item)comboBox1.SelectedItem;
           
            textBox1.Text = itm.Name;
            textBox2.Text = itm.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ad.Update(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void heeek(object sender, EventArgs e)
        {

            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "cname" + " like '%" + textBox3.Text + "%'"; // sql command
            dataGridView1.DataSource = bs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {

                dataGridView2.Rows[1].Cells[0].Value = i.ToString();


            }
        }
    }
}
