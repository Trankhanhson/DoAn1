using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Presentation
{
    class Menu
    {
        public void ChonMenuVL()
        {
            FormVatlieu vl = new FormVatlieu();
            while (true)
            {
                Console.WriteLine(@$"  ╔════════════════════════════════════════════════════════╗
  ║                   QUẢN LÝ VẬT LIỆU                     ║
  ║════════════════════════════════════════════════════════║
  ║ 1. THÊM VẬT LIỆU MỚI                                   ║
  ║════════════════════════════════════════════════════════║
  ║ 2. SỬA VẬT LIỆU                                        ║
  ║════════════════════════════════════════════════════════║
  ║ 3. XÓA VẬT LIỆU                                        ║
  ║════════════════════════════════════════════════════════║
  ║ 4. TÌM KIẾM VẬT LIỆU                                   ║
  ║════════════════════════════════════════════════════════║
  ║ 5. TÌM KIẾM THEO KHOẢNG GIÁ                            ║
  ║════════════════════════════════════════════════════════║
  ║ 6. VẬT LIỆU CẦN NHẬP THÊM                              ║
  ║════════════════════════════════════════════════════════║
  ║ 7. QUAY VỀ TRANG TRƯỚC                                 ║
  ║════════════════════════════════════════════════════════║
  ║ MỜI CHỌN CHỨC NĂNG:                                    ║
  ╚════════════════════════════════════════════════════════╝");

                Console.SetCursorPosition(0,21);vl.Hien();
                int checkVL;
                do
                {
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 17);
                            checkVL = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    
                    switch (checkVL)
                    {
                        case 1:
                            Console.Clear();
                            vl.Them();
                            break;
                        case 2:
                            Console.Clear();
                            vl.Sua();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            vl.Xoa();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            vl.TimVL();
                            break;
                        case 5:
                            Console.Clear();
                            vl.TimGia();
                            break;
                        case 6:
                            Console.Clear();
                            vl.VLCannhap();
                            break;
                        case 7:
                            Console.Clear();
                            break;
                    }
                } while (checkVL < 1 || checkVL > 7);
                if (checkVL == 7)
                {
                    break;
                }
            }
        }

        public void ChonMenuNCC()
        {
            FormNCC ncc = new FormNCC();
            while (true)
            {
                Console.WriteLine(@$" ╔════════════════════════════════════════════════════════╗
 ║                 QUẢN LÝ NHÀ CUNG CẤP                   ║
 ║════════════════════════════════════════════════════════║
 ║ 1. THÊM NHÂN NHÀ CUNG CẤP MỚI                          ║
 ║════════════════════════════════════════════════════════║
 ║ 2. SỬA THÔNG TIN NHÀ CUNG CẤP                          ║
 ║════════════════════════════════════════════════════════║
 ║ 3. XÓA THÔNG TIN NHÀ CUNG CẤP                          ║
 ║════════════════════════════════════════════════════════║
 ║ 4. TÌM KIẾM THÔNG TIN NHÀ CUNG CẤP                     ║
 ║════════════════════════════════════════════════════════║
 ║ 5. QUAY VỀ TRANG TRƯỚC                                 ║
 ║════════════════════════════════════════════════════════║
 ║ MỜI CHỌN CHỨC NĂNG:                                    ║
 ╚════════════════════════════════════════════════════════╝");
                int checkNCC;
                Console.SetCursorPosition(0, 17); ncc.Hien();
                do
                {
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 13);
                            checkNCC = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    

                    switch (checkNCC)
                    {
                        case 1:
                            Console.Clear();
                            ncc.Them();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            ncc.Sua();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            ncc.Xoa();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            ncc.Tim();                            
                            Console.Clear();
                            break;

                        case 5:
                            Console.Clear();

                            break;
                    }

                } while (checkNCC < 1 || checkNCC > 5);
                if (checkNCC == 5)
                {
                    break;
                }
            }
        }

        public void ChonMenuNhapHang()
        {
            FormHDNhap hdn = new FormHDNhap();
            while (true)
            {
                Console.WriteLine(@$"  ╔════════════════════════════════════════════════════════╗
  ║                       NHẬP HÀNG                        ║
  ║════════════════════════════════════════════════════════║
  ║ 1. THÊM PHIẾU NHẬP HÀNG MỚI                            ║
  ║════════════════════════════════════════════════════════║
  ║ 2. XÓA PHIẾU NHẬP HÀNG                                 ║                                     
  ║════════════════════════════════════════════════════════║
  ║ 3. TÌM KIẾM THÔNG TIN PHIẾU NHẬP                       ║
  ║════════════════════════════════════════════════════════║
  ║ 4. QUAY VỀ TRANG TRƯỚC                                 ║
  ║════════════════════════════════════════════════════════║
  ║ MỜI CHỌN CHỨC NĂNG:                                    ║
  ╚════════════════════════════════════════════════════════╝                                     ");
                int checkHD;
                Console.SetCursorPosition(0, 15); hdn.Hien();
                do
                {
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 11);
                            checkHD = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    

                    switch (checkHD)
                    {
                        case 1:
                            Console.Clear();
                            hdn.Them();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            hdn.Xoa();                            
                            break;
                        case 3:
                            Console.Clear();
                            hdn.Tim();                           
                            break;

                        case 4:
                            Console.Clear();
                            break;
                    }
                } while (checkHD < 1 || checkHD > 4);
                if (checkHD == 4)
                {
                    break;
                }
            }
        }

        public void ChonMenuHD()
        {
            FormHoadon hd = new FormHoadon();
            while (true)
            {
                Console.WriteLine(@$"  ╔════════════════════════════════════════════════════════╗
  ║                       BÁN HÀNG                         ║
  ║════════════════════════════════════════════════════════║
  ║ 1. THÊM HÓA ĐƠN MỚI                                    ║
  ║════════════════════════════════════════════════════════║
  ║ 2. HỦY HÓA ĐƠN                                         ║ 
  ║════════════════════════════════════════════════════════║
  ║ 3. SỬA HÓA ĐƠN                                         ║
  ║════════════════════════════════════════════════════════║
  ║ 4. TÌM KIẾM THÔNG TIN HÓA ĐƠN                          ║
  ║════════════════════════════════════════════════════════║
  ║ 5. QUAY VỀ TRANG TRƯỚC                                 ║
  ║════════════════════════════════════════════════════════║
  ║ MỜI CHỌN CHỨC NĂNG:                                    ║
  ╚════════════════════════════════════════════════════════╝");
                int checkHD;
                Console.SetCursorPosition(0, 17); hd.Hien();
                do
                {
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 13);
                            checkHD = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    

                    switch (checkHD)
                    {
                        case 1:
                            Console.Clear();
                            hd.Them();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            hd.Xoa();
                            
                            break;
                        case 3:
                            Console.Clear();
                            hd.Sua();
                            break;
                        case 4:
                            Console.Clear();
                            hd.Tim();                           
                            break;

                        case 5:
                            Console.Clear();
                            break;
                    }
                } while (checkHD < 1 || checkHD > 5);
                if (checkHD == 5)
                {
                    break;
                }
            }
        }

        public void ChonMenuPhieuChi()
        {
            FormPhieuchi phieuchi = new FormPhieuchi();
            while (true)
            {

                Console.WriteLine(@$"  ╔════════════════════════════════════════════════════════╗
  ║                   QUẢN LÝ PHIẾU CHI                    ║
  ║════════════════════════════════════════════════════════║
  ║ 1. THÊM PHIẾU CHI MỚI                                  ║
  ║════════════════════════════════════════════════════════║
  ║ 2. CẬP NHẬT PHIẾU CHI                                  ║
  ║════════════════════════════════════════════════════════║
  ║ 3. XÓA THÔNG TIN PHIẾU CHI                             ║
  ║════════════════════════════════════════════════════════║
  ║ 4. TÌM KIẾM THÔNG TIN PHIẾU CHI                        ║
  ║════════════════════════════════════════════════════════║
  ║ 5. QUAY VỀ TRANG TRƯỚC                                 ║
  ║════════════════════════════════════════════════════════║
  ║ MỜI CHỌN CHỨC NĂNG:                                    ║
  ╚════════════════════════════════════════════════════════╝");
                int checkHD;
                Console.SetCursorPosition(0, 17); phieuchi.Hien();
                do
                {
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 13);
                            checkHD = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
          

                    switch (checkHD)
                    {
                        case 1:
                            Console.Clear();
                            phieuchi.Them();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            phieuchi.Sua();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            phieuchi.Xoa();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            phieuchi.Tim();                            
                            break;

                        case 5:
                            Console.Clear();
                            break;
                    }
                } while (checkHD < 1 || checkHD > 5);
                if (checkHD == 5)
                {
                    break;
                }
            }
        }

        public void ChonMenuKH()
        {
            FormKH kh = new FormKH();
            while (true)
            {

                Console.WriteLine(@$"  ╔════════════════════════════════════════════════════════╗
  ║                   QUẢN LÝ KHÁCH HÀNG                   ║
  ║════════════════════════════════════════════════════════║
  ║ 1. THÊM KHÁCH HÀNG MỚI                                 ║
  ║════════════════════════════════════════════════════════║
  ║ 2. SỬA THÔNG TIN KHÁCH HÀNG                            ║
  ║════════════════════════════════════════════════════════║
  ║ 3. XÓA THÔNG TIN KHÁCH HÀNG                            ║
  ║════════════════════════════════════════════════════════║
  ║ 4. TÌM KIẾM THÔNG TIN KHÁCH HÀNG                       ║
  ║════════════════════════════════════════════════════════║
  ║ 5. HIỆN KHÁCH HÀNG CÓ NỢ PHẢI TRẢ                      ║
  ║════════════════════════════════════════════════════════║
  ║ 6. THANH TOÁN CÔNG NỢ                                  ║
  ║════════════════════════════════════════════════════════║
  ║ 7. QUAY VỀ TRANG TRƯỚC                                 ║
  ║════════════════════════════════════════════════════════║
  ║ MỜI CHỌN CHỨC NĂNG:                                    ║
  ╚════════════════════════════════════════════════════════╝");
                int checkKH;
                Console.SetCursorPosition(0, 21); kh.Hien();
                do
                {
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 17);
                            checkKH = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    

                    switch (checkKH)
                    {
                        case 1:
                            Console.Clear();
                            kh.Them();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            kh.Sua();
                            break;
                        case 3:
                            Console.Clear();
                            kh.Xoa();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            kh.Tim();                           
                            break;
                        case 5:
                            Console.Clear();
                             kh.HienKHNo();
                            break;
                        case 6:
                            Console.Clear();
                            kh.Thanhtoan();
                            break;
                        case 7:
                            Console.Clear();
                            break;

                    }
                } while (checkKH < 1 || checkKH > 7);
                if (checkKH == 7)
                {
                    break;
                }
            }

        }

        public void ChonMenuNV()
        {
            FormNV nv = new FormNV();
            while (true)
            {
                Console.WriteLine(@$"  ╔════════════════════════════════════════════════════════╗
  ║                   QUẢN LÝ NHÂN VIÊN                    ║
  ║════════════════════════════════════════════════════════║
  ║ 1. THÊM NHÂN VIÊN MỚI                                  ║
  ║════════════════════════════════════════════════════════║
  ║ 2. SỬA THÔNG TIN NHÂN VIÊN                             ║
  ║════════════════════════════════════════════════════════║
  ║ 3. XÓA THÔNG TIN NHÂN VIÊN                             ║
  ║════════════════════════════════════════════════════════║
  ║ 4. TÌM KIẾM THÔNG TIN NHÂN VIÊN                        ║
  ║════════════════════════════════════════════════════════║
  ║ 5. QUAY VỀ TRANG TRƯỚC                                 ║
  ║════════════════════════════════════════════════════════║
  ║ MỜI CHỌN CHỨC NĂNG:                                    ║
  ╚════════════════════════════════════════════════════════╝");
                int checkNV;
                Console.SetCursorPosition(0, 17); nv.Hien();
                do
                {
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 13);
                            checkNV = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    

                    switch (checkNV)
                    {
                        case 1:
                            Console.Clear();
                            nv.Them();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            nv.Sua();
                            break;
                        case 3:
                            Console.Clear();
                            nv.Xoa();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            nv.Tim();                           
                            break;

                        case 5:
                            Console.Clear();
                            break;

                    }
                } while (checkNV < 1 || checkNV > 5);
                if (checkNV == 5)
                {
                    break;
                }
            }

        }

        public void ChonMenuBaocao()
        {
            FormBaocao bc = new FormBaocao();
            while (true)
            {
                Console.WriteLine(@$"  ╔════════════════════════════════════════════════════════╗
  ║                        BÁO CÁO                         ║
  ║════════════════════════════════════════════════════════║
  ║ 1. BÁO CÁO NGÀY                                        ║
  ║════════════════════════════════════════════════════════║
  ║ 2. BÁO CÁO THÁNG                                       ║                                     
  ║════════════════════════════════════════════════════════║
  ║ 3. BÁO CÁO NĂM                                         ║
  ║════════════════════════════════════════════════════════║
  ║ 4. THỐNG KÊ VẬT LIỆU                                   ║
  ║════════════════════════════════════════════════════════║
  ║ 5. QUAY VỀ TRANG TRƯỚC                                 ║
  ║════════════════════════════════════════════════════════║
  ║ MỜI CHỌN CHỨC NĂNG:                                    ║
  ╚════════════════════════════════════════════════════════╝");
                int checkKH;
                do
                {
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(25, 13);
                            checkKH = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    

                    switch (checkKH)
                    {
                        case 1:
                            Console.Clear();
                            bc.Baocaongay();
                            string exit1;                           
                            break;
                        case 2:
                            Console.Clear();
                            bc.Baocaothang();                          
                            break;
                        case 3:
                            Console.Clear();
                            bc.Baocaonam();                           
                            break;
                        case 4:
                            Console.Clear();
                            bc.ThongkeVL();
                            break;

                        case 5:
                            Console.Clear();
                            break;

                    }
                } while (checkKH < 1 || checkKH > 5);
                if (checkKH == 5)
                {
                    break;
                }
            }
        } 
    }
}
