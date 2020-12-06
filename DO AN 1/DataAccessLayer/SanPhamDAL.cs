using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;
namespace DOAN1.DataAccessLayer
{
    public class SanPhamDAL : ISanPhamDAL
    {
        //Xác định đường dẫn của tệp dữ liệu SanPham.txt
        private string txtSanPham = "Data/sanpham.txt";
        //Lấy toàn bộ dữ liệu có trong file SanPham.txt đưa vào một danh sách 
        public List<Sanpham> GetAllSanPham()
        {
            List<Sanpham> list = new List<Sanpham>();
            StreamReader fread = File.OpenText(txtSanPham);
            string s = fread.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new Sanpham(a[0], a[1], a[2], int.Parse(a[3]), int.Parse(a[4]),a[5]));
                }
                s = fread.ReadLine();
            }
            fread.Close();
            return list;
        }
        //Chèn một bản ghi san pham vào tệp
        public void ThemSanPham(Sanpham sp)
        {
            string masanpham = sp.Masp;
            StreamWriter fwrite = File.AppendText(txtSanPham);
            fwrite.WriteLine();
            fwrite.Write(masanpham + "#" + sp.Maloai + "#" + sp.Tensp + "#" + sp.Soluong + "#" + sp.Giaban + "#" + sp.Nhasx);
            fwrite.Close();
        }
        //Cập nhật lại danh sách vào tệp        
        public void Update(List<Sanpham> list)
        {
            StreamWriter fwrite = File.CreateText(txtSanPham);
            for (int i = 0; i < list.Count; ++i)
                fwrite.WriteLine(list[i].Masp + "#" + list[i].Maloai + "#" + list[i].Tensp + "#" + list[i].Soluong + "#" + list[i].Giaban + "#" + list[i].Nhasx);
            fwrite.Close();
        }
    }
}

