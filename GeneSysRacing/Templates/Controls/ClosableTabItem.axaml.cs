using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Data.Common;
using System.Windows.Input;

namespace Templates.Controls
{
	public class ClosableTabItem : TabItem
	{
		private Avalonia.Controls.Button _editHeaderButton;
		
		public static readonly StyledProperty<bool> HasCloseButtonProperty =
			AvaloniaProperty.Register<ClosableTabItem, bool>(
				nameof(HasCloseButton), false);

		public static readonly StyledProperty<bool> HasEditHeaderButtonProperty =
			AvaloniaProperty.Register<ClosableTabItem, bool>(
				nameof(HasEditHeaderButton), false);

		public static readonly StyledProperty<bool> IsEditHeaderActiveProperty =
			AvaloniaProperty.Register<ClosableTabItem, bool>(
				nameof(IsEditHeaderActive), false);

		public static readonly StyledProperty<ICommand?> CloseTabCommandProperty =
			AvaloniaProperty.Register<ClosableTabItem, ICommand?>(
				nameof(CloseTabCommand));

		public static readonly StyledProperty<object?> CloseTabCommandParameterProperty =
			AvaloniaProperty.Register<ClosableTabItem, object?>(
				nameof(CloseTabCommandParameter));

		protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
		{
			base.OnApplyTemplate(e);

			_editHeaderButton = e.NameScope.Find<Avalonia.Controls.Button>("PART_EditHeader") ?? throw new System.Exception("Button not found");

			_editHeaderButton.Click += (s, e) => IsEditHeaderActive = true;
		}


		public bool HasCloseButton
		{
			get => GetValue(HasCloseButtonProperty);
			set => SetValue(HasCloseButtonProperty, value);
		}

		public bool HasEditHeaderButton
		{
			get => GetValue(HasEditHeaderButtonProperty);
			set => SetValue(HasEditHeaderButtonProperty, value);
		}
		public bool IsEditHeaderActive
		{
			get => GetValue(IsEditHeaderActiveProperty);
			set => SetValue(IsEditHeaderActiveProperty, value);
		}

		public ICommand? CloseTabCommand
		{
			get => GetValue(CloseTabCommandProperty);
			set => SetValue(CloseTabCommandProperty, value);
		}
		public object? CloseTabCommandParameter
		{
			get => GetValue(CloseTabCommandParameterProperty);
			set => SetValue(CloseTabCommandParameterProperty, value);
		}
	}
}
