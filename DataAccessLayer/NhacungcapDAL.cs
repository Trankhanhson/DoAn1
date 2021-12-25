using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using System.IO;
using Project.Utility;
namespace Project.DataAccessLayer
{
    class NhacungcapDAL : INhacungcapDAL
    {
        private string fileNCC = "D:/nhacungcap.txt";
        public void Insert(Nhacungcap ncc)
        {
            int Maso = Tool.MaCuoi(fileNCC) + 1;//Mã chạy tự động mỗi lần lên 1 đơn vị
            string Mancc = "NC" + Maso.ToString();
            StreamWriter w = File.AppendText(fileNCC);
            w.WriteLine(Mancc + "*" + ncc.Ten + "*" + ncc.Diachi + "*" + ncc.Sdt);
            w.Close();
        }
        public List<Nhacungcap> GetAllData()
        {
            List<Nhacungcap> ds = new List<Nhacungcap>();
            StreamReader r = new StreamReader(fileNCC);
            string s = r.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('*');
                    Nhacungcap n = new Nhacungcap(a[0], a[1], a[2], a[3]);
                    ds.Add(n);
                    s = r.ReadLine();
                }
            }
            r.Close();
            return ds;
        }
        public void Update(List<Nhacungcap> ds)
        {
            StreamWriter w = File.CreateText(fileNCC);
            foreach (Nhacungcap n in ds)
            {
                w.WriteLine(n.Ma + "*" + n.Ten + "*" + n.Diachi + "*" + n.Sdt);
            }
            w.Close();
        }
    }
}
