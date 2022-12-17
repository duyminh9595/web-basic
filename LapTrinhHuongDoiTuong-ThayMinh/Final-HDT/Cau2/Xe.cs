using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_HDT.Cau2
{
    class Xe
    {
        public int TocDo { get; set; }
        public string BienSo { get; set; }
        public string HangSanXuat { get; set; }
        public virtual void NhapThongTinXe()
        {
            Console.WriteLine("Moi ban toc do cua xe: ");
            TocDo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Moi ban nhap bien so cua xe: ");
            BienSo = Console.ReadLine();
            Console.WriteLine("Moi ban nhap hang san xuat em: ");
            HangSanXuat = Console.ReadLine();
        }
        public virtual void XuatThongTinXe()
        {
            Console.WriteLine("\nToc do: {0}",TocDo);
            Console.WriteLine("Bien so: {0}", BienSo);
            Console.WriteLine("Hang san xuat {0}", HangSanXuat);
        }
    }
}
