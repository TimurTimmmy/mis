using System.Windows;

namespace mis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WPFMainWindow wPFMainWindow = new WPFMainWindow();
            wPFMainWindow.Show();
            Close();
        }      
    }
}
