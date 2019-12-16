using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudokuGame
{
    /// <summary>
    /// Логика взаимодействия для Leaderboards.xaml
    /// </summary>
    public partial class Leaderboards : Page
    {
        public Leaderboards()
        {
            InitializeComponent();
        }

        private void ToMainMenu(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new MainMenu());
        }
    }
}
