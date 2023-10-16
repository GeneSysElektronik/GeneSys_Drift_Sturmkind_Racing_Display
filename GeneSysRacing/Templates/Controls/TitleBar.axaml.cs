using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Primitives;
using System;

namespace Templates.Controls
{
	public class TitleBar : TemplatedControl
	{
		private Path? _maximizeIcon;

		public static readonly StyledProperty<bool> CloseButtonEnabledProperty =
			AvaloniaProperty.Register<TitleBar, bool>(
				nameof(CloseButtonEnabled), true);

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
		{
			base.OnApplyTemplate(e);

			var minimizeButton = e.NameScope.Find<Avalonia.Controls.Button>("PART_MinimizeButton") ?? throw new Exception("Button not found");
			var maximizeButton = e.NameScope.Find<Avalonia.Controls.Button>("PART_MaximizeButton") ?? throw new Exception("Button not found");
			var closeButton = e.NameScope.Find<Avalonia.Controls.Button>("PART_CloseButton") ?? throw new Exception("Button not found");
			_maximizeIcon = e.NameScope.Find<Path>("MaximizeIcon") ?? throw new Exception("Path not found");
			_maximizeIcon.Data = GeometryPathData.GetIconPath(IconKey.MaximizeWindow);

			minimizeButton.Click += MinimizeWindow;
			maximizeButton.Click += MaximizeWindow;
			closeButton.Click += CloseWindow;

			(VisualRoot as Window)!.PropertyChanged += WindowStateChanged;
		}

		private void CloseWindow(object? sender, EventArgs e)
		{
			Window? hostWindow = (Window)VisualRoot!;
			hostWindow.Close();
		}
		private void MinimizeWindow(object? sender, EventArgs e)
		{
			Window? hostWindow = (Window)VisualRoot!;
			hostWindow.WindowState = WindowState.Minimized;
		}
		private void MaximizeWindow(object? sender, EventArgs e)
		{
			Window hostWindow = (Window)VisualRoot!;

			if (hostWindow.WindowState == WindowState.Normal)
				hostWindow.WindowState = WindowState.Maximized;
			else
				hostWindow.WindowState = WindowState.Normal;
		}

		private void WindowStateChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
		{
			if (e.NewValue is WindowState windowState)
				_maximizeIcon.Data = GeometryPathData.GetIconPath(windowState == WindowState.Maximized ? IconKey.WindowMaximized : IconKey.MaximizeWindow);
		}

		public bool CloseButtonEnabled
		{
			get => GetValue(CloseButtonEnabledProperty);
			set => SetValue(CloseButtonEnabledProperty, value);
		}
	}
}
