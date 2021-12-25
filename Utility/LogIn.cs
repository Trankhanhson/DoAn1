using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Utility
{

    public class LogIn
    {
        private string taikhoan;
        private string matkhau;
        public string TaiKhoan
        {
            get
            {
                return taikhoan;
            }
            set
            {
                taikhoan = value;
            }
        }
        public string Matkhau
        {
            get
            {
                return matkhau;
            }
            set
            {
                matkhau = value;
            }
        }
        public LogIn()
        {

        }
        public int CheckLogIn(string taikhoan,string matkhau)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetCursorPosition(33, 5);
            Console.WriteLine(@$"╔════════════════════════════════════════════════════════╗
                                 ║                  ĐẠI LÝ VẬT LIỆU DA1                   ║
                                 ║════════════════════════════════════════════════════════║
                                 ║                                                        ║  
                                 ║   TÀI KHOẢN:                                           ║  
                                 ║                                                        ║  
                                 ║   MẬT KHẨU:                                            ║  
                                 ║                                                        ║  
                                 ║                                                        ║  
                                 ║--------------------------------------------------------║  
                                 ║                                                        ║  
                                 ║                                                        ║  
                                 ║                                                        ║  
                                 ║                                                        ║
                                 ╚════════════════════════════════════════════════════════╝");

            int i=1;
            while (true)
            {
                Console.SetCursorPosition(48, 9);
                this.taikhoan=Console.ReadLine();
                Console.SetCursorPosition(47, 11);
                this.matkhau=Tool.ReadPassword();

                if (this.taikhoan == taikhoan && this.matkhau == matkhau)
                {
                    return i;
                }
                else if ((this.taikhoan != taikhoan || this.matkhau != matkhau) && i <= 3)
                {
                    i++;
                    Console.SetCursorPosition(43, 16);
                    Console.WriteLine("Bạn nhập sai tài khoản hoặc mật khẩu");
                    Console.SetCursorPosition(39, 17);
                    Console.WriteLine("Nếu nhập sai quá 3 lần chương trình sẽ ngừng");

                }
                else                    
                    return i+1;
                Tool.WriteXY(9, 48, "                                     ");
                Tool.WriteXY(11, 47, "                                    ");
            }
            
        }
    }
    
}
