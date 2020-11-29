using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;

namespace DOAN1.BusinessLayer
{
    public interface IKhachHangBLL
    {
        List<Khachhang > GetAllKhachHang();
        void ThemKhachHang(Khachhang kh);
        void XoaKhachHang(string makhachhang);
        void SuaKhachHang(Khachhang kh);
        List<Khachhang> TimKhachHang(Khachhang kh);
    }
}
