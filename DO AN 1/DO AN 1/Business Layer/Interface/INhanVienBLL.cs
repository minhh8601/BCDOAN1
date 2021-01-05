using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;

namespace DOAN1.BusinessLayer
{
    public interface INhanVienBLL
    {
        List<NhanVien> GetAllNhanVien();
        void ThemNhanVien(NhanVien nv);
        void XoaNhanVien(string manhanvien);
        void SuaNhanVien(NhanVien nv, string manhanvien);
        List<NhanVien> TimNhanVien(NhanVien nv);
    }
}
