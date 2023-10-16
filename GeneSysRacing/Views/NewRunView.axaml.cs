using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace GeneSysRacing.Views
{
	public partial class NewRunView : UserControl
	{
		public NewRunView()
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
