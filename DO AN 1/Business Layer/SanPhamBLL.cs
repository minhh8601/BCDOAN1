using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;
using DOAN1.DataAccessLayer;

namespace DOAN1.BusinessLayer
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại sản phẩm BLL
    public class SanPhamBLL : ISanPhamBLL
    {
        private ISanPhamDAL spDA = new SanPhamDAL();
        //Thực thi các yêu cầu
        public List<Sanpham> GetAllSanPham()
        {
            return spDA.GetAllSanPham();
        }
        public void ThemSanPham(Sanpham sp)
        {
            if (!string.IsNullOrEmpty(sp.Tensp))
            {
                //Tiến hành chuẩn hóa dữ liệu nếu cần
                spDA.ThemSanPham(sp);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void XoaSanPham(string masanpham)
        {
            int i;
            List<Sanpham> list = GetAllSanPham();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Masp == masanpham) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                spDA.Update(list);
            }
        }
        public void SuaSanPham(Sanpham sp)
        {
            int i;
            List<Sanpham> list = GetAllSanPham();
            for (i = 0; i < list.Count; ++i)
                if (list[i].Masp == sp.Masp) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(sp);
                spDA.Update(list);
            }
        }
        public List<Sanpham> TimSanPham(Sanpham sp)
        {
            List<Sanpham> list = GetAllSanPham();
            List<Sanpham> kq = new List<Sanpham>();
            if (string.IsNullOrEmpty(sp.Masp) &&
                string.IsNullOrEmpty(sp.Maloai) &&
                string.IsNullOrEmpty(sp.Tensp) &&
                sp.Soluong ==0 &&
                sp.Giaban == 0 &&
                string.IsNullOrEmpty(sp.Nhasx ))             
            {
                kq = list;
            }
            if (!string.IsNullOrEmpty(sp.Tensp))
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Tensp.IndexOf(sp.Tensp) >= 0)
                    {
                        kq.Add(new Sanpham(list[i]));
                    }
            }

            //Tim theo ma khach hang
            else if (sp.Masp!= "")
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Masp  == sp.Masp)
                    {
                        kq.Add(new Sanpham(list[i]));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}
