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
    /// Логика взаимодействия для IssueBookPage.xaml
    /// </summary>
    public partial class IssueBookPage : Page
    {
        public IssueBookPage()
        {
            InitializeComponent();
            BookCmb.ItemsSource = AppData.db.Books.Where(b => b.IsAvailable == true).ToList();
            IssueDatePicker.SelectedDate = DateTime.Today;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (BookCmb.SelectedItem == null || string.IsNullOrWhiteSpace(ReaderNameTxb.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            var selectedBook = BookCmb.SelectedItem as Book;
            selectedBook.IsAvailable = false;

            AppData.db.IssuedBooks.Add(new IssuedBook
            {
                BookId = selectedBook.Id,
                ReaderName = ReaderNameTxb.Text.Trim(),
                IssueDate = IssueDatePicker.SelectedDate ?? DateTime.Today,
                ReturnDate = null
            });
            AppData.db.SaveChanges();

            MessageBox.Show("Книга успешно выдана!");
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
