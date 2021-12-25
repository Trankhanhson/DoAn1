using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    class HDNhap
    {
        private string mahdn, tenncc;
        private DateTime ngaynhap;
        private int tongtien;

        public string Mahdn
        {
            get { return mahdn; }
            set { mahdn = value; }
        }

        public string Tenncc
        {
            get { return tenncc; }
            set { tenncc = value; }
        }
        
        public DateTime Ngaynhap
        {
            get { return ngaynhap; }
            set { ngaynhap = value; }
        }
        public int Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        public HDNhap()
        {

        }

        public HDNhap(string mahdn, string tenncc, DateTime ngaynhap, int tongtien)
        {
            this.mahdn = mahdn;
            this.tenncc = tenncc;
            this.ngaynhap = ngaynhap;
            this.tongtien = tongtien;            
        }
    }
}
