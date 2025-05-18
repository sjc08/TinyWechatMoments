using Asjc.JsonConfig;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace TinyWechatMoments
{
    [ObservableObject]
    public partial class Data : JsonConfig
    {
        public bool ShowWarnings { get; init; }

        [ObservableProperty]
        public ObservableCollection<Moment> moments =
        [
            new()
            {
                Friend = "我",
                Text = "这是范例。",
                Medias =
                [
                    "Medias\\1.jpg",
                    "Medias\\2.jpg",
                    "Medias\\3.jpg"
                ],
                Likers =
                [
                    "小明",
                    "小红"
                ],
                Comments =
                [
                    new()
                    {
                        Friend = "小明",
                        Text = "你好！"
                    }
                ]
            }
        ];
    }
}
