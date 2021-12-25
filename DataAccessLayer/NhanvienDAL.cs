using System;
using System.Collections.Generic;
using System.Text;
using Project.Utility;
using System.IO;
using Project.Entities;
namespace Project.DataAccessLayer
{
    class NhanVienDAL : INhanVienDAL
    {
        private string fileNV = "D:/nhanvien.txt";
        public void Insert(Nhanvien nv)
        {
            int Maso = Tool.MaCuoi(fileNV) + 1;//Mã chạy tự động mỗi lần lên 1 đơn vị
            string Manv = "NV" + Maso;
            StreamWriter w = File.AppendText(fileNV);
            w.WriteLine(Manv + "*" + nv.Ten + "*" + nv.Diachi + "*" + nv.Sdt + "*" + nv.Gioitinh + "*" + nv.Ngaysinh.Month + "/" + nv.Ngaysinh.Day + "/" + nv.Ngaysinh.Year + "*" + 0);
            w.Close();
        }
        public List<Nhanvien> GetAllData()
        {
            List<Nhanvien> ds = new List<Nhanvien>();
            StreamReader r = new StreamReader(fileNV);
            string s = r.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('*');
                    Nhanvien n = new Nhanvien(a[0], a[1], a[2], a[3], a[4], DateTime.Parse(a[5]), int.Parse(a[6]));
                    ds.Add(n);
                    s = r.ReadLine();
                }
            }
            r.Close();
            return ds;
        }
        public void Update(List<Nhanvien> ds)
        {
            StreamWriter w = File.CreateText(fileNV);
            foreach (Nhanvien n in ds)
            {
                w.WriteLine(n.Ma + "*" + n.Ten + "*" + n.Diachi + "*" + n.Sdt + "*" + n.Gioitinh + "*" + n.Ngaysinh.Month + "/" + n.Ngaysinh.Day + "/" + n.Ngaysinh.Year + "*" + n.Ngaycong);
            }
            w.Close();
        }
    }
}
