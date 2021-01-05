using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;
using DOAN1.DataAccessLayer;
namespace DOAN1.DataAccessLayer
{
    public class NhanVienDAL : INhanVienDAL
    {
        //Xác định đường dẫn của tệp dữ liệu SanPham.txt
        private string txtNhanVien = "Data/NhanVien.txt";
        //Lấy toàn bộ dữ liệu có trong file SanPham.txt đưa vào một danh sách 
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            StreamReader fread = File.OpenText(txtNhanVien);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new NhanVien(a[0], a[1], a[2], a[3], a[4], double.Parse(a[5]), int.Parse(a[6])));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //string manv, string tennv, string diachinv, string sdtnv, string gmail, double hsl, int luongcb
        //Chèn một bản ghi san pham vào tệp
        public void ThemNhanVien(NhanVien nv)
        {
            string manhanvien = nv.MaNhanVien;
            StreamWriter fwrite = File.AppendText(txtNhanVien);
            fwrite.WriteLine();
            fwrite.Write(manhanvien + "#" + nv.TenNhanVien + "#" + nv.DiaChiNV + "#" + nv.SoDienThoaiNV + "#" + nv.Gmail + "#" + nv.HeSoLuong + "#" + nv.LuongCoBan);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<NhanVien> list)
        {
            StreamWriter fwrite = File.CreateText(txtNhanVien);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].MaNhanVien + "#" + list[i].TenNhanVien + "#" + list[i].DiaChiNV + "#" + list[i].SoDienThoaiNV + "#" + list[i].Gmail + "#" + list[i].HeSoLuong + "#" + list[i].LuongCoBan);
            fwrite.Close();
        }
    }
}

