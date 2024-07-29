using EngineLine.Pages;
using Microsoft.UI.Xaml;

namespace EngineLine
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            ContentFrame.Navigate(typeof(Connection));
        }
    }
}
