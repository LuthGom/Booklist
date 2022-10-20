using ListofBooksByGenre.Classes;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
namespace ListofBooksByGenre
{
    public class MainWindowsVM
    {
        public ObservableCollection<Book> BookList { get; set; }
        public ObservableCollection<Book> BooksTemp { get; set; }
        public ICommand InsertBook { get; private set; }
        public ICommand RemoveBook { get; private set; }
        public ICommand UpdateBook { get; private set; }
        public ICommand SelectedBook   { get; set; }
        public Book RegisteredBook { get; set; }
        public string genre { get; set; }
        public MainWindowsVM()
        {
            BookList = new ObservableCollection<Book>()
            {

            };
            Commands();
        }
        public void Commands()
        {
            InsertBook = new RelayCommand((object __) =>
            {
                Book newBook = new Book();
                RegistrationBook insertScreen = new RegistrationBook();
                insertScreen.DataContext = newBook;
                insertScreen.ShowDialog();
                BookList.Add(newBook);
            });

            RemoveBook = new RelayCommand((object __) =>
            {
                BookList.Remove(RegisteredBook);
            });
            UpdateBook = new RelayCommand((object __) =>
            {
                Book NovoBook = new Book();

                if (RegisteredBook != null)
                {
                    RegistrationBook updateScreen = new RegistrationBook();
                    NovoBook = RegisteredBook.Clone();
                    updateScreen.DataContext = NovoBook;
                    bool? register = updateScreen.ShowDialog();
                    if (register.HasValue && register.Value)
                    {
                        RegisteredBook.Update(NovoBook);
                        ;
                    }


                }
            });
            SelectedBook = new RelayCommand((object _) =>

            {

                BookList = BookList.Where(x => {

                    if (x.LiteraryGenre.Equals(genre))
                    {
                        return true;
                    }else
                    {
                        return false;
                    }
                        });
            });
        }
        
    }
}
