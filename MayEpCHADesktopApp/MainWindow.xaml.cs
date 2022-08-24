using MayEpCHADesktopApp.Resources.Components;
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

namespace MayEpCHADesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Object DataContext)
        {

                // Runtime mode specific functionality
            this.DataContext = DataContext;
            this.StateChanged += new EventHandler(MainWindow_StateChanged);
            InitializeComponent();

        }
        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                return;
            }
            if (this.WindowState == WindowState.Normal)
            {
                this.Width = SystemParameters.PrimaryScreenWidth * 0.7;
                this.Height = SystemParameters.PrimaryScreenHeight * 0.7;
                //Loginbtn.UpdateMinimizedUI();
                //Settingbtn.UpdateMinimizedUI();
                //Supervisorbtn.UpdateMinimizedUI();
                //Reporttn.UpdateMinimizedUI();
                //Historybtn.UpdateMinimizedUI();
                //Alertbtn.UpdateMinimizedUI();
                //Helpbtn.UpdateMinimizedUI();
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                //Loginbtn.UpdateNormalUI();
                //Settingbtn.UpdateNormalUI();
                //Supervisorbtn.UpdateNormalUI();
                //Historybtn.UpdateNormalUI();
                //Alertbtn.UpdateNormalUI();
                //Reporttn.UpdateNormalUI();
                //Helpbtn.UpdateNormalUI();
            }
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Có bấm");
        }
    }
}