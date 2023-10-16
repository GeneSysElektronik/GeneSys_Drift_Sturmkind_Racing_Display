using GeneSysRacing.BaseViewModel;
using System.Collections.Generic;
using System.Linq;

namespace GeneSysRacing.ViewModels.Views
{
	public class OverviewViewModel : RaceStepBaseViewModel
	{
		public PlayerViewModel? LastPlayer { get; }
		public RaceViewModel CurrentRace { get; }
		public List<PlayerViewModel> TopTenCollection { get; }

        public OverviewViewModel(RaceViewModel currentRace, PlayerViewModel? lastPlayer = null)
        {
			CurrentRace	= currentRace;

			RightButtonText = "Neuer Lauf";
			TopTenCollection = new List<PlayerViewModel>(currentRace.AllPlayerCollection.Take(10));
			
			if (lastPlayer != null)
			{
				IsShowOverviewExtensionVisible = true;
				LastPlayer = lastPlayer;
			}
		}
	}
}
