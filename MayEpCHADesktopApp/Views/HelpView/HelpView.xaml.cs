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
using System.Windows.Threading;

namespace MayEpCHADesktopApp.Views.HelpView
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView: UserControl
    {
        DispatcherTimer TLoad = new DispatcherTimer( );
        public HelpView ( )
        {
            InitializeComponent( );
            TLoad.Interval=TimeSpan.FromSeconds(1);
            TLoad.Tick+=TLoad_Tick;
            LBTime.Content=" / 00:03:14";
        }

        private void TLoad_Tick (object? sender,EventArgs e)
        {
            Slider.Value=EVideo.Position.TotalSeconds;
            LBRealTime.Content=EVideo.Position;
        }

        private void BTPlay_Click (object sender,RoutedEventArgs e)
        {
            TLoad.Start( );
            LBRealTime.Content="00:00:00";
        }

        private void BTStop_Click (object sender,RoutedEventArgs e)
        {
            TLoad.Stop( );
            LBRealTime.Content="00:00:00";
        }

        private void BTPause_Click (object sender,RoutedEventArgs e)
        {
            TLoad.Stop( );

        }
    }
}
