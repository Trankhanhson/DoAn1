using System;
using System.Collections.Generic;
using System.Text;
using Project.DataAccessLayer;
namespace Project.Business
{
    interface ILibraryCheck
    {
        bool CheckListNCC(string tenncc);//kiểm tra tên khách hàng
        bool CheckListVL(string mavl);//kiểm tra mã vật liệu
        bool CheckListKH(string makh);//kiểm tra mã khách hàng
        bool CheckListNV(string manv);//kiểm tra mã nhân viên
        bool CheckListHD(string mahd);//kiểm tra mã hóa đơn
        bool CheckKHNo(string makh);
    }
}
