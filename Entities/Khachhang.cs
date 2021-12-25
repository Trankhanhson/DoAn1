using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    class Khachhang
    {
        private string ma;
        private string ten;
        private string diachi;
        private string sdt;
        private string gioitinh;
        private DateTime ngaysinh;
        private int congno;

        #region Các thuộc tính
        public string Ma
        {
            get { return ma; }
            set { if (value != "") ma = value; }
        }
        public string Ten
        {
            get { return ten; }
            set { if (value != "") ten = value; }
        }
        public string Diachi
        {
            get { return diachi; }
            set { if (value != "") diachi = value; }
        }
        public string Sdt
        {
            get { return sdt; }
            set { if (value != "") sdt = value; }
        }
        public string Gioitinh
        {
            get { return gioitinh; }
            set
            {
                gioitinh = value;
            }
        }
        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        public int Congno
        {
            get { return congno; }
            set { congno = value; }
        }
        #endregion

        #region Các phuong thức
        public Khachhang()
        {

        }
        public Khachhang(string ma, string ten, string diachi, string sdt, string gioitinh, DateTime ngaysinh,int congno)
        {
            this.ma = ma;
            this.ten = ten;
            this.diachi = diachi;
            this.sdt = sdt;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.congno = congno;
        }
        #endregion
    }
}
