using Sudoku.Manipulation;
using Sudoku.GameModel;
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
using Sudoku.Repository;
using System.Windows.Threading;

namespace SudokuGame
{
    /// <summary>
    /// Логика взаимодействия для GameSession.xaml
    /// </summary>
    public partial class GameSession : Page
    {
        private TextBox[,] sudokuTextBoxes;
        private string[,] _textBoxesValidation;
        private List<int[]> coordinates;
        private int difficulty;
        private int[][] random;
        private Session _currentsession;
        private Repository _repos = new Repository();
        private DateTime fixedDate = DateTime.Now;


        public GameSession(int i)
        {
            InitializeComponent();

            _currentsession = new Session();
            var randomized = new RandomizeMatrix();
            difficulty = i;
            var hint = new HintGenerator(difficulty);
            coordinates = hint.coordinates;
            random = randomized.finalmatrix;
            
            GenerateSudokuGrid();
            ShowHints();

            DispatcherTimer sudokuTimer = new DispatcherTimer();
            sudokuTimer.Interval = TimeSpan.FromSeconds(1);

            sudokuTimer.Tick += timerTick;

            sudokuTimer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            TimeSpan dtdiff = dt1 - fixedDate;
            int hours = dtdiff.Hours;
            int minutes = dtdiff.Minutes;
            int seconds = dtdiff.Seconds;

            sudokuTimerLabel.Content = new DateTime(2019, 12, 19, hours, minutes, seconds).ToLongTimeString();
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


        private void ShowHints()
        {
            for(int i=0; i<coordinates.Count; i++)
            {
                sudokuTextBoxes[coordinates[i][0], coordinates[i][1]].Text = random[coordinates[i][0]][coordinates[i][1]].ToString();
                sudokuTextBoxes[coordinates[i][0], coordinates[i][1]].IsReadOnly = true;
                sudokuTextBoxes[coordinates[i][0], coordinates[i][1]].Background = Brushes.LemonChiffon;
                _textBoxesValidation[coordinates[i][0], coordinates[i][1]] = random[coordinates[i][0]][coordinates[i][1]].ToString();
            }
        }


        private void GenerateSudokuGrid()
        {
            // This Method was partially borrowed from here: https://github.com/manio143/Sudoku 
            sudokuTextBoxes = new TextBox[9, 9];
            _textBoxesValidation = new string[9, 9];
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
                        Name = "currentTextBox",
                        FontSize = 3,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        MaxLength = 1,
                        Background = new SolidColorBrush(Colors.White),
                        IsUndoEnabled = true,
                        BorderBrush = new SolidColorBrush(Colors.Transparent),
                        BorderThickness = new Thickness(0.5),

                    };
                    sudokuTextBoxes[i, j].TextChanged += FixHandler(i, j);
                    border.Child = sudokuTextBoxes[i, j];
                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);
                    SudokuGrid.Children.Add(border);
                }
        }

        private TextChangedEventHandler FixHandler(int x, int y)
            => (textBox, _) => OnTextBoxValueChange(x, y, textBox as TextBox);

        private void OnTextBoxValueChange(int x, int y, TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                _textBoxesValidation[x, y] = null;
                textBox.Text = null;
            }
            else if (uint.TryParse(textBox.Text, out var number) && number <= 9)
            {
                textBox.FontWeight = FontWeights.SemiBold;
                _textBoxesValidation[x, y] = textBox.Text;
            }
            else
            {
                textBox.Text = _textBoxesValidation[x, y];
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void Retry(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new GameSession(difficulty));
        }

        private void Completing(object sender, RoutedEventArgs e)
        {
            if (Check()) 
            {

                _repos.CloseGame(_currentsession);
                if (_repos.BestSessionCheck(_currentsession.TotalTime)) 
                {
               
                    _repos.Add(_currentsession);
                    Navigator.Default.Navigate(new NewRecordRegistration(_currentsession));
                }
                else 
                {
                    _repos.Add(_currentsession);
                    Navigator.Default.Navigate(new CongratulationPage(_currentsession)); 
                }               
                 
            }
            else
            {

                MessageBox.Show("Oh! I'm afraid there is a mistake! Try again!");
            }
        }

        private bool Check()
        {
            var check = true;
            for(int i=0; i<9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int.TryParse(_textBoxesValidation[i,j], out var number);
                    if (random[i][j] != number) { check = false; }
                }
            }
            return check;
        }
    }
}
