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

        public DonHangStatus Status { get; set; }

        public int SoLuong { get; set; }

        public DateTime ThoiGianDat { get; set; }

        public DateTime? ThoiGianHoanThien { get; set; }

        public string getStatusName
        {
            get
            {
                return StatusName[(int)this.Status];
            }
        }

        public List<Sheep> dsSheep { get; set; } = new List<Sheep>();
    }

    public enum DonHangStatus
    {
        WAITING = 0,
        IN_PROGRESS = 1,
        FINISHED = 2
    }
}
