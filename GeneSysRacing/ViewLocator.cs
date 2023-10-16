using Avalonia.Controls;
using Avalonia.Controls.Templates;
using GeneSysRacing.ViewModels;
using System;

namespace GeneSysRacing
{
	public class ViewLocator : IDataTemplate
	{
		public bool Match(object? data) => data is MainViewModel;

		Control? ITemplate<object?, Control?>.Build(object? param)
		{
			if (param?.GetType().FullName is string fullName && Type.GetType(fullName.Replace("ViewModel", "View")) is Type type)
				return (Control?)Activator.CreateInstance(type);
			return new TextBlock { Text = "Not Found: " + param?.GetType().FullName };
		}
	}
}