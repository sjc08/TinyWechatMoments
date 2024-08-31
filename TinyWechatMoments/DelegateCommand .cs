using System.Windows.Input;

namespace TinyWechatMoments
{
    public class DelegateCommand : ICommand
    {
        public Predicate<object?> CanExecuteDelegate { set; get; } = _ => true;

        public Action<object?>? ExecuteDelegate { set; get; }

        public bool CanExecute(object? parameter) => CanExecuteDelegate.Invoke(parameter);

        public void Execute(object? parameter) => ExecuteDelegate?.Invoke(parameter);

        public event EventHandler? CanExecuteChanged;
    }
}
