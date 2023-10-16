Jedes ControlTemplate das verwendet werden möchte muss in App.axaml beannt gemacht werden:

in App.axaml:
<Application.Styles>
	<FluentTheme />
    <StyleInclude Source="/Templates/Styles/Styles.axaml" />
	<StyleInclude Source="/Templates/Controls/Button.axaml" />
	<StyleInclude Source="/Templates/Controls/PopUp.axaml" />
	<StyleInclude Source="/Templates/Controls/GroupBox.axaml" />
</Application.Styles>

// -------------------------------------------------------

Dark- und LightMode können folgendermaßen verwendet werden:

in App.axaml.cs:
public override void Initialize()
{
    AvaloniaXamlLoader.Load(this);
    Styles.Add(new Templates.LightTheme()); // oder Styles.Add(new Templates.DarkTheme());
    RequestedThemeVariant = ThemeVariant.Light; // oder RequestedThemeVariant = ThemeVariant.Dark;
}

// -------------------------------------------------------

Die Fonts im ordner /Templates/Fonts/ müssen als AvaloniaResource Deklariert werden (Rechtsklick auf Font -> Eigenschaften -> Buildvorgang=AvaloniaResource)

// -------------------------------------------------------

Verwendung der ControlTemplates:

<UserControl
    ...
    xmlns:controls="using:Templates.Controls"
    ...
    >
    <controls:PopUp />
    <controls:Button />
    <controls:GroupBox />
</UserControl>

