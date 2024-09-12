using HandyControl.Controls;

namespace TinyWechatMoments
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : GlowWindow
    {
        public EditWindow(Moment moment)
        {
            InitializeComponent();
            DataContext = new EditViewModel(moment);
        }
    }
}
