using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.Utility;
using System.IO;
namespace Project.DataAccessLayer
{
    class HoadonDAL : IHoadonDAL
    {
        private string fileHD = "D:/hoadon.txt";
        public void Insert(Hoadon h)
        {
            StreamWriter w = File.AppendText(fileHD);
            w.WriteLine(h.Mahd + "*" + h.Makh + "*" + h.Tenkh + "*" + h.Manv + "*" + h.Ngayxuat.Month + "/" + h.Ngayxuat.Day + "/" + h.Ngayxuat.Year + "*" + h.Tongtien + "*" + h.Dathanhtoan+"*"+h.Tienlai);
            w.Close();
        }
        public List<Hoadon> GetAllData()
        {
            List<Hoadon> ds = new List<Hoadon>();
            StreamReader r = File.OpenText(fileHD);
            string s = r.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('*');
                    Hoadon b = new Hoadon(a[0], a[1], a[2], a[3], DateTime.Parse(a[4]), int.Parse(a[5]), int.Parse(a[6]),int.Parse(a[7]));
                    ds.Add(b);
                }
                s = r.ReadLine();
            }
            r.Close();
            return ds;
        }
        public void Update(List<Hoadon> ds)
        {
            StreamWriter w = File.CreateText(fileHD);
            foreach (Hoadon h in ds)
            {
                w.WriteLine(h.Mahd + "*" + h.Makh + "*" + h.Tenkh + "*" + h.Manv + "*" + h.Ngayxuat.Month + "/" + h.Ngayxuat.Day + "/" + h.Ngayxuat.Year + "*" + h.Tongtien + "*" + h.Dathanhtoan+"*"+h.Tienlai);
            }
            w.Close();
        }
    }
}
