using GeneSysRacing.BaseViewModel;
using GeneSysRacing.ViewModels.Views;
using GeneSysRacing.Views;

namespace GeneSysRacing.ViewModels
{
	public class CreateRaceViewModel : RaceBaseViewModel
	{
		public CreateRaceViewModel(RaceViewModel newRace)
        {
			ActiveHeader = "RENNSETTINGS";
			ActiveControl = new SettingsView() { DataContext = new SettingsViewModel(newRace) };
		}
    }
}
