using GeneSysRacing.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneSysRacing.BaseViewModel
{
	public class RaceStepBaseViewModel : ReactiveObject
	{

        private bool _isRightButtonVisible;
        public bool IsRightButtonVisible
        {
            get => _isRightButtonVisible;
            set => this.RaiseAndSetIfChanged(ref _isRightButtonVisible, value);
        }

		private bool _isRightButtonEnabled = true;
		public bool IsRightButtonEnabled
		{
			get => _isRightButtonEnabled;
			set => this.RaiseAndSetIfChanged(ref _isRightButtonEnabled, value);
		}

		private bool _isLeftButtonVisible;
        public bool IsLeftButtonVisible
        {
            get => _isLeftButtonVisible;
            set => this.RaiseAndSetIfChanged(ref _isLeftButtonVisible, value);
        }


        private string? _rightButtonText;
        public string? RightButtonText
        {
            get => _rightButtonText;
            set
            {
                this.RaiseAndSetIfChanged(ref _rightButtonText, value);
                IsRightButtonVisible = value != null;
            }
        }

        private string? _leftButtonText;
        public string? LeftButtonText
        {
            get => _leftButtonText;
			set
			{
				this.RaiseAndSetIfChanged(ref _leftButtonText, value);
				IsLeftButtonVisible = value != null;
			}
		}

        private PlayerViewModel? _currentPlayer;
        public PlayerViewModel? CurrentPlayer
        {
            get => _currentPlayer;
            set => this.RaiseAndSetIfChanged(ref _currentPlayer, value);
        }

        private bool _isShowFinishedExtensionVisible;
        private bool _isShowOverviewExtensionVisible;

		protected bool IsShowFinishedExtensionVisible
        { 
            get => _isShowFinishedExtensionVisible; 
            set => this.RaiseAndSetIfChanged(ref _isShowFinishedExtensionVisible, value); 
        }
        protected bool IsShowOverviewExtensionVisible
		{
			get => _isShowOverviewExtensionVisible;
			set => this.RaiseAndSetIfChanged(ref _isShowOverviewExtensionVisible, value);
		}

        private ObservableCollection<PlayerViewModel>? _multiplayerCollection;
		public ObservableCollection<PlayerViewModel>? MultiplayerCollection
        {
            get => _multiplayerCollection;
            set => this.RaiseAndSetIfChanged(ref _multiplayerCollection, value);
		}


        public RaceStepBaseViewModel()
        {
            
        }
    }
}
