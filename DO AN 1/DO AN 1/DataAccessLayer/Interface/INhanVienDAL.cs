using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;

namespace DOAN1.DataAccessLayer
{
    public interface INhanVienDAL
    {
        List<NhanVien> GetAllNhanVien();
        void ThemNhanVien(NhanVien nv);
        void Update(List<NhanVien> list);
    }
}

