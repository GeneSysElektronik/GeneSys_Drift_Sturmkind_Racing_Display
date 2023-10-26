using Avalonia.Media;
using GeneSysRacing.BaseViewModel;
using GeneSysRacing.Models;
using Newtonsoft.Json.Linq;
using ReactiveUI;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Templates;

namespace GeneSysRacing.ViewModels.Views
{
	public class CurrentRunViewModel : RaceStepBaseViewModel
	{
		private string _lapInformation;
		private long _lapsCompleted;
		private bool _singlePlayerFinished;

		private readonly System.Timers.Timer _updateLapTimes = new()
		{
			AutoReset = true,
			Interval = 1000
		};

		public Geometry QuestionmarkIcon { get; } = GeometryPathData.GetIconPath(IconKey.InfoAndLicensing);

		public RaceViewModel CurrentRace { get; }
		
		public string LapInformation
		{
			get => _lapInformation;
			set => this.RaiseAndSetIfChanged(ref _lapInformation, value);
		}
		
		public CurrentRunViewModel(RaceViewModel currentRace, PlayerViewModel currentPlayer)
		{
			LeftButtonText = "Abbruch";
			RightButtonText = "Finish";

			_updateLapTimes.Elapsed += UpdateRaceInformationCallback;

			CurrentRace = currentRace;
			CurrentPlayer = currentPlayer;
			_lapInformation = $"0/{currentRace.MaxLaps}";
		}
        public CurrentRunViewModel(RaceViewModel currentRace)
        {
			LeftButtonText = "Abbruch";
			RightButtonText = "Finish";

			_updateLapTimes.Elapsed += UpdateRaceInformationCallback;

			CurrentRace = currentRace;
			_lapInformation = $"0/{currentRace.MaxLaps}";
		}
        
		private async void UpdateRaceInformationCallback(object? sender, ElapsedEventArgs e)
		{
			if (await WebCommunicationModel.TryGetResponseAsync(CurrentRace) is not JArray multiPlayerStatus) return;

			if (CurrentRace.IsMultiplayerSelected)
			{
				MultiplayerCollection ??= new();

				foreach (var playerStatus in multiPlayerStatus)
				{
					string userName = playerStatus?.Value<string>("user_name") ?? string.Empty;
					if (!MultiplayerCollection.Any(player => player.Name == userName))
						MultiplayerCollection.Add(new(userName));

					var player = MultiplayerCollection.First(player => player.Name == userName);

					var maxLaps = playerStatus?["enter_data"]?.Value<long>("lap_count") ?? 0;
					long lapsCompleted = playerStatus?.Value<long>("laps_completed") ?? 0;
					if (lapsCompleted >= maxLaps) continue;

					if (!double.TryParse(playerStatus?.Value<string?>("last_lap")?.Replace('.', ','), out double lastLapSeconds))
					{
						player.LapsCompleted = 0;
						continue;
					}

					TimeSpan lastLapTime = lastLapSeconds > 0 ? TimeSpan.FromSeconds(lastLapSeconds) : TimeSpan.MaxValue;

					if (player.LapsCompleted < lapsCompleted)
					{
						player.LapFinished(lastLapTime);
						player.LapsCompleted = lapsCompleted;
					}
				}

				var backup = MultiplayerCollection.ToList();
				backup.Sort((a, b) =>
				{
					if (a.LapRecord != null && b.LapRecord != null)
						return a.LapRecord.Time.CompareTo(b.LapRecord.Time);
					else if (a.LapRecord != null)
						return -1;
					else if (b.LapRecord != null)
						return 1;
					else
						return 0;
				});
				for (int i = 0; i < backup.Count; i++)
					backup[i].Rank = i + 1;
				MultiplayerCollection = new(backup);
			}
			else
			{
				var singlePlayerStatus = multiPlayerStatus[0];
				
				long lapsCompleted = singlePlayerStatus.Value<long>("laps_completed");
				if (!double.TryParse(singlePlayerStatus.Value<string?>("last_lap")?.Replace('.', ','), out double lastLapSeconds)) return;
				TimeSpan lastLapTime = lastLapSeconds > 0 ? TimeSpan.FromSeconds(lastLapSeconds) : TimeSpan.MaxValue;

				if (_lapsCompleted < lapsCompleted)
				{
					CurrentPlayer?.LapFinished(lastLapTime);
					_lapsCompleted = lapsCompleted;
				}
				if (_lapsCompleted == CurrentRace.MaxLaps)
					_singlePlayerFinished = true;

				LapInformation = $"{_lapsCompleted + 1}/{CurrentRace.MaxLaps}";
			}
		}
		public async Task WaitForFinishAsync(CancellationToken token)
		{
			_updateLapTimes.Start();
			while (!_singlePlayerFinished && !token.IsCancellationRequested)
				await Task.Delay(1000, CancellationToken.None);
			_updateLapTimes.Stop();
			_updateLapTimes.Elapsed -= UpdateRaceInformationCallback;
		}
	}
}
