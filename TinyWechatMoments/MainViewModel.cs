using Asjc.JsonConfig;
using Asjc.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Tools.Extension;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace TinyWechatMoments
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            JsonConfig.GlobalOptions.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            Load();
        }

        [ObservableProperty]
        private Data? data;

        public string Identity { get; set; } = "我";

        [ObservableProperty]
        private bool autoTime = true;

        [ObservableProperty]
        private bool manualTime;

        private DateTime? time;
        public DateTime? Time
        {
            get => AutoTime ? DateTime.Now : ManualTime ? time : null;
            set => time = value;
        }

        public List<string>? FriendList => Data?.Moments.Select(m => m.Friend).Distinct().ToList();

        [RelayCommand]
        private async Task AddComment(Moment moment)
        {
            var text = await Dialog.Show<TextDialog>()
                                   .Initialize<TextDialogViewModel>(vm => vm.Message = $"以 {Identity} 的身份进行评论")
                                   .GetResultAsync<string?>();
            if (!string.IsNullOrEmpty(text))
            {
                moment.Comments ??= [];
                moment.Comments.Add(new() { Time = Time, Friend = Identity, Text = text });
                Growl.Success("评论成功。");
            }
            else
            {
                Growl.Warning("操作已取消。");
            }
        }

        [RelayCommand]
        private void Post()
        {
            Moment moment = new() { Friend = Identity, Time = Time };
            Data?.Moments.Add(moment);
            PublishWindow window = new() { DataContext = moment };
            window.Show();
        }

        [RelayCommand]
        private void Load()
        {
            Data = Tryer.Try(JsonConfig.Load<Data>, e => Growl.Error(e.Message));
        }

        [RelayCommand]
        private void Save()
        {
            Data.Save();
        }

        [RelayCommand]
        private void OpenFile(string path)
        {
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        }
    }
}
