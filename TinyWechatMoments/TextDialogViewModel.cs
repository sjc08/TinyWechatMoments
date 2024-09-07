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
        private async Task Confirm()
        {
            Result = text;
            CloseAction();
        }

        [RelayCommand]
        private async Task Cancel()
        {
            CloseAction();
        }

        public string? Result { get; set; }

        public Action? CloseAction { get; set; }
    }
}
