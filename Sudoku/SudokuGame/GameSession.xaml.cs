﻿using System;
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
    /// Логика взаимодействия для GameSession.xaml
    /// </summary>
    public partial class GameSession : Page
    {
        private TextBox[,] sudokuTextBoxes;

        public GameSession()
        {
            InitializeComponent();
            GenerateSudokuGrid();
        }

        private void ToMainMenu(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new MainMenu());
        }

        private Thickness GetThickness(int i, int j, double thin, double thick)
        {
            // This Method was borrowed from here: https://github.com/manio143/Sudoku 
            var top = i % 3 == 0 ? thick : thin;
            var bottom = i % 3 == 2 ? thick : thin;
            var left = j % 3 == 0 ? thick : thin;
            var right = j % 3 == 2 ? thick : thin;
            return new Thickness(left, top, right, bottom);
        }

        private void GenerateSudokuGrid()
        {

            sudokuTextBoxes = new TextBox[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {

                    var border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = GetThickness(i, j, 0.1, 0.5)
                    };
                    sudokuTextBoxes[i, j] = new TextBox
                    {

                        FontSize = 3,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        MaxLength = 1,
                        Background = new SolidColorBrush(Colors.White),
                        IsUndoEnabled = true,
                        BorderBrush = new SolidColorBrush(Colors.Transparent),
                        BorderThickness = new Thickness(0.5),

                    };

                    border.Child = sudokuTextBoxes[i, j];
                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);
                    SudokuGrid.Children.Add(border);
                }
        }


    }
}
