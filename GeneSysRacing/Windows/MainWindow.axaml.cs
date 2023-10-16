using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace GeneSysRacing.Windows
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			PropertyChanged += SubscribeToWindowState;
		}

		private void SubscribeToWindowState(object? sender, AvaloniaPropertyChangedEventArgs e)
		{
			if (e.NewValue is WindowState windowState)
				Padding = new Thickness(windowState == WindowState.Maximized ? 7 : 0);
		}

		private void UnfocusHelper(object sender, PointerPressedEventArgs e)
		{
			GetTopLevel((Visual)sender)?.FocusManager?.ClearFocus();
		}
	}
}