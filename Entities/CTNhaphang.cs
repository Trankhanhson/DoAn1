using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    class CTNhaphang
    {
        private string mavl, mahdn;
        private int soluong, gianhap, tongtien;
        public string Mavl
        {
            get { return mavl; }
            set { if (value != "") mavl = value; }

        }
        public string Mahdn
        {
            get { return mahdn; }
            set { if (value != "") mahdn = value; }
        }
        public int Soluong
        {
            get { return soluong; }
            set { if (value > 0) soluong = value; }
        }
        public int Gianhap
        {
            get { return gianhap; }
            set { if (value > 0) gianhap = value; }
        }
        public int Tongtien
        {
            get { return tongtien; }
            set { if (value > 0) tongtien = value; }
        }
        public CTNhaphang() { }
        public CTNhaphang(string mahdn, string mavl, int soluong, int gianhap, int tongtien)
        {
            this.mahdn = mahdn;
            this.mavl = mavl;
            this.soluong = soluong;
            this.tongtien = tongtien;
            this.gianhap = gianhap;
        }
    }
}
