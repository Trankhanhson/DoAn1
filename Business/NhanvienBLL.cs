using System;
using System.Collections.Generic;
using System.Text;
using Project.DataAccessLayer;
using Project.Entities;
namespace Project.Business
{
    class NhanvienBLL : INhanvienBLL
    {
        private INhanVienDAL nv = new NhanVienDAL();

        public void ThemNV(Nhanvien v)
        {
            nv.Insert(v);
        }

        public void SuaNV(Nhanvien v)
        {
            List<Nhanvien> ds = nv.GetAllData();
            for(int i=0; i<ds.Count; i++)
            {
                if (v.Ma == ds[i].Ma)
                {
                    ds[i] = v;
                    nv.Update(ds);
                    break;
                }
            }
        }

        public void XoaNV(string ma)
        {
            List<Nhanvien> ds = nv.GetAllData();
            bool check = false;
            foreach (Nhanvien a in ds)
            {
                if (a.Ma == ma)
                {
                    ds.Remove(a);
                    check = true;
                    break;
                }
            }
            if (check)
            {
                nv.Update(ds);
            }
            else
                throw new Exception("Mã này hiện không tồn tại");
        }

        public List<Nhanvien> TimNV(Nhanvien v)
        {
            List<Nhanvien> ds = nv.GetAllData();
            List<Nhanvien> result = new List<Nhanvien>();
            if (v.Ma != null && v.Ten == null && v.Sdt == null && v.Diachi == null)
            {
                foreach (Nhanvien a in ds)
                {
                    if (a.Ma == v.Ma)
                    {
                        result.Add(a);
                        break;
                    }
                }
            }
            else if (v.Ma == null && v.Ten != null && v.Sdt == null && v.Diachi == null)
            {
                foreach (Nhanvien a in ds)
                {
                    if (a.Ten.ToLower().Contains(v.Ten.ToLower()))
                    {
                        result.Add(a);
                    }
                }

            }
            else if (v.Ma == null && v.Ten == null && v.Sdt != null && v.Diachi == null)
            {
                foreach (Nhanvien a in ds)
                {
                    if (a.Sdt.Contains(v.Sdt))
                    {
                        result.Add(a);
                    }
                }

            }
            else if (v.Ma == null && v.Ten == null && v.Sdt == null && v.Diachi != null)
            {
                foreach (Nhanvien a in ds)
                {
                    if (a.Diachi.ToLower().Contains(v.Diachi.ToLower()))
                    {
                        result.Add(a);
                    }
                }
            }
            return result;
        }

        public List<Nhanvien> GetListNV()
        {
            return nv.GetAllData();
        }

        public Nhanvien GetNV(string ma)
        {
            List<Nhanvien> ds = nv.GetAllData();
            foreach (Nhanvien a in ds)
            {
                if (a.Ma == ma)
                {
                    return a;
                }
            }
            throw new Exception("Nhân viên này không tồn tại");
        }
    }
}
