using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Project.Entities;
namespace Project.DataAccessLayer
{
    class HDNhapDAL : IHDNhapDAL
    {
        private string fileHDN = "D:/nhaphang.txt";
        public void Insert(HDNhap h)
        {
            StreamWriter w = File.AppendText(fileHDN);
            w.WriteLine(h.Mahdn + "*" + h.Tenncc + "*" + h.Ngaynhap.Month + "/" + h.Ngaynhap.Day + "/" + h.Ngaynhap.Year + "*" + h.Tongtien);
            w.Close();
        }
        public List<HDNhap> GetAllData()
        {
            List<HDNhap> ds = new List<HDNhap>();
            StreamReader r = File.OpenText(fileHDN);
            string s = r.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('*');
                    HDNhap b = new HDNhap(a[0], a[1], DateTime.Parse(a[2]), int.Parse(a[3]));
                    ds.Add(b);
                }
                s = r.ReadLine();
            }
            r.Close();
            return ds;
        }
        public void Update(List<HDNhap> ds)
        {
            StreamWriter w = File.CreateText(fileHDN);
            foreach (HDNhap h in ds)
            {
                w.WriteLine(h.Mahdn + "*" + h.Tenncc + "*" + h.Ngaynhap.Month + "/" + h.Ngaynhap.Day + "/" + h.Ngaynhap.Year + "*" + h.Tongtien);
            }
            w.Close();
        }
    }
}
