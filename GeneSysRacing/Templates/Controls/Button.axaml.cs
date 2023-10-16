using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using System;
using System.Windows.Input;

namespace Templates.Controls
{
    public class Button : TemplatedControl
    {
        #region properties
        public static readonly StyledProperty<string> TextProperty = 
            AvaloniaProperty.Register<Button, string>( 
                nameof(Text), "Placeholder" );
        
        public static readonly StyledProperty<Geometry> PathDataProperty =
            AvaloniaProperty.Register<Button, Geometry>(
                nameof(PathData), GeometryPathData.GetIconPath(IconKey.Placeholder));
        
        public static new readonly StyledProperty<double> FontSizeProperty = 
            AvaloniaProperty.Register<Button, double>( 
                nameof(FontSize), 12 );
        
        public static readonly StyledProperty<bool> HasIconProperty =
           AvaloniaProperty.Register<Button, bool>(
               nameof(HasIcon), true);
        
        public static readonly StyledProperty<ICommand?> CommandProperty = 
            AvaloniaProperty.Register<Button, ICommand?>(
                nameof(Command));
        
        public static readonly StyledProperty<object?> CommandParameterProperty =
            AvaloniaProperty.Register<Button, object?>(
                nameof(CommandParameter) );
        #endregion

        #region parameters
        public string Text
        {
            get => GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Geometry PathData
        {
            get => GetValue(PathDataProperty);
            set => SetValue(PathDataProperty, value);
        }

        public new double FontSize
        {
            get => GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
        
        public bool HasIcon
        {
            get => GetValue(HasIconProperty);
            set => SetValue(HasIconProperty, value);
        }

        public ICommand? Command
        {
            get => GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object? CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
        #endregion
    }
}
