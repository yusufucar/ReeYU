using System.ComponentModel;

namespace ReeYU.Module.Modules
{
    public class ExcelImportOptions : INotifyPropertyChanged
    {
        private bool _hasHeaderRow = true;
        private char _columnDelimiter = ',';

        public bool HasHeaderRow
        {
            get => _hasHeaderRow;
            set
            {
                _hasHeaderRow = value;
                OnPropertyChanged(nameof(HasHeaderRow));
            }
        }

        public char ColumnDelimiter
        {
            get => _columnDelimiter;
            set
            {
                _columnDelimiter = value;
                OnPropertyChanged(nameof(ColumnDelimiter));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
