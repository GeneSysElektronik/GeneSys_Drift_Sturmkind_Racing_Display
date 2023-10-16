using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Media;
using Avalonia.Metadata;
using Templates.Controls;

namespace Templates.Controls
{
    public class GroupBox : TemplatedControl
    {
        #region properties
        public static readonly StyledProperty<string> HeaderProperty =
            AvaloniaProperty.Register<GroupBox, string>(
                nameof(Header));

        public static readonly StyledProperty<Control?> ChildProperty =
            AvaloniaProperty.Register<GroupBox, Control?>(
                nameof(Child));
        #endregion

        #region parameters
        public string Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
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

        public GroupBox()
        {
            ChildProperty.Changed.AddClassHandler<GroupBox>((x, e) => x.ChildChanged(e));
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
