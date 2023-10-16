using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Media;
using Avalonia.Metadata;
using System.Windows.Input;

namespace Templates.Controls
{
	public class PopUp : TemplatedControl
    {
        #region properties
        public static readonly StyledProperty<string> HeaderLabelProperty =
            AvaloniaProperty.Register<PopUp, string>(
                nameof(HeaderLabel), "Header");

        public static readonly StyledProperty<double> HeaderFontSizeProperty =
            AvaloniaProperty.Register<PopUp, double>(
                nameof(HeaderFontSize), 20);
        
        public static readonly StyledProperty<bool> HasCloseButtonProperty =
            AvaloniaProperty.Register<PopUp, bool>(
                nameof(HasCloseButton), true);

        public static readonly StyledProperty<bool> HasFullscreenButtonProperty =
            AvaloniaProperty.Register<PopUp, bool>(
                nameof(HasFullscreenButton), false);

        public static readonly StyledProperty<IImage> ApplicationIconProperty =
            AvaloniaProperty.Register<PopUp, IImage>(
                nameof(ApplicationIcon));

        public static readonly StyledProperty<bool> HasNavigationBarProperty =
            AvaloniaProperty.Register<PopUp, bool>(
                nameof(HasNavigationBar), true);

        public static readonly StyledProperty<string> CancelButtonTextProperty =
            AvaloniaProperty.Register<PopUp, string>(
                nameof(CancelButtonText), "Cancel");

        public static readonly StyledProperty<string> BackButtonTextProperty =
            AvaloniaProperty.Register<PopUp, string>(
                nameof(BackButtonText), "Back");
        
        public static readonly StyledProperty<string> NextButtonTextProperty =
            AvaloniaProperty.Register<PopUp, string>(
                nameof(NextButtonText), "Next");

		public static readonly StyledProperty<bool> IsThinProperty =
			AvaloniaProperty.Register<PopUp, bool>(
				nameof(IsThin), false);

		public static readonly StyledProperty<Geometry> FullscreenButtonPathDataProperty =
			AvaloniaProperty.Register<PopUp, Geometry>(
				nameof(FullscreenButtonPathData), GeometryPathData.GetIconPath(IconKey.MaximizeWindow));

		public static readonly StyledProperty<Geometry> CancelButtonPathDataProperty =
            AvaloniaProperty.Register<PopUp, Geometry>(
                nameof(CancelButtonPathData), GeometryPathData.GetIconPath(IconKey.Close));

        public static readonly StyledProperty<Geometry> BackButtonPathDataProperty =
            AvaloniaProperty.Register<PopUp, Geometry>(
                nameof(BackButtonPathData), GeometryPathData.GetIconPath(IconKey.ArrowLeft));
        
        public static readonly StyledProperty<Geometry> NextButtonPathDataProperty =
            AvaloniaProperty.Register<PopUp, Geometry>(
                nameof(NextButtonPathData), GeometryPathData.GetIconPath(IconKey.ArrowRight));

        public static readonly StyledProperty<bool> CancelButtonIsEnabledProperty =
            AvaloniaProperty.Register<PopUp, bool>(
                nameof(CancelButtonIsEnabled), true);

        public static readonly StyledProperty<bool> BackButtonIsEnabledProperty =
            AvaloniaProperty.Register<PopUp, bool>(
                nameof(BackButtonIsEnabled), true);
        
        public static readonly StyledProperty<bool> NextButtonIsEnabledProperty =
            AvaloniaProperty.Register<PopUp, bool>(
                nameof(NextButtonIsEnabled), true);

        public static readonly StyledProperty<bool> CancelButtonIsVisibleProperty =
            AvaloniaProperty.Register<PopUp, bool>(
                nameof(CancelButtonIsVisible), true);

        public static readonly StyledProperty<bool> BackButtonIsVisibleProperty =
            AvaloniaProperty.Register<PopUp, bool>(
                nameof(BackButtonIsVisible), true);
        
        public static readonly StyledProperty<bool> NextButtonIsVisibleProperty =
            AvaloniaProperty.Register<PopUp, bool>(
                nameof(NextButtonIsVisible), true);
        
        public static readonly StyledProperty<ICommand?> CloseCommandProperty =
            AvaloniaProperty.Register<PopUp, ICommand?>(
                nameof(CloseCommand));

        public static readonly StyledProperty<ICommand?> FullscreenCommandProperty = 
            AvaloniaProperty.Register<PopUp, ICommand?>(
                nameof(FullscreenCommand));

        public static readonly StyledProperty<ICommand?> CancelButtonCommandProperty = 
            AvaloniaProperty.Register<PopUp, ICommand?>(
                nameof(CancelButtonCommand));

        public static readonly StyledProperty<ICommand?> BackButtonCommandProperty = 
            AvaloniaProperty.Register<PopUp, ICommand?>(
                nameof(BackButtonCommand));
        
        public static readonly StyledProperty<ICommand?> NextButtonCommandProperty = 
            AvaloniaProperty.Register<PopUp, ICommand?>(
                nameof(NextButtonCommand));
        
        public static readonly StyledProperty<Control?> ChildProperty =
            AvaloniaProperty.Register<PopUp, Control?>(
                nameof(Child));
        #endregion
        
        #region parameters
        public string HeaderLabel
        {
            get => GetValue(HeaderLabelProperty);
            set => SetValue(HeaderLabelProperty, value);
        }
        public double HeaderFontSize
        {
            get => GetValue(HeaderFontSizeProperty);
            set => SetValue(HeaderFontSizeProperty, value);
        }

        public bool HasNavigationBar
        {
            get => GetValue(HasNavigationBarProperty);
            set => SetValue(HasNavigationBarProperty, value);
        }

        public bool HasCloseButton
        {
            get => GetValue(HasCloseButtonProperty);
            set => SetValue(HasCloseButtonProperty, value);
        }

        public bool HasFullscreenButton
        {
            get => GetValue(HasFullscreenButtonProperty);
            set => SetValue(HasFullscreenButtonProperty, value);
        }

        public IImage ApplicationIcon
        {
            get => GetValue(ApplicationIconProperty);
            set => SetValue(ApplicationIconProperty, value);
        }

        public string CancelButtonText
        {
            get => GetValue(CancelButtonTextProperty);
            set => SetValue(CancelButtonTextProperty, value);
        }

        public string BackButtonText
        {
            get => GetValue(BackButtonTextProperty);
            set => SetValue(BackButtonTextProperty, value);
        }

        public string NextButtonText
        {
            get => GetValue(NextButtonTextProperty);
            set => SetValue(NextButtonTextProperty, value);
        }
		
        public Geometry FullscreenButtonPathData
		{
			get => GetValue(FullscreenButtonPathDataProperty);
			set => SetValue(FullscreenButtonPathDataProperty, value);
		}

		public Geometry CancelButtonPathData
        {
            get => GetValue(CancelButtonPathDataProperty);
            set => SetValue(CancelButtonPathDataProperty, value);
        }

        public Geometry BackButtonPathData
        {
            get => GetValue(BackButtonPathDataProperty);
            set => SetValue(BackButtonPathDataProperty, value);
        }

        public Geometry NextButtonPathData
        {
            get => GetValue(NextButtonPathDataProperty);
            set => SetValue(NextButtonPathDataProperty, value);
        }

        public bool CancelButtonIsEnabled
        {
            get => GetValue(CancelButtonIsEnabledProperty);
            set => SetValue(CancelButtonIsEnabledProperty, value);
        }

        public bool BackButtonIsEnabled
        {
            get => GetValue(BackButtonIsEnabledProperty);
            set => SetValue(BackButtonIsEnabledProperty, value);
        }

        public bool NextButtonIsEnabled
        {
            get => GetValue(NextButtonIsEnabledProperty);
            set => SetValue(NextButtonIsEnabledProperty, value);
        }

        public bool CancelButtonIsVisible
        {
            get => GetValue(CancelButtonIsVisibleProperty);
            set => SetValue(CancelButtonIsVisibleProperty, value);
        }

        public bool BackButtonIsVisible
        {
            get => GetValue(BackButtonIsVisibleProperty);
            set => SetValue(BackButtonIsVisibleProperty, value);
        }

        public bool NextButtonIsVisible
        {
            get => GetValue(NextButtonIsVisibleProperty);
            set => SetValue(NextButtonIsVisibleProperty, value);
        }

        public bool IsThin
        {
			get => GetValue(IsThinProperty);
			set => SetValue(IsThinProperty, value);
		}

        public ICommand? CloseCommand
        {
            get => GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }

        public ICommand? FullscreenCommand
        {
            get => GetValue(FullscreenCommandProperty);
            set => SetValue(FullscreenCommandProperty, value);
        }

        public ICommand? CancelButtonCommand
        {
            get => GetValue(CancelButtonCommandProperty); 
            set => SetValue(CancelButtonCommandProperty, value);
        }

        public ICommand? BackButtonCommand
        {
            get => GetValue(BackButtonCommandProperty); 
            set => SetValue(BackButtonCommandProperty, value);
        }

        public ICommand? NextButtonCommand
        {
            get => GetValue(NextButtonCommandProperty); 
            set => SetValue(NextButtonCommandProperty, value);
        }
        #endregion

        #region content
        [Content]
        public Control? Child
        {
            get => GetValue(ChildProperty);
            set => SetValue(ChildProperty, value);
        }
        #endregion

        public PopUp()
        {
            ChildProperty.Changed.AddClassHandler<PopUp>((x, e) => x.ChildChanged(e));
        }

        #region methods
        /// <summary>
        /// Called when the <see cref="Child"/> property changes.
        /// </summary>
        /// <param name="e">The event args.</param>
        private void ChildChanged(AvaloniaPropertyChangedEventArgs e)
        {
            LogicalChildren.Clear();

            ((ISetLogicalParent?)e.OldValue)?.SetParent(null);

            if (e.NewValue != null)
            {
                ((ISetLogicalParent)e.NewValue).SetParent(this);
                LogicalChildren.Add((ILogical)e.NewValue);
            }
        }
        #endregion
    }
}
