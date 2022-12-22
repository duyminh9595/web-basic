// Final-CTDL.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
using namespace std;
#include <iostream>
#include<string>
const int constantNumber=10000 ;
struct SinhVien {
    string sinhvienMSSV;
    string sinhvienHoTen;
    float sinhvienDiemTongKet;
    int sinhvienNamSinh;
    string  sinhvienDiaChiLuuTru;
};
struct NodeSinhVien
{
    SinhVien sv;
    NodeSinhVien* next=nullptr;
};
class HashTableSinhVien {
    private:
        NodeSinhVien* hashtable[constantNumber];
    public:
        HashTableSinhVien()
        {
            for (int i = 0; i < constantNumber; i++)
            {
                hashtable[i]=nullptr;
            }
        }
        int convertStringToASCII(string mssv)
        {
            int mssvToInt = 0;
            for (int i = 0; i < mssv.size(); i++)
            {
                char x = mssv.at(i);
                mssvToInt += (int)x;
            }
            return mssvToInt;
        }
        int HashFunc(int k)
        {
            return k % constantNumber;
        }
        void AddSv(SinhVien sv,int& count)
        {
            int hash = HashFunc(convertStringToASCII(sv.sinhvienMSSV));
            if (hashtable[hash]==nullptr)
            {
                hashtable[hash] = new NodeSinhVien;
                hashtable[hash]->sv.sinhvienMSSV = sv.sinhvienMSSV;
                hashtable[hash]->sv.sinhvienHoTen = sv.sinhvienHoTen;
                hashtable[hash]->sv.sinhvienDiemTongKet = sv.sinhvienDiemTongKet;
                hashtable[hash]->sv.sinhvienNamSinh = sv.sinhvienNamSinh;
                hashtable[hash]->sv.sinhvienDiaChiLuuTru = sv.sinhvienDiaChiLuuTru;
                cout << "***************************************" << endl;
                cout << "Them sinh vien ma so: " << sv.sinhvienMSSV << " thanh cong" << endl;
                cout << "***************************************" << endl;
                ++count;
            }
            else
            {
                NodeSinhVien* ptr = nullptr;
                ptr = hashtable[hash];
                bool isAdd = true;
                NodeSinhVien* ptrPrev = nullptr;
                while (ptr != nullptr)
                {
                    if (ptr->sv.sinhvienMSSV.compare(sv.sinhvienMSSV) == 0)
                    {
                        isAdd = false;
                        break;
                    }
                    ptrPrev = ptr;
                    ptr = ptr->next;
                }
                if (isAdd)
                {
                    ptr = new NodeSinhVien;
                    ptr->sv.sinhvienMSSV = sv.sinhvienMSSV;
                    ptr->sv.sinhvienHoTen = sv.sinhvienHoTen;
                    ptr->sv.sinhvienDiemTongKet = sv.sinhvienDiemTongKet;
                    ptr->sv.sinhvienNamSinh = sv.sinhvienNamSinh;
                    ptr->sv.sinhvienDiaChiLuuTru = sv.sinhvienDiaChiLuuTru;
                    ptrPrev->next = ptr;
                    cout << "***************************************" << endl;
                    cout << "Them sinh vien ma so: " << sv.sinhvienMSSV << " thanh cong" << endl;
                    cout << "***************************************" << endl;
                    ++count;
                }
                else
                {
                    cout << "***************************************" << endl;
                    cout << "Sinh vien ma so: " << sv.sinhvienMSSV << " da co trong he thong, khong the them." << endl;
                    cout << "***************************************" << endl;
                }
            }
        }
        NodeSinhVien* chonKSinhVien(int numRand, int numberSvHasPickedInBucket)
        {
            if (hashtable[numRand]==nullptr)
            {
                return nullptr;
            }
            else
            {
                NodeSinhVien* head = hashtable[numRand];
                NodeSinhVien* curr = head;
                int countInBucket = 1;
                if (numberSvHasPickedInBucket == 0)
                    return curr;
                while (countInBucket <= numberSvHasPickedInBucket && curr->next != nullptr)
                {
                    ++countInBucket;
                    curr = curr->next;
                }
                if (countInBucket-1 != numberSvHasPickedInBucket)
                    return nullptr;
                else
                    return curr;
            }
        }
        void SearchSv(string mssv)
        {
            int hash = HashFunc(convertStringToASCII(mssv));
            SinhVien sv;
            if (hashtable[hash]==NULL)
            {
                cout << "Sinh vien voi ma so: " << mssv << " khong ton tai. " << endl;
            }
            else
            {
                if (hashtable[hash]->sv.sinhvienMSSV.compare(mssv) == 0)
                {
                    sv = hashtable[hash]->sv;
                    printSinhVienInfo(sv);
                    return;
                }
                NodeSinhVien* ptr = nullptr;
                ptr = hashtable[hash]->next;
                bool check = false;
                while (ptr != nullptr)
                {
                    if (ptr->sv.sinhvienMSSV.compare(mssv) == 0)
                    {
                        sv = ptr->sv;
                        printSinhVienInfo(sv);
                        check = true;
                        break;
                    }
                    else
                        ptr = ptr->next;
                }
                if(!check)
                    cout << "Sinh vien voi ma so: " << mssv << " khong ton tai. " << endl;
            }
        }
        void printSinhVienInfo(const SinhVien& sv) {
            cout << "Ma so sinh vien:" << sv.sinhvienMSSV << endl;
            cout << "Ho ten: " << sv.sinhvienHoTen << endl;
            cout << "Diem tong ket: " << sv.sinhvienDiemTongKet << endl;
            cout << "Nam sinh: " << sv.sinhvienNamSinh << endl;
            cout << "Dia chi luu tru: " << sv.sinhvienDiaChiLuuTru << endl;
        }
};
void themSinhVien(SinhVien& sv);
int main()
{
    HashTableSinhVien hashTableSv;
    string mssv;
    int c;
    int count = 0;
    int k = 0;
    SinhVien sv;
    while (1) {
        
        cout << "***************************************" << endl;
        cout <<"So luong sinh vien da them: "<< count << endl;
        cout << "1.Them sinh vien vao hashtable" << endl;
        cout << "2.In sinh vien tu hashtable" << endl;
        cout << "3.Chon k sinh vien tu n sinh vien da nhap" << endl;
        cout << "4.Exit" << endl;
        cout << "***************************************" << endl;
        cout << "Enter your choice: ";
        cin >> c;
        cout << "***************************************" << endl;
        switch (c) {
        case 1:
            cout << "Moi ban nhap thong tin sinh vien can them:" << endl;
            themSinhVien(sv);
            hashTableSv.AddSv(sv,count);
            break;
        case 2:
            cout << "Moi ban nhap ma so sinh vien can tim" << endl;
            cin >> mssv;
            hashTableSv.SearchSv(mssv);
            break;
        case 3:
            cout << "Moi ban nhap so luong k sinh vien" << endl;
            cin >> k;
            if (k < 0 || k >= count)
            {
                cout << "So luong sinh vien muon chon khong hop le." << endl;
            }
            else
            {
                int *hashArraysSvChon=new int[constantNumber];
                NodeSinhVien* headSvChon = nullptr;
                NodeSinhVien* ptr = headSvChon;
                NodeSinhVien* curr = headSvChon;
                int numberSvPicked = 0;
                int numRand = -1;
                while (numberSvPicked < k)
                {
                    numRand = rand() % constantNumber;
                    if (hashArraysSvChon[numRand] < 0) hashArraysSvChon[numRand] = 0;
                    curr = hashTableSv.chonKSinhVien(numRand, hashArraysSvChon[numRand]);
                    if (curr == nullptr)
                        continue;
                    else
                    {
                        if (headSvChon == nullptr)
                        {
                            headSvChon = new NodeSinhVien;
                            headSvChon->sv=curr->sv;
                            ptr = headSvChon;
                        }
                        else
                        {
                            ptr->next = new NodeSinhVien;
                            ptr->next->sv = curr->sv;
                            ptr = ptr->next;
                        }
                        ++hashArraysSvChon[numRand];
                        numberSvPicked++;
                    }
                    
                }
                curr = headSvChon;
                cout << "Thu tu sinh vien duoc chon gom: " << endl;
                int count = 1;
                while (curr != nullptr)
                {
                    cout << "-----------------------------" << endl;
                    cout << "Sinh vien thu "<<count++ << endl;
                    hashTableSv.printSinhVienInfo(curr->sv);
                    cout << "-----------------------------" << endl;
                    curr = curr->next;
                }
                delete[] hashArraysSvChon;
            }
            break;
        case 4:
            exit(1);
        default:
            cout << "\nEnter correct option\n";
        }
    }
    return 0;
}
void themSinhVien(SinhVien& sv)
{
    cout << "Nhap ma so sinh vien:" << endl;
    cin >> sv.sinhvienMSSV;
    cout << "Nhap ho ten: " << endl;
    string tensv;
    cin.ignore();
    getline(cin, tensv);
    sv.sinhvienHoTen=tensv;
    cout << "Nhap diem tong ket: " << endl;
    cin >> sv.sinhvienDiemTongKet;
    cout << "Nhap nam sinh: " << endl;
    cin >> sv.sinhvienNamSinh;
    cout << "Nhap dia chi luu tru: " << endl;
    string diachiluutru;
    cin.ignore();
    getline(cin, diachiluutru);
    sv.sinhvienDiaChiLuuTru = diachiluutru;
}