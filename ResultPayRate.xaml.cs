using MyHours.Converter;
using MyHours.Converter.Calculation;
using MyHours.Helper;
using System;
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

namespace MyHours
{
    /// <summary>
    /// Interaction logic for ResultPayRate.xaml
    /// </summary>
    public partial class ResultPayRate : Page
    {
        public ResultPayRate()
        {
            InitializeComponent();
        }

        private void ResultPayRate_Load(object sender, RoutedEventArgs e)
        {
            MyHours.Converter.ICalculation toPay = new CalculateToPay();
            String output = toPay.calculate("noData", GLOBALS.digitFormat, GLOBALS.payEntGlobal);
            outputPayrate.FontSize = ResizeFont.resizeFont(output);
            outputPayrate.Text = output;
        }

        private void homeFromResultPayRate_Click(object sender, RoutedEventArgs e)
        {
            GLOBALS.fromEntHours = "HH";
            GLOBALS.fromEntMinutes = "mm";
            GLOBALS.toEntHours = "HH";
            GLOBALS.toEntMinutes = "mm";

            Calculate page = new Calculate();
            NavigationService.Navigate(page);
        }

        private void backFromResultPayRate_Click(object sender, RoutedEventArgs e)
        {
            Result page = new Result();
            NavigationService.Navigate(page);
        }
    }
}
