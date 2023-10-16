using System;
using System.Reflection;

namespace Templates.ViewModels
{
    public class SplashScreenWindowViewModel
    {
        public static Version? ApplicationVersion { get; private set; }
        public string? ApplicationName { get; }

        public SplashScreenWindowViewModel()
        {
			ApplicationName = Assembly.GetExecutingAssembly().GetName().Name;

            if (Assembly.GetExecutingAssembly().GetName().Version is Version version)
				ApplicationVersion = new(version.Major, version.Minor, version.Build);
		}
	}
}
