using Avalonia.Controls;
using ReactiveUI;

namespace GeneSysRacing.ViewModels
{
	public class RaceStateViewModel : ReactiveObject
	{

		private string? _header;
		public string? Header
		{
			get => _header;
			set => this.RaiseAndSetIfChanged(ref _header, value);
		}

		public UserControl Control { get; }

        public RaceStateViewModel(string? header, UserControl control)
        {
			_header = header;
			Control = control;
        }
	}
}
