using mis.Items;
using System.Windows;


namespace mis
{
    /// <summary>
    /// Interaction logic for WPFMainWindow.xaml
    /// </summary>
    public partial class WPFMainWindow : Window
    {
        public WPFMainWindow()
        {
            InitializeComponent();
        }

        private void ButtonDocs_Click(object sender, RoutedEventArgs e)
        {
            WPFDoctors doctorsWindow = new WPFDoctors();
            while (doctorsWindow.ShowDialog() == true) { }
        }

        private void ButtonPatients_Click(object sender, RoutedEventArgs e)
        {
            WPFPatients patientsWindow = new WPFPatients();
            while (patientsWindow.ShowDialog() == true) { }
        }

        private void AddVisitButton_Click(object sender, RoutedEventArgs e)
        {
            AddVisit addVisit = new AddVisit();
            addVisit.Show();
        }

        private void MkbButton_Click(object sender, RoutedEventArgs e)
        {
            WPFMkb wPFMkb = new WPFMkb();
            wPFMkb.Show();
        }

        private void RefreshVisits_Click(object sender, RoutedEventArgs e)
        {
            Actions.RefreshVisits(VisitsGrid);
        }
    }
}
