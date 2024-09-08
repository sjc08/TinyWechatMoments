using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Tools.Extension;

namespace TinyWechatMoments
{
    public partial class TextDialogViewModel : ObservableObject, IDialogResultable<string?>
    {
        [ObservableProperty]
        private string? message;

        [ObservableProperty]
        private string? text;

        [RelayCommand]
        private void Confirm()
        {
            Result = Text;
            CloseAction();
        }

        [RelayCommand]
        private void Cancel()
        {
            CloseAction();
        }

        public string? Result { get; set; }

        public Action? CloseAction { get; set; }
    }
}
