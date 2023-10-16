using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using System.Threading.Tasks;
using Templates.ViewModels;

namespace Templates.Windows
{
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();

            SubScribeToFullscreenEvent();
            PropertyChanged += SubscribeToWindowState;
        }

		private void ClearFocus(object sender, PointerPressedEventArgs e)
		{
            GetTopLevel((Visual)sender)?.FocusManager?.ClearFocus();
		}

		private async void SubScribeToFullscreenEvent()
        {
            var vm = (DialogWindowViewModel?)DataContext;

            while (vm == null)
            {
                vm = (DialogWindowViewModel?)DataContext;
                await Task.Delay(50);
            }

            vm.FullscreenEvent += ToggleFullscreen;
        }


        private void SubscribeToWindowState(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.NewValue is WindowState ws)
            {
                if (ws == WindowState.Maximized)
                {
                    Padding = new Thickness(7);
					if (DataContext is DialogWindowViewModel vm)
						vm.FullscreenIcon = GeometryPathData.GetIconPath(IconKey.WindowMaximized);
				}
                if (ws != WindowState.Maximized)
                {
                    Padding = new Thickness(0);
					if (DataContext is DialogWindowViewModel vm)
						vm.FullscreenIcon = GeometryPathData.GetIconPath(IconKey.MaximizeWindow);
				}
            }
        }

        private void ToggleFullscreen(object? sender, System.EventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }
    }
}
