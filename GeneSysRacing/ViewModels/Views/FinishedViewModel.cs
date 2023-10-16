using GeneSysRacing.BaseViewModel;
using System.Collections.Generic;
using System.Linq;

namespace GeneSysRacing.ViewModels.Views
{
	public class FinishedViewModel : RaceStepBaseViewModel
	{
		#region Private Members
		private readonly RaceViewModel _currentRace;
		#endregion

		#region Constructors
		public FinishedViewModel(RaceViewModel currentRace, PlayerViewModel currentPlayer)
        {
			IsShowFinishedExtensionVisible = true;
			RightButtonText = "Rennübersicht";

			_currentRace = currentRace;
			CurrentPlayer = currentPlayer;
		}
        public FinishedViewModel(RaceViewModel currentRace)
        {
			RightButtonText = "Rennübersicht";

			_currentRace = currentRace;
		}
		#endregion

		#region Public Methods
		public PlayerViewModel? AddPlayerToCollection(PlayerViewModel currentPlayer)
		{
			var existingPlayer = _currentRace.AllPlayerCollection.Find(x => x.Name == currentPlayer.Name);
			if (existingPlayer == null)
				_currentRace.AllPlayerCollection.Add(currentPlayer);

			_currentRace.AllPlayerCollection.Sort((a, b) =>
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

			for (int i = 0; i < _currentRace.AllPlayerCollection.Count; i++)
				_currentRace.AllPlayerCollection[i].Rank = i + 1;

			_currentRace.TopTenCollection = new List<PlayerViewModel>(_currentRace.AllPlayerCollection.Take(10));

			if (_currentRace.TopTenCollection.FirstOrDefault()?.LapRecord is LapTimeViewModel lapRecord)
				_currentRace.LapRecord = lapRecord;

			return _currentRace.AllPlayerCollection.Find(player => player.Name == currentPlayer.Name);
		}

		public void AddEachMultiPlayerToCollection(IEnumerable<PlayerViewModel> multiplayerCollection)
		{
			foreach (var player in multiplayerCollection)
				AddPlayerToCollection(player);
		}
		#endregion
	}
}
