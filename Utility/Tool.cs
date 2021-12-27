using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Project.Utility
{
    public class Tool
    {


        public static string Catxau(string xau)
        {
            string s = xau.Trim();
            while (s.IndexOf("  ") >= 0)
            { s = s.Remove(s.IndexOf("  "), 1); }
            return s;
        }

        public static int MaCuoi(string file)
        {
            StreamReader read = File.OpenText(file);
            string s = read.ReadLine();
            //lấy vị trí cuối
            string tmp = "";
            while (s != null)
            {
                if (s != "")
                {
                    tmp = s;
                }
                s = read.ReadLine();
            }
            read.Close();

            int soma;
            if (tmp == "") return 0;
            else { 
                string[] a = tmp.Split('*');
                soma = int.Parse(a[0].Substring(2));
            }
            return soma;

        }
        //hàm trả về true thì chuỗi không có kí tự khác số còn false thì ngược lại

        public static bool DuyetChuoiSo(string a)
        {
            bool check = true;
            foreach (char c in a)
            {
                if (c < '0' || c > '9')
                {
                    check = false;
                    return check;
                }
            }
            return check;
        }

        public static string ReadPassword()
        {
            string pass = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");//lùi con trỏ lại 1 đơn vị rồi ghi khoảng trắng vào rồi lùi tiếp
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }

        //ghi đè khoảng trắng vào thông tin cũ rồi cho người dùng nhập thông tin mới, nếu người dùng nhập rỗng thì sẽ in lại thông tin cũ
        public static string ReadInfoXY(int x,int y,string OldInfo)
        {
            string newInfo = "";
            ConsoleKeyInfo key;
            Console.SetCursorPosition(y,x);
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    if(newInfo.Length == 0)//khi nhập kí tự đầu tiên
                    {
                        string space = "";
                        for (int i = 0; i < OldInfo.Length; i++)
                        {
                            space += ' ';
                        }
                        WriteXY(x, y, space);
                    }

                    newInfo += key.KeyChar;
                    Console.SetCursorPosition(y, x);//nếu không chỉ rõ vị trí hiện thì key sẽ hiện sau các khoảng trắng phía trên
                    Console.Write(key.KeyChar);
                    y++;
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && newInfo.Length > 0)
                    {
                        newInfo = newInfo.Substring(0, (newInfo.Length - 1));                       
                        Console.Write("\b \b");
                        y--;
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return Catxau(newInfo);
        }

        public static void WriteXY(int x,int y,string str)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(str);
        }

       

        public static void overwriteOldInfo(int x,int y,string newinfo,string oldinfo)
        {
                      
            if (newinfo.Length <= oldinfo.Length)
            {
                string str = "";
                for(int i = 0; i < oldinfo.Length; i++)
                {
                    str += ' ';
                }
                WriteXY(x, y, str);
            }
            WriteXY(x, y, newinfo);
        }

        public static void StopScreen()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Write("Nhấn Enter để thoát: ");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);
            Console.Clear();
        }

        public static int NgayTrongThang(int nam, int thang)
        {
            int sumday = 0;
            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: sumday = 31; break;
                case 4:
                case 6:
                case 9:
                case 11: sumday = 30; break;
                case 2:
                    if (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 != 0))//lấy năm tròn thập kỉ chia cho 400 và không trong chi cho 4
                    {
                        sumday = 29;
                    }
                    else { sumday = 28; }
                    break;
            }
            return sumday;
        }
    }
}
