using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReeYU.Module.Modules
{
    public interface IExcelImportable<T>
    {
        void ImportFromExcel(DataTable dataTable);
        IEnumerable<T> ImportFromExcel(IEnumerable<DataRow> dataRows);
        void ValidateDataRow(DataRow dataRow, List<string> errors);
        void FillFromExcelRow(string[] row);

    }
}
