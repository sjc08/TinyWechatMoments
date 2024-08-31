using Asjc.JsonConfig;
using HandyControl.Controls;

namespace TinyWechatMoments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : GlowWindow
    {
        private Data data = JsonConfig.Load<Data>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = data;
        }

        private void AddComment(object parameter)
        {

        }
    }
}