using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Logic
{
    class User
    {
        public User(string uid,string email,string pass,string fname,string cno,string college,string course,string branch,string sem,string doe,string dob,string utype)
        {
            Uid = uid;
            Email = email;
            Pass = pass;
            Fname = fname;
            Cno = cno;
            College = college;
            Course = course;
            Branch = branch;
            Sem = sem;
            Doe = doe;
            Dob = dob;
            Utype = utype;
        }
        public string  Uid { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string  Fname { get; set; }
        public string  Cno { get; set; }
        public string College { get; set; }
        public string Course { get; set; }
        public string Branch { get; set; }
        public string Sem { get; set; }
        public string Doe { get; set; }
        public string Dob { get; set; }
        public string Utype { get; set; }

    }
}
