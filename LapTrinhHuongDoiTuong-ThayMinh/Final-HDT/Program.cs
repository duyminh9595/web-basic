using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_HDT.Cau1;
using Final_HDT.Cau2;

namespace Final_HDT
{
    class Program
    {
        //dcsa
        static void Main(string[] args)
        {
            while (true)
            {
                int chonCau;
                Console.WriteLine("Moi ban chon cau muon thuc hien: \n1.Cau 1\n2.Cau 2 \n3. Exit");
                chonCau = Convert.ToInt32(Console.ReadLine());
                switch (chonCau)
                {
                    case 1:
                        while (true)
                        {
                            CDate cDate = new CDate();
                            int chooseOptionInputDate;
                            Console.WriteLine("Ban muon kiem tra xem ngay vua nhap co hop la khong bang: \n1.Thu vien DateTime \n2.Khong xai thu vien DateTime");
                            chooseOptionInputDate = Convert.ToInt32(Console.ReadLine());
                            if (chooseOptionInputDate != 1)
                                cDate.NhapNgayThangNamCheckConditionNotUseLibrary();
                            else
                                cDate.NhapNgayThangNamCheckConditionByLibrary();
                            Console.WriteLine("\nNgay vua nhap: ");
                            cDate.HienThiNgayThangNam();
                            int chucnangcau1;
                            while (true)
                            {
                                Console.WriteLine("Ban co muon tang hay giam 1 ngay: \n1.Tang \n2.Giam\n3.Khong thuc hien nua");
                                chucnangcau1 = Convert.ToInt32(Console.ReadLine());
                                if (chucnangcau1 == 1)
                                {
                                    ++cDate;
                                    Console.WriteLine("Ngay sau khi tang 1 ngay");
                                    cDate.HienThiNgayThangNam();
                                }
                                else if (chucnangcau1 == 2)
                                {
                                    --cDate;
                                    Console.WriteLine("Ngay sau khi giam 1 ngay");
                                    cDate.HienThiNgayThangNam();
                                }
                                else
                                    break;
                            }
                            cDate.HienThiNgayThangNam();
                            Console.WriteLine("Ban co muon tiep tuc thuc hien cau 1 khong: \n1.Co \n2.Khong");
                            int cau1;
                            cau1 = Convert.ToInt32(Console.ReadLine());
                            if (cau1 != 1)
                                break;
                        }
                        
                        break;
                    case 2:
                        List<Xe> danhSachXe = new List<Xe>();
                        XeKhach xeKhach;
                        XeTai xeTai;
                        int loaixe;
                        while(true)
                        {
                            Console.WriteLine("Moi ban chon muon nhap loai xe nao: \n1. Xe khach \n2.Xe tai");
                            loaixe = Convert.ToInt32(Console.ReadLine());
                            switch (loaixe)
                            {
                                case 1:
                                    xeKhach = new XeKhach();
                                    xeKhach.NhapThongTinXe();
                                    danhSachXe.Add(xeKhach);
                                    break;
                                case 2:
                                    xeTai = new XeTai();
                                    xeTai.NhapThongTinXe();
                                    danhSachXe.Add(xeTai);
                                    break;
                                default:
                                    Console.WriteLine("Loai xe muon nhap khong hop le.");
                                    break;
                            }
                            Console.WriteLine("Ban co muon tiep thuc them xe vao danh sach khong: \n1. Co \n2.Khong");
                            int checkThemXe;
                            checkThemXe = Convert.ToInt32(Console.ReadLine());
                            if (checkThemXe != 1)
                                break;
                        }
                        List<XeKhach> danhsachXeKhach = new List<XeKhach>();
                        foreach (Xe item in danhSachXe)
                        {
                            if (item is XeKhach xeKhachData)
                            {
                                danhsachXeKhach.Add(xeKhachData);
                            }
                        }
                        danhsachXeKhach.Sort(new XeKhachCompare());
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Danh sach xe khach gom:");
                        foreach (XeKhach i in danhsachXeKhach)
                        {
                            i.XuatThongTinXe();
                        }
                        Console.WriteLine("********************************************");
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                
            }
            Console.ReadKey();
            
        }
    }
}
