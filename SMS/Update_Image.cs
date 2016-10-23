using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SMS
{
    public partial class Update_Image : Form
    {
        int asd = 0;
        public Update_Image()
        {
            InitializeComponent();
            var data_previous = SearchList.iimm_upload.Split('-');
            pictureBox1.ImageLocation = data_previous.Last();
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
                asd++;

            }
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data_previous = Search_Record.search_record_report.Split('-');
            string path = AppDomain.CurrentDomain.BaseDirectory + "images\\" + data_previous.First().Trim() + ".jpg";
            
            if(asd!=0){
            if (File.Exists(path) == true)
            {
                File.Delete(path);
            }
            
            File.Copy(pictureBox1.ImageLocation,path);}
           
           
            this.Dispose();

        }

        private void Update_Image_FormClosing(object sender, FormClosingEventArgs e)
        {
            SearchList.iimm_upload = pictureBox1.ImageLocation;
        }
    }
}
