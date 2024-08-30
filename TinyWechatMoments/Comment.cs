namespace TinyWechatMoments
{
    public class Comment
    {
        public DateTime Time { get; set; } = DateTime.Now;

        public string Friend { get; set; } = "我";

        public string? Text { get; set; }
    }
}
