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
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Page
    {
        public Result()
        {
            InitializeComponent();
        }

        private void Result_Load(object sender, RoutedEventArgs e)
        {
            payEntPound.Text = GLOBALS.payEntPound;
            if (String.Equals(payEntPound.Text, ""))
                payEntPence.Text = GLOBALS.payEntPence = "00";
            else
                payEntPence.Text = GLOBALS.payEntPence;

            MyHours.Converter.ICalculation toDigit = new CalculateToDigit();
            MyHours.Converter.ICalculation toHours = new CalculateToHours();
            GLOBALS.digitFormat = toDigit.calculate("noData", GLOBALS.fromEntGlobal, GLOBALS.toEntGlobal);

            String output = toHours.calculate(GLOBALS.digitFormat, GLOBALS.fromEntGlobal, GLOBALS.toEntGlobal);
            if (GLOBALS.errorDisplay == false)
            {
                outputHours.Text = "";
                outputHours.Text = output;
            }
            else
            {
                outputHours.Text = output;
            }
        }

        private void homeFromResult_Click(object sender, RoutedEventArgs e)
        {
            Calculate page = new Calculate();
            NavigationService.Navigate(page);
        }

        private void calculatePayRate_Click(object sender, RoutedEventArgs e)
        {
            int[] verify = { 0, 0 }; // collects errors 0 are changed to 1 if errror detected
            if (CheckPoundFormat.checkPoundFormat(payEntPound.Text))
            {
                GLOBALS.payEntPound = payEntPound.Text; // from hours
            }
            else
            {
                GLOBALS.payEntPound = payEntPound.Text; // error
                verify[0] = 1;
            }
            if (CheckPenceFormat.checkPenceFormat(payEntPence.Text))
            {
                GLOBALS.payEntPence = payEntPence.Text; // from hours
            }
            else
            {
                GLOBALS.payEntPence = payEntPence.Text; // error
                verify[1] = 1;
            }
            if (!verify.Contains(1)) // if it does NOT contains a 1 then there was NO error
            {

                GLOBALS.payEntGlobal = GLOBALS.payEntPound + "." + GLOBALS.payEntPence;
                ResultPayRate page = new ResultPayRate();
                NavigationService.Navigate(page);
            }
            else
            {
                payEntPound.Text = GLOBALS.payEntPound;
                if (verify[0] == 1)
                {
                    //payEntPound.Foreground = Brushes.Red;
                    payEntPound.BorderThickness = new Thickness(3, 3, 3, 3);
                    payEntPound.Padding = new Thickness(3, 2, 0, 0);
                    payEntPound.BorderBrush = Brushes.Red;
                }

                payEntPence.Text = GLOBALS.payEntPence;
                if (verify[1] == 1)
                {
                    //payEntPence.Foreground = Brushes.Red;
                    //payEntPence.Text = "";
                    payEntPence.BorderThickness = new Thickness(3, 3, 3, 3);
                    payEntPence.Padding = new Thickness(4, 4, 0, 0);
                    payEntPence.BorderBrush = Brushes.Red;
                }                    
            }            
        }

        private void payEntPound_Focus(object sender, RoutedEventArgs e)
        {
            if (payEntPound.Foreground == Brushes.Red)
            {
                payEntPound.Foreground = Brushes.Black;
            }
            payEntPound.BorderThickness = new Thickness(0, 0, 0, 0);
            payEntPound.Padding = new Thickness(4, 4, 0, 0);
            payEntPound.ClearValue(Border.BorderBrushProperty);
        }

        private void payEntPence_Focus(object sender, RoutedEventArgs e)
        {
            if(payEntPence.Text == "00")
            {
                payEntPence.Text = "";
            }
            if (payEntPence.Foreground == Brushes.Red)
            {
                payEntPence.Foreground = Brushes.Black;
            }
            payEntPence.BorderThickness = new Thickness(0, 0, 0, 0);
            payEntPence.Padding = new Thickness(4, 4, 0, 0);
            payEntPence.ClearValue(Border.BorderBrushProperty);
        }

        private void button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Space && System.Text.RegularExpressions.Regex.IsMatch(e.Key.ToString(), "[0-9]") || e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Left || e.Key == Key.Right)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void payEntPence_LostFocus(object sender, RoutedEventArgs e)
        {
            if (payEntPence.Text == "")
            {
                payEntPence.Text = "00";
            }
        }
    }
}
