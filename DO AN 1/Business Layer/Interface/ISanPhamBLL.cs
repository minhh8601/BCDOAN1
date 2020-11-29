using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;

namespace DOAN1.BusinessLayer
{
    public interface ISanPhamBLL
    {
        List<Sanpham> GetAllSanPham();
        void ThemSanPham(Sanpham sp);
        void XoaSanPham(string masanpham);
        void SuaSanPham(Sanpham sp);
        List<Sanpham> TimSanPham(Sanpham sp);
    }
}
