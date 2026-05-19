using LibraryManager.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.Views
{
    /// <summary>
    /// Логика взаимодействия для EditIssuedBookPage.xaml
    /// </summary>
    public partial class EditIssuedBookPage : Page
    {
        private IssuedBook _currentRecord;

        public EditIssuedBookPage(IssuedBook record)
        {
            InitializeComponent();
            _currentRecord = record;

            BookCmb.ItemsSource = AppData.db.Books
                  .Where(b => b.IsAvailable == true || b.Id == _currentRecord.BookId).ToList();

            BookCmb.SelectedItem = AppData.db.Books.FirstOrDefault(b => b.Id == _currentRecord.BookId);
            ReaderNameTxb.Text = _currentRecord.ReaderName;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BookCmb.SelectedItem as Book;

            if (selectedBook != null && selectedBook.Id != _currentRecord.BookId)
            {
                _currentRecord.Book.IsAvailable = true;
                selectedBook.IsAvailable = false;
                _currentRecord.BookId = selectedBook.Id;
            }

            _currentRecord.ReaderName = ReaderNameTxb.Text;

            AppData.db.SaveChanges();
            MessageBox.Show("Запись была изменена");
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
