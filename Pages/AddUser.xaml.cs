using Documents_Тепляков.Classes;
using Documents_Тепляков.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.OleDb;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.AccessControl;
using System.Data.Common;

namespace Documents_Тепляков.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        public User User;
        public UserContext UserContext;
        public static OleDbConnection connection = Classes.Common.DBConnection.Connection();

        public AddUser(User User = null)
        {
            InitializeComponent();
            CreateUser();
            if (User != null)
            {
                this.User = User;
                cb_user.SelectedItem = this.User.user;
            }
        }

        public void CreateUser()
        {
            cb_user.Items.Clear();
            foreach (UserContext user in MainWindow.init.AllUsers)
            {
                cb_user.Items.Add(user.user);
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
                MainWindow.init.AllUsers = new UserContext().AllUsers();
                CreateUser();
                tb_new_user.Text = "";
            } 
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            if(tb_new_user.Text != "")
            {
                Classes.Common.DBConnection.Query($"DELETE FROM [Ответственные] WHERE [Ответственный] = '{tb_new_user.Text}'", connection);
                MessageBox.Show("Ответственный удален");
                MainWindow.init.AllUsers = new UserContext().AllUsers();
                CreateUser();
            }
            else MessageBox.Show("Выбирите ответственного для удаления");
        }

        private void UpdateUser(object sender, RoutedEventArgs e)
        {
            if (tb_new_user.Text != "")
            {
                UserContext newUser = new UserContext();
                newUser.user = tb_new_user.Text;
                newUser.Save(true);
                MessageBox.Show("Ответственный изменен");
                MainWindow.init.AllUsers = new UserContext().AllUsers();
                CreateUser();
            }
            else MessageBox.Show("Выбирите ответственного для изменения");
            
        }

        private void Users(object sender, SelectionChangedEventArgs e)
        {
            if (tb_new_user.Text == "")
                tb_new_user.Text = cb_user.SelectedItem.ToString();
            else
                tb_new_user.Text = "";
        }
    }
}
