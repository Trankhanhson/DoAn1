using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.Utility;
using System.IO;
namespace Project.DataAccessLayer
{
    class KhachhangDAL : IKhachhangDAL
    {
        private string fileKH = "D:/khachhang.txt";
        public void Insert(Khachhang kh)
        {
            int Maso = Tool.MaCuoi(fileKH) + 1;//Mã chạy tự động mỗi lần lên 1 đơn vị
            string Makh = "KH" + Maso;
            StreamWriter w = File.AppendText(fileKH);
            w.WriteLine(Makh + "*" + kh.Ten + "*" + kh.Diachi + "*" + kh.Sdt + "*" + kh.Gioitinh + "*" + kh.Ngaysinh.Month + "/" + kh.Ngaysinh.Day + "/" + kh.Ngaysinh.Year+"*"+kh.Congno);
            w.Close();
        }
        public List<Khachhang> GetAllData()
        {
            List<Khachhang> ds = new List<Khachhang>();
            StreamReader r = new StreamReader(fileKH);
            string s = r.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('*');
                    Khachhang k = new Khachhang(a[0], a[1], a[2], a[3], a[4], DateTime.Parse(a[5]),int.Parse(a[6]));
                    ds.Add(k);                   
                }
                s = r.ReadLine();
            }
            r.Close();
            return ds;
        }
        public void Update(List<Khachhang> ds)
        {
            StreamWriter w = File.CreateText(fileKH);
            foreach (Khachhang n in ds)
            {
                w.WriteLine(n.Ma + "*" + n.Ten + "*" + n.Diachi + "*" + n.Sdt + "*" + n.Gioitinh + "*" + n.Ngaysinh.Month + "/" + n.Ngaysinh.Day + "/" + n.Ngaysinh.Year + "*" + n.Congno);
            }
            w.Close();
        }
    }
}
