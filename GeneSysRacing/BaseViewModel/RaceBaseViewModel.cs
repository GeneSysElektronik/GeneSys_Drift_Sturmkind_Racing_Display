using Avalonia.Controls;
using GeneSysRacing.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace GeneSysRacing.BaseViewModel
{
	public class RaceBaseViewModel : ReactiveObject, IDisposable
	{
		private int _maxSteps;
		private int _currentStep;
        private List<RaceStateViewModel> _stateCollection = new();
		private UserControl? _activeControl;
		private string? _activeHeader;
		private bool disposedValue;



        public List<RaceStateViewModel> StateCollection
        {
            get => _stateCollection;
			set
			{
				this.RaiseAndSetIfChanged(ref _stateCollection, value);
				_maxSteps = value.Count;
			}
		}


		public string? ActiveHeader
		{
			get => _activeHeader;
			set => this.RaiseAndSetIfChanged(ref _activeHeader, value);
		}

		public UserControl? ActiveControl
		{
			get => _activeControl;
			set => this.RaiseAndSetIfChanged(ref _activeControl, value);
		}

		public ReactiveCommand<Unit, Unit> BackCommand { get; }
        public ReactiveCommand<Unit, Unit> NextCommand { get; }

		protected event EventHandler<int>? ActiveViewChanged;
		public event EventHandler? Finished;

        public RaceBaseViewModel()
        {
            BackCommand = ReactiveCommand.Create(Back);
            NextCommand = ReactiveCommand.Create(Next);
        }

		/// <summary>
		/// Activates and deactivates views within the modify process based on the current state.
		/// </summary>
		protected void UpdateView()
		{
			if (StateCollection.Count > _currentStep)
			{
				var activeState = StateCollection[_currentStep];
				ActiveHeader = activeState.Header;
				ActiveControl = activeState.Control;
			}
			ActiveViewChanged?.Invoke(this, _currentStep);
		}

		private void Next()
		{
			if (_currentStep < _maxSteps - 1)
			{
				_currentStep++;
				UpdateView();
			}
			else
				Back();
		}
		private void Back()
		{
			_currentStep = 0;
			UpdateView();
			Finished?.Invoke(this, EventArgs.Empty);
		}

		public async Task NextAfterFinishedTask(Task task)
		{
			await task;
			Next();
		}


		#region Dispose
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting
		/// unmanaged resources.
		/// </summary>
		/// <param name="disposing">disposing value.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
				disposedValue = true;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting
		/// unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			// Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
