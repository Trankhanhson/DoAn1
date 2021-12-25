using System;
using System.Collections.Generic;
using System.Text;
using Project.DataAccessLayer;
using Project.Entities;
namespace Project.Business
{
    class LibraryCheck : ILibraryCheck
    {
        private IKhachhangDAL kh = new KhachhangDAL();
        private IVatlieuDAL vl = new VatlieuDAL();
        private INhacungcapDAL ncc = new NhacungcapDAL();
        private INhanVienDAL nv = new NhanVienDAL();
        private IHoadonDAL hd = new HoadonDAL();
        private IHDNhapDAL hdn = new HDNhapDAL();

        public bool CheckListNCC(string tenncc)
        {          
            foreach (Nhacungcap a in ncc.GetAllData())
            {
                if (a.Ten.ToLower() == tenncc.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckListVL(string mavl)
        {
            
            foreach (Vatlieu a in vl.GetAllData())
            {
                if (a.Ma == mavl)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckListKH(string makh)
        {

            foreach (Khachhang a in kh.GetAllData())
            {
                if (a.Ma == makh)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// true là khách còn nợ false thì ngược lại
        /// </summary>
        /// <param name="makh"></param>
        /// <returns></returns>
        public bool CheckKHNo(string makh)
        {
            foreach(Hoadon a in hd.GetAllData())
            {
                if(a.Makh==makh && a.Tongtien > a.Dathanhtoan)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckListNV(string manv)
        {
            
            foreach (Nhanvien a in nv.GetAllData())
            {
                if (a.Ma == manv)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckListHD(string mahd)
        {
            
            foreach (Hoadon a in hd.GetAllData())
            {
                if (a.Mahd == mahd)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckListHDN(string mahdn)
        {
            
            foreach (HDNhap a in hdn.GetAllData())
            {
                if (a.Mahdn == mahdn)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
