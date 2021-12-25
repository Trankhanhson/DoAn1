using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.Business;
using Project.Utility;
namespace Project.Presentation
{
    class FormKH
    {
        private IKhachhangBLL kh = new KhachhangBLL();
        FormHoadon formHoadon = new FormHoadon();
        private IHoadonBLL hoadon = new HoadonBLL();
        private ILibraryCheck check=new LibraryCheck();

        public void Them()
        {
            Khachhang k = new Khachhang();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("                                             NHẬP THÔNG TIN KHÁCH HÀNG                                               ");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Tên:                Địa chỉ:                Số điện thoại:                 Giới tính:           Ngày sinh:   /  /    ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("THÔNG BÁO LỖI");
                int i = 9;
                //nhập tên
                while (true)
                {
                    Console.SetCursorPosition(4, 4); k.Ten = Tool.Catxau(Console.ReadLine());
                    if (k.Ten.Trim() != null)
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(i, 0, "Tên phải khác rỗng");
                    }
                }
                Tool.WriteXY(i, 0, "                                ");

                //nhập địa chỉ
                while (true)
                {
                    Console.SetCursorPosition(28, 4); k.Diachi = Console.ReadLine();
                    if (k.Diachi.Trim() != null)
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(i, 0, "Địa chỉ không được rỗng");

                    }
                }
                Tool.WriteXY(i, 0, "                                ");


                //nhập số điện thoại
                while (true)
                {
                    Console.SetCursorPosition(58, 4); k.Sdt = Console.ReadLine();
                    if (k.Sdt == null)
                    {
                        Tool.WriteXY(i, 0, "Số điện thoại không được rỗng");

                    }
                    else if ( Tool.DuyetChuoiSo(k.Sdt) == false)
                    {
                        Tool.WriteXY(i, 0, "Bạn nhập sai định dạng           ");
                    }
                    else if (k.Sdt.Length != 10 && k.Sdt.Length != 9)
                    {
                        Tool.WriteXY(i, 0, "Bạn nhập thiếu hoặc thừa số         ");

                    }
                    else break;
                }
                Tool.WriteXY(i, 0, "                                    ");

                //nhập giới tính
                while (true)
                {
                    Console.SetCursorPosition(85, 4);
                    k.Gioitinh = Console.ReadLine();
                    if (k.Gioitinh == "nam" || k.Gioitinh == "nu")
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(i, 0, "Gioi tính không được kahcs nam hoặc nữ");
                    }
                }
                Tool.WriteXY(i, 0, "                                ");


                //Nhập ngày sinh
                int ngay, thang, nam;
                DateTime now = DateTime.Now;
                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(107, 4); ngay = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(110, 4); thang = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(113, 4); nam = int.Parse(Console.ReadLine());
                        k.Ngaysinh = new DateTime(nam, thang, ngay);
                        if (k.Ngaysinh.Year <= now.Year - 18)
                        {
                            break;
                        }
                        else
                        {
                            Tool.WriteXY(i, 0, "Khách hàng phải từ 18 tuổi trở lên");
                        }
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(i, 0, "Bạn nhập sai định dạng          ");


                    }
                    catch (Exception)
                    {
                        Tool.WriteXY(i, 0, "Thời gian này không tồn tại         ");
                    }

                }
                Tool.WriteXY(i, 0, "                                  ");

                //Them khách hàng vào danh sách
                kh.ThemKH(k);


                Tool.WriteXY(i + 2, 0, "Nhấn Enter để thoát, nếu nhập tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public void Sua()
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("                                  SỬA THÔNG TIN KHÁCH HÀNG                               ");
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Mã:                              Tên:                             Địa chỉ:                  ");
                Console.WriteLine();
                Console.WriteLine("Ngày sinh:   /  /                Số điện thoại:                   Giới tính:               ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("THÔNG BÁO LỖI");
                int i = 10;

                Khachhang k;//tạo một biến Khachhang để nhập dữ liệu

                //cho nhập vào những biến dữ liệu số là string để khi người dùng không muốn sửa dữ liệu này thì chỉ cần nhấn Enter
                string ma, ten, diachi, sdt, gt;
                string ngay, thang, nam;

                while (true)
                {
                    Console.SetCursorPosition(3, 4);
                    ma = Console.ReadLine();
                    try
                    {
                        k = kh.GetKH(ma);//gán đói tượng k bằng đối tượng có ma trong danh sách
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.SetCursorPosition(0, i);
                        Console.WriteLine(e.Message);
                        i++;
                    }
                }
                Tool.WriteXY(i, 0, "                                        ");

                #region hiển thị thông tin cũ của khách
                Tool.WriteXY(4, 38, k.Ten);
                Tool.WriteXY(4, 75, k.Diachi);
                Tool.WriteXY(6, 11, k.Ngaysinh.Day.ToString());
                Tool.WriteXY(6, 14, k.Ngaysinh.Month.ToString());
                Tool.WriteXY(6, 17, k.Ngaysinh.Year.ToString());
                Tool.WriteXY(6, 48, k.Sdt);
                Tool.WriteXY(6,77, k.Gioitinh);
                #endregion

                bool checkChange=false;

                //sửa tên
                ten = Tool.ReadInfoXY(4, 38, k.Ten);
                if(ten!="" && ten != k.Ten)
                {
                    k.Ten = ten;
                    checkChange=true;
                }

                //sửa địa chỉ
                diachi = Tool.ReadInfoXY(4, 75, k.Diachi);
                if(diachi!=""&& diachi != k.Diachi)
                {
                    k.Diachi = diachi;
                    checkChange = true;
                }

                //sửa ngày sinh
                DateTime now = DateTime.Now;
                DateTime ngaysinh;
                while (true)
                {
                    try
                    {
                        ngay = Tool.ReadInfoXY(6, 11, k.Ngaysinh.Day.ToString());
                        if (ngay == "")
                        {
                            ngay = k.Ngaysinh.Day.ToString();
                        }
                        thang=Tool.ReadInfoXY(6,14,k.Ngaysinh.Month.ToString());
                        if (thang == "")
                        {
                            thang = k.Ngaysinh.Month.ToString();
                        }
                        nam=Tool.ReadInfoXY(6,17,k.Ngaysinh.Year.ToString());
                        if (nam == "")
                        {
                            nam = k.Ngaysinh.Year.ToString();
                        }
                        ngaysinh = new DateTime(int.Parse(nam), int.Parse(thang), int.Parse(ngay));
                        if (k.Ngaysinh.Year <= now.Year - 18)
                        {
                            break;
                        }
                        else
                        {
                            Tool.WriteXY(i, 0, "Nhân viên phải từ 18 tuổi trở lên");
                        }
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(i, 0, "Bạn nhập sai định dạng              ");

                    }
                    catch (Exception)
                    {
                        Tool.WriteXY(i, 0, "Thời gian này không tồn tại          ");
                    }
                }
                Tool.WriteXY(i, 0, "                                            ");
                if (ngaysinh != k.Ngaysinh)
                {
                    k.Ngaysinh= ngaysinh;
                }

                //sửa số điện thoại
                while (true)
                {
                    sdt = Tool.ReadInfoXY(6, 48, k.Sdt);
                    if(sdt != "")
                    {
                        if (Tool.DuyetChuoiSo(sdt) == false)
                        {
                            Console.SetCursorPosition(0, i); i++;
                            Console.WriteLine("Bạn nhập sai định dạng           ");
                        }
                        else if (sdt.Length != 10 && sdt.Length != 9)
                        {
                            Tool.WriteXY(i, 0, "Bạn nhập thiếu hoặc thừa số     ");
                        }
                        else
                            break;
                    }
                    else
                    {
                        break;
                    }
                }
                Tool.WriteXY(i, 0, "                                            ");
                if(sdt!="" && sdt != k.Sdt)
                {
                    k.Sdt= sdt;
                    checkChange= true;
                }

                //sửa giới tính
                while (true)
                {
                    gt = Tool.ReadInfoXY(6, 77, k.Gioitinh);
                    if(gt != "")
                    {
                        if (gt == "nam" || gt == "nu")
                        {
                            break;
                        }
                        else
                        {
                            Tool.WriteXY(i, 0, "Gioi tính không được khác nam hoạc nữ");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Tool.WriteXY(i, 0, "                                                ");
                if(gt!="" && gt != k.Gioitinh)
                {
                    k.Gioitinh= gt;
                    checkChange = true;
                }


                //Sửa đối tượng k vào trong danh sách
                if (checkChange)
                {
                    kh.SuaKH(k);
                }

                Tool.WriteXY(i + 2, 0, "Nhấn Enter để thoát, nếu sửa tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

            }
        }

        public void Xoa()
        {
            string ma;
            while (true)
            {
                Console.Write("MỜI NHẬP MÃ KHÁCH HÀNG MUỐN XÓA: ");
                ma = Console.ReadLine();
                if (check.CheckListKH(ma))
                {
                    if (check.CheckKHNo(ma) == false)
                    {
                        kh.XoaKH(ma);
                        Console.WriteLine("Đã xóa thành khách hàng có mã {0}", ma);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bạn không thể xóa khách hàng đang nợ tiền");
                    }
                }
                else
                {
                    Console.WriteLine("Mã khách hàng không tồn tại");
                }

                Console.Write("\nNhấn Enter để thoát, nhấn bất kì để xóa mã khác: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }


        }

        public void DisplayListKH(List<Khachhang> ds)
        {
            Console.WriteLine($"  {"Mã",-10}{"Tên",-20}{"Địa chỉ",-25}{"Số điện thoại",-20}{"Giới tính",-15}{"Ngày sinh",-15}{"Nợ phải trả"}");
            foreach (Khachhang a in ds)
            {
                Console.WriteLine($"  {a.Ma,-10}{a.Ten,-20}{a.Diachi,-25}{a.Sdt,-20}{a.Gioitinh,-15}{a.Ngaysinh.Day+ "/"+a.Ngaysinh.Month+"/"+a.Ngaysinh.Year,-15}{String.Format("{0:0,0}",a.Congno)}");
            }
        }

        public void Hien()
        {
            List<Khachhang> ds = kh.GetListKH();
            DisplayListKH(ds);
        }

        public void Tim()
        {
            Khachhang k = new Khachhang();
            char c;
            while (true)
            {
                while (true)
                {
                    Console.Write("\nNếu tìm mã nhấn (m), nếu tìm tên nhấn (t), nếu tìm số điện thoại nhấn (s), nếu tìm địa chỉ nhấn (d): ");
                    try
                    {
                        c = Char.ToLower(char.Parse(Console.ReadLine()));
                        if (c == 'm' || c == 't' || c == 's' || c == 'd')
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("BẠN NHẬP SAI MỜI NHẬP LẠI");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("BẠN NHẬP SAI ĐỊNH DẠNG");
                    }
                }
                Console.Clear();
                switch (c)
                {
                    case 'm':
                        Console.Write("Mời nhập mã khách hàng muốn tìm: ");
                        k.Ma = Console.ReadLine();
                        break;
                    case 't':
                        Console.Write("Mời nhập tên khách hàng muốn tìm: ");
                        k.Ten = Console.ReadLine();
                        break;
                    case 's':
                        Console.Write("Mời nhập số điện thoại của khách hàng muốn tìm: ");
                        k.Sdt = Console.ReadLine();
                        break;
                    case 'd':
                        Console.Write("Mời nhập địa chỉ của khách hàng muốn tìm: ");
                        k.Diachi = Console.ReadLine();
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
                List<Khachhang> dskh = kh.TimKH(k);
                if (dskh.Count > 0)
                {
                    DisplayListKH(dskh);
                }
                else
                {
                    Console.WriteLine("Thông tin khách hàng bạn muốn tìm không tồn tại");
                }

                Console.Write("Nhấn Enter để thoát, nếu tìm tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public void HienKHNo()
        {
            Console.WriteLine();
            DisplayListKH(kh.GetKHNo());
            Console.WriteLine();
            Tool.StopScreen();
        }

        public void Thanhtoan()
        {
            Khachhang k=new Khachhang();
            
            string ma, sdt;
            char option;
            int thanhtoanthem=0;


            while (true)
            {
                Console.Write("\n     Tìm khách nợ theo mã nhấn m, theo số điện thoại nhấn s: ");
                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(61, 1);
                        option = Char.ToLower(char.Parse(Console.ReadLine()));
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Bạn nhập sai định dạng");
                    }
                }
                Console.Clear();
                ConsoleKeyInfo check;
                switch (option)
                {
                    case 'm':
                        Console.Write("\n Mã khách hàng: ");
                        ma=Console.ReadLine();
                        try
                        {
                            k = kh.GetKH(ma);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);                          
                            Console.Write("Nhấn Enter để thoát, nếu tìm lại nhấn bất kì: ");
                            check = Console.ReadKey();
                            Console.Clear();
                            if (check.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                            else { continue; }
                        }
                        break;
                    case 's':
                        Console.Write("\n Số điện thoại: ");
                        sdt=Console.ReadLine();
                        try
                        {
                            k = kh.GetKHSdt(sdt);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.Write("Nhấn Enter để thoát, nếu tìm lại nhấn bất kì: ");
                            check = Console.ReadKey();
                            Console.Clear();
                            if (check.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                            else { continue; }
                        }
                        break;
                }

                //hiển thị khách tìm được
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"  {"Mã",-10}{"Tên",-20}{"Địa chỉ",-20}{"Số điện thoại",-20}{"Giới tính",-15}{"Ngày sinh",-15}{"Nợ phải trả"}");
                Console.WriteLine($"  {k.Ma,-10}{k.Ten,-20}{k.Diachi,-20}{k.Sdt,-20}{k.Gioitinh,-15}{k.Ngaysinh.Day + "/" + k.Ngaysinh.Month + "/" + k.Ngaysinh.Year,-15}{String.Format("{0:0,0}", k.Congno)}");

                //nếu khách có khoản nợ thì cho thanh toán nếu không thì thôi
                if (k.Congno > 0)
                {
                    Console.WriteLine();
                    formHoadon.HienDSHoadon(hoadon.GetHDChuaThanhToan(k.Ma));
                    while (true)
                    {
                        try
                        {
                            Console.Write("\n Khách thanh toán thêm: ");
                            thanhtoanthem = int.Parse(Console.ReadLine());
                            if (thanhtoanthem >= 0 && thanhtoanthem <= k.Congno)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine(" Bạn không được nhập số âm hoặc lớn hơn tổng nợ");
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine(" Bạn nhập sai định dạng              ");
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Khách hàng không có công nợ cần thanh toán");
                    Console.WriteLine();
                    Console.Write("Nhấn Enter để thoát, nếu thanh toán tiếp nhấn bất kì: ");
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.Clear();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            Console.Clear();
            if (thanhtoanthem > 0)
            {
                List<Hoadon> list = kh.Thanhtoan(k.Ma, thanhtoanthem);
                Console.WriteLine("Những hóa đơn đã được sửa công nợ\n");
                formHoadon.HienDSHoadon(list);
                Tool.StopScreen();
            }

        }
            
    }
}
