using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_HDT.Cau2
{
    class XeTai:Xe
    {
        public int TrongTaiChoCuaXe { get; set; }

        public override void XuatThongTinXe()
        {
            base.XuatThongTinXe();
            Console.WriteLine("Trong tai cua xe co the cho toi da: {0} kg", TrongTaiChoCuaXe);
        }
        public override void NhapThongTinXe()
        {
            base.NhapThongTinXe();
            Console.WriteLine("Nhap trong tai cua xe co the cho toi da: ");
            TrongTaiChoCuaXe = Convert.ToInt32(Console.ReadLine());
        }

    }
}
