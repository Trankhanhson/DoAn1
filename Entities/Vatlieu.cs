using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Vatlieu
    {
        #region Trường dữ liệu
        private string ma, ten, donvitinh;
        private int giaban, gianhap, soluong, mucnhaphang;
        #endregion

        #region Các thuộc tính

        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        
        public string Donvitinh
        {
            get { return donvitinh; }
            set { donvitinh = value; }
        }
        public int Giaban
        {
            get { return giaban; }
            set { if (value > 0) giaban = value; }
        }
        public int Gianhap
        {
            get { return gianhap; }
            set { if (value > 0) gianhap = value; }

        }
        public int Soluong
        {
            get { return soluong; }
            set {  soluong = value; }
        }
        public int Mucnhaphang
        {
            get { return mucnhaphang; }
            set { mucnhaphang = value; }
        }
        #endregion

        #region phuong thuc
        public Vatlieu()
        {
        }
        public Vatlieu(string ma, string ten, string donvitinh, int gianhap, int giaban, int soluong,int mucnhaphang)
        {
            this.ma = ma;
            this.ten = ten;
            this.soluong = soluong;
            this.donvitinh = donvitinh;
            this.giaban = giaban;
            this.gianhap = gianhap;
            this.mucnhaphang=mucnhaphang;
        }
        #endregion
    }
}
