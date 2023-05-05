using System;

namespace ReeYU.Module.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExcelImportAttribute : Attribute
    {
        public bool Enabled { get; set; } = false;
    }
}
