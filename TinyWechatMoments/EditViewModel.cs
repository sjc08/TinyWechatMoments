using CommunityToolkit.Mvvm.Input;
using System.Collections;
using System.Windows;

namespace TinyWechatMoments
{
    public partial class EditViewModel(Moment moment)
    {
        public Moment Moment { get; } = moment;

        [RelayCommand]
        private void Drop(DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string[] medias)
            {
                Moment.Medias ??= [];
                foreach (var item in medias)
                    Moment.Medias.Add(item);
            }
        }

        [RelayCommand]
        private void Delete(IList medias)
        {
            foreach (var i in medias.OfType<string>().ToList())
                Moment.Medias?.Remove(i);
        }
    }
}
