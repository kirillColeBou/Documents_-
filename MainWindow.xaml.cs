using Documents_Тепляков.Classes;
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

namespace Documents_Тепляков
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public List<DocumentContext> AllDocuments = new DocumentContext().AllDocuments();
        public List<UserContext> AllUsers = new UserContext().AllUsers();

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPage(pages.main);
        }

        public enum pages
        {
            main, add, adduser
        }

        public void OpenPage(pages _pages)
        {
            if (_pages == pages.main)
                frame.Navigate(new Pages.Main());
            if (_pages == pages.add)
                frame.Navigate(new Pages.Add());
            if (_pages == pages.adduser)
                frame.Navigate(new Pages.AddUser());
        }
    }
}
