using GeneSysRacing.BaseViewModel;
using GeneSysRacing.ViewModels.Views;
using GeneSysRacing.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace GeneSysRacing.ViewModels
{
	public class SinglePlayerViewModel : RaceBaseViewModel
	{
		#region Private Members
		private PlayerViewModel _currentPlayer;
		private readonly StartRunViewModel _startRunViewModel;
		private readonly CurrentRunViewModel _currentRunViewModel;
		private readonly FinishedViewModel _finishedViewModel;
		private readonly CancellationTokenSource _cts = new();
		#endregion

		#region Public Members
		public PlayerViewModel? LastPlayer { get; set; }
		#endregion

		#region Constructor
		public SinglePlayerViewModel(RaceViewModel currentRace, PlayerViewModel? lastPlayer = null)
        {	
			_currentPlayer = new();
			_startRunViewModel = new StartRunViewModel(currentRace, _currentPlayer);
			_currentRunViewModel = new CurrentRunViewModel(currentRace, _currentPlayer);
			_finishedViewModel = new FinishedViewModel(currentRace, _currentPlayer);

			StateCollection = new()
            {
				new($"BESTENLISTE - {currentRace.Name}", new OverviewView() { DataContext = new OverviewViewModel(currentRace, lastPlayer) }),
				new("SPIELERINFOS", new NewRunView() { DataContext = new NewRunViewModel(currentRace, _currentPlayer) }),
				new(_currentPlayer.Name, new StartRunView() { DataContext = _startRunViewModel }),
				new(_currentPlayer.Name, new CurrentRunView() { DataContext = _currentRunViewModel }),
				new(_currentPlayer.Name, new FinishedView() { DataContext = _finishedViewModel })
            };
			UpdateView();

			_startRunViewModel.ExistingPlayerFoundEvent += OnExistingPlayerFound;
			_currentPlayer.PropertyChanged += OnPropertyChanged;
			ActiveViewChanged += OnActiveViewChanged;
		}
		#endregion

		#region Private Methods
		private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(_currentPlayer.Name))
			{
				StateCollection[2].Header = _currentPlayer.Name;
				StateCollection[3].Header = _currentPlayer.Name;
				StateCollection[4].Header = _currentPlayer.Name;
			}
		}
		private void OnExistingPlayerFound(object? sender, EventArgs e)
		{
			_currentPlayer = _startRunViewModel.CurrentPlayer!;

			foreach (var item in StateCollection)
				if (item.Control.DataContext is RaceStepBaseViewModel step)
					step.CurrentPlayer = _currentPlayer;
		}
		private async void OnActiveViewChanged(object? sender, int indexOfActiveView)
		{
			if (indexOfActiveView == StateCollection.IndexOf(StateCollection.First(step => step.Control.DataContext == _startRunViewModel)))
				await NextAfterFinishedTask(_startRunViewModel.StartRunAsync(_cts.Token));
			if (indexOfActiveView == StateCollection.IndexOf(StateCollection.First(step => step.Control.DataContext == _currentRunViewModel)))
				await NextAfterFinishedTask(_currentRunViewModel.WaitForFinishAsync(_cts.Token));
			if (indexOfActiveView == StateCollection.IndexOf(StateCollection.First(step => step.Control.DataContext == _finishedViewModel)))
				LastPlayer = _finishedViewModel.AddPlayerToCollection(_currentPlayer);
			if (indexOfActiveView == 0)
				_cts.Cancel();
		}
		#endregion

		#region Public Methods
		protected override void Dispose(bool disposing)
		{
			_startRunViewModel.ExistingPlayerFoundEvent -= OnExistingPlayerFound;
			_currentPlayer.PropertyChanged -= OnPropertyChanged;
			ActiveViewChanged -= OnActiveViewChanged;
			base.Dispose(disposing);
		}
		#endregion
	}
}
