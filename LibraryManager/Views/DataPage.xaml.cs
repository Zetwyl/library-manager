using LibraryManager.ADO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPage()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            UsersGrid.ItemsSource = AppData.db.IssuedBooks.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.IssuedBooks
                .Where(h => h.ReaderName.Contains(search.Text)).ToList();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.IssuedBooks
                .Where(h => h.ReturnDate == null).ToList();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.IssuedBooks
                .OrderByDescending(h => h.IssueDate).ToList();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            search.Text = "";
            RefreshData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem is IssuedBook selected)
            {
                if (selected.ReturnDate != null)
                {
                    MessageBox.Show("Эта книга уже была возвращена!");
                    return;
                }

                selected.ReturnDate = DateTime.Today;
                selected.Book.IsAvailable = true;

                AppData.db.SaveChanges();
                RefreshData();
                MessageBox.Show("Книга успешно возвращена!");
            }
            else
            {
                MessageBox.Show("Выберите запись для отметки возврата.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem is IssuedBook selected)
            {
                if (MessageBox.Show("Удалить эту запись?", "Подтверждение",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (selected.ReturnDate == null)
                        selected.Book.IsAvailable = true;

                    AppData.db.IssuedBooks.Remove(selected);
                    AppData.db.SaveChanges();
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления.");
            }
        }
    }
}
