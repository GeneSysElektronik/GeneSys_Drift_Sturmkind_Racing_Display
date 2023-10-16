using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using AvaloniaStyles = Avalonia.Styling.Styles;

namespace Templates.Themes
{
	public partial class Light : AvaloniaStyles, IThemeVariantProvider
	{
		public Light()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public ThemeVariant? Key { get; set; }
	}
}
