using MyHours.Converter;
using MyHours.Helper;
using MyHours.Models;
using OpenQA.Selenium;
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
    /// Interaction logic for Calculate.xaml
    /// </summary>
    public partial class Calculate : Page
    {
        public Calculate()
        {
            InitializeComponent();
        }
        private void Calculate_Load(object sender, RoutedEventArgs e)
        {
            fromEntHours.Text = GLOBALS.fromEntHours;
            fromEntMinutes.Text = GLOBALS.fromEntMinutes;
            toEntHours.Text = GLOBALS.toEntHours;
            toEntMinutes.Text = GLOBALS.toEntMinutes;
            if (!String.Equals(fromEntHours.Text, "HH"))
            {
                fromEntHours.Foreground = Brushes.Black;
            }            
            if (!String.Equals(fromEntMinutes.Text, "mm"))
            {
                fromEntMinutes.Foreground = Brushes.Black;
            }
            if (!String.Equals(toEntHours.Text, "HH"))
            {
                toEntHours.Foreground = Brushes.Black;
            }
            if (!String.Equals(toEntMinutes.Text, "mm"))
            {
                toEntMinutes.Foreground = Brushes.Black;
            }

        }

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            int[] verify = { 0, 0, 0, 0 }; // collects errors 0 are changed to 1 if errror detected
            if (CheckHoursFormat.checkHoursFormat(fromEntHours.Text))
            {
                GLOBALS.fromEntHours = fromEntHours.Text; // from hours
            }
            else
            {
                GLOBALS.fromEntHours = fromEntHours.Text; // error
                verify[0] = 1;
            }
            if (CheckMinutesFormat.checkMinutesFormat(fromEntMinutes.Text))
            {
                GLOBALS.fromEntMinutes = fromEntMinutes.Text; // from minutes
            }
            else
            {
                GLOBALS.fromEntMinutes = fromEntMinutes.Text; // error
                verify[1] = 1;
            }
            if (CheckHoursFormat.checkHoursFormat(toEntHours.Text))
            {
                GLOBALS.toEntHours = toEntHours.Text; // to hours
            }
            else
            {
                GLOBALS.toEntHours = toEntHours.Text; // error
                verify[2] = 1;
            }
            if (CheckMinutesFormat.checkMinutesFormat(toEntMinutes.Text))
            {
                GLOBALS.toEntMinutes = toEntMinutes.Text; // to minutes
            }
            else
            {
                GLOBALS.toEntMinutes = toEntMinutes.Text; // error
                verify[3] = 1;
            }
            if (!verify.Contains(1)) // if it contains a 1 then there was an error
            {
                GLOBALS.fromEntGlobal = GLOBALS.fromEntHours + ":" + GLOBALS.fromEntMinutes;
                GLOBALS.toEntGlobal = GLOBALS.toEntHours + ":" + GLOBALS.toEntMinutes;
                GLOBALS.fromEntGlobal = NormaliseTime.normaliseTime(GLOBALS.fromEntGlobal);
                GLOBALS.toEntGlobal = NormaliseTime.normaliseTime(GLOBALS.toEntGlobal);
                if (CheckTimeLogic.checkTimeLogic(GLOBALS.fromEntGlobal, GLOBALS.toEntGlobal))
                {
                    GLOBALS.payEntPound = "";
                    GLOBALS.payEntPence = "";
                    Result page = new Result();
                    NavigationService.Navigate(page);
                }
                else
                {
                    fromEntMinutes.Text = GLOBALS.fromEntMinutes;
                    fromEntMinutes.BorderThickness = new Thickness(3, 3, 3, 3);
                    fromEntMinutes.BorderBrush = Brushes.Red;
                    toEntMinutes.Text = GLOBALS.toEntMinutes;
                    toEntMinutes.BorderThickness = new Thickness(3, 3, 3, 3);
                    toEntMinutes.BorderBrush = Brushes.Red;
                }

            }
            else
            {
                // when empty textbox
                fromEntHours.Text = GLOBALS.fromEntHours;
                if (verify[0] == 1)
                {
                    //fromEntHours.Foreground = Brushes.Red;
                    fromEntHours.BorderThickness = new Thickness(3, 3, 3, 3);
                    fromEntHours.BorderBrush = Brushes.Red;
                }
                fromEntMinutes.Text = GLOBALS.fromEntMinutes;
                if (verify[1] == 1)
                {
                    //fromEntMinutes.Foreground = Brushes.Red;
                    fromEntMinutes.BorderThickness = new Thickness(3, 3, 3, 3);
                    fromEntMinutes.BorderBrush = Brushes.Red;
                }
                toEntHours.Text = GLOBALS.toEntHours;
                if (verify[2] == 1)
                {
                    //toEntHours.Foreground = Brushes.Red;
                    toEntHours.BorderThickness = new Thickness(3, 3, 3, 3);
                    toEntHours.BorderBrush = Brushes.Red;
                }
                toEntMinutes.Text = GLOBALS.toEntMinutes;
                if (verify[3] == 1)
                {
                    //toEntMinutes.Foreground = Brushes.Red;
                    toEntMinutes.BorderThickness = new Thickness(3, 3, 3, 3);
                    toEntMinutes.BorderBrush = Brushes.Red;
                }
            }
        }

        private void fromEntHours_Focus(object sender, RoutedEventArgs e)
        {
            if (String.Equals(fromEntHours.Text, "HH"))
            {
                fromEntHours.Text = "";
            }
            fromEntHours.BorderThickness = new Thickness(0, 0, 0, 0);
            fromEntHours.SelectAll();
            fromEntHours.Foreground = Brushes.Black;
            fromEntHours.ClearValue(Border.BorderBrushProperty);
        }

        private void fromEntMinutes_Focus(object sender, RoutedEventArgs e)
        {
            if (String.Equals(fromEntMinutes.Text, "mm"))
            {
                fromEntMinutes.Text = "";
            }
            fromEntMinutes.BorderThickness = new Thickness(0, 0, 0, 0);
            fromEntMinutes.SelectAll();
            fromEntMinutes.Foreground = Brushes.Black;
            fromEntMinutes.ClearValue(Border.BorderBrushProperty);
        }

        private void toEntHours_Focus(object sender, RoutedEventArgs e)
        {
            if (String.Equals(toEntHours.Text, "HH"))
            {
                toEntHours.Text = "";
            }
            toEntHours.BorderThickness = new Thickness(0, 0, 0, 0);
            toEntHours.SelectAll();
            toEntHours.Foreground = Brushes.Black;
            toEntHours.ClearValue(Border.BorderBrushProperty);
        }

        private void toEntMinutes_Focus(object sender, RoutedEventArgs e)
        {
            if (String.Equals(toEntMinutes.Text, "mm"))
            {
                toEntMinutes.Text = "";
            }
            toEntMinutes.BorderThickness = new Thickness(0, 0, 0, 0);
            toEntMinutes.SelectAll();
            toEntMinutes.Foreground = Brushes.Black;
            toEntMinutes.ClearValue(Border.BorderBrushProperty);
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

        private void moveToNext_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (fromEntHours.Foreground == Brushes.Black && fromEntHours.Text.Length == 2)
            {
                fromEntMinutes.Focus();
            }
        }

        private void moveToNext2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (fromEntMinutes.Foreground == Brushes.Black && fromEntMinutes.Text.Length == 2)
            {
                toEntHours.Focus();
            }
            else if (fromEntMinutes.Foreground == Brushes.Black && fromEntMinutes.Text.Length == 0)
            {
                fromEntHours.Focus();
            }
        }

        private void moveToNext3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (toEntHours.Foreground == Brushes.Black && toEntHours.Text.Length == 2)
            {
                toEntMinutes.Focus();
            }
            else if (toEntHours.Foreground == Brushes.Black && toEntHours.Text.Length == 0)
            {
                fromEntMinutes.Focus();
            }
        }

        private void moveToNext4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (toEntMinutes.Foreground == Brushes.Black && toEntMinutes.Text.Length == 0)
            {
                toEntHours.Focus();
            }
        }

        private void fromEntHours_LostFocus(object sender, RoutedEventArgs e)
        {
            if (fromEntHours.Text.Length == 0)
            {
                fromEntHours.Foreground = Brushes.LightGray;
                fromEntHours.Text = "HH";
            }
        }

        private void fromEntMinutes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (fromEntMinutes.Text.Length == 0)
            {
                fromEntMinutes.Foreground = Brushes.LightGray;
                fromEntMinutes.Text = "mm";
            }
        }

        private void toEntHours_LostFocus(object sender, RoutedEventArgs e)
        {
            if (toEntHours.Text.Length == 0)
            {
                toEntHours.Foreground = Brushes.LightGray;
                toEntHours.Text = "HH";
            }
        }

        private void toEntMinutes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (toEntMinutes.Text.Length == 0)
            {
                toEntMinutes.Foreground = Brushes.LightGray;
                toEntMinutes.Text = "mm";
            }
        }
    }
}
