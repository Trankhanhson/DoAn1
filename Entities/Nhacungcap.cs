using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class Nhacungcap
    {
        private string ten, diachi, sdt, ma;
        #region các thuộc tính
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
        #endregion

        #region các phương thức
        public Nhacungcap()
        {

        }
        public Nhacungcap(Nhacungcap n)
        {
            this.ma = n.Ma;
            this.Ten = n.Ten;
            this.diachi = n.diachi;
            this.sdt = n.sdt;
        }
        public Nhacungcap(string ma, string ten, string diachi, string sdt)
        {
            this.ma = ma;
            this.ten = ten;
            this.diachi = diachi;
            this.sdt = sdt;
        }
        #endregion
    }
}
