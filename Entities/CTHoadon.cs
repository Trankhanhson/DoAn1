using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    class CTHoadon
    {
        private string mavl, mahd;
        private int soluong, tongtien, tienlai;
        public string Mavl
        {
            get { return mavl; }
            set { if (value != "") mavl = value; }
        }
        public string Mahd
        {
            get { return mahd; }
            set { if (value != "") mahd = value; }
        }
        public int Soluong
        {
            get { return soluong; }
            set { if (value > 0) soluong = value; }
        }
        public int Tongtien
        {
            get { return tongtien; }
            set { if (value > 0) tongtien = value; }
        }
        public int Tienlai
        {
            get { return tienlai; }
            set { tienlai = value; }
        }
        public CTHoadon() { }
        public CTHoadon(string mahd, string mavl, int soluong, int tongtien, int tienlai)
        {
            this.mahd = mahd;
            this.mavl = mavl;
            this.soluong = soluong;
            this.tongtien = tongtien;
            this.tienlai = tienlai;
        }
    }
}
