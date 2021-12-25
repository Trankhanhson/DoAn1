using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using System.IO;

namespace Project.DataAccessLayer
{
    class CTHoadonDAL : ICTHoadonDAL
    {
        private string fileCTHD = "D:/cthoadon.txt";
        public void Insert(CTHoadon c)
        {
            StreamWriter w = File.AppendText(fileCTHD);
            w.WriteLine(c.Mahd + "*" + c.Mavl + "*" + c.Soluong + "*" + c.Tongtien);
            w.Close();
        }
        public List<CTHoadon> GetAllData()
        {
            List<CTHoadon> ds = new List<CTHoadon>();
            StreamReader r = File.OpenText(fileCTHD);
            string s = r.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('*');
                    CTHoadon b = new CTHoadon(a[0], a[1], int.Parse(a[2]), int.Parse(a[3]));
                    ds.Add(b);
                }
                s = r.ReadLine();
            }
            r.Close();
            return ds;
        }
        public void Update(List<CTHoadon> ds)
        {
            StreamWriter w = File.CreateText(fileCTHD);
            foreach (CTHoadon a in ds)
            {
                if (a != null)
                {
                    w.WriteLine(a.Mahd + "*" + a.Mavl + "*" + a.Soluong + "*" + a.Tongtien);
                }
            }
            w.Close();
        }
    }
}
