using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_HDT.Cau1
{
    class CDate
    {
        private int _ngay;
        private int _thang;
        private int _nam;
        public int Thang
        {
            get { return _thang; }
            set
            {
                if (value >= 1 && value <= 12)
                {
                    _thang = value;
                }
            }
        }
        public int Nam
        {
            get { return _nam; }
            set
            {
                if (value > 0 && value <= 2099)
                {
                    _nam = value;
                }
            }
        }
        public int Ngay
        {
            get { return _ngay; }
            set
            {
                if (value > 0 && value <= 31)
                {
                    _ngay = value;
                }
            }
        }
        public void HienThiNgayThangNam()
        {
            Console.Write("{0}-{1}-{2}\n", _ngay, _thang, _nam);
        }
        public void NhapNgayThangNamCheckConditionByLibrary()
        {
            while (true)
            {
                Console.WriteLine("Moi ban nhap ngay: ");
                _ngay = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Moi ban nhap thang: ");
                _thang = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Moi ban nhap nam: ");
                _nam = Convert.ToInt32(Console.ReadLine());
                String txtDate = _thang + "/" + _ngay + "/" + _nam;
                if (IsDateTime(txtDate))
                {
                    break;
                }
                Console.WriteLine("Ngay thang nam nhap khong hop le. Vui long nhap lai.");
            }
        }
        public static bool IsDateTime(string txtDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }
        public void NhapNgayThangNamCheckConditionNotUseLibrary()
        {
            int dateInMonth;
            while (true)
            {
                Console.WriteLine("Moi ban nhap ngay: ");
                _ngay = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Moi ban nhap thang: ");
                _thang = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Moi ban nhap nam: ");
                _nam = Convert.ToInt32(Console.ReadLine());
                if (_nam == 0)
                {
                    Console.WriteLine("Nam nhap khong hop le. Vui long nhap lai.");
                    continue;
                }
                if (_thang == 0)
                {
                    Console.WriteLine("Thang nhap khong hop le. Vui long nhap lai.");
                    continue;
                }
                if (_ngay == 0)
                {
                    Console.WriteLine("Ngay nhap khong hop le. Vui long nhap lai.");
                    continue;
                }
                bool checkNamNhuan = TemplateDateMonth.CheckNamNhuan(_nam);
                if (!checkNamNhuan)
                {
                    dateInMonth = TemplateDateMonth.dateMonth[_thang - 1];
                    if (_ngay > 0 && _ngay <= dateInMonth)
                    {
                        break;
                    }
                }
                else
                {
                    if (_thang == 2)
                    {
                        dateInMonth = TemplateDateMonth.dateMonth[12];
                        if (_ngay > 0 && _ngay <= dateInMonth)
                        {
                            break;
                        }
                    }
                    else
                    {
                        dateInMonth = TemplateDateMonth.dateMonth[_thang - 1];
                        if (_ngay > 0 && _ngay <= dateInMonth)
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("Ngay thang nam nhap khong hop le. Vui long nhap lai.");
            }
        }
        public static CDate operator ++(CDate cDate)
        {
            CDate newcDate = cDate;
            bool checkNamNhuan = TemplateDateMonth.CheckNamNhuan(cDate.Nam);
            if (!checkNamNhuan)
            {
                int _ngayTemporary = newcDate.Ngay;
                if (_ngayTemporary >= TemplateDateMonth.dateMonth[newcDate.Thang-1])
                {
                    newcDate.Ngay = 1;
                    if (newcDate.Thang == 12)
                    {
                        ++newcDate.Nam;
                        newcDate.Thang = 1;
                    }
                    else
                    {
                        ++newcDate.Thang;
                    }
                }
                else
                    ++newcDate.Ngay;
            }
            else
            {
                int _ngayTemporary = newcDate.Ngay;
                if (newcDate.Thang == 2)
                {
                    if (_ngayTemporary >= TemplateDateMonth.dateMonth[12])
                    {
                        newcDate.Ngay = 1;
                        if (newcDate.Thang == 12)
                        {
                            ++newcDate.Nam;
                            newcDate.Thang = 1;
                        }
                        else
                        {
                            ++newcDate.Thang;
                        }
                    }
                    else
                    {
                        ++newcDate.Ngay;
                    }
                }
                else
                {
                    if (_ngayTemporary > TemplateDateMonth.dateMonth[newcDate.Thang])
                    {
                        newcDate.Ngay = 1;
                        if (newcDate.Thang == 12)
                        {
                            ++newcDate.Nam;
                            newcDate.Thang = 1;
                        }
                        else
                        {
                            ++newcDate.Thang;
                        }
                    }
                    else
                        ++newcDate.Ngay;
                }
            }
            return newcDate;
        }
        public static CDate operator --(CDate cDate)
        {
            CDate newcDate = cDate;
            bool checkNamNhuan = TemplateDateMonth.CheckNamNhuan(cDate.Nam);

            int _ngayTemporary = --newcDate.Ngay;
            if (!checkNamNhuan)
            {
                if (_ngayTemporary <= 0)
                {
                    if (newcDate.Thang == 1)
                    {
                        newcDate.Ngay = TemplateDateMonth.dateMonth[11];
                        newcDate.Thang = 12;
                        --newcDate.Nam;
                    }
                    else if(newcDate.Thang==3)
                    {
                        --newcDate.Thang;
                        newcDate.Ngay = TemplateDateMonth.dateMonth[newcDate.Thang-1];
                    }
                    else
                    {
                        --newcDate.Thang;
                        newcDate.Ngay = TemplateDateMonth.dateMonth[newcDate.Thang-1]; 
                    }
                }
            }
            else
            {
                if (newcDate.Thang == 3)
                {
                    if (_ngayTemporary <= 0)
                    {
                        newcDate.Ngay = TemplateDateMonth.dateMonth[12];
                        --newcDate.Thang;
                    }
                }
                else
                {
                    if (_ngayTemporary <= 0)
                    {
                        if (newcDate.Thang == 1)
                        {
                            newcDate.Ngay = TemplateDateMonth.dateMonth[11];
                            newcDate.Thang = 12;
                            --newcDate.Nam;
                        }
                        else
                        {
                            newcDate.Ngay = 1;
                            --newcDate.Thang;
                        }
                    }
                }
            }
            return newcDate;
        }
    }
}
