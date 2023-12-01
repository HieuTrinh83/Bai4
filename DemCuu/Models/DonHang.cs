using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemCuu.Models
{
    public class DonHang
    {
        public short Status { get; set; }

        public int SoLuong { get; set; }

        public DateTime ThoiGianDat { get; set; }

        public DateTime ThoiGianHoanThien { get; set; }
    }
}
