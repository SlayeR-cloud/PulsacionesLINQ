using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Entity;
using BussinessLogicLayer;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationGUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowDataInDataGrid();
            GetAgeSum();
            GetAgeAverage();
            GetMostSex();
        }

        private void ShowDataInDataGrid()
        {
            dataGridPulsations.ItemsSource = PersonService.GetPeople();
        }
        private void GetAgeSum()
        {
            var sum = PersonService.GetAgeSum();
            sumLabel.Content += "" + sum;
        }
        private void GetAgeAverage()
        {
            var age = PersonService.GetAgeAverage();
            averageLabel.Content += "" + age;
        }
        private void GetMostSex()
        {
            var response = PersonService.GetMostSex();
            sexLabel.Content += response;
        }
    }
}