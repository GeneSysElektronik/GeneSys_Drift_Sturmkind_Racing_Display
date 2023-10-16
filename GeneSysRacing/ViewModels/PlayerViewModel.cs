using CsvHelper.Configuration.Attributes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GeneSysRacing.ViewModels
{
	public class PlayerViewModel : ReactiveObject
	{
		#region private meber
		private IEnumerable<LapTimeViewModel> _lapTimes = new List<LapTimeViewModel>();
        private LapTimeViewModel? _lapRecord;
		#endregion

		#region public member
        public int Rank { get; set; }
		public LapTimeViewModel? LapRecord
        {
            get => _lapRecord;
            set => this.RaiseAndSetIfChanged(ref _lapRecord, value);
        }



        private string _name = string.Empty;
		public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

		public string EMail { get; set; } = string.Empty;
		public string Company { get; set; } = string.Empty;
		public IEnumerable<LapTimeViewModel> LapTimes
        {
            get => _lapTimes;
            set => this.RaiseAndSetIfChanged(ref _lapTimes, value);
        }

        [Ignore]
        public long LapsCompleted { get; set; }
        #endregion

        #region constructor
        public PlayerViewModel()
        {
            
        }
        public PlayerViewModel(string name, string email, string company)
        {
            Name = name;
			EMail = email;
			Company = company;
        }
        public PlayerViewModel(string name)
        {
            Name = name;
        }
        public PlayerViewModel(PlayerViewModel player)
        {
			Name = player.Name;
			EMail = player.EMail;
			Company = player.Company;
		}
        #endregion

        #region public methods
        public void LapFinished(TimeSpan? time)
        {
            if (time == null) return;

            var lapTimes = LapTimes.ToList();
            lapTimes.Add(new(lapTimes.Count + 1, time.Value));
            LapRecord = lapTimes.First(lap => lap.Time == lapTimes.Select(lap => lap.Time).Min());

			foreach (var lapTime in lapTimes)
				lapTime.IsFastestLap = lapTime.Time == LapRecord.Time;

			LapTimes = new List<LapTimeViewModel>(lapTimes);
        }
		#endregion
	}
}
