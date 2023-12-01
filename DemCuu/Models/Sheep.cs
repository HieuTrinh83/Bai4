using System;

namespace DemCuu.Models
{
    public class Sheep
    {
        public Sheep()
        {
            
        }

        public Sheep(int stt, float khoiLuong, int colorIdx, float khoiLuongLong, DateTime start, DateTime end)
        {
            Stt = stt;
            KhoiLuong = khoiLuong;
            ColorIdx = colorIdx;
            KhoiLuongLong = khoiLuongLong;
            Start = start;
            End = end;
        }
        public int Stt { get; set; }
        public float KhoiLuong { get; set; }
        public int ColorIdx { get; set; }
        public float KhoiLuongLong { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public TimeSpan ProcessTime { 
            get {
                return End - Start;
            } 
        }

    }
}
