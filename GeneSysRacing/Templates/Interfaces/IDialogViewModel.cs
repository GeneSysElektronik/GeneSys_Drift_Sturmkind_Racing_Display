using ReactiveUI;
using System.Reactive;

namespace Templates.Interfaces
{
	public interface IDialogViewModel
    {
        string WindowTitle { get; }
        double WindowWidth { get; }
        double WindowHeight { get; }

        bool CanResize { get; }

        ReactiveCommand<Unit, Unit>? CancelButtonCommand { get; }
        ReactiveCommand<Unit, Unit>? BackButtonCommand { get; }
        ReactiveCommand<Unit, Unit>? NextButtonCommand { get; }
    }
}
