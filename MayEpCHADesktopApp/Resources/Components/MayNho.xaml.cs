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

namespace MayEpCHADesktopApp.Resources.Components
{
    /// <summary>
    /// Interaction logic for MayNho.xaml
    /// </summary>
    public partial class MayNho : UserControl, INotifyPropertyChanged
    {
        private SolidColorBrush statusBackground1;
        public SolidColorBrush StatusBackground1 { get => statusBackground1; set { statusBackground1 = value; OnPropertyChanged(); } }
        public static SolidColorBrush StatusBackground2 { set; get; }
        public MayNho()
        {
            InitializeComponent();
        }
        public string MachineNames
        {
            get { return (string)GetValue(MachineNameProperty); }
            set { SetValue(MachineNameProperty, value); OnPropertyChanged(); }
        }

        public static readonly DependencyProperty MachineNameProperty =
            DependencyProperty.Register("MachineNames", typeof(string), typeof(MayNho), new PropertyMetadata("Content"));
        public string CodeMachine
        {
            get { return (string)GetValue(CodeMachineProperty); }
            set { SetValue(CodeMachineProperty, value); OnPropertyChanged(); }
        }

        public static readonly DependencyProperty CodeMachineProperty =
            DependencyProperty.Register("CodeMachine", typeof(string), typeof(MayNho), new PropertyMetadata("Content"));
       
        public string NoteMachine
        {
            get { return (string)GetValue(NoteMachineProperty); }
            set { SetValue(NoteMachineProperty, value); OnPropertyChanged(); }
        }

        public static readonly DependencyProperty NoteMachineProperty =
            DependencyProperty.Register("NoteMachine", typeof(string), typeof(MayNho), new PropertyMetadata(""));
        //Onpropperty
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
        //màu trạng thái
        public SolidColorBrush StatusBackground
        {
            get { return (SolidColorBrush)GetValue(StatusBackgroundProperty); }
            set { SetValue(StatusBackgroundProperty, value); OnPropertyChanged(); }
        }
        public static readonly DependencyProperty StatusBackgroundProperty =
         DependencyProperty.Register("StatusBackground", typeof(SolidColorBrush), typeof(MayNho), new PropertyMetadata(new SolidColorBrush(Colors.Gray),OnChange));

        private static void OnChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StatusBackground2 = new SolidColorBrush(Colors.White);


        }

        public SolidColorBrush MachineBackground
        {
            get { return (SolidColorBrush)GetValue(MachineBackgroundProperty); }
            set { SetValue(MachineBackgroundProperty, value); OnPropertyChanged(); }
        }
        public static readonly DependencyProperty MachineBackgroundProperty =
         DependencyProperty.Register("MachineBackground", typeof(SolidColorBrush), typeof(MayNho), new PropertyMetadata((SolidColorBrush)new BrushConverter().ConvertFrom("#FF00294D")));
        public SolidColorBrush NameForeground
        {
            get { return (SolidColorBrush)GetValue(NameForegroundProperty); }
            set { SetValue(NameForegroundProperty, value); OnPropertyChanged(); }
        }
        public static readonly DependencyProperty NameForegroundProperty =
         DependencyProperty.Register("NameForeground", typeof(SolidColorBrush), typeof(MayNho), new PropertyMetadata(new SolidColorBrush(Colors.White)));
        //màu codemachine
        public SolidColorBrush CodeForeground
        {
            get { return (SolidColorBrush)GetValue(CodeForegroundProperty); }
            set { SetValue(CodeForegroundProperty, value); OnPropertyChanged(); }
        }
        public static readonly DependencyProperty CodeForegroundProperty =
         DependencyProperty.Register("CodeForeground", typeof(SolidColorBrush), typeof(MayNho), new PropertyMetadata(new SolidColorBrush(Colors.White)));
        //màu note
        public SolidColorBrush NoteForeground
        {
            get { return (SolidColorBrush)GetValue(NoteForegroundProperty); }
            set { SetValue(NoteForegroundProperty, value); OnPropertyChanged(); }
        }
        public static readonly DependencyProperty NoteForegroundProperty =
         DependencyProperty.Register("NoteForeground", typeof(SolidColorBrush), typeof(MayNho), new PropertyMetadata(new SolidColorBrush(Colors.White)));
        //tạo sự kiện
        public static readonly RoutedEvent ClickEvent =
      EventManager.RegisterRoutedEvent(nameof(LeftMouseDown), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ButtonMenu));

        public event RoutedEventHandler LeftMouseDown
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {

            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }

    }
}