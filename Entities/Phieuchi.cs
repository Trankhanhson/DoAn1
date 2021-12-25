using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    class Phieuchi
    {
        private string maphieu, ghichu;
        private DateTime thoigian;
        int sotien;
        public string Maphieu
        {
            get { return maphieu; }
            set { maphieu = value; }
        }
        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
        public DateTime Thoigian
        {
            get { return thoigian; }
            set { thoigian = value; }
        }
        public int Sotien
        {
            get { return sotien; }
            set { sotien = value; }
        }

        public Phieuchi() { }
        public Phieuchi(string maphieu, int sotien, DateTime thoigian, string ghichu)
        {
            this.maphieu = maphieu;
            this.ghichu = ghichu;
            this.thoigian = thoigian;
            this.sotien = sotien;
        }
    }
}
