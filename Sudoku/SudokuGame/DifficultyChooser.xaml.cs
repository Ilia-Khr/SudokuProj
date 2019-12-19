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
    /// Логика взаимодействия для DifficultyChooser.xaml
    /// </summary>
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }


    public partial class DifficultyChooser : Page
    {
    
        public Difficulty currentDiffculty = new Difficulty();
        public DifficultyChooser()
        {

            InitializeComponent();
        }

        private void ToMainMenu(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new MainMenu());
        }

        private void OnEasyClick(object sender, RoutedEventArgs e)
        {
            currentDiffculty = Difficulty.Easy;
            Navigator.Default.Navigate(new GameSession(1 ));
        }

        private void OnMediumClick(object sender, RoutedEventArgs e)
        {
            currentDiffculty = Difficulty.Medium;
            Navigator.Default.Navigate(new GameSession(2));
        }

        private void OnHardClick(object sender, RoutedEventArgs e)
        {
            currentDiffculty = Difficulty.Hard;
            Navigator.Default.Navigate(new GameSession(3));
        }
    }
}
