using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.BusinessLayer;
using DOAN1.Entities;
namespace DOAN1.Presenation
{
    class frmKhachHang
    {
        private IKhachHangBLL khBLL = new KhachHangBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN KHACH HANG");
            Khachhang kh = new Khachhang();
            string nhapthem;
            do
            {
                do
                {
                    Console.Write("Nhap ma khach hang:"); kh.MaKhach = Console.ReadLine();
                } while (string.IsNullOrEmpty(kh.MaKhach));
                do
                {
                    Console.Write("Nhap ten khach hang:"); kh.Hoten = (Console.ReadLine());
                } while (string.IsNullOrEmpty(kh.Hoten));
                do
                {
                    Console.Write("Nhap que quan khac hang :"); kh.QueQuan = Console.ReadLine();
                } while (string.IsNullOrEmpty(kh.QueQuan));
                do
                {
                    Console.Write("Nhap dia chi khach hang:"); kh.DiaChi = Console.ReadLine();
                } while (string.IsNullOrEmpty(kh.DiaChi));
                do
                {
                    Console.Write("Nhap so dien thoai :"); kh.SodienThoai = Console.ReadLine();
                } while (string.IsNullOrEmpty(kh.SodienThoai) && kh.SodienThoai.Length < 10 && kh.SodienThoai.Length > 10);
                khBLL.ThemKhachHang(kh);
                Console.Write("Bạn có muốn nhập tiếp không ?(Y or y để nhập tiếp,nhấn bất kì để thoát )");
                do
                {
                    nhapthem = Console.ReadLine();
                } while (nhapthem == "");
            } while (nhapthem == "Y" || nhapthem== "y");
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔═══════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                         DANH SÁCH KHÁCH HÀNG                                      ║");
            Console.WriteLine("\t\t╠═════════════╦═════════════════╦═══════════════════╦═══════════════╦═══════════════╣");
            Console.WriteLine("\t\t║    Mã Khách ║ Họ Tên khách    ║     Quê Quán      ║   Địa Chỉ     ║ Số điện thoại ║");
            Console.WriteLine("\t\t╠═════════════╬═════════════════╬═══════════════════╬═══════════════╬═══════════════╣");
            List<Khachhang> list = khBLL.GetAllKhachHang();
            foreach (var kh in list)
                Console.WriteLine("\t\t║    {0,-5}    ║ {1,-15} ║ {2,-15}   ║{3,-15}║ {4,-11}   ║", kh.MaKhach, kh.Hoten, kh.QueQuan, kh.DiaChi, kh.SodienThoai);

            Console.WriteLine("\t\t╚═════════════╩═════════════════╩═══════════════════╩═══════════════╩═══════════════╝");
        }
        public void Sua()
        {
            Hien();
            Console.WriteLine("SUA THONG TIN KHACH HANG");
            List<Khachhang> list = khBLL.GetAllKhachHang();
            string makhachhang;
            Console.Write("Nhap ma khach hang can sua:");
            makhachhang = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhach == makhachhang) break;

            if (i < list.Count)
            {
                Khachhang kh = new Khachhang(list[i]);
                Console.Write("Nhap ma khach hang moi:");
                string ma = Console.ReadLine();
                if (!string.IsNullOrEmpty(ma)) kh.MaKhach = ma;
                Console.Write("Nhap ho ten khach hang moi:");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) kh.Hoten = ten;
                Console.Write("Nhap que quan moi :");
                string que = Console.ReadLine();
                if (!string.IsNullOrEmpty(que)) kh.QueQuan = que;
                Console.Write("Nhap dia chi moi:");
                string dc = Console.ReadLine();
                if (!string.IsNullOrEmpty(dc)) kh.DiaChi = dc;
                Console.Write("Nhap so dien thoai moi:");
                string sdt = Console.ReadLine();
                if (!string.IsNullOrEmpty(sdt)) kh.SodienThoai = sdt;
                khBLL.SuaKhachHang(kh,makhachhang);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma khach hang nay");
            }
        }
        public void Tim()
        {
            Console.Clear();
            IKhachHangBLL Khachhang = new KhachHangBLL();
            List<Khachhang> list = Khachhang.TimKhachHang(new Khachhang());
            string makhach;
            Console.Write("Nhap ma khach hang can tim:");
            makhach = Console.ReadLine();
            for(int i = 0; i < list.Count; ++i)
            {
                if(makhach== list[i].MaKhach )
                    Console.WriteLine(list[i].MaKhach + "\t" + list[i].Hoten + "\t" + list[i].QueQuan + "\t" + list[i].DiaChi + "\t" + list[i].SodienThoai);
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XOA THONG TIN KHACH HANG");
            List<Khachhang> list = khBLL.GetAllKhachHang();
            string makhachhang;
            Console.Write("Nhap ma khach hang can xoa:");
            makhachhang = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhach == makhachhang) break;

            if (i < list.Count)
            {
                list.RemoveAt(i);
                khBLL.XoaKhachHang(makhachhang);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma khach hang nay");
            }
        }
        public void Menu()
        {
            do
            {
                Console.SetCursorPosition(47, 1); Console.WriteLine("QUAN LY KHACH HANG");
                Console.SetCursorPosition(25, 6); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(25, 7); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 8); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 9); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 10); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(25, 11); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 12); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 13); Console.WriteLine("█░              F1. Nhap thong tin khach hang.                       ░█");
                Console.SetCursorPosition(25, 14); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 15); Console.WriteLine("█░              F2. Sua thong tin khach hang.                        ░█");
                Console.SetCursorPosition(25, 16); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 17); Console.WriteLine("█░              F3. tim kiem thong tin khach hang.                   ░█");
                Console.SetCursorPosition(25, 18); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 19); Console.WriteLine("█░              F4. Hien thi danh sach khach hang.                   ░█");
                Console.SetCursorPosition(25, 20); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 21); Console.WriteLine("█░              F5. Xoa thong tin khach hang.                        ░█");
                Console.SetCursorPosition(25, 22); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 23); Console.WriteLine("█░              F6. Thoat.                                           ░█");
                Console.SetCursorPosition(25, 24); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 25); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 26); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 27); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(50, 8); Console.WriteLine("MENU QUAN LY KHACH HANG");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        Nhap();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F2:
                        Sua();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F3:
                        Tim();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F4:
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F5:
                        Xoa();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F6:
                        Program.Menu();
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}
