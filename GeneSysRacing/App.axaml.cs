using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using GeneSysRacing.ViewModels;
using GeneSysRacing.Views;
using System.Threading.Tasks;
using System;
using Templates.Themes;
using Templates.ViewModels;
using Templates.Windows;
using GeneSysRacing.Windows;

namespace GeneSysRacing
{
	public partial class App : Application
	{
		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);

			Resources.ThemeDictionaries.Add(ThemeVariant.Dark, new Dark());
			Current!.RequestedThemeVariant = ThemeVariant.Dark;
		}

		public override async void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				var splashViewModel = new SplashScreenWindowViewModel();
				var splash = new SplashScreenWindow { DataContext = splashViewModel };
				splash.Show();
				desktop.MainWindow = await GetMainWindowAsync();
				desktop.MainWindow?.Show();
				desktop.MainWindow?.Activate();
				splash.Close();
			}

			base.OnFrameworkInitializationCompleted();
		}

		static async Task<MainWindow> GetMainWindowAsync()
		{
			await Task.Delay(TimeSpan.FromSeconds(1));
			return new MainWindow { DataContext = new MainViewModel() };
		}
	}
}