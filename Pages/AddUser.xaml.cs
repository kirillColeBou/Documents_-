﻿using System;
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
        public AddUser()
        {
            InitializeComponent();
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(MainWindow.pages.add);
        }

        private void AddUsers(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateUser(object sender, RoutedEventArgs e)
        {

        }
    }
}
