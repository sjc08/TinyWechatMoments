using Asjc.JsonConfig;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Tools.Extension;
using System.Text.Json.Serialization;

namespace TinyWechatMoments
{
    public partial class MainViewModel : ObservableObject
    {
        public Data Data { get; set; }

        public MainViewModel()
        {
            JsonConfig.GlobalOptions.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            Data = JsonConfig.Load<Data>();
        }

        public string Identity { get; set; } = "我";

        [ObservableProperty]
        private bool manualTime = false;

        private DateTime currentTime;
        public DateTime CurrentTime
        {
            get => ManualTime ? currentTime : DateTime.Now;
            set => currentTime = value;
        }

        [RelayCommand]
        private async Task AddComment(Moment moment)
        {
            var text = await Dialog.Show<TextDialog>()
                                   .Initialize<TextDialogViewModel>(vm => vm.Message = $"以 {Identity} 的身份进行评论")
                                   .GetResultAsync<string>();
            moment.Comments.Add(new() { Friend = Identity, Text = text, Time = CurrentTime });
            Data.Save();
        }

        public List<string> FriendList => Data.Moments.Select(m => m.Friend).Distinct().ToList();
    }
}
