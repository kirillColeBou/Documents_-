using Documents_Тепляков.Classes;
using Documents_Тепляков.Model;
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

namespace Documents_Тепляков.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        public User User;
        public UserContext UserContext;
        public AddUser(User User = null)
        {
            InitializeComponent();
            if(User != null)
            {
                this.User = User;
                tb_new_user.Text = this.User.user;
            }
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(MainWindow.pages.add);
        }

        private void AddUsers(object sender, RoutedEventArgs e)
        {
            if (tb_new_user.Text.Length == 0)
            {
                MessageBox.Show("Укажите нового ответственного");
                return;
            }
            if (User == null)
            {
                UserContext newUser = new UserContext();
                newUser.user = tb_new_user.Text;
                newUser.Save();
                MessageBox.Show("Ответственный добавлен");
            }
            else
            {
                UserContext newUser = new UserContext();
                newUser.user = tb_new_user.Text;
                newUser.Save(true);
                MessageBox.Show("Ответственный изменен");
            }
            MainWindow.init.AllUsers = new UserContext().AllUsers();
            MainWindow.init.OpenPage(MainWindow.pages.main);
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            UserContext.Delete();
            MainWindow.init.AllUsers = new UserContext().AllUsers();
        }

        private void UpdateUser(object sender, RoutedEventArgs e)
        {

        }
    }
}
