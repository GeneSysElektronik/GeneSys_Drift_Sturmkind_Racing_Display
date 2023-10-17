using GeneSysRacing.BaseViewModel;
using GeneSysRacing.Views;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GeneSysRacing.ViewModels.Views
{
    public class MultiplayerViewModel : RaceBaseViewModel
    {
        private readonly StartRunViewModel _startRunViewModel;
        private readonly CurrentRunViewModel _currentRunViewModel;
        private readonly FinishedViewModel _finishedViewModel;
        private readonly CancellationTokenSource _cts = new();

        public MultiplayerViewModel(RaceViewModel currentRace)
        {
            _startRunViewModel = new StartRunViewModel(currentRace);
            _currentRunViewModel = new CurrentRunViewModel(currentRace);
            _finishedViewModel = new FinishedViewModel(currentRace);

            StateCollection = new()
            {
                new($"BESTENLISTE - {currentRace.Name}", new OverviewView() { DataContext = new OverviewViewModel(currentRace) }),
                new(currentRace.Name, new StartRunView() { DataContext = _startRunViewModel }),
                new(currentRace.Name, new CurrentRunView() { DataContext = _currentRunViewModel }),
                new(currentRace.Name, new FinishedView() { DataContext = _finishedViewModel })
            };
            UpdateView();

            ActiveViewChanged += OnActiveViewChanged;
        }

        #region Private Methods
        private async void OnActiveViewChanged(object? sender, int indexOfActiveView)
        {
            if (indexOfActiveView == StateCollection.IndexOf(StateCollection.First(step => step.Control.DataContext == _startRunViewModel)))
                await NextAfterFinishedTask(_startRunViewModel.StartRunAsync(_cts.Token));
            if (indexOfActiveView == StateCollection.IndexOf(StateCollection.First(step => step.Control.DataContext == _currentRunViewModel)))
                await NextAfterFinishedTask(_currentRunViewModel.WaitForFinishAsync(_cts.Token));
            if (indexOfActiveView == StateCollection.IndexOf(StateCollection.First(step => step.Control.DataContext == _finishedViewModel)) && _currentRunViewModel.MultiplayerCollection != null)
                await NextAfterFinishedTask(Task.Run(() => _finishedViewModel.AddEachMultiPlayerToCollection(_currentRunViewModel.MultiplayerCollection)));
            if (indexOfActiveView == 0)
                _cts.Cancel();
        }
        #endregion

        #region Public Methods
        protected override void Dispose(bool disposing)
        {
            _cts.Cancel();
            ActiveViewChanged -= OnActiveViewChanged;
            base.Dispose(disposing);
        }
        #endregion
    }
}
