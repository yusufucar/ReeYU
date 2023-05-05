using DevExpress.ExpressApp;
using DevExpress.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ReeYU.Module.Modules
{
    public class ExcelImporter<T> where T : IExcelImportable<T>
    {
        private IObjectSpace objectSpace;
        private string[] columnNames;

        public ExcelImporter(IObjectSpace objectSpace)
        {
            this.objectSpace = objectSpace;
        }

        public ImportResult<T> Import(string fileName)
        {
            var result = new ImportResult<T>();

            try
            {
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    var workbook = new Workbook();
                    workbook.LoadDocument(stream);
                    var worksheet = (Worksheet)workbook.Worksheets[0];

                    // Get the header row (first row) of the worksheet
                    var headerRow = worksheet.GetDataRange().First();
                    columnNames = headerRow.Select(cell => cell.DisplayText).ToArray();

                    // Load all data into a DataTable
                    var dataTable = worksheet.CreateDataTable(headerRow, true, true);

                    // Import each data row
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        try
                        {
                            var obj = objectSpace.CreateObject<T>();
                            obj.ImportFromExcel(dataTable);
                            obj.ValidateDataRow(dataRow, new List<string>());
                            objectSpace.CommitChanges();
                            result.AddImportedObject(obj);
                        }
                        catch (ImportException ex)
                        {
                            result.AddException(new ImportException(ImportException.ErrorType.Unknown, -1, "", ex.Message, ex));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.AddException(new ImportException(ImportException.ErrorType.Unknown, -1, "", ex.Message, ex));
            }

            return result;
        }

        private T ImportRow(Row row)
        {
            // Convert the row data to a DataTable to pass to the IExcelImportable methods
            var dataTable = new DataTable();
            for (int i = 0; i < columnNames.Length; i++)
            {
                dataTable.Columns.Add(columnNames[i]);
                dataTable.Rows.Add(row[i].Value);
            }

            // Create a new object using the IObjectSpace
            var obj = objectSpace.CreateObject<T>();

            // Call the IExcelImportable methods to import and validate the data
            obj.ImportFromExcel(dataTable);
            obj.ValidateDataRow(dataTable.Rows[0], new List<string>());

            // Save the object to the database
            objectSpace.CommitChanges();

            return obj;
        }

    }

    public static class WorksheetExtensions
    {
        public static Cell GetSelectedCell(this Worksheet worksheet)
        {
            var selection = worksheet.Selection;
            var row = selection.TopRowIndex;
            var column = selection.LeftColumnIndex;
            return worksheet.Cells[row, column];
        }
    }
}
