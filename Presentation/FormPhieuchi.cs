using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.Business;
using Project.Utility;
namespace Project.Presentation
{
    class FormPhieuchi
    {
        private PhieuchiBLL phieuchi = new PhieuchiBLL();
        public void Them()
        {
            while (true)
            {

                Phieuchi pc = new Phieuchi();

                Console.WriteLine("\t                                     ĐẠI LÝ VẬT LIỆU XÂY DỰNG DA1                                     ");
                Console.WriteLine("\t------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\t                                           THÊM PHIẾU CHI                                             ");
                Console.WriteLine("\t══════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine("\tKhoản tiền:                Thời gian:   /   /         Ghi chú:                                        ");


                int i = 8;//vị trí dòng của các thông báo
                //Nhập khoản tiền
                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(19, 4);
                        pc.Sotien = int.Parse(Console.ReadLine());
                        if (pc.Sotien > 0)
                        {
                            break;
                        }
                        else
                        {
                            Tool.WriteXY(i, 4, "Khoản tiền phải lớn hơn 0   ");
                        }
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(i, 4, "Bạn nhập sai định dạng      ");
                    }
                }
                Tool.WriteXY(i, 4, "                                        ");

                //Nhập thời gian 
                int ngay, thang, nam;
                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(46, 4); ngay = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(49, 4); thang = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(53, 4); nam = int.Parse(Console.ReadLine());
                        pc.Thoigian = new DateTime(nam, thang, ngay);
                        break;
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(i, 4, "Bạn nhập sai định dạng          ");
                    }
                    catch (Exception)
                    {
                        Tool.WriteXY(i, 4, "Thời gian này không tồn tại         ");
                    }

                }
                Tool.WriteXY(i, 4, "                                                    ");

                //nhập ghi chú
                Console.SetCursorPosition(70, 4);
                pc.Ghichu = Console.ReadLine();

                phieuchi.ThemPC(pc);

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
            Console.WriteLine("\t                                     ĐẠI LÝ VẬT LIỆU XÂY DỰNG DA1                                     ");
            Console.WriteLine("\t------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t                                           SỬA PHIẾU CHI                                             ");
            Console.WriteLine("\t══════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("\tMã:            Khoản tiền:                Thời gian:   /  /         Ghi chú:                         ");


            //cho nhập vào những biến dữ liệu số là string để khi người dùng không muốn sửa dữ liệu này thì chỉ cần nhấn Enter
            string ma, ghichu;
            string nam, thang, ngay;
            string sotien;

            Phieuchi pc; //tạo một biến phiếu chi để nhập thông tin muốn sửa

            int i = 10;//vị trí dong thông báo

            //nhập mã phiếu muốn sửa
            while (true)
            {
                Console.SetCursorPosition(11, 4);
                ma = Console.ReadLine();
                try
                {
                    pc = phieuchi.GetPC(ma);
                    break;
                }
                catch (Exception e)
                {
                    Tool.WriteXY(i, 4, e.Message);
                }
            }
            Tool.WriteXY(i, 4, "                                    ");

            #region hiện thông tin phiếu cũ
            Tool.WriteXY(4, 34, String.Format("{0:0,0}",pc.Sotien));
            Tool.WriteXY(4, 61, pc.Thoigian.Day.ToString());
            Tool.WriteXY(4, 64, pc.Thoigian.Month.ToString());
            Tool.WriteXY(4, 67, pc.Thoigian.Year.ToString());
            Tool.WriteXY(4, 85, pc.Ghichu);
            #endregion

            bool check = false;//check người dùng có sửa hay không

            //sửa khoản tiền
            while (true)
            {
                sotien = Tool.ReadInfoXY(4, 34, String.Format("{0:0,0}",pc.Sotien));
                if (Tool.DuyetChuoiSo(sotien) == false)
                {
                    Tool.WriteXY(i, 4, "Bạn nhập sai định dạng");
                }
                else
                    break;
            }
            Tool.WriteXY(i, 4, "                                ");
            if (sotien != "" && int.Parse(sotien) != pc.Sotien)
            {
                pc.Sotien = int.Parse(sotien);
                check = true;
            }

            //Sửa ngày tháng
            DateTime time;
            while (true)
            {
                try
                {
                    ngay = Tool.ReadInfoXY(4, 61, pc.Thoigian.Day.ToString());
                    if (ngay == "")
                    {
                        ngay = pc.Thoigian.Day.ToString();//nếu không muốn sửa thì gán bằng thời gian cũ
                    }
                    thang = Tool.ReadInfoXY(4, 64, pc.Thoigian.Month.ToString());

                    if (thang == "")
                    {
                        thang = pc.Thoigian.Month.ToString();
                    }
                    nam = Tool.ReadInfoXY(4, 67, pc.Thoigian.Year.ToString());
                    if (nam == "")
                    {
                        nam = pc.Thoigian.Year.ToString();
                    }

                    time = new DateTime(int.Parse(nam), int.Parse(thang), int.Parse(ngay));
                    break;
                }
                catch (FormatException)
                {
                    Tool.WriteXY(i, 4, "Bạn nhập sai định dạng          ");
                }
                catch (Exception)
                {
                    Tool.WriteXY(i, 4, "Thời gian này không tồn tại         ");
                }
            }
            Tool.WriteXY(i, 4, "                                                  ");
            if (time != pc.Thoigian)
            {
                pc.Thoigian = time;
                check = true;
            }

            ghichu = Tool.ReadInfoXY(4, 85, pc.Ghichu);
            if (ghichu!="" && ghichu.ToLower() != pc.Ghichu.ToLower())
            {
                pc.Ghichu = ghichu;
                check = true;
            }

            if (check)
            {
                phieuchi.SuaPC(pc);
            }
            
        }
        public void Xoa()
        {
            string ma;
            while (true)
            {
                Console.Write("Mời nhập mã phiếu muốn xóa: ");
                ma = Console.ReadLine();
                try
                {
                    phieuchi.XoaPC(ma);
                    Console.WriteLine("Đã xóa thành công phiếu chi có mã {0}", ma);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void DisplayListPC(List<Phieuchi> ds)
        {
            Console.WriteLine($"  {"Mã",-15}{"Khoản tiền",-20}{"Thời gian",-20}{"Ghi chú"}");
            foreach (Phieuchi a in ds)
            {
                Console.WriteLine($"  {a.Maphieu,-15}{String.Format("{0:0,0}", a.Sotien),-20}{a.Thoigian.Day + "/" + a.Thoigian.Month + "/" + a.Thoigian.Year,-20}{a.Ghichu}");
            }
        }

        public void Hien()
        {
            List<Phieuchi> ds = phieuchi.GetListPC();
            DisplayListPC(ds);
        }
        public void Tim()
        {
            char check;
            while (true)
            {
                try
                {
                    Console.Write("Tìm theo mã nhấn (m), theo thời gian nhấn (n), tìm theo ghi chú nhấn (g): ");
                    check = Char.ToLower(char.Parse(Console.ReadLine()));
                    if (check == 'g' || check == 'n' || check=='m')
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Bạn nhập sai");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn nhập sai định dạng");
                }
            }

            Console.Clear();
            Phieuchi pc = new Phieuchi();
            int ngay, thang, nam;
            switch (check)
            {
                case 'm':
                    Console.Write("Mời nhập mã phiếu chi muốn tìm: ");
                    pc.Maphieu=Console.ReadLine();
                    break;
                case 'n':
                    Console.Write("Ngày:   /");
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(6, 0);
                            thang = int.Parse(Console.ReadLine());

                            Console.SetCursorPosition(9, 0);
                            nam = int.Parse(Console.ReadLine());
                            pc.Thoigian = new DateTime(nam, thang, 1);
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("Bạn nhập sai định dạng     ");
                        }
                        catch (Exception)
                        {
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("Thời gian này không tồn tại      ");
                        }
                    }
                    break;
                case 'g':
                    Console.Write("Ghi chú: ");
                    pc.Ghichu = Console.ReadLine();
                    break;
            }
            Console.Clear();
            List<Phieuchi> phieuchis = phieuchi.TimPC(pc);
            if (phieuchis.Count > 0)
            {
                DisplayListPC(phieuchis);
            }
            else
            {
                Console.WriteLine("Không tìm thấy");
            }

            Tool.StopScreen();
        }
    }
}
