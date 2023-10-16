using Avalonia.Media;
using GeneSysRacing.BaseViewModel;
using GeneSysRacing.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Templates;

namespace GeneSysRacing.ViewModels.Views
{
	public class StartRunViewModel : RaceStepBaseViewModel
	{
		public RaceViewModel CurrentRace { get; }

		public Geometry QuestionmarkIcon { get; } = GeometryPathData.GetIconPath(IconKey.InfoAndLicensing);

		public event EventHandler? ExistingPlayerFoundEvent;
		
		public StartRunViewModel(RaceViewModel currentRace, PlayerViewModel currentPlayer)
        {
			CurrentRace = currentRace;
			CurrentPlayer = currentPlayer;

			LeftButtonText = "Abbruch";
		}
        public StartRunViewModel(RaceViewModel currentRace)
        {
			CurrentRace = currentRace;

			LeftButtonText = "Abbruch";
		}

		public async Task StartRunAsync(CancellationToken token)
		{
			if (CurrentPlayer != null && CurrentRace.AllPlayerCollection.Find(player => player.Name == CurrentPlayer.Name) is PlayerViewModel existingPlayer)
			{
				CurrentPlayer = existingPlayer;
				ExistingPlayerFoundEvent?.Invoke(this, EventArgs.Empty);
			}

			await WebCommunicationModel.ResetServer(CurrentRace);

			while (!token.IsCancellationRequested)
			{
				try
				{
					if (await WebCommunicationModel.TryGetResponseAsync(CurrentRace) is JArray playerStatus && playerStatus.Count > 0)
						break;
				}
				finally
				{
					await Task.Delay(1000, CancellationToken.None);
				}
			}
		}
	}
}
