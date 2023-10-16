using GeneSysRacing.BaseViewModel;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace GeneSysRacing.ViewModels.Views
{
	public class SettingsViewModel : RaceStepBaseViewModel
	{
		#region Private Members
		private IEnumerable<IPAddress>? _availableIPsCollection;
		private IPAddress? _selectedIPAdress;
		#endregion

		#region Public Members
		public RaceViewModel CurrentRace { get; }
		
		public IEnumerable<IPAddress>? AvailableIPsCollection
		{
			get => _availableIPsCollection;
			set => this.RaiseAndSetIfChanged(ref _availableIPsCollection, value);
		}

		public IPAddress? SelectedIPAdress
		{
			get => _selectedIPAdress;
			set
			{
				this.RaiseAndSetIfChanged(ref _selectedIPAdress, value);
				if (value != null)
					CurrentRace.IP = value.ToString();
			}
		}
		#endregion

		#region Commands
		#endregion

		#region Constructor
		public SettingsViewModel(RaceViewModel currentRace)
        {
            CurrentRace = currentRace;
			IsRightButtonEnabled = false;
			CurrentRace.EnableRaceEvent += (_, enable) => IsRightButtonEnabled = enable;
            RightButtonText = "Starte Rennen";
		
			AvailableIPsCollection = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily == AddressFamily.InterNetwork);
			if (currentRace.IP != null)
				SelectedIPAdress = AvailableIPsCollection.FirstOrDefault(ip => ip.ToString() == currentRace.IP);
		}
		#endregion
	}
}
