using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemCuu.Models
{
    public class Sheep
    {
        public Sheep()
        {
            
        }

        public Sheep(float _khoiLuong, int _color, float _khoiLuongLong)
        {
            KhoiLuong = _khoiLuong;
            ColorIdx = _color;
            KhoiLuongLong = _khoiLuongLong;
        }

        public float KhoiLuong { get; set; }
        public int ColorIdx { get; set; }
        public float KhoiLuongLong { get; set; }

    }
}
