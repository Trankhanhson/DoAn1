using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using System.IO;
using Project.Utility;
namespace Project.DataAccessLayer
{
    class PhieuchiDAL : IPhieuchiDAL
    {
        private string filePC = "D:/phieuchi.txt";
        public void Insert(Phieuchi pc)
        {
            int Maso = Tool.MaCuoi(filePC) + 1;//Mã chạy tự động mỗi lần lên 1 đơn vị
            string Mapc = "PC" + Maso.ToString();
            StreamWriter w = File.AppendText(filePC);
            w.WriteLine(Mapc + "*" + pc.Sotien + "*" + pc.Thoigian.Month + "/" + pc.Thoigian.Day + "/" + pc.Thoigian.Year + "*" + pc.Ghichu);
            w.Close();
        }
        public List<Phieuchi> GetAllData()
        {
            List<Phieuchi> ds = new List<Phieuchi>();
            StreamReader r = new StreamReader(filePC);
            string s = r.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('*');
                    Phieuchi k = new Phieuchi(a[0], int.Parse(a[1]), DateTime.Parse(a[2]), a[3]);
                    ds.Add(k);
                }
                s = r.ReadLine();
            }
            r.Close();
            return ds;
        }
        public void Update(List<Phieuchi> ds)
        {
            StreamWriter w = File.CreateText(filePC);
            foreach (Phieuchi pc in ds)
            {
                w.WriteLine(pc.Maphieu + "*" + pc.Sotien + "*" + pc.Thoigian.Month + "/" + pc.Thoigian.Day + "/" + pc.Thoigian.Year + "*" + pc.Ghichu);
            }
            w.Close();
        }
    }
}
