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
    /// Логика взаимодействия для That_sARecord_.xaml
    /// </summary>
    public partial class NewRecordRegistration : Page
    {
        private Session _session;
        private Repository _repos;
        public NewRecordRegistration(Session session, Repository repos)
        {
            InitializeComponent();
            _session = session;
            _repos = repos;
            if(recordname.Text != null)
            {
                RegisterRecord();
            }

        }

        private void RegisterRecord()
        {
            _repos.Record(recordname.Text, _session);
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new CongratulationPage(_repos, _session));
        }
    }
}
