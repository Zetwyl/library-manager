using LibraryManager.ADO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LibraryManager.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.Login == TxbLogin.Text && u.Password == TxbPassword.Text);

            if (CurrentUser != null)
            {
                NavigationService.Navigate(new DataPage());
            }
            else
            {
                MessageBox.Show("Данного пользователя нет в базе");
            }
        }
    }
}
