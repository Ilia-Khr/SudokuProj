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
using Sudoku.GameModel;
using Sudoku.Repository;

namespace SudokuGame
{
    /// <summary>
    /// Логика взаимодействия для Leaderboards.xaml
    /// </summary>
    public partial class Leaderboards : Page
    {

        private List<Record> _recordsessions = new List<Record>();
        public Leaderboards(Repository _repos)
        {
            AverageTime(_repos);
            _repos.BindRecords(_recordsessions);
            InitializeComponent();
    
        }

        private void ToMainMenu(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new MainMenu());
        }

        private void AverageTime(Repository _repos)
        {
            avtime.Text = _repos.AverageTime().ToString();
        }
    }
}
