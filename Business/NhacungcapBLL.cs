using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.DataAccessLayer;
namespace Project.Business
{
    class NhacungcapBLL : INhacungcapBLL
    {
        private INhacungcapDAL n = new NhacungcapDAL();
        public void ThemNCC(Nhacungcap a)
        {
            n.Insert(a);
        }
        public void SuaNCC(Nhacungcap newNCC)
        {
            List<Nhacungcap> ds = n.GetAllData();
            for(int i=0;i<ds.Count; i++)
            {
                if (newNCC.Ma == ds[i].Ma)
                {
                    ds[i] = newNCC;
                    n.Update(ds);
                    break;
                }
            }
        }

        public void XoaNCC(string ma)
        {
            List<Nhacungcap> ds = n.GetAllData();
            bool check = false;
            foreach (Nhacungcap a in ds)
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
                n.Update(ds);
            }
            else
                throw new Exception("Mã này hiện không tồn tại");
        }
        public List<Nhacungcap> TimNCC(Nhacungcap ncc)
        {
            List<Nhacungcap> ds = n.GetAllData();
            List<Nhacungcap> result = new List<Nhacungcap>();
            if (ncc.Ma != null && ncc.Ten == null && ncc.Sdt == null && ncc.Diachi == null)
            {
                foreach (Nhacungcap a in ds)
                {
                    if (a.Ma == ncc.Ma)
                    {
                        result.Add(a);
                        break;
                    }
                }
            }
            else if (ncc.Ma == null && ncc.Ten != null && ncc.Sdt == null && ncc.Diachi == null)
            {
                foreach (Nhacungcap a in ds)
                {
                    if (a.Ten.ToLower().Contains(ncc.Ten.ToLower()))
                    {
                        result.Add(a);
                    }
                }

            }
            else if (ncc.Ma == null && ncc.Ten == null && ncc.Sdt != null && ncc.Diachi == null)
            {
                foreach (Nhacungcap a in ds)
                {
                    if (a.Sdt.Contains(ncc.Sdt))
                    {
                        result.Add(a);
                    }
                }

            }
            else if (ncc.Ma == null && ncc.Ten == null && ncc.Sdt == null && ncc.Diachi != null)
            {
                foreach (Nhacungcap a in ds)
                {
                    if (a.Diachi.ToLower().Contains(ncc.Diachi.ToLower()))
                    {
                        result.Add(a);
                    }
                }
            }
            return result;

        }
        public List<Nhacungcap> GetListNCC()
        {
            return n.GetAllData();
        }
        public Nhacungcap GetNCC(string ma)
        {
            List<Nhacungcap> ds = n.GetAllData();
            foreach (Nhacungcap a in ds)
            {
                if (a.Ma == ma)
                {
                    return a;
                }
            }
            throw new Exception("Mã nhà cung cấp hiện không tồn tại");
        }
    }
}
