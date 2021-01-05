using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;

namespace DOAN1.DataAccessLayer
{
    public interface ISanPhamDAL
    {
        List<Sanpham> GetAllSanPham();
        void ThemSanPham(Sanpham sp);
        void Update(List<Sanpham> list);
    }
}

