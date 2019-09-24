using LiteDB;
using mis.Items;
using System;
using System.Windows;

namespace mis
{
    /// <summary>
    /// Interaction logic for EditDocs.xaml
    /// </summary>
    public partial class EditDocs : Window
    {
        public EditDocs()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                var colDoc = db.GetCollection<Doctor>("Doctors");
                var doc = new Doctor
                {
                    Name = DocName.Text,
                    Position = DocPosition.Text,
                    Phone = DocPhone.Text,
                    Office = DocOffice.Text
                };
                colDoc.Insert(doc);
            }
            Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditDocs_Click(object sender, RoutedEventArgs e)
        {
            Actions.EditDocs(Guid.Parse(DocIdLabel.Content.ToString()), DocName.Text, DocPosition.Text, DocPhone.Text, DocOffice.Text);
        }
    }
}
