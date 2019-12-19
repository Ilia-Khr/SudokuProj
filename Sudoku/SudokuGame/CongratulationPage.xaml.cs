using Sudoku.GameModel;
using Sudoku.Repository;
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
    /// Логика взаимодействия для CongratulationPage.xaml
    /// </summary>
    public partial class CongratulationPage : Page
    {
        
        public CongratulationPage(Session session)
        {
            InitializeComponent();
            time.Text = session.TotalTimeMinutes.ToString();            
         
        }

        public void OnNewGameClick(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new DifficultyChooser());
        }

        public void OnLeaderboardsClick(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new Leaderboards());
        }
        private void ToMainMenu(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new MainMenu());
        }
    }
}
