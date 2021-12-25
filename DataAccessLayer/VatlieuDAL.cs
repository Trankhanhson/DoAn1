using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using System.IO;
using Project.Utility;
namespace Project.DataAccessLayer
{
    class VatlieuDAL : IVatlieuDAL
    {
        private string file = "D:/vatlieu.txt";
        public List<Vatlieu> GetAllData()
        {
            List<Vatlieu> ds = new List<Vatlieu>();

            StreamReader r = new StreamReader(file);
            string s = r.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('*');

                    Vatlieu v = new Vatlieu(a[0], a[1], a[2], int.Parse(a[3]), int.Parse(a[4]), int.Parse(a[5]),int.Parse(a[6]));
                    ds.Add(v);
                }
                s = r.ReadLine();
            }
            r.Close();
            return ds;
        }
        public void Insert(Vatlieu vl)
        {
            int Soma = Tool.MaCuoi(file) + 1;//Mã chạy tự động mỗi lần lên 1 đơn vị
            string Mavl = "VL" + Soma.ToString();
            StreamWriter w = File.AppendText(file);
            w.WriteLine(Mavl + "*" + vl.Ten  + "*" + vl.Donvitinh + "*" + vl.Gianhap + "*" + vl.Giaban + "*" + vl.Soluong+"*"+vl.Mucnhaphang);
            w.Close();
        }
        public void Update(List<Vatlieu> ds)
        {
            StreamWriter w = File.CreateText(file);
            foreach (Vatlieu vl in ds)
            {
                w.WriteLine(vl.Ma + "*" + vl.Ten + "*" + vl.Donvitinh + "*" + vl.Gianhap + "*" + vl.Giaban + "*" + vl.Soluong + "*" + vl.Mucnhaphang);
            }
            w.Close();
        }
    }
}
