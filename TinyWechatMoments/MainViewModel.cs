using Asjc.JsonConfig;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TinyWechatMoments
{
    public partial class MainViewModel : ObservableObject
    {
        public Data Data { get; set; } = JsonConfig.Load<Data>();

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
        private void AddComment(Moment moment)
        {

        }

        public List<string> FriendList => Data.Moments.Select(m => m.Friend).Distinct().ToList();
    }
}
