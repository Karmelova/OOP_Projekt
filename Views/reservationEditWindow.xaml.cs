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
using System.Windows.Shapes;

namespace OOP
{
    /// <summary>
    /// Logika interakcji dla klasy reservationEditWindow.xaml
    /// </summary>
    public partial class reservationEditWindow : Window
    {
        public reservationEditWindow()
        {
            InitializeComponent();
        }

        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }
    }
}