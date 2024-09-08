namespace TinyWechatMoments
{
    public class Comment
    {
        public DateTime? Time { get; set; }

        public required string Friend { get; set; }

        public string? Text { get; set; }
    }
}
