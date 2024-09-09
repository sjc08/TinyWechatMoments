using CommunityToolkit.Mvvm.ComponentModel;

namespace TinyWechatMoments
{
    public partial class Comment : ObservableObject
    {
        public required string Friend { get; init; }

        public DateTime? Time { get; init; }

        [ObservableProperty]
        public string? text;
    }
}
