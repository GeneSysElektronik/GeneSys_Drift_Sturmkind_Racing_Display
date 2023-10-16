using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Reactive;
using Templates.Interfaces;

namespace Templates.ViewModels
{
    public class DialogWindowViewModel : ReactiveObject, IDisposable
    {
		#region private members
		private Geometry _fullscreenIcon = GeometryPathData.GetIconPath(IconKey.MaximizeWindow);
		#endregion

		#region public members
		public string WindowTitle { get; }
		public double WindowWidth { get; }
		public double WindowHeight { get; }
		public bool CanResize { get; }

		public UserControl Content { get; }

		public Geometry FullscreenIcon
		{
			get => _fullscreenIcon;
			set => this.RaiseAndSetIfChanged(ref _fullscreenIcon, value);
		}
		public Geometry NextButtonIcon { get; } = GeometryPathData.GetIconPath(IconKey.Check);
		#endregion

		#region commands
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; }
        public ReactiveCommand<Unit, Unit> FullscreenCommand { get; }
        
        public ReactiveCommand<Unit, Unit>? CancelCommand { get; }
		public ReactiveCommand<Unit, Unit>? BackCommand { get; }
		public ReactiveCommand<Unit, Unit>? NextCommand { get; }
		#endregion

		#region events
		public static event EventHandler? CloseWindowEvent;
        public event EventHandler? FullscreenEvent;
		#endregion

		public DialogWindowViewModel(UserControl content)
        {
            Content = content;
            if (content.DataContext is not IDialogViewModel viewModel) throw new Exception("No ViewModel found");

            WindowTitle = viewModel.WindowTitle;
            WindowWidth = viewModel.WindowWidth;
            WindowHeight = viewModel.WindowHeight;
            CanResize = viewModel.CanResize;

            CloseWindowCommand = ReactiveCommand.Create(() => CloseWindowEvent?.Invoke(this, EventArgs.Empty));
            FullscreenCommand = ReactiveCommand.Create(() => FullscreenEvent?.Invoke(this, EventArgs.Empty));

            CancelCommand = viewModel.CancelButtonCommand;
            BackCommand = viewModel.BackButtonCommand;
            NextCommand = viewModel.NextButtonCommand;
        }


        public static void CloseDialog() => CloseWindowEvent?.Invoke(null, EventArgs.Empty);

		public void Dispose()
		{

		}
	}
}
