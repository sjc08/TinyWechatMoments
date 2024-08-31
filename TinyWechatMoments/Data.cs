using Asjc.JsonConfig;

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
    }
}
