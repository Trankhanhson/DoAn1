using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    class Nhanvien
    {
        private string ma;
        private string ten;
        private string diachi;
        private string sdt;
        private float ngaycong;
        private string gioitinh;
        private DateTime ngaysinh;
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
        public float Ngaycong
        {
            get { return ngaycong; }
            set { if (value >= 0) ngaycong = value; }
        }
        public string Gioitinh
        {
            get { return gioitinh; }
            set { if (value == "nam" || value == "nu") gioitinh = value; }
        }
        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        #endregion

        #region Các phuong thức
        public Nhanvien()
        {

        }
        public Nhanvien(string ma, string ten, string diachi, string sdt, string gioitinh, DateTime ngaysinh, float ngaycong)
        {
            this.ma = ma;
            this.ten = ten;
            this.diachi = diachi;
            this.sdt = sdt;
            this.ngaycong = ngaycong;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
        }
        #endregion
    }
}
