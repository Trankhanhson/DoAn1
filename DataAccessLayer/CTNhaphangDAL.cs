using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using System.IO;
namespace Project.DataAccessLayer
{
    class CTNhaphangDAL : ICTNhaphangDAL
    {
        private string fileCTNH = "D:/ctnhaphang.txt";
        public void Insert(CTNhaphang c)
        {
            StreamWriter w = File.AppendText(fileCTNH);
            w.WriteLine(c.Mahdn + "*" + c.Mavl + "*" + c.Soluong + "*" + c.Gianhap + "*" + c.Tongtien);
            w.Close();
        }
        public List<CTNhaphang> GetAllData()
        {
            List<CTNhaphang> ds = new List<CTNhaphang>();
            StreamReader r = File.OpenText(fileCTNH);
            string s = r.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('*');
                    CTNhaphang b = new CTNhaphang(a[0], a[1], int.Parse(a[2]), int.Parse(a[3]), int.Parse(a[4]));
                    ds.Add(b);
                }
                s = r.ReadLine();
            }
            r.Close();
            return ds;
        }
        public void Update(List<CTNhaphang> ds)
        {
            StreamWriter w = File.CreateText(fileCTNH);
            foreach (CTNhaphang a in ds)
            {
                if (a != null)
                {
                    w.WriteLine(a.Mahdn + "*" + a.Mavl + "*" + a.Soluong + "*" + a.Gianhap + "*" + a.Tongtien);
                }
            }
            w.Close();
        }
    }
}
