using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.DataAccessLayer;
namespace Project.Business
{
    class HDNhapBLL : IHDNhapBLL
    {
        private HDNhapDAL hoadonnhap = new HDNhapDAL();
        public void ThemHDN(HDNhap hdn)
        {
            hoadonnhap.Insert(hdn);           

        }
        public void SuaHDN(HDNhap hdn)
        {
            List<HDNhap> ds = hoadonnhap.GetAllData();
            for (int i = 0; i < ds.Count; i++)
            {
                if (hdn.Mahdn == ds[i].Mahdn)
                {
                    ds[i] = hdn;
                    hoadonnhap.Update(ds);
                    break;
                }
            }
        }
        public List<HDNhap> TimHDN(HDNhap hdn)
        {
            List<HDNhap> ds = hoadonnhap.GetAllData();
            List<HDNhap> result = new List<HDNhap>();
            DateTime defaultTime = new DateTime(1, 1, 0001);//nếu không nhập thì Datetime có giá trị mặc định là 1/1/0001
            if (hdn.Mahdn!=null && hdn.Tenncc == null && hdn.Ngaynhap == defaultTime)
            {
                foreach (HDNhap a in ds)
                {
                    if (a.Mahdn==hdn.Mahdn)
                    {
                        result.Add(a);
                        break;
                    }
                }
            }
            else if (hdn.Tenncc != null && hdn.Ngaynhap == defaultTime)
            {
                foreach (HDNhap a in ds)
                {
                    if (a.Tenncc.Contains(hdn.Tenncc))
                    {
                        result.Add(a);
                    }
                }
            }

            else if (hdn.Ngaynhap != defaultTime && hdn.Tenncc == null)
            {
                foreach (HDNhap a in ds)
                {
                    if (a.Ngaynhap == hdn.Ngaynhap)
                    {
                        result.Add(a);
                    }
                }
            }
            return result;
        }

        public List<HDNhap> GetListHDN()
        {
            return hoadonnhap.GetAllData();
        }

        public HDNhap GetHDN(string mahdn)
        {
            List<HDNhap> ds = hoadonnhap.GetAllData();
            foreach(HDNhap a in ds)
            {
                if(a.Mahdn == mahdn)
                {
                    return a;
                }
            }
            throw new Exception("Hóa đơn nhập hàng này không tồn tại");
        }
        public void XoaHDN(string mahdn)
        {
            List<HDNhap> ds = hoadonnhap.GetAllData();
            bool check = true;
            foreach (HDNhap a in ds)
            {
                if (a.Mahdn == mahdn)
                {
                    ds.Remove(a);
                    hoadonnhap.Update(ds);
                    check = false;
                    break;
                }
            }
            if (check)
            {
                throw new Exception("Hóa đơn này không tồn tại");
            }
        }

        public int TongTienHDN(List<CTNhaphang> ds)
        {
            int sum = 0;//biến cộng dồn để tìm tổng tiền của bill
            foreach (CTNhaphang b in ds)
            {
                sum += b.Tongtien;
            }
            return sum;
        }
    }
}
