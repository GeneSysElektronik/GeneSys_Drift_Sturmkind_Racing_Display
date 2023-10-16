using System;

namespace GeneSysRacing.Models
{
    public class LapModel
    {
        public int Lap { get; }
        public TimeSpan Time { get; }
        public bool IsFastestLap { get; set; }

        public LapModel(int lap, TimeSpan time)
        {
            Lap = lap;
            Time = time;
        }
    }
}
