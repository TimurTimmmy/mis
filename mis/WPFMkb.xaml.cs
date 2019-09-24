using System;
using System.IO;
using System.Windows;
using mis.Items;
using mis.MKB;
using Newtonsoft.Json;

namespace mis
{
    /// <summary>
    /// Interaction logic for WPFMkb.xaml
    /// </summary>
    public partial class WPFMkb : Window
    {
        string Dir = AppDomain.CurrentDomain.BaseDirectory;
        public WPFMkb()
        {
            InitializeComponent();
            MkbGrid.ItemsSource = Actions.LoadMkb().MkbList;
        }

        //public void LoadMkb()
        //{
        //    try
        //    {
        //        using (StreamReader file = File.OpenText(Dir + "mkb.json"))
        //        {
        //            JsonSerializer serializer = new JsonSerializer();
        //            var mkb = (Mkb10)serializer.Deserialize(file, typeof(Mkb10));
        //            MkbGrid.ItemsSource = mkb.MkbList;
        //        }
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        MessageBox.Show("Файл не найденю. Обратитесь в поддержку.");
        //    }
        //}
    }
}
