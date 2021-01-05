using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;

namespace DOAN1.DataAccessLayer
{
    public interface IKhachHangDAL
    {
        List<Khachhang> GetAllKhachHang();
        void ThemKhachHang(Khachhang kh);
        void Update(List<Khachhang> list);
    }
}

