using GeneSysRacing.BaseViewModel;

namespace GeneSysRacing.ViewModels.Views
{
	public class NewRunViewModel : RaceStepBaseViewModel
	{
		public RaceViewModel CurrentRace { get; }

		public NewRunViewModel(RaceViewModel currentRace, PlayerViewModel currentPlayer)
        {
			LeftButtonText = "Abbruch";
			RightButtonText = "Start";

			CurrentRace = currentRace;
			CurrentPlayer = currentPlayer;
		}
	}
}
