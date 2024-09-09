using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace TinyWechatMoments
{
    public partial class Moment : ObservableObject
    {
        public required string Friend { get; init; }

        public DateTime? Time { get; init; }

        [ObservableProperty]
        public string? text;

        [ObservableProperty]
        public ObservableCollection<string>? medias;

        [ObservableProperty]
        public ObservableCollection<string>? likers;

        [ObservableProperty]
        public ObservableCollection<Comment>? comments;
    }
}
