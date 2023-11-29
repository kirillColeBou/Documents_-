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

namespace Documents_Тепляков.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            CreateUI();
        }

        public void CreateUI()
        {
            parent.Children.Clear();
            foreach(DocumentContext document in MainWindow.init.AllDocuments)
                parent.Children.Add(new Elements.Item(document));
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.init.Close();
        }

        private void AddDocuments(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(MainWindow.pages.add);
        }
    }
}
