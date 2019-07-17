using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using testWPF.Model;

namespace testWPF.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Books = new ObservableCollection<Book>(Book.Get2Books());
            AddCommand = new DelegateCommand(AddBook);
            RemoveCommand = new DelegateCommand(RemoveBook, canRemoveBook);
        }

        private bool canRemoveBook(object arg)
        {
            return (arg as Book) != null;
        }

        private void RemoveBook(object obj)
        {
            Books.Remove((Book)obj);
        }

        private void AddBook(object obj)
        {
            Books.Add(new Book { Author= "Автор", Title = "Новая книга"});
        }

        Book[] books;
        Book selectedBook;
        public ObservableCollection<Book> Books { get; private set; }
        public Book SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }

        #region MVVM Pattern
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string property_name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property_name));
        }
        #endregion
    }
}
