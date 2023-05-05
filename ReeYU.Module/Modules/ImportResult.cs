using System;
using System.Collections.Generic;

namespace ReeYU.Module.Modules
{
    public class ImportResult<T>
    {
        private readonly List<T> importedObjects = new List<T>();
        private readonly List<ImportException> exceptions = new List<ImportException>();

        public IReadOnlyList<T> ImportedObjects => importedObjects.AsReadOnly();
        public IReadOnlyList<ImportException> Exceptions => exceptions.AsReadOnly();
        public int ImportedObjectCount => importedObjects.Count;
        public int ErrorCount => exceptions.Count;

        public void AddImportedObject(T importedObject)
        {
            importedObjects.Add(importedObject);
        }

        public void AddException(ImportException exception)
        {
            exceptions.Add(exception);
        }
    }

    public class ImportException : Exception
    {
        public enum ErrorType { Unknown, InvalidData, DuplicateData, Validation }

        public ErrorType Type { get; private set; }
        public int Row { get; set; }
        public string ColumnName { get; private set; }
        public string ErrorMessage { get; private set; }

        public ImportException(ErrorType type, int row, string columnName, string errorMessage, Exception innerException = null) : base(errorMessage, innerException)
        {
            Type = type;
            Row = row;
            ColumnName = columnName;
            ErrorMessage = errorMessage;
        }

        public override string ToString()
        {
            return $"[{Type}] Row: {Row}, Column: {ColumnName}, Message: {ErrorMessage}";
        }
    }
}
