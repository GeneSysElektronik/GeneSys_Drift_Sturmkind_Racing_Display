﻿using GeneSysRacing.BaseViewModel;
using GeneSysRacing.Views;

namespace GeneSysRacing.ViewModels.Views
{
    public class ShowOverviewViewModel : RaceBaseViewModel
    {
        public ShowOverviewViewModel(RaceViewModel currentRace, PlayerViewModel newPlayer)
        {
            StateCollection = new()
            {
                new($"BESTENLISTE - {currentRace.Name}", new OverviewView() { DataContext = new OverviewViewModel(currentRace) }),
                new("SPIELERINFOS", new NewRunView() { DataContext = new NewRunViewModel(currentRace, newPlayer) })
            };
            UpdateView();
        }
    }
}
