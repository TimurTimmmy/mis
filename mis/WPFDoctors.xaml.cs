using mis.Items;
using System;
using System.Windows;
using System.Windows.Controls;

namespace mis
{
    /// <summary>
    /// Interaction logic for Doctors.xaml
    /// </summary>
    public partial class WPFDoctors : Window
    {

        Doctor tmp;

        public WPFDoctors()
        {
            InitializeComponent();         

            Actions.RefreshDocs(GridDoctors);
        }

        private void AddDoc_Click(object sender, RoutedEventArgs e)
        {
            EditDocs editDocs = new EditDocs();
            editDocs.EditDocsButton.Visibility = Visibility.Hidden;
            editDocs.OkEditDocs.Visibility = Visibility.Visible;
            editDocs.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Actions.RefreshDocs(GridDoctors);
        }

        private void DelDoc_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                Guid g = tmp.Id;
                MessageBox.Show("Удален", tmp.Name);
                Actions.DelDocs(g);
                Actions.RefreshDocs(GridDoctors);
            }
            catch (Exception)
            {
                MessageBox.Show("Ничего не выбрано", "Ошибка");
            }            
        }

        private void GridDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           DataGrid dg = (DataGrid)sender;
           tmp = (Doctor)dg.SelectedValue;            
        }

        private void EditDoc_Click(object sender, RoutedEventArgs e)
        {
            EditDocs editDocs = new EditDocs();
            editDocs.OkEditDocs.Visibility = Visibility.Hidden;
            editDocs.EditDocsButton.Visibility = Visibility.Visible;
            try
            {
                editDocs.DocName.Text = tmp.Name;
                editDocs.DocOffice.Text = tmp.Office;
                editDocs.DocPhone.Text = tmp.Phone;
                editDocs.DocPosition.Text = tmp.Position;
                editDocs.DocIdLabel.Content = tmp.Id;
                editDocs.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Ничего не выбрано", "Ошибка");
            }
        }
    }
}
