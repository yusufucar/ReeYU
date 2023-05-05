using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace ReeYU.Module.Modules
{
    [NonPersistent]
    public class ColumnMapping : XPObject
    {
        public ColumnMapping() : base(Session.DefaultSession) { }

        private int excelColumnIndex;
        [ModelDefault("DisplayFormat", "0")]
        public int ExcelColumnIndex
        {
            get { return excelColumnIndex; }
            set { SetPropertyValue(nameof(ExcelColumnIndex), ref excelColumnIndex, value); }
        }

        private string excelColumnName;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ExcelColumnName
        {
            get { return excelColumnName; }
            set { SetPropertyValue(nameof(ExcelColumnName), ref excelColumnName, value); }
        }

        private string objectPropertyName;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ObjectPropertyName
        {
            get { return objectPropertyName; }
            set { SetPropertyValue(nameof(ObjectPropertyName), ref objectPropertyName, value); }
        }
    }
}
