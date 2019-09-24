using LiteDB;
using mis.Items;
using mis.MKB;
using System;
using System.Windows;

namespace mis
{
    /// <summary>
    /// Interaction logic for AddVisit.xaml
    /// </summary>
    public partial class AddVisit : Window
    {
        //public string PurposeId = "test";
        public AddVisit()
        {
            InitializeComponent();
            var MKB = Actions.LoadMkb().MkbList;            
            MkbComboBox.ItemsSource = MKB;
            ExtraMkbComboBox.ItemsSource = MKB;
            PatientComboBox.ItemsSource = Actions.LoadPatients();
            DoctorComboBox.ItemsSource = Actions.LoadDocs();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            EditPatient editPatient = new EditPatient();
            editPatient.EditPatientsButton.Visibility = Visibility.Hidden;
            editPatient.OkEditPatients.Visibility = Visibility.Visible;
            editPatient.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                Doctor tmpdoc = (Doctor)DoctorComboBox.SelectedItem;
                var colVisit = db.GetCollection<Visit>("Visits");
                var visit = new Visit
                {
                    Patient = (Patient)PatientComboBox.SelectedItem,
                    VisitDate = (System.DateTime)VisitDateTime.Value,
                    //Doc = (Doctor)DoctorComboBox.SelectedItem,
                    Doc = tmpdoc,
                    GuidDoc = tmpdoc.Id,
                    VisitDetails = new VisitDetails
                    {
                        VisitPurpose = 0,
                        VisitCase = 0,
                        VisitCharacter = 0,
                        VisitMkb = (Mkb)MkbComboBox.SelectedItem,
                        VisitСomplaints = СomplaintsText.Text,
                        VisitСheckup = СheckupText.Text,
                        VisitСonclusion = СonclusionText.Text,
                        VisitTreatment = TreatmentText.Text,
                        VisitDiagnosis = DiagnosisText.Text                        
                    }
                };
                colVisit.Insert(visit);
                VisitIdLabel.Content = visit.Id;
                SaveButton.IsEnabled = false;
            }
        }

    }
}
