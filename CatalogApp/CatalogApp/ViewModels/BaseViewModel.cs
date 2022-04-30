using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CatalogApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }
        #endregion

        private int _id;
        private string _title;
        private string _genre;
        private int _row;
        private int _shelving;
        private int _shelf;

        public int ID
        {
            get { return _id; }
            set
            {
                SetValue(ref _id, value);
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                SetValue(ref _title, value);
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Genre
        {
            get { return _genre; }
            set
            {
                SetValue(ref _genre, value);
                OnPropertyChanged(nameof(Genre));
            }
        }

        public int Row
        {
            get { return _row; }
            set
            {
                SetValue(ref _row, value);
                OnPropertyChanged(nameof(Row));
            }
        }

        public int Shelving
        {
            get { return _shelving; }
            set
            {
                SetValue(ref _shelving, value);
                OnPropertyChanged(nameof(Shelving));
            }
        }

        public int Shelf
        {
            get { return _shelf; }
            set
            {
                SetValue(ref _shelf, value);
                OnPropertyChanged(nameof(Shelf));
            }
        }
    }
}