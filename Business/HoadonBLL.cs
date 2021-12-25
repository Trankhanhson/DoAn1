using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.Utility;
using Project.DataAccessLayer;
using System.IO;
namespace Project.Business
{
    class HoadonBLL : IHoadonBLL
    {
        private IHoadonDAL hoadon = new HoadonDAL();
        private IKhachhangBLL khachhang = new KhachhangBLL();//dùng để thêm công nợ

        public List<Hoadon> GetListHD()
        {
            return hoadon.GetAllData();
        }

        public void ThemHD(Hoadon h)
        {
            hoadon.Insert(h);

            //thêm nợ khách hàng
            int no = h.Tongtien - h.Dathanhtoan;
            if (no>0)
            {
                khachhang.ThemCongno(h.Makh, no);
            }
        }

        

        public Hoadon GetHD(string ma)
        {
            List<Hoadon> ds = hoadon.GetAllData();
            foreach (Hoadon a in ds)
            {
                if (a.Mahd == ma)
                {
                    return a;
                }
            }
            throw new Exception("Hóa đơn này không tồn tại");
        }

        public void SuaHD(Hoadon hd)
        {
            int thanhtoanthem=0;

            List<Hoadon> ds = hoadon.GetAllData();
            for (int i = 0; i < ds.Count; i++)
            {
                if (hd.Mahd == ds[i].Mahd)
                {
                    thanhtoanthem = hd.Dathanhtoan - ds[i].Dathanhtoan;
                    ds[i] = hd;
                    hoadon.Update(ds);
                    break;
                }
            }

            //cập nhật tiền kacsh mới hanh toán thêm
            if (thanhtoanthem > 0)
            {
                khachhang.TruCongno(hd.Makh, thanhtoanthem);
            }
        }

        public List<Hoadon> TimHD(Hoadon h)
        {
            List<Hoadon> ds = hoadon.GetAllData();
            List<Hoadon> result = new List<Hoadon>();
            
            DateTime defaultTime = new DateTime(1, 1, 0001);//nếu không nhập thì Datetime có giá trị mặc định là 1/1/0001

            if (h.Mahd != null && h.Manv == null && h.Tenkh == null && h.Ngayxuat == defaultTime)
            {
                foreach (Hoadon a in ds)
                {
                    if (a.Mahd == h.Mahd)
                    {
                        result.Add(a);
                        break;
                    }
                }
            }
            else if (h.Mahd == null && h.Manv != null && h.Tenkh == null && h.Ngayxuat != defaultTime)
            {
                foreach (Hoadon a in ds)
                {
                    if (a.Manv == h.Manv && h.Ngayxuat.Month==a.Ngayxuat.Month && h.Ngayxuat.Year==a.Ngayxuat.Year)
                    {
                        result.Add(a);
                    }
                }
            }
            else if (h.Mahd == null && h.Manv == null && h.Tenkh != null && h.Ngayxuat == defaultTime)
            {
                foreach (Hoadon a in ds)
                {
                    if (a.Tenkh.ToLower().Contains(h.Tenkh.ToLower()))
                    {
                        result.Add(a);
                    }
                }
            }
            else if (h.Mahd == null && h.Manv == null && h.Tenkh == null && h.Ngayxuat != defaultTime)
            {
                foreach (Hoadon a in ds)
                {
                    if (a.Ngayxuat == h.Ngayxuat)
                    {
                        result.Add(a);
                    }
                }
            }
            
            return result;
        }

        public void XoaHD(string mahd)
        {
            List<Hoadon> ds = hoadon.GetAllData();
            bool check = true;
            foreach (Hoadon a in ds)
            {
                if (a.Mahd == mahd)
                {
                    if (a.Tongtien == a.Dathanhtoan)
                    {
                        ds.Remove(a);
                        hoadon.Update(ds);
                        check = false;
                        break;
                    }
                    else
                    {
                        throw new Exception("Không thể xóa vì hóa đơn này chưa thanh toán");
                    }
                }
            }
            if (check)
            {
                throw new Exception("Hóa đơn này không tồn tại");
            }
        }

        //Tính tổng tiền của hóa đơn
        public int TongTienBill(List<CTHoadon> ds)
        {
            int sum = 0;//biến cộng dồn để tìm tổng tiền của bill
            foreach (CTHoadon b in ds)
            {
                sum += b.Tongtien;
            }
            return sum;
        }
       

        public List<Hoadon> GetHDChuaThanhToan(string makh)
        {
            List<Hoadon> ds = hoadon.GetAllData();
            List<Hoadon> result = new List<Hoadon>();
            foreach (Hoadon a in ds)
            {
                if (a.Makh == makh && a.Tongtien > a.Dathanhtoan)
                {
                    result.Add(a);
                }
            }
            return result;
        }//sử dụng ở công nợ


    }
}
