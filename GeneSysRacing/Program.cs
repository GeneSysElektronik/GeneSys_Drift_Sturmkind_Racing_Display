using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GeneSysRacing
{
	static internal class Program
	{
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		private const int SW_RESTORE = 9;

		// Initialization code. Don't use any Avalonia, third-party APIs or any
		// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
		// yet and stuff might break.
		[STAThread]
		public static void Main(string[] args)
		{
			CheckRunningInstance();
			BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
		}

		// Avalonia configuration, don't remove; also used by visual designer.
		public static AppBuilder BuildAvaloniaApp()
			=> AppBuilder.Configure<App>()
				.UsePlatformDetect()
				.LogToTrace()
				.UseReactiveUI();

		private static void CheckRunningInstance()
		{
			Process[] processes = Process.GetProcessesByName("GeneSysRacing");

			if (processes.Length > 0)
			{
				Process process = processes[0];

				if (process.MainWindowHandle != IntPtr.Zero)
				{
					ShowWindow(process.MainWindowHandle, SW_RESTORE);
					SetForegroundWindow(process.MainWindowHandle);
					Environment.Exit(0);
				}
			}
		}
	}
}
