using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace SMS.Logic
{
    class return_unique_no
    {
        public int count_(string name_tabe)
        {
            String str = " SELECT `AUTO_INCREMENT` FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'eschool' AND   TABLE_NAME   = '" + name_tabe + "'";


            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            cn.Open();

            MySqlCommand cmd = new MySqlCommand(str, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            int a = 0;
            if (dr.Read())
            {
                a = Int32.Parse(dr[0].ToString());

            }
            cmd.Dispose();
            cn.Close();
            return a;




        }


        public int check_status(int bid_check,int cumid_check) {

            String str = " SELECT id FROM batchcourseusermapping WHERE bid= '"+bid_check+"' AND   cumid  = '" + cumid_check+ "'";


            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            cn.Open();

            MySqlCommand cmd = new MySqlCommand(str, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            int a = 0;
            if (dr.Read())
            {
                a ++;

            }
            cmd.Dispose();
            cn.Close();
            return a;

        
        
        
        
        }

        public string return_course_name(int couse_id)
        {

            String str = " SELECT cname  FROM courses WHERE cid= '" + couse_id+ "'";


            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            cn.Open();

            MySqlCommand cmd = new MySqlCommand(str, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            string a = "";
            if (dr.Read())
            {
                a = dr[0].ToString();

            }
            cmd.Dispose();
            cn.Close();
            return a;





        }

        public string return_batch_name(int batch_id)
        {
            
            String str = " SELECT  bname,cid  FROM batches WHERE bid= '" + batch_id+ "'";


            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            cn.Open();

            MySqlCommand cmd = new MySqlCommand(str, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            string a = "uc";
            if (dr.Read())
            {

               String temp= return_course_name(Int32.Parse( dr[1].ToString()));

                a = dr[0].ToString()+" - "+temp;

            }
            cmd.Dispose();
            cn.Close();
            return a;





        }


    }
}
