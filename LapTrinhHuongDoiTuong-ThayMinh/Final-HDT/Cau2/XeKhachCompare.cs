using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_HDT.Cau2
{
    class XeKhachCompare : Comparer<XeKhach>
    {
        public override int Compare(XeKhach x, XeKhach y)
        {
            if (x.SoGhe > y.SoGhe)
                return 1;
            return 0;
        }
    }
}
