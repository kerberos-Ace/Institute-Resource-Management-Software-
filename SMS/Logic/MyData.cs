using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace SMS.Logic
{
    class MyData
    {
        static MySqlConnection cn;
       
        public MyData()
        {
            if(cn==null)
            {
                cn = new MySqlConnection();
                cn.ConnectionString = GetConnectionString();
                cn.Open();
            }
           
        }
        public string GetConnectionString()
        {
            return "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
        }

        public string Save_College(String  colgname)
        {
            string msg = "";
            try
            {
                string q = "insert into college(collegename) values(?collegename)";
                MySqlCommand cmd = new MySqlCommand(q, cn);
                MySqlParameter p1 = new MySqlParameter("collegename", colgname);
        


                cmd.Parameters.Add(p1);

             

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                msg = "Data Saved Successfully";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }


        public string Save_Course(Course c)
        {
            string msg = "";
            try
            {
                string q = "insert into courses(cname,cduration,cfee) values(?cname,?cduration,?cfee)";
                MySqlCommand cmd = new MySqlCommand(q, cn);
                MySqlParameter p1 = new MySqlParameter("cname", c.Cname);
                MySqlParameter p2 = new MySqlParameter("cduration", c.Duration);
                MySqlParameter p3 = new MySqlParameter("cfee", c.Cfee);
               

                cmd.Parameters.Add(p1);

                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
               

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                msg = "Data Saved Successfully";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }

        public string Save_batch(Batch c)
        {
            string msg = "";
            try
            {
                string q = "insert into batches(bname,doa,sdate,edate,cid,facultyid) values(?bname,?doa,?sdate,?edate,?cid,?facultyid)";
                MySqlCommand cmd = new MySqlCommand(q, cn);
                MySqlParameter p1 = new MySqlParameter("bname", c.Bname);
                MySqlParameter p2 = new MySqlParameter("doa", c.Doa);
                MySqlParameter p3 = new MySqlParameter("sdate", c.Sdate);
                MySqlParameter p4 = new MySqlParameter("edate", c.Edate);
                MySqlParameter p5 = new MySqlParameter("cid", c.Cid);
                MySqlParameter p6 = new MySqlParameter("facultyid", c.Facultyid);
               


                cmd.Parameters.Add(p1);

                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
            
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                msg = "Data Saved Successfully";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
        public string Save(User c)
        {
            string msg = "";
            try
            {
                string q = "insert into users(email,pass,fname,cno,college,course,branch,sem,doe,dob,utype) values(?email,?pass,?fname,?cno,?college,?course,?branch,?sem,?doe,?dob,?utype)";
                MySqlCommand cmd = new MySqlCommand(q, cn);
                MySqlParameter p1 = new MySqlParameter("email",c.Email);
                MySqlParameter p2 = new MySqlParameter("pass", c.Pass);
                MySqlParameter p3 = new MySqlParameter("fname", c.Fname);
                MySqlParameter p4 = new MySqlParameter("cno", c.Cno);
                MySqlParameter p5 = new MySqlParameter("college", c.College);
                MySqlParameter p6 = new MySqlParameter("course", c.Course);
                MySqlParameter p7 = new MySqlParameter("branch", c.Branch);
                MySqlParameter p8 = new MySqlParameter("sem", c.Sem);
                MySqlParameter p9 = new MySqlParameter("doe", c.Doe);
                MySqlParameter p10 = new MySqlParameter("dob", c.Dob);
                MySqlParameter p11 = new MySqlParameter("utype", c.Utype);
                

                cmd.Parameters.Add(p1);
                
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);
                cmd.Parameters.Add(p10);
                cmd.Parameters.Add(p11);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                msg = "Data Saved Successfully";
            }
            catch (Exception e)
            {
                msg = e.Message;
              
            }
            return msg;
        }


        public string IsValidUser(User c)
        {
            string msg = "";
            try
            {
                string q = "select * from users where uid=?uid and pass=?pass and utype=?utype";
                MySqlCommand cmd = new MySqlCommand(q, cn);
                MySqlParameter p1 = new MySqlParameter("uid", c.Email);
                MySqlParameter p2 = new MySqlParameter("pass", c.Pass);
                MySqlParameter p3 = new MySqlParameter("utype", c.Utype);
                cmd.Parameters.Add(p1);
                
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                MySqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    msg = c.Utype;
                    
                }
                else
                {
                    msg = "Invalid Credential";
                }
                dr.Close();
                cmd.Dispose();
                
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }


    }
}
