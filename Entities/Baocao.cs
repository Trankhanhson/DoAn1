using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    class Baocao
    {
        private int tongthu, tongchi, thucthu,lairong,laigop;
        private DateTime time;

        public int Tongthu
        {
            get { return tongthu; }
            set { if (value >= 0) tongthu = value; }
        }
        public int Thucthu
        {
            get { return thucthu; }
            set { if (thucthu >= 0) thucthu = value; }
        }
        public int Tongchi
        {
            get { return tongchi; }
            set { if (tongchi >= 0) tongchi = value; }
        }
        public int Lairong
        {
            get { return lairong; }
            set { lairong = value; }
        }
        public int Laigop
        {
            get { return laigop; }
            set { laigop = value; }
        }
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public Baocao()
        {

        }
        public Baocao(int tongthu, int tongchi, int thucthu,int lairong,int laigop, DateTime time)
        {
            this.tongthu = tongthu;
            this.thucthu = thucthu;
            this.tongchi = tongchi;
            this.time = time;
            this.Laigop = laigop;
            this.lairong = lairong;
        }
    }
}
