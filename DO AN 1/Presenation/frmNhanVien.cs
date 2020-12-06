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
            Console.Write("Nhap ma nhan vien:"); nv.MaNhanVien = Console.ReadLine();
            Console.Write("Nhap ten nhan vien:"); nv.TenNhanVien = Console.ReadLine();
            Console.Write("Nhap dia chi nhan vien:"); nv.DiaChiNV = Console.ReadLine();
            Console.Write("Nhap so dien thoai nhan vien:"); nv.SoDienThoaiNV = Console.ReadLine();
            Console.Write("Nhap gmail nhan vien:"); nv.Gmail = Console.ReadLine();
            Console.Write("Nhap he so luong nhan vien:"); nv.HeSoLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhap luong co ban nhan vien:"); nv.LuongCoBan = int.Parse(Console.ReadLine());
            nvBLL.ThemNhanVien(nv);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN NHAN VIEN");
            List<NhanVien> list = nvBLL.GetAllNhanVien();
            foreach (var nv in list)
                Console.WriteLine(nv.MaNhanVien + "\t" + nv.TenNhanVien + "\t" + nv.DiaChiNV + "\t" + nv.SoDienThoaiNV + "\t" + nv.Gmail + "\t" + nv.HeSoLuong + "\t" + nv.LuongCoBan);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN KHACH HANG");
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
                Console.Write("Nhap gia ban san pham moi:");
                int lcb = int.Parse(Console.ReadLine());
                if (lcb > 0) nv.LuongCoBan = lcb;
                nvBLL.SuaNhanVien(nv);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma nhan vien nay");
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
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN NHAN VIEN");
                Console.WriteLine(" F1.Nhap thong tin NHAN VIEN ");
                Console.WriteLine(" F2.Sua thong tin NHAN VIEN ");
                Console.WriteLine(" F3.Tim thong tin NHAN VIEN ");
                Console.WriteLine(" F4.Hien danh sach NHAN VIEN ");
                Console.WriteLine(" F5.Xoa thong tin NHAN VIEN ");
                Console.WriteLine(" F6.Back ");
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
                    case ConsoleKey.F6:
                        Program.Menu();
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}
