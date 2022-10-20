using ListofBooksByGenre.Classes;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ListofBooksByGenre
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowsVM();
        }


        public bool MyTextFilter(object item)
        {
            Book book = (Book)item;
            return (book.literaryGenre.ToString() == Genres.SelectedItem.ToString());

        }
        private void Genres_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {

            ICollectionView view = CollectionViewSource.GetDefaultView(List.ItemsSource);


            {
                view.SortDescriptions.Clear();
                view.Filter = new Predicate<object>(view.Filter = MyTextFilter);
            }
        }
    }
}
