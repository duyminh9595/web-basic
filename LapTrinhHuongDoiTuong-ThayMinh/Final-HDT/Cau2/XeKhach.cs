using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_HDT.Cau2
{
    class XeKhach : Xe
    {
        public int SoGhe { get; set; }

        public override void XuatThongTinXe()
        {
            base.XuatThongTinXe();
            Console.WriteLine("So ghe cua xe: {0} ", SoGhe);
        }
        public override void NhapThongTinXe()
        {
            base.NhapThongTinXe();
            Console.WriteLine("Nhap so ghe cua xe khach: ");
            SoGhe = Convert.ToInt32(Console.ReadLine());
        }
        

    }
}
