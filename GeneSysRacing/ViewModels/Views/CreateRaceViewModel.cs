using GeneSysRacing.BaseViewModel;
using GeneSysRacing.Views;

namespace GeneSysRacing.ViewModels.Views
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
