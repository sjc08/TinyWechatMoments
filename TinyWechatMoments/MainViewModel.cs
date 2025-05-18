using Asjc.JsonConfig;
using Asjc.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Tools.Extension;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using HC = HandyControl.Controls;

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

        public bool ReadOnly { get; set; }

        [RelayCommand]
        private void Edit(Moment moment)
        {
            new EditWindow(moment).Show();
        }

        [RelayCommand]
        private async Task Comment(Moment moment)
        {
            var text = await HC.Dialog.Show<TextDialog>()
                                      .Initialize<TextDialogViewModel>(vm => vm.Message = $"以 {Identity} 的身份进行评论")
                                      .GetResultAsync<string?>();
            if (!string.IsNullOrEmpty(text))
            {
                moment.Comments ??= [];
                moment.Comments.Add(new() { Time = Time, Friend = Identity, Text = text });
                HC.Growl.Success("评论成功。");
            }
            else
            {
                HC.Growl.Warning("操作已取消。");
            }
        }

        [RelayCommand]
        private void Like(Moment moment)
        {
            moment.Likers ??= [];
            if (!moment.Likers.Contains(Identity))
                moment.Likers.Add(Identity);
        }

        [RelayCommand]
        private void Post()
        {
            Moment moment = new() { Friend = Identity, Time = Time };
            Data?.Moments.Add(moment);
            Edit(moment);
        }

        [RelayCommand]
        private void Open(string path)
        {
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        }

        [RelayCommand]
        private void Load()
        {
            Data = Tryer.Try(JsonConfig.Load<Data>, e => HC.Growl.Error(e.Message));
            if (Data != null && Data.ShowWarnings)
            {
                HashSet<string> medias = [];
                foreach (var moment in Data.Moments)
                {
                    if (moment.Medias != null)
                    {
                        foreach (var media in moment.Medias)
                        {
                            if (!File.Exists(media))
                                HC.Growl.Warning($"无效的媒体：{media}");
                            if (!medias.Add(Path.GetFullPath(media)))
                                HC.Growl.Warning($"重复的媒体：{media}");
                        }
                    }
                }
                foreach (var media in Directory.EnumerateFiles("Medias"))
                {
                    if (!medias.Contains(Path.GetFullPath(media)))
                        HC.Growl.Warning($"未使用的媒体：{media}");
                }
            }
        }

        [RelayCommand]
        private void Closing(CancelEventArgs e)
        {
            if (ReadOnly)
            {
                if (Tryer.Try(JsonConfig.Load<Data>)?.Json != Data?.Json)
                {
                    if (HC.MessageBox.Ask("此操作会放弃所有未保存的更改，确定要继续吗？") != MessageBoxResult.OK)
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                Data?.Save();
            }
        }
    }
}
