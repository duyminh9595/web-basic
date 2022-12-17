using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_HDT.Cau1
{
    class TemplateDateMonth
    {
        public static int[] dateMonth ={
            31,28,31,30,31,30,31,31,30,31,30,31,29
        };
        public static bool CheckNamNhuan(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            return false;
        }
    }
}
