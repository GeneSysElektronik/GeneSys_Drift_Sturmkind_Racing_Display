using GeneSysRacing.BaseViewModel;
using GeneSysRacing.Models;
using GeneSysRacing.ViewModels.Views;
using ReactiveUI;
using System;
using System.IO;
using System.Linq;
using System.Reactive;

namespace GeneSysRacing.ViewModels
{
    public class MainViewModel : ReactiveObject
	{
		#region Private Members
		private RaceBaseViewModel? _raceContainer;
		private bool _isResultsLocationSet;
		#endregion

		#region Public Members
		public RaceViewModel CurrentRace { get; set; } = new();
		public PlayerViewModel? CurrentPlayer { get; set; }
		
		public RaceBaseViewModel? RaceContainer
		{
			get => _raceContainer;
			set => this.RaiseAndSetIfChanged(ref _raceContainer, value);
		}
		#endregion
		
		#region Commands
		public ReactiveCommand<Unit, Unit> ManageServerCommand { get; }
		public ReactiveCommand<Unit, Unit> NewRaceCommand { get; }
		public ReactiveCommand<Unit, Unit> EditRaceCommand { get; }
		#endregion

		#region Constructor
		public MainViewModel()
        {
			ManageServerCommand = ReactiveCommand.Create(ManageServer);
			NewRaceCommand = ReactiveCommand.Create(CreateRace);
			EditRaceCommand = ReactiveCommand.Create(EditRace);

			WebCommunicationModel.LoadXmlData();
			ManageServer();
		}
		#endregion

		#region Private Methods
		private void ManageServer()
		{
			RaceContainer = new DriftServerViewModel();
		}
		private void CreateRace()
		{
			CurrentRace = new();
			_isResultsLocationSet = false;
			var createRace = new CreateRaceViewModel(CurrentRace);
			createRace.Finished += CreateRaceFinished;
			RaceContainer = createRace;
		}
		private void EditRace()
		{
			var editRace = new CreateRaceViewModel(CurrentRace);
			editRace.Finished += CreateRaceFinished;
			RaceContainer = editRace;
		}
		
		private void CreateRaceFinished(object? sender, EventArgs e)
		{
			if (!_isResultsLocationSet)
			{
				var count = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "GeneSysRacing Ergebnisse")).GetDirectories().Count(directory => directory.Name.Contains(CurrentRace.Name));
				WebCommunicationModel.Results = count > 0 ? $"{CurrentRace.Name} ({count})" : CurrentRace.Name;
				_isResultsLocationSet = true;
			}

			PlayerViewModel? lastPlayer = null;
			if (RaceContainer != null)
			{
				WebCommunicationModel.ExportRace(CurrentRace);
				RaceContainer.Finished -= CreateRaceFinished;
				if (RaceContainer is SinglePlayerViewModel singlePlayer)
					lastPlayer = singlePlayer.LastPlayer;
				RaceContainer.Dispose();
			}

			if (CurrentRace.IsMultiplayerSelected)
			{
				var multiPlayer = new MultiplayerViewModel(CurrentRace);
				multiPlayer.Finished += CreateRaceFinished;
				RaceContainer = multiPlayer;
			}
			else
			{
				CurrentPlayer = new();
				var singlePlayer = new SinglePlayerViewModel(CurrentRace, lastPlayer);
				singlePlayer.Finished += CreateRaceFinished;
				RaceContainer = singlePlayer;
			}
		}
		#endregion
	}
}
