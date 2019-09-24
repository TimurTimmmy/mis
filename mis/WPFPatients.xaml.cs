using mis.Items;
using System;
using System.Windows;
using System.Windows.Controls;

namespace mis
{
    /// <summary>
    /// Interaction logic for WPFPatients.xaml
    /// </summary>
    public partial class WPFPatients : Window
    {
        Patient tmp;
        public WPFPatients()
        {
            InitializeComponent();
            Actions.RefreshPatients(GridPatients);           
        }

        private void AddPat_Click(object sender, RoutedEventArgs e)
        {
            EditPatient editPatient = new EditPatient();
            editPatient.EditPatientsButton.Visibility = Visibility.Hidden;
            editPatient.OkEditPatients.Visibility = Visibility.Visible;
            editPatient.Show();
        }

        private void GridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            tmp = (Patient)dg.SelectedValue;
        }

        private void DelPat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guid g = tmp.Id;
                MessageBox.Show("Удален", tmp.Name);
                Actions.DelPats(g);
                Actions.RefreshPatients(GridPatients);
            }
            catch (Exception)
            {
                MessageBox.Show("Ничего не выбрано", "Ошибка");
            }
        }

        private void EditPat_Click(object sender, RoutedEventArgs e)
        {
            EditPatient editPats = new EditPatient();
            editPats.EditPatientsButton.Visibility = Visibility.Visible;
            editPats.OkEditPatients.Visibility = Visibility.Hidden;
            try
            {
                editPats.PatientIdLabel.Content = tmp.Id;
                editPats.BirthPicker.SelectedDate = tmp.Birth;
                editPats.PatientName.Text = tmp.Name;
                editPats.PatientSexCombo.Text = tmp.Sex == "Муж" ? "Муж" : "Жен";
                editPats.PatientInsuranceId.Text = tmp.InsuranceID.ToString();
                editPats.PatientPhone.Text = tmp.Phone.ToString();
                editPats.PatientAddres.Text = tmp.Address;
                editPats.PatientSnilsID.Text = tmp.SnilsID.ToString();                
                editPats.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Ничего не выбрано", "Ошибка");
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Actions.RefreshPatients(GridPatients);
        }
    }
}
