using Asjc.JsonConfig;
using Asjc.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Tools.Extension;
using System.Text.Json.Serialization;

namespace TinyWechatMoments
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private Data data;

        public MainViewModel()
        {
            JsonConfig.GlobalOptions.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            Load();
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
                                   .GetResultAsync<string?>();
            if (!string.IsNullOrEmpty(text))
            {
                moment.Comments.Add(new() { Time = CurrentTime, Friend = Identity, Text = text });
                Data.Save();
                Growl.Success("评论成功。");
            }
            else
            {
                Growl.Warning("操作已取消。");
            }
        }

        [RelayCommand]
        private void Load()
        {
            Data = Tryer.Try(JsonConfig.Load<Data>, e => Growl.Error(e.Message));
        }

        public List<string> FriendList => Data.Moments.Select(m => m.Friend).Distinct().ToList();
    }
}
