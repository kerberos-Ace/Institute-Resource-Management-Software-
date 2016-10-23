using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Logic
{
    class Course
    {
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string Duration { get; set; }
        public int Cfee { get; set; }
        
         public Course(int cid,string cname,string duration,int cfee)
        {
            Cid = cid;
            Cname = cname;
            Duration = duration;
            Cfee = cfee;
           
        }
       
    }
}
