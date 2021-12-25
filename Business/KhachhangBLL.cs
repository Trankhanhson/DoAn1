using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.Utility;
using Project.DataAccessLayer;
namespace Project.Business
{
    class KhachhangBLL : IKhachhangBLL
    {
        private IKhachhangDAL kh = new KhachhangDAL();
        private IHoadonDAL hoadon = new HoadonDAL();

        public void ThemKH(Khachhang k)
        {
            kh.Insert(k);
        }

        public void SuaKH(Khachhang v)
        {
            List<Khachhang> ds = kh.GetAllData();
            for (int i = 0; i < ds.Count; i++)
            {
                if (v.Ma == ds[i].Ma)
                {
                    ds[i] = v;
                    kh.Update(ds);
                    break;
                }
            }
        }

        public void ThemCongno(string ma,int no)
        {
            List<Khachhang> ds = kh.GetAllData();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ma == ds[i].Ma)
                {
                    ds[i].Congno += no;
                    kh.Update(ds);
                    break;
                }
            }
        }

        public void TruCongno(string ma, int thanhtoanthem)
        {
            List<Khachhang> ds=kh.GetAllData();
            foreach (Khachhang k in ds)
            {
                if(k.Ma == ma)
                {
                    k.Congno = k.Congno - thanhtoanthem;
                    kh.Update(ds);
                    break;
                }
            }
        }

        public void XoaKH(string ma)
        {
            List<Khachhang> ds = kh.GetAllData();
            bool check = false;
            foreach (Khachhang a in ds)
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
                kh.Update(ds);
            }
            else
                throw new Exception("Mã này hiện không tồn tại");
        }

        public List<Khachhang> TimKH(Khachhang v)
        {
            List<Khachhang> ds = kh.GetAllData();
            List<Khachhang> result = new List<Khachhang>();
            if (v.Ma != null && v.Ten == null && v.Sdt == null && v.Diachi == null)
            {
                foreach (Khachhang a in ds)
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
                foreach (Khachhang a in ds)
                {
                    if (a.Ten.ToLower().Contains(v.Ten.ToLower()))
                    {
                        result.Add(a);
                    }
                }

            }
            else if (v.Ma == null && v.Ten == null && v.Sdt != null && v.Diachi == null)
            {
                foreach (Khachhang a in ds)
                {
                    if (a.Sdt==v.Sdt)
                    {
                        result.Add(a);
                        break;
                    }
                }

            }
            else if (v.Ma == null && v.Ten == null && v.Sdt == null && v.Diachi != null)
            {
                foreach (Khachhang a in ds)
                {
                    if (a.Diachi == v.Diachi)
                    {
                        result.Add(a);
                    }
                }
            }            
            return result;
        }


        public List<Khachhang> GetListKH()
        {
            return kh.GetAllData();
        }

        public Khachhang GetKH(string ma)
        {
            List<Khachhang> ds = kh.GetAllData();
            foreach (Khachhang a in ds)
            {
                if (a.Ma == ma)
                {
                    return a;
                }
            }
            throw new Exception("Khách hàng này không tồn tại");
        }

        public Khachhang GetKHSdt(string sdt)
        {
            List<Khachhang> ds = kh.GetAllData();
            foreach (Khachhang a in ds)
            {
                if (a.Sdt==sdt)
                {
                    return a;
                }
            }
            throw new Exception("Khách hàng này không tồn tại");
        }

        public List<Khachhang> GetKHNo()
        {
            List<Khachhang> khachhangs = kh.GetAllData();
            List<Khachhang> result=new List<Khachhang>();
            foreach (Khachhang k in khachhangs)
            {
                if (k.Congno > 0)
                {
                    result.Add(k);
                }
            }
            return (result);
        }

        public List<Hoadon> Thanhtoan(string ma, int thanhtoanthem)
        {
            List<Hoadon> dshd = hoadon.GetAllData();
            List<Khachhang> dskh=kh.GetAllData();
            //update tiền thanh toán thêm vào công nợ
            if (thanhtoanthem > 0)
            {
                foreach (Khachhang c in dskh)
                {
                    if (c.Ma == ma || c.Sdt==ma)
                    {
                        c.Congno = c.Congno - thanhtoanthem;
                        break;
                    }
                }
                kh.Update(dskh);
            }


            //Cộng thêm tiền đã thanh toán vào các hóa đơn nợ của khách
            List<Hoadon> tmp = new List<Hoadon>();
            int no;
            foreach (Hoadon a in dshd)
            {
                
                if (a.Makh == ma)
                {
                    no = a.Tongtien - a.Dathanhtoan;
                    if (no > 0)
                    {
                        if (thanhtoanthem > no)//trường hợp thanh toán thêm lớn hơn nợ của 1 hóa đơn
                        {
                            a.Dathanhtoan = a.Tongtien;
                            thanhtoanthem = thanhtoanthem - no;
                            tmp.Add(a);

                        }
                        else //trường hợp thanhtoanthem <= no thì cộng luôn vào dathanhtoan
                        {
                            a.Dathanhtoan = a.Dathanhtoan + thanhtoanthem;
                            tmp.Add(a);
                            break;
                        }
                    }
                }
            }
            hoadon.Update(dshd);

            return tmp;
        }
    }
}
