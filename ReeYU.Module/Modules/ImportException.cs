using System;
using System.Collections.Generic;
using System.Linq;

public class ImportException : Exception
{
    public enum ErrorType
    {
        Unknown,
        Validation,
        Critical
    }

    public ErrorType Type { get; }
    public IEnumerable<string> FailedImports { get; }

    public ImportException(string message, ErrorType type = ErrorType.Unknown, IEnumerable<string> failedImports = null)
        : base(message)
    {
        Type = type;
        FailedImports = failedImports ?? Enumerable.Empty<string>();
    }
}
