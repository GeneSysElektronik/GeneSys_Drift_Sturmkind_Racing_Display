using GeneSysRacing.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net;

namespace GeneSysRacing.ViewModels
{
	public class RaceViewModel : ReactiveObject
	{
		private string? _ip;
		private string _name = "GeneSys Cup";
		public string Name 
		{ 
			get => _name; 
			set
			{
				_name = value;
				WebCommunicationModel.Results = value;
			}
		}
		public long MaxLaps { get; set; } = 10;

		public string? IP
		{
			get => _ip;
			set
			{
				_ip = value;
				EnableRaceEvent?.Invoke(this, IPAddress.TryParse(value, out _));
			}
		}
		public string ID { get; set; } = "1";

		public bool IsCompanyEnabled { get; set; }
		public bool IsEMailEnabled { get; set; }

		private bool _isMultiplayerSelected;
		public bool IsMultiplayerSelected
		{
			get => _isMultiplayerSelected;
			set => this.RaiseAndSetIfChanged(ref _isMultiplayerSelected, value);
		}


		public List<PlayerViewModel> AllPlayerCollection { get; set; } = new();
		public List<PlayerViewModel>? TopTenCollection { get; set; }
		public LapTimeViewModel? LapRecord { get; set; }

		public event EventHandler<bool>? EnableRaceEvent;

		public RaceViewModel()
        {
			WebCommunicationModel.Results = _name;
		}
    }
}
