using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Logic
{
    class Batch
    {
        public Batch(string bid, string bname, string doa, string sdate, string edate, int cid, int facultyid)
        {
            Bid = bid;
            Bname = bname;
            Doa = doa;
            Sdate = sdate;
            Edate = edate;
            Cid = cid;
            Facultyid = facultyid;

        }
        public string Bid { get; set; }

        public string Bname { get; set; }

        public string Doa { get; set; }
        public string Sdate { get; set; }
        public string Edate { get; set; }
        public int Cid { get; set; }
        public int Facultyid { get; set; }

    }
}
