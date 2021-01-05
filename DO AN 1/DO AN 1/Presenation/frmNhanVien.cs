using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.BusinessLayer;
using DOAN1.Entities;
namespace DOAN1.Presenation
{
    class frmNhanVien
    {
        private INhanVienBLL nvBLL = new NhanVienBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN NHAN VIEN");
            NhanVien nv = new NhanVien();
            string nhapthem;
            do {
                do
                {
                    Console.Write("Nhap ma nhan vien:"); nv.MaNhanVien = Console.ReadLine();
                } while (string.IsNullOrEmpty(nv.MaNhanVien));
                do {
                    Console.Write("Nhap ten nhan vien:"); nv.TenNhanVien = Console.ReadLine();
                } while (string.IsNullOrEmpty(nv.TenNhanVien));
                do {
                    Console.Write("Nhap dia chi nhan vien:"); nv.DiaChiNV = Console.ReadLine();
                } while (string.IsNullOrEmpty(nv.DiaChiNV));
                do {
                    Console.Write("Nhap so dien thoai nhan vien:"); nv.SoDienThoaiNV = Console.ReadLine();
                } while (string.IsNullOrEmpty(nv.MaNhanVien)&&nv.SoDienThoaiNV.Length <10&& nv.SoDienThoaiNV.Length>10);
                do {
                    Console.Write("Nhap gmail nhan vien:"); nv.Gmail = Console.ReadLine();
                }while (string.IsNullOrEmpty(nv.DiaChiNV));
                do
                {
                    Console.Write("Nhap he so luong nhan vien:"); nv.HeSoLuong = double.Parse(Console.ReadLine());
                } while (nv.HeSoLuong < 1);
                do
                {
                    Console.Write("Nhap luong co ban nhan vien:"); nv.LuongCoBan = int.Parse(Console.ReadLine());
                } while (nv.LuongCoBan <= 999999);
                nvBLL.ThemNhanVien(nv);
                Console.Write("Bạn có muốn nhập tiếp không ?(Y or y để nhập tiếp,nhấn bất kì để thoát )");
                do
                {
                    nhapthem = Console.ReadLine();
                } while (nhapthem == "");
            } while (nhapthem == "Y" || nhapthem == "y");
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                              DANH SÁCH NHÂN VIÊN                                                        ║");
            Console.WriteLine("\t\t╠═════════════╦═══════════════╦══════════════════════╦════════════════╦════════════════════╦══════════════╦═══════════════╣");
            Console.WriteLine("\t\t║    Mã NV    ║  Tên nhân viên║      Địa Chỉ         ║   Số Điện thoại║     Gmail          ║ Hệ số lương  ║lương cơ bản   ║");
            Console.WriteLine("\t\t╠═════════════╬═══════════════╬══════════════════════╬════════════════╬════════════════════╬══════════════╬═══════════════╣");
            List<NhanVien> list = nvBLL.GetAllNhanVien();
            foreach (var nv in list)
            Console.WriteLine("\t\t║    {0,-5}    ║{1,-15}║   {2,-15}    ║    {3,-11} ║{4,-20}║ {5,-2}           ║ {6,-8}      ║", nv.MaNhanVien, nv.TenNhanVien,nv.DiaChiNV, nv.SoDienThoaiNV, nv.Gmail, nv.HeSoLuong, nv.LuongCoBan);

            Console.WriteLine("\t\t╚═════════════╩═══════════════╩══════════════════════╩════════════════╩════════════════════╩══════════════╩═══════════════╝");           
        }
        public void Sua()
        {
            Hien();
            Console.WriteLine("SỬA THÔNG TIN KHÁCH HÀNG");
            List<NhanVien> list = nvBLL.GetAllNhanVien();
            string manhanvien;
            Console.Write("Nhap ma nhan vien can sua:");
            manhanvien = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaNhanVien == manhanvien) break;

            if (i < list.Count)
            {
                NhanVien nv = new NhanVien(list[i]);
                Console.Write("Nhap ma nhan vien moi:");
                string ma = Console.ReadLine();
                if (!string.IsNullOrEmpty(ma)) nv.MaNhanVien = ma;
                Console.Write("Nhap ho ten nhan vien moi:");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) nv.TenNhanVien = ten;
                Console.Write("Nhap dia chi moi :");
                string dc = Console.ReadLine();
                if (!string.IsNullOrEmpty(dc)) nv.DiaChiNV = dc;
                Console.Write("Nhap so dien thoai moi:");
                string sdt = Console.ReadLine();
                if (!string.IsNullOrEmpty(sdt)) nv.SoDienThoaiNV = sdt;
                Console.Write("Nhap gmail moi:");
                string gm = Console.ReadLine();
                if (!string.IsNullOrEmpty(gm)) nv.Gmail = gm;
                Console.Write("Nhap he so luong moi:");
                double hsl = double.Parse(Console.ReadLine());
                if (hsl > 0) nv.HeSoLuong = hsl;
                Console.Write("Nhap lương cơ bản moi:");
                int lcb = int.Parse(Console.ReadLine());
                if (lcb > 0) nv.LuongCoBan = lcb;
                nvBLL.SuaNhanVien(nv,manhanvien);
            }
            else
            {
                Console.WriteLine("Không tồn tại mã nhân viên này !");
            }
        }
        public void Tim()
        {
            Console.Clear();
            INhanVienBLL NhanVien = new NhanVienBLL();
            List<NhanVien> list = NhanVien.TimNhanVien(new NhanVien());
            string manhanv;
            Console.Write("Nhap ma nhan vien can tim:");
            manhanv = Console.ReadLine();
            for (int i = 0; i < list.Count; ++i)
            {
                if (manhanv == list[i].MaNhanVien)
                    Console.WriteLine(list[i].MaNhanVien + "#" + list[i].TenNhanVien + "#" + list[i].DiaChiNV + "#" + list[i].SoDienThoaiNV + "#" + list[i].Gmail + "#" + list[i].HeSoLuong + "#" + list[i].LuongCoBan);
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XOA THONG TIN NHAN VIEN");
            List<NhanVien> list = nvBLL.GetAllNhanVien();
            string manhanvien;
            Console.Write("Nhap ma nhan vien can xoa:");
            manhanvien = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaNhanVien == manhanvien) break;

            if (i < list.Count)
            {
                list.RemoveAt(i);
                nvBLL.XoaNhanVien(manhanvien);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma nhan vien nay");
            }
        }
        public void Menu()
        {
            do
            {
                Console.SetCursorPosition(47, 1); Console.WriteLine("QUAN LY NHAN VIEN");
                Console.SetCursorPosition(25, 6); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(25, 7); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 8); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 9); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 10); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(25, 11); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 12); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 13); Console.WriteLine("█░              F1. Nhap thong tin nhan vien.                        ░█");
                Console.SetCursorPosition(25, 14); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 15); Console.WriteLine("█░              F2. Sua thong tin nhan vien.                         ░█");
                Console.SetCursorPosition(25, 16); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 17); Console.WriteLine("█░              F3. Tim kiem thong tin nhan vien.                    ░█");
                Console.SetCursorPosition(25, 18); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 19); Console.WriteLine("█░              F4. Hien thi danh sach nhan vien.                    ░█");
                Console.SetCursorPosition(25, 20); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 21); Console.WriteLine("█░              F5. Xoa thong tin nhan vien.                         ░█");
                Console.SetCursorPosition(25, 22); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 23); Console.WriteLine("█░              F6. Thoat.                                           ░█");
                Console.SetCursorPosition(25, 24); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 25); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 26); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 27); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(50, 8); Console.WriteLine("MENU QUAN LY NHAN VIEN");
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
