using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace GeneSysRacing.Views
{
	public partial class SettingsView : UserControl
	{
		public SettingsView()
		{
			InitializeComponent();
		}

		private void EntryFinishedHelper(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter || e.Key == Key.Escape)
				TopLevel.GetTopLevel((Visual)sender)?.FocusManager?.ClearFocus();
		}
	}
}
