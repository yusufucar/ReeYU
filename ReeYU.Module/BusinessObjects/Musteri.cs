//using DevExpress.Data.Filtering;
//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.DC;
//using DevExpress.ExpressApp.Model;
//using DevExpress.Persistent.Base;
//using DevExpress.Persistent.BaseImpl;
//using DevExpress.Persistent.Validation;
//using DevExpress.Xpo;
//using ReeYU.Module.Modules;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;

//namespace ReeYU.Module.BusinessObjects
//{
//    [DefaultClassOptions]
//    //[ImageName("BO_Contact")]
//    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
//    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
//    //[Persistent("DatabaseTableName")]
//    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).

//    [Persistent("Musteri")]
//    public class Musteri : BaseObject, IExcelImportable
//    {
//        public Musteri(Session session) : base(session)
//        {
//        }

//        private string _adi;
//        [Persistent("Adi")]
//        [RuleRequiredField(DefaultContexts.Save)]
//        public string Adi
//        {
//            get { return _adi; }
//            set { SetPropertyValue(nameof(Adi), ref _adi, value); }
//        }

//        private string _soyadi;
//        [Persistent("Soyadi")]
//        [RuleRequiredField(DefaultContexts.Save)]
//        public string Soyadi
//        {
//            get { return _soyadi; }
//            set { SetPropertyValue(nameof(Soyadi), ref _soyadi, value); }
//        }

//        private string _telefon;
//        [Persistent("Telefon")]
//        [RuleRequiredField(DefaultContexts.Save)]
//        public string Telefon
//        {
//            get { return _telefon; }
//            set { SetPropertyValue(nameof(Telefon), ref _telefon, value); }
//        }

//        public void ExcelImport(string sheetName, List<Dictionary<string, object>> worksheetData)
//        {
//            // Get the property names of the Musteri class
//            var propertyNames = typeof(Musteri).GetProperties().Select(p => p.Name).ToList();

//            foreach (var row in worksheetData)
//            {
//                // Create a new Musteri object
//                var musteri = new Musteri(Session);

//                // Set the property values from the Excel data
//                foreach (var kvp in row)
//                {
//                    var propertyName = kvp.Key;
//                    if (propertyNames.Contains(propertyName))
//                    {
//                        var propertyInfo = typeof(Musteri).GetProperty(propertyName);
//                        var propertyValue = Convert.ChangeType(kvp.Value, propertyInfo.PropertyType);
//                        propertyInfo.SetValue(musteri, propertyValue);
//                    }
//                }

//                // Save the new Musteri object
//                musteri.Save();
//            }
//        }

//        public void Import(List<Dictionary<string, object>> rowData)
//        {
//            foreach (var row in rowData)
//            {
//                // Create a new Musteri object
//                var musteri = new Musteri(Session);

//                // Set the property values from the Excel data
//                musteri.Adi = Convert.ToString(row["Adi"]);
//                musteri.Soyadi = Convert.ToString(row["Soyadi"]);
//                musteri.Telefon = Convert.ToString(row["Telefon"]);

//                // Save the new Musteri object
//                musteri.Save();
//            }
//        }
//    }
//}