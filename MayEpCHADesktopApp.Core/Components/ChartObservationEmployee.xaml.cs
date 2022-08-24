using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace MayEpCHADesktopApp.Core.Components
{
    /// <summary>
    /// Interaction logic for ChartObservationEmployee.xaml
    /// </summary>

    public partial class ChartObservationEmployee : UserControl, INotifyPropertyChanged
    {
   
            public Func<Double, string> yformatter { set; get; }
            private SeriesCollection seriesCollection;
            public SeriesCollection SeriesCollection { get => seriesCollection; set { seriesCollection = value; OnPropertyChanged(); } }
            private List<string> labels;
            public List<string> Labels { get => labels; set { labels = value; OnPropertyChanged(); } }
            public string Title { get => title; set { title = value; OnPropertyChanged(); } }

            private string title;

            private ChartValues<Double> cycleStandard;
            public ChartValues<Double> CycleStandard { get => cycleStandard; set { cycleStandard = value; OnPropertyChanged(); } }
            private ChartValues<Double> cycle;
            public ChartValues<Double> Cycle { get => cycle; set { cycle = value; OnPropertyChanged(); } }

        LineSeries LineSpeed =
        new LineSeries()
        {
            Title = "Cycle Standard",
               //  Stroke = Brushes.DeepSkyBlue,
              //   Fill = (SolidColorBrush)(Brush)new BrushConverter().ConvertFrom("#E4F0FF"),
                PointGeometry = DefaultGeometries.Circle,
                PointForeground = Brushes.DeepSkyBlue,
                PointGeometrySize = 3

            };
        LineSeries LineData =
        new LineSeries()
        {
            Title = "Cycle Injection",
            //  Foreground = Brushes.DeepSkyBlue,
            //Fill= Brushes.Black,
            // Stroke = Brushes.DeepPink,
            //LineSmoothness = 0.5,
                //Stroke = Brushes.Red,
                PointGeometry = DefaultGeometries.Circle,
                PointForeground = Brushes.SkyBlue,
                PointGeometrySize = 3
                
            };
            public ChartObservationEmployee()
            {
                InitializeComponent();
                Title = "Nhân viên Lê Thanh Đạt ngày 18 tháng 6 năm 2022";
                SeriesCollection = new SeriesCollection();
                Cycle = new ChartValues<double>();
                CycleStandard = new ChartValues<double>();
                Labels = new List<string>();
                //    yformatter = value => value.ToString();
                chart();
                this.DataContext = this;
            }
            public void chart()
            {
                LineData.Values = Cycle;
                LineSpeed.Values = CycleStandard;
                SeriesCollection.Add(LineData);
                SeriesCollection.Add(LineSpeed);
            }
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }


        
    }
}
