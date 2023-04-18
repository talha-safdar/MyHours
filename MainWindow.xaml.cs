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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public event System.Windows.RoutedEventHandler Click;

        public MainWindow()
        {
            InitializeComponent();
            // Specify the main application UI
            Main.Content = new Calculate();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }

        private void frameWindow_Focus(object sender, RoutedEventArgs e)
        {

        }

        private void closeApp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void topBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {
                // do nothing
            }
            
        }

        private void maximise_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void fullWindow_Load(object sender, RoutedEventArgs e)
        {
            
        }

        private void minimise_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void maximise_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
