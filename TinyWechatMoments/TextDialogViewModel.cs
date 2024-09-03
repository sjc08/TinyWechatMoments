using CommunityToolkit.Mvvm.ComponentModel;
using HandyControl.Tools.Extension;

namespace TinyWechatMoments
{
    public partial class TextDialogViewModel : ObservableObject, IDialogResultable<string>
    {
        [ObservableProperty]
        private string? message;

        [ObservableProperty]
        private string? result;

        public Action? CloseAction { get; set; }
    }
}
