using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB
{
    public class QLNV
    {
        public int maNV { get; set; }
        public string tenNV { get; set; }
        public DateTime ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public DateTime ngayvaolam { get; set; }
        public string bangcap { get; set; }
        public string hinhthucNV { get; set; }

        public QLNV(int maNV, string tenNV, DateTime ngaysinh, string gioitinh, string diachi, DateTime ngayvaolam, string bangcap, string hinhthucNV)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.ngayvaolam = ngayvaolam;
            this.bangcap = bangcap;
            this.hinhthucNV = hinhthucNV;
        }
        public double timeworking(int start, int lunchbreak, int end)
        {



            int isLate = 0;
            // Thời gian làm vc = end - start.

            int timeWorking = end - start + lunchbreak;
            // thgian làm vc từ 8-12 tiếng: mỗi giờ thêm được tính bằng
            //2 giờ làm bình thường
            if (timeWorking > 8)
            {
                int extraTime = (timeWorking - 8) * 2;
                //the fuk, where do i put this?
            }
            // thgian < 8h 
            if (timeWorking < 8) { isLate = 8 - timeWorking; }
            // 1. nếu trễ <1.5 tiếng ngày làm vc được tính 1 ngày 
            if (isLate < 1.5)
            {
                return 1;
            }
            // 2. nếu trễ 1.5-2h ngày làm vc được tính 1/2 ngày
            if (isLate >= 1.5 && isLate < 2)
            {
                return 0.5;
            }
            // tre >2 tieng thi  return 0
            if (isLate > 2)
            {
                return 0;
            }
            return -1;

        }
        public double Tinhphep(string dieuKien, int ngayNghi)
        {
            // Nếu thâm niên >= 12 thì 
            double thamnien = ((ngayvaolam - DateTime.Now).TotalDays) / 365;
            int overTheLimit = 0;
            // Ngược lại thâm niên <12 thì ngayphep = thamNien
            if (thamnien < 12)
            {
                overTheLimit = 12;
            }
            // 1. Điều kiện bình thương có ngayphep là 12
            if (dieuKien == "binhthuong")
            {
                overTheLimit = 12 - ngayNghi;
            }
            // 2. điều kiện đặc biệt có ngayphep là 14
            if (dieuKien == "dacbiet")
            {
                overTheLimit = 14 - ngayNghi;
            }
            //3. điều kiện nặng nhọc có ngày phép là 16
            if (dieuKien == "nangnhoc")
            {
                overTheLimit = 16 - ngayNghi;
            }

            // nếu nghỉ quá ngày phép thì tiền phạt = bằng 20% lương tháng
            if (overTheLimit < 0)
            {
                //tru luong
            }
            // nếu ngày nghỉ <0 (tức là đi làm thêm ca) thì những ngày làm thêm lương = 200% lương thông thường
            if (overTheLimit >= 12)
            {
                //gap doi blah bla
            }
            return -1;
        }
        public double TinhPhuCap(string hocVi, string chucDanh, string phongBan)
        {
            double luongHocVi = 0;
            switch (hocVi)
            {
                case "THPT":
                    luongHocVi = 0;
                    break;
                case "Trung cấp":
                    luongHocVi = 2000;
                    break;
                case "Cao đẳng":
                    luongHocVi = 4000;
                    break;
                case "Đại học":
                    luongHocVi = 6000;
                    break;
                case "Thạc sĩ":
                    luongHocVi = 8000;
                    break;
                case "Tiến sĩ":
                    luongHocVi = 10000;
                    break;
            }

            double luongChucDanh = 0;
            switch (chucDanh)
            {
                case "Nhân viên":
                    luongChucDanh = 2000;
                    break;
                case "Phó trưởng phòng":
                    luongChucDanh = 5000;
                    break;
                case "Trưởng phòng":
                    luongChucDanh = 10000;
                    break;
            }

            double luongPhongBan = 0;
            switch (phongBan)
            {
                case "Kinh doanh":
                    luongPhongBan = 5000;
                    break;
                case "Kế toán":
                    luongPhongBan = 5000;
                    break;
                case "Ban giám đốc":
                    luongPhongBan = 20000;
                    break;
                case "Hành chính":
                    luongPhongBan = 10000;
                    break;
                case "Bảo vệ":
                    luongPhongBan = 1000;
                    break;
            }

            return luongHocVi + luongChucDanh + luongPhongBan;
        }
        public double TinhluongParttime(string loaiCV)
        {

            switch (loaiCV)
            {
                case "Van phong":
                    return 19000;
                    break;
                case "San xuat":
                    return 20000;
                    break;

            }
            return -1;
        }
        public double Tinhluong(int soGioLam, int soNgayNghiPhep, double luongGio, double phuCap, double thue)
        {
            double gioLamThucTe = soGioLam - soNgayNghiPhep * 8;
            double luong = luongGio * gioLamThucTe + phuCap - thue;
            return luong;
        }
        public double TinhThue(double luongThang)
        {
            double BHXH = luongThang * 8 / 100;
            double BHYT = luongThang * 1.5 / 100;
            double BHTN = luongThang * 1 / 100;
            double TNCN = luongThang * 10 / 100;

            double thue = BHXH + BHYT + BHTN + TNCN;


            return thue;
        }


    }
}
