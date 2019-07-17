using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWPF.Model
{
    class Book : INotifyPropertyChanged
    {
        string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

        string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public static Book[] Get2Books()
        {
            Book[] books = new Book[2]
            {
                new Book(){Author = "Стивен Кинг", Title = "Книга Кинга" },
                new Book(){Author = "Миша Булгаков", Title = "Мастер и Маргарита"}
            };
            return books;
        }
        #region MVVM Pattern
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property_name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
        #endregion
    }
}
