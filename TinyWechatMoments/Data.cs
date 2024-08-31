using Asjc.JsonConfig;
using System.Text.Json.Serialization;

namespace TinyWechatMoments
{
    public class Data : JsonConfig
    {
        public List<Moment> Moments { get; set; } =
        [
            new()
            {
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


        [JsonIgnore]
        public string Identity { get; set; } = "我";

        [JsonIgnore]
        public bool ManualTime { get; set; }

        private DateTime currentTime;
        [JsonIgnore]
        public DateTime CurrentTime 
        {
            get => ManualTime ? currentTime : DateTime.Now;
            set => currentTime = value;
        }

        [JsonIgnore]
        public List<string> FriendList => Moments.Select(m => m.Friend).Distinct().ToList();
    }
}
