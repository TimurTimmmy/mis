using LiteDB;
using mis.MKB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace mis.Items
{
    public static class Actions
    {

        public static List<Doctor> LoadDocs()
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                var colDoc = db.GetCollection<Doctor>("Doctors");
                var result = colDoc.FindAll();
                var ItemList = new List<Doctor>();

                foreach (Doctor d in result)
                {
                    ItemList.Add(d);
                }
                return ItemList;
            }
        }

        public static List<Patient> LoadPatients()
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                var colPat = db.GetCollection<Patient>("Patients");
                var result = colPat.FindAll();
                var ItemList = new List<Patient>();

                foreach (Patient d in result)
                {
                    ItemList.Add(d);
                }
                return ItemList;
            }
        }

        public static List<Visit> LoadVisits()
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                var colPat = db.GetCollection<Visit>("Visits");
                var result = colPat.FindAll();
                var ItemList = new List<Visit>();

                foreach (Visit d in result)
                {
                    ItemList.Add(d);
                }
                return ItemList;
            }
        }

        public static void RefreshDocs(DataGrid dataGrid)
        {
            dataGrid.ItemsSource = LoadDocs();
        }

        public static void RefreshPatients(DataGrid dataGrid)
        {
            dataGrid.ItemsSource = LoadPatients();            
        }

        public static void RefreshVisits(DataGrid dataGrid)
        {
            dataGrid.ItemsSource = LoadVisits();
        }

        public static void DelDocs(Guid id)
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                var colDoc = db.GetCollection<Doctor>("Doctors");
                colDoc.EnsureIndex(x => x.Id);
                colDoc.Delete(x => x.Id.Equals(id));
            }
        }

        public static void EditDocs(Guid id, string name, string position, string phone, string office)
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                var colDoc = db.GetCollection<Doctor>("Doctors");
                var tempdoc = colDoc.FindById(id);                
                tempdoc.Name = name;
                tempdoc.Office = office;
                tempdoc.Phone = phone;
                tempdoc.Position = position;
                colDoc.Update(tempdoc);
            }
        }

        public static void EditPats(Patient p)
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                var colPat = db.GetCollection<Patient>("Patients");
                var tempPat = colPat.FindById(p.Id);
                tempPat = p;
                colPat.Update(tempPat);
            }
        }

        public static void DelPats(Guid id)
        {
            using (var db = new LiteDatabase(@"info.db"))
            {
                var colDoc = db.GetCollection<Patient>("Patients");
                colDoc.EnsureIndex(x => x.Id);
                colDoc.Delete(x => x.Id.Equals(id));
            }
        }

        public static Mkb10 LoadMkb()
        {
            string Dir = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                using (StreamReader file = File.OpenText(Dir + "mkb.json"))
                {
                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    var mkb = (Mkb10)serializer.Deserialize(file, typeof(Mkb10));
                    return mkb;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл не найденю. Обратитесь в поддержку.");
                return null;
            }
        }
    }
}
