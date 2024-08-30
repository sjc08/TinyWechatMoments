namespace TinyWechatMoments
{
    public class Moment
    {
        public DateTime Time { get; set; } = DateTime.Now;

        public string Friend { get; set; } = "我";

        public string? Text { get; set; }

        public List<string>? Medias { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
