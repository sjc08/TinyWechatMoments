using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace TinyWechatMoments
{
    [ObservableObject]
    public partial class Moment
    {
        public DateTime? Time { get; set; }

        public string? Friend { get; set; }

        public string? Text { get; set; }

        [ObservableProperty]
        public ObservableCollection<string>? medias;

        [ObservableProperty]
        public ObservableCollection<string>? likers;

        [ObservableProperty]
        public ObservableCollection<Comment>? comments;
    }
}
