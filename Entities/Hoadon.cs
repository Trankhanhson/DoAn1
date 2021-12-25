using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    class Hoadon
    {
        private string mahd, makh, manv, tenkh;
        private int dathanhtoan, tongtien,tienlai;
        private DateTime ngayxuat;

        public string Mahd
        {
            get { return mahd; }
            set { if (value != "") mahd = value; }
        }
        public string Makh
        {
            get { return makh; }
            set { if (value != "") makh = value; }
        }
        public string Tenkh
        {
            get { return tenkh; }
            set { if (value != "") tenkh = value; }
        }
        public string Manv
        {
            get { return manv; }
            set { if (value != "") manv = value; }
        }
        public int Tongtien
        {
            get { return tongtien; }
            set { if (value > 0) tongtien = value; }
        }
        public int Dathanhtoan
        {
            get { return dathanhtoan; }
            set { dathanhtoan = value; }
        }
        public int Tienlai
        {
            get { return tienlai; }
            set { tienlai = value; }
        }
        public DateTime Ngayxuat
        {
            get { return ngayxuat; }
            set {  ngayxuat = value; }
        }

        public Hoadon()
        {

        }
        public Hoadon(string mahd, string makh, string tenkh, string manv, DateTime ngayxuat, int tongtien, int dathanhtoan,int tienlai)
        {
            this.mahd = mahd;
            this.makh = makh;
            this.tenkh = tenkh;
            this.manv = manv;
            this.dathanhtoan = dathanhtoan;
            this.ngayxuat = ngayxuat;
            this.tongtien = tongtien;
            this.tienlai= tienlai;
        }
    }
}
