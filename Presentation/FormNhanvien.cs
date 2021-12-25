using System;
using System.Collections.Generic;
using System.Text;
using Project.Business;
using Project.Entities;
using Project.Utility;
namespace Project.Presentation
{
    class FormNV
    {
        private INhanvienBLL nv = new NhanvienBLL();
        public void Them()
        {
            Nhanvien v = new Nhanvien();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("                                            NHẬP THÔNG TIN NHÂN VIÊN                                                 ");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Tên:                Địa chỉ:                Số điện thoại:                 Giới tính:           Ngày sinh:   /  /    ");

                int i = 9;

                //nhập tên nhân viên
                while (true)
                {
                    Console.SetCursorPosition(4, 4); v.Ten = Tool.Catxau(Console.ReadLine());
                    if (v.Ten.Trim() != null)
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(i, 0, "Tên phải khác rỗng");
                    }
                }
                Tool.WriteXY(i, 0, "                                  ");

                //nhập địa chỉ nhân viên
                while (true)
                {
                    Console.SetCursorPosition(28, 4); v.Diachi = Console.ReadLine();
                    if (v.Diachi.Trim() != null)
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(i, 0, "Dịa chỉ phải khác rỗng");
                    }
                }
                Tool.WriteXY(i, 0, "                                 ");

                //nhập số điện thoại
                while (true)
                {
                    Console.SetCursorPosition(58, 4); v.Sdt = Console.ReadLine();
                    if (v.Sdt == null)
                    {
                        Tool.WriteXY(i, 0, "Số điện thoại không được trống");
                    }                   
                    else if (Tool.DuyetChuoiSo(v.Sdt) == false)
                    {
                        Tool.WriteXY(i,0,"Bạn nhập sai định dạng        ");
                    }
                    else if (v.Sdt.Length !=10 && v.Sdt.Length !=9)
                    {
                        Tool.WriteXY(i, 0, "Bạn nhập thiếu hoặc thừa số    ");

                    }
                    else break;
                }
                Tool.WriteXY(i, 0, "                                   ");

                //nhập giới tính
                while (true)
                {
                    Console.SetCursorPosition(85, 4);
                    v.Gioitinh = Console.ReadLine();
                    if (v.Gioitinh == "nam" || v.Gioitinh == "nu")
                    {
                        break;
                    }
                    else
                    { 
                        Tool.WriteXY(i, 0, "Gioi tính không được khác nam hoặc nu ");
                    }
                }
                Tool.WriteXY(i, 0, "                                    ");

                //nhập ngày sinh
                int ngay, thang, nam;
                DateTime now = DateTime.Now;
                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(107, 4); ngay = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(110, 4); thang = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(113, 4); nam = int.Parse(Console.ReadLine());
                        v.Ngaysinh = new DateTime(nam, thang, ngay);
                        if (v.Ngaysinh.Year <= now.Year - 18)
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
                        Tool.WriteXY(i, 0, "Thời gian này không tồn tại         ");
                    }

                }
                Tool.WriteXY(i, 0, "                                       ");

                //thêm nhân viên mới
                nv.ThemNV(v);

                Tool.WriteXY(i + 2, 0, "Nhấn Enter để thoát, nếu sửa tiếp nhấn bất kì: ");
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
                Console.WriteLine("                                  SỬA THÔNG TIN NHÂN VIÊN                           ");
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Mã:                 Tên:                      Địa chỉ:                Ngày sinh:   /  /    ");
                Console.WriteLine();
                Console.WriteLine("Số điện thoại:                   Giới tính:                  Ngày công:     ");

                int i = 11;
                Nhanvien v;//tạo biến Nhanvien v để chứa dữ liệu nhập vào

                //cho nhập vào những biến dữ liệu số là string để khi người dùng không muốn sửa dữ liệu này thì chỉ cần nhấn Enter
                string ma, ten, diachi, sdt, gt, ngaycong;
                string ngay, thang, nam;

                while (true)
                {
                    Console.SetCursorPosition(3, 4);
                    ma = Console.ReadLine();
                    try
                    {
                        v = nv.GetNV(ma);//gán đói tượng v bằng đối tượng có ma trong danh sách
                        break;
                    }
                    catch (Exception e)
                    {             
                        Tool.WriteXY(i, 0, e.Message);
                    }
                }
                Tool.WriteXY(i, 0, "                                                ");

                #region hiện thông tin cũ của nhân viên
                Tool.WriteXY(4, 25, v.Ten);
                Tool.WriteXY(4, 55, v.Diachi);
                Tool.WriteXY(4, 81, v.Ngaysinh.Day.ToString());
                Tool.WriteXY(4, 84, v.Ngaysinh.Month.ToString());
                Tool.WriteXY(4, 87, v.Ngaysinh.Year.ToString());
                Tool.WriteXY(6, 15, v.Sdt);
                Tool.WriteXY(6, 44, v.Gioitinh);
                Tool.WriteXY(6, 72, v.Ngaycong.ToString());

                #endregion

                bool checkChange = false;//check xem người dùng ó thay đổi thông tin hay không

                //sửa tên
                ten = Tool.ReadInfoXY(4, 25, v.Ten);
                if (ten != "" && ten != v.Ten)
                {
                    v.Ten = ten;
                    checkChange = true;
                }
                
                
                //sửa địa chỉ
                diachi = Tool.ReadInfoXY(4,55, v.Diachi);
                if (diachi != "" && diachi != v.Diachi)
                {
                    v.Diachi = diachi;
                    checkChange = true;
                }

                //sửa ngày sinh
                DateTime now = DateTime.Now;
                DateTime ngaysinh;
                while (true)
                {
                    try
                    {
                        ngay = Tool.ReadInfoXY(4,81,v.Ngaysinh.Day.ToString());
                        if (ngay == "")
                        {
                            ngay = v.Ngaysinh.Day.ToString();
                        }
                        thang =Tool.ReadInfoXY(4,84,v.Ngaysinh.Month.ToString());
                        if (thang == "")
                        {
                            thang = v.Ngaysinh.Month.ToString();
                        }
                        nam = Tool.ReadInfoXY(4,87,v.Ngaysinh.Year.ToString());
                        if (nam == "")
                        {
                            nam = v.Ngaysinh.Year.ToString();
                        }

                        ngaysinh = new DateTime(int.Parse(nam), int.Parse(thang), int.Parse(ngay));

                        if (v.Ngaysinh.Year <= now.Year - 18)
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
                Tool.WriteXY(i, 0, "                                                   ");
                if (ngaysinh != v.Ngaysinh)
                {
                    v.Ngaysinh = ngaysinh;
                    checkChange = true;

                }

                //sửa số điện thoại
                while (true)
                {
                    sdt = Tool.ReadInfoXY(6, 15, v.Sdt);
                    if (sdt != "")
                    {
                        if (Tool.DuyetChuoiSo(sdt) == false)
                        {
                            Tool.WriteXY(i, 0, "Bạn nhập sai định dạng      ");
                        }
                        else if(sdt.Length !=10 && sdt.Length != 9)
                        {
                            Tool.WriteXY(i, 0, "Bạn nhập thiếu hoặc thừa số     ");
                        }
                        else
                            break;
                    }
                    else { break; }
                }
                Tool.WriteXY(i, 0, "                                                   ");
                if (sdt != "" && sdt != v.Sdt)
                {
                    v.Sdt = sdt;
                    checkChange=true;
                }

                //sửa giới tính
                while (true)
                {
                    gt = Tool.ReadInfoXY(6, 44, v.Gioitinh);
                    if(gt != "")
                    {
                        if (v.Gioitinh == "nam" || v.Gioitinh == "nu")
                        {
                            break;
                        }
                        else
                        {
                            Tool.WriteXY(i, 0, "Gioi tính không dược khác nam hoặc nu");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Tool.WriteXY(i, 0, "                                                  ");
                if (gt != "" && gt != v.Gioitinh)
                {
                    v.Gioitinh = gt;
                    checkChange =true;
                }

                //sửa ngày công
                while (true)
                {
                    ngaycong = Tool.ReadInfoXY(6,72,v.Ngaycong.ToString());
                    if(ngaycong != "")
                    {
                        if (Tool.DuyetChuoiSo(ngaycong) == false)
                        {                       
                            Tool.WriteXY(i, 0, "Bạn nhập sai định dạng hoặc bạn nhập ngày công bị âm");
                        }
                        else
                        {
                            break;
                        }
                    }
                }         
                Tool.WriteXY(i, 0, "                                                          ");

                if (ngaycong != "" && int.Parse(ngaycong) != v.Ngaycong)
                {
                    v.Ngaycong = int.Parse(ngaycong);
                    checkChange =true;
                }


                //Sửa đối tượng v vào trong danh sách
                if (checkChange)
                {
                    nv.SuaNV(v);

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
                Console.Write("MỜI NHẬP MÃ NHÂN VIÊN MUỐN XÓA: ");
                ma = Console.ReadLine();
                try
                {
                    nv.XoaNV(ma);
                    Console.WriteLine("Đã xóa thành công nhân viên có mã {0}", ma);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void DisplayListNV(List<Nhanvien> ds)
        {
            Console.WriteLine($@"  {"Mã",-10}{"Tên",-20}{"Địa chỉ",-25}{"Số điện thoại",-20}{"Giới tính",-20}{"Ngày sinh",-20}{"Ngày công"}");
            foreach (Nhanvien a in ds)
            {
                Console.WriteLine($@"  {a.Ma,-10}{a.Ten,-20}{a.Diachi,-25}{a.Sdt,-20}{a.Gioitinh,-20}{a.Ngaysinh.Day+"/"+ a.Ngaysinh.Month+"/"+ a.Ngaysinh.Year,-20}{a.Ngaycong}");

            }
        }
        public void Hien()
        {
            List<Nhanvien> ds = nv.GetListNV();
            DisplayListNV(ds);
        }
        public void Tim()
        {
            Nhanvien v = new Nhanvien();
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
                        Console.Write("Mời nhập mã nhân viên muốn tìm: ");
                        v.Ma = Console.ReadLine();
                        break;
                    case 't':
                        Console.Write("Mời nhập tên nhân viên muốn tìm: ");
                        v.Ten = Console.ReadLine();
                        break;
                    case 's':
                        Console.Write("Mời nhập số điện thoại của nhân viên muốn tìm: ");
                        v.Sdt = Console.ReadLine();
                        break;
                    case 'd':
                        Console.Write("Mời nhập địa chỉ của nhân viên muốn tìm: ");
                        v.Diachi = Console.ReadLine();
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
                if (nv.TimNV(v).Count > 0)
                {
                    DisplayListNV(nv.TimNV(v));
                }
                else
                {
                    Console.WriteLine("Thông tin nhân viên bạn muốn tìm không tồn tại");
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
            
    }
}
