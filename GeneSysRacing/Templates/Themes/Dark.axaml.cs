using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using AvaloniaStyles = Avalonia.Styling.Styles;

namespace Templates.Themes
{
	public partial class Dark : AvaloniaStyles, IThemeVariantProvider
	{
		public Dark()
		{
			AvaloniaXamlLoader.Load(this);
		}
		public ThemeVariant? Key { get; set; }
	}
}
