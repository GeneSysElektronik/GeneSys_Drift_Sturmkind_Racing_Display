using System;
using CsvHelper.Configuration.Attributes;

namespace GeneSysRacing.ViewModels
{
	public class LapTimeViewModel
	{
		[Ignore]
		public int Lap { get; }
		
		public TimeSpan Time { get; }

		[Ignore]
		public string DisplayTimeSpan { get; }

		[Ignore]
		public bool IsFastestLap { get; set; }

		public LapTimeViewModel(int lap, TimeSpan actualTimeSpan)
        {
            Lap = lap;
			Time = actualTimeSpan;
            DisplayTimeSpan = GetDisplayString(actualTimeSpan);
        }

        private string GetDisplayString(TimeSpan actualTimeSpan)
        {
			return $"{actualTimeSpan.Minutes:D2}:{actualTimeSpan.Seconds:D2}:{actualTimeSpan.Milliseconds:D3}";
		}
    }
}
