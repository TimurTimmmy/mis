using LiteDB;
using mis.Items;
using System;
using System.Windows;


namespace mis
{
    /// <summary>
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {
        public EditPatient()
        {
            InitializeComponent();
            Actions.LoadPatients();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                var colPatient = db.GetCollection<Patient>("Patients");
                var patient = new Patient
                {
                    Name = PatientName.Text,
                    Sex = PatientSexCombo.Text,
                    Birth = BirthPicker.DisplayDate,
                    InsuranceID = Int32.Parse(PatientInsuranceId.Text),
                    Phone = Int32.Parse(PatientPhone.Text),
                    Address = PatientAddres.Text,
                    SnilsID = Int32.Parse(PatientSnilsID.Text)
                };
                colPatient.Insert(patient);
            }
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditPatients_Click(object sender, RoutedEventArgs e)
        {
            Actions.EditPats
                (
                new Patient
                {
                    Id = (Guid)PatientIdLabel.Content,
                    Name = PatientName.Text,
                    Sex = PatientSexCombo.Text,
                    Birth = BirthPicker.DisplayDate,
                    InsuranceID = Int32.Parse(PatientInsuranceId.Text),
                    Phone = Int32.Parse(PatientPhone.Text),
                    Address = PatientAddres.Text,
                    SnilsID = Int32.Parse(PatientSnilsID.Text)
                }
                );           
            Close();
        }

        private void PatientPhone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            NumControl.NumsOnlyInput(sender, e);
        }
    }
}
