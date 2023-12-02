using System;
using System.Collections.Generic;

namespace DemCuu.Models
{
    public class DonHang
    {
        private static List<string> StatusName = new List<string>() { "Waiting", "In progress", "Finished" };

        public int Stt { get; set; }

        public string TenKhachHang { get; set; }

        public string Phone {  get; set; }

        public short Status { get; set; }

        public int SoLuong { get; set; }

        public DateTime ThoiGianDat { get; set; }

        public DateTime? ThoiGianHoanThien { get; set; }

        public string getStatusName
        {
            get
            {
                return StatusName[this.Status];
            }
        }
    }

    enum DonHangStatus
    {
        WAITING,
        IN_PROGRESS,
        FINISHED
    }
}
