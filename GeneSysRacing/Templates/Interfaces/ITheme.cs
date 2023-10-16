using Avalonia.Media;

namespace Templates.Interfaces
{
    public interface ITheme
    {
        ISolidColorBrush AccentBrush { get; }

        ISolidColorBrush ThemeDisabledBrush { get; }

        ISolidColorBrush ThemeBackgroundBrush { get; }
        ISolidColorBrush ThemeForegroundBrush { get; }
        ISolidColorBrush ThemeFrameBackgroundBrush { get; }

        ISolidColorBrush ThemeBorderBrush { get; }
        ISolidColorBrush ThemeBorderPointeroverBrush { get; }
        ISolidColorBrush ThemeBorderSelectedBrush { get; }

        ISolidColorBrush ThemeItemBackgroundBrush { get; }
        ISolidColorBrush ThemeItemPointeroverBackgroundBrush { get; }

        ILinearGradientBrush ThemeNavigationGradientBrush { get; }
        ILinearGradientBrush ThemeFadeLeftGradientBrush { get; }

		ISolidColorBrush CheckBoxCheckBackgroundStrokeUnchecked { get; }
        ISolidColorBrush CheckBoxCheckBackgroundStrokeUncheckedDisabled { get; }
        ISolidColorBrush CheckBoxCheckBackgroundStrokeUncheckedPressed { get; }
        ISolidColorBrush CheckBoxCheckBackgroundStrokeChecked { get; }
        ISolidColorBrush CheckBoxCheckBackgroundStrokeCheckedDisabled { get; }
        ISolidColorBrush CheckBoxCheckBackgroundStrokeCheckedPointerOver { get; }
        ISolidColorBrush CheckBoxCheckBackgroundStrokeCheckedPressed { get; }
        ISolidColorBrush CheckBoxCheckBackgroundFillUnchecked { get; }
        ISolidColorBrush CheckBoxCheckBackgroundFillUncheckedDisabled { get; }
        ISolidColorBrush CheckBoxCheckBackgroundFillUncheckedPointerOver { get; }
        ISolidColorBrush CheckBoxCheckBackgroundFillUncheckedPressed { get; }
        ISolidColorBrush CheckBoxCheckBackgroundFillChecked { get; }
        ISolidColorBrush CheckBoxCheckBackgroundFillCheckedDisabled { get; }
        ISolidColorBrush CheckBoxCheckBackgroundFillCheckedPointerOver { get; }
        ISolidColorBrush CheckBoxCheckBackgroundFillCheckedPressed { get; }
        ISolidColorBrush CheckBoxCheckGlyphForegroundChecked { get; }
        ISolidColorBrush CheckBoxCheckGlyphForegroundCheckedDisabled { get; }
        ISolidColorBrush CheckBoxCheckGlyphForegroundCheckedPointerOver { get; }
        ISolidColorBrush CheckBoxCheckGlyphForegroundCheckedPressed { get; }

        ISolidColorBrush TextControlBackground { get; }
        ISolidColorBrush TextControlBackgroundDisabled { get; }
        ISolidColorBrush TextControlBackgroundPointerOver { get; }
        ISolidColorBrush TextControlBackgroundFocused { get; }
        ISolidColorBrush TextControlBorderBrush { get; }
        ISolidColorBrush TextControlBorderBrushDisabled { get; }
        ISolidColorBrush TextControlBorderBrushPointerOver { get; }
        ISolidColorBrush TextControlBorderBrushFocused { get; }
        ISolidColorBrush TextControlPlaceholderForegroundDisabled { get; }
        ISolidColorBrush TextControlPlaceholderForegroundPointerOver { get; }
        ISolidColorBrush TextControlPlaceholderForegroundFocused { get; }

        ISolidColorBrush ComboBoxBackground { get; }
        ISolidColorBrush ComboBoxBackgroundDisabled { get; }
        ISolidColorBrush ComboBoxBackgroundPointerOver { get; }
        ISolidColorBrush ComboBoxBackgroundPressed { get; }
        ISolidColorBrush ComboBoxBorderBrush { get; }
        ISolidColorBrush ComboBoxBorderBrushDisabled { get; }
        ISolidColorBrush ComboBoxBorderBrushPointerOver { get; }
        ISolidColorBrush ComboBoxBorderBrushPressed { get; }

        ISolidColorBrush RadioButtonOuterEllipseStroke { get; }
        ISolidColorBrush RadioButtonOuterEllipseStrokeDisabled { get; }
        ISolidColorBrush RadioButtonOuterEllipseStrokePointerOver { get; }
        ISolidColorBrush RadioButtonOuterEllipseStrokePressed { get; }
        ISolidColorBrush RadioButtonOuterEllipseFill { get; }
        ISolidColorBrush RadioButtonOuterEllipseFillDisabled { get; }
        ISolidColorBrush RadioButtonOuterEllipseFillPointerOver { get; }
        ISolidColorBrush RadioButtonOuterEllipseFillPressed { get; }
        ISolidColorBrush RadioButtonOuterEllipseCheckedStroke { get; }
        ISolidColorBrush RadioButtonOuterEllipseCheckedStrokeDisabled { get; }
        ISolidColorBrush RadioButtonOuterEllipseCheckedStrokePointerOver { get; }
        ISolidColorBrush RadioButtonOuterEllipseCheckedStrokePressed { get; }
        ISolidColorBrush RadioButtonOuterEllipseCheckedFill { get; }
        ISolidColorBrush RadioButtonOuterEllipseCheckedFillDisabled { get; }
        ISolidColorBrush RadioButtonOuterEllipseCheckedFillPointerOver { get; }
        ISolidColorBrush RadioButtonOuterEllipseCheckedFillPressed { get; }
        ISolidColorBrush RadioButtonCheckGlyphStroke { get; }
        ISolidColorBrush RadioButtonCheckGlyphStrokeDisabled { get; }
        ISolidColorBrush RadioButtonCheckGlyphStrokePointerOver { get; }
        ISolidColorBrush RadioButtonCheckGlyphStrokePressed { get; }
        ISolidColorBrush RadioButtonCheckGlyphFill { get; }
        ISolidColorBrush RadioButtonCheckGlyphFillDisabled { get; }
        ISolidColorBrush RadioButtonCheckGlyphFillPointerOver { get; }
        ISolidColorBrush RadioButtonCheckGlyphFillPressed { get; }

        Geometry DisplayModeIcon { get; }
    }
}
