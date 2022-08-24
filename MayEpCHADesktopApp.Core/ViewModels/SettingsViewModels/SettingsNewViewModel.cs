using ImmServiceContainers;
using MassTransit;
using MayEpCHADesktopApp.Core.Components;
using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using MayEpCHADesktopApp.Core.Model;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels
{
    public class SettingsNewViewModel: ViewModels.BaseViewModels.BaseViewModel
    {
        #region var
        public bool IsShift1 { get => isShift1; set { isShift1=value; OnPropertyChanged( ); } }
        private bool isShift1;
        public bool IsShift2 { get => isShift2; set { isShift2=value; OnPropertyChanged( ); } }
        private bool isShift2;
        private string productId;
        private string machineId;
        private string moldId;
        private int quantity;
        private int shift;
        private double cycleInjection;
        public Product Product
        {
            get => product; set
            {
                product=value;
                ProductId=Product.ProductId;

                Mold=Product.Mold;
                MoldId=Mold.Id;
                CycleInjection=Mold.StandardInjectionCycle;



                OnPropertyChanged( );
            }
        }
        private Product product;
        private Mold mold;
        public Mold Mold { get => mold; set { mold=value; OnPropertyChanged( ); } }
        private Machine machine;
        public Machine Machine { get => machine; set { machine=value; if ( Machine!=null ) { MachineId=Machine.Id; }; OnPropertyChanged( ); } }
        public string ProductId { get => productId; set { productId=value; OnPropertyChanged( ); } }
        public string MachineId { get => machineId; set { machineId=value; OnPropertyChanged( ); } }
        public string MoldId { get => moldId; set { moldId=value; OnPropertyChanged( ); } }
        public int Quantity { get => quantity; set { quantity=value; OnPropertyChanged( ); } }
        public int Shift { get => shift; set { shift=value; OnPropertyChanged( ); } }
        public Configuration ConfigurationSelect { get => configurationSelect; set { configurationSelect=value; OnPropertyChanged( ); } }
        private Configuration configurationSelect;
        public double CycleInjection { get => cycleInjection; set { cycleInjection=value; try { Quantity=Convert.ToInt32(43200/CycleInjection); } catch ( Exception ex ) { } OnPropertyChanged( ); } }
        private ObservableCollection<Product> listProduct;
        public ObservableCollection<Product> ListProduct
        {
            get => listProduct; set
            {
                listProduct=value; OnPropertyChanged( );
            }
        }
        private ObservableCollection<Mold> listMold;
        public ObservableCollection<Mold> ListMold { get => listMold; set { listMold=value; } }
        private ObservableCollection<Employee> listEmployee;
        public ObservableCollection<Employee> ListEmployee { get => listEmployee; set { listEmployee=value; OnPropertyChanged( ); } }
        private ObservableCollection<Machine> listMachine;
        public ObservableCollection<Machine> ListMachine { get => listMachine; set { listMachine=value; OnPropertyChanged( ); } }
        private ObservableCollection<Configuration> listConfigurationShift2;
        public ObservableCollection<Configuration> ListConfigurationShift2 { get => listConfigurationShift2; set { listConfigurationShift2=value; OnPropertyChanged( ); } }
        public static Action ActionChangeDatabase { get; set; }

        public static event Action ActionLoad;
        public static event Action ChangeEvent;
        public ICommand Shift1 { set; get; }
        public ICommand Shift2 { set; get; }
        public ICommand AddCommandShift2 { set; get; }
        public ICommand TextChangedCommand { set; get; }
        public ICommand DeleteCommandShift2 { set; get; }
        public ICommand LoadCommand { set; get; }

        private IDatabaseServices _databaseServices;
        private IApiServices _apiServices;
        private IBusControl _busControl;
        DispatcherTimer TSendConfigShift = new DispatcherTimer( );
  
        DispatcherTimer TSendDelete = new DispatcherTimer( );
        DispatcherTimer TTest = new DispatcherTimer( );
        #endregion var
        public SettingsNewViewModel (IDatabaseServices databaseServices,IApiServices apiServices,IBusControl busControl)
        {
            _databaseServices=databaseServices;
            _apiServices=apiServices;
            _busControl=busControl;
            _apiServices.ChangeConfigEvent+=Load;
            ListConfigurationShift2=new ObservableCollection<Configuration>( );
            AddCommandShift2=new RelayCommand(async ( ) => await Add( ));
            DeleteCommandShift2=new RelayCommand(async ( ) => await Delete( ));
            LoadCommand=new RelayCommand(async ( ) => Load( ));
            TSendConfigShift.Tick+=ActionTimerSendConfig;
            TSendDelete.Tick+=ActionTimerDelete;
            TSendDelete.Interval=TimeSpan.FromMinutes(30);
            DeleteAllConfigLastDay( );
            GetTotalMachine( );
            GetTotalMold( );
            GetTotalProduct( );
            GetTotalEmployee( );
            Load( );
            Send( );
            StartTimer( );
        }
        //chạy timer 
        public void StartTimer ( )
        {
            try
            {
                DateTime time = DateTime.Now;
                if ( DateTime.Now.Hour>7&&DateTime.Now.Hour<19 )
                {
                    time=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,19,00,00);
                }
                else if ( DateTime.Now.Hour<7&&DateTime.Now.Hour>0 )
                {
                    time=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,7,00,00);
                }
                double TTime = (time-DateTime.Now).TotalSeconds;
                TSendDelete.Interval=TimeSpan.FromSeconds(TTime);
                TSendConfigShift.Start( );
            }
            catch { }

        }
        //xóa database 2 ngày trước đó
        public ObservableCollection<Configuration> ListConfigurationRemove = new ObservableCollection<Configuration>( );
        public void DeleteAllConfigLastDay ( )
        {
            ListConfigurationRemove.Clear( );
            foreach ( var item in _databaseServices.LoadConfiguration( ) )
            {
                if ( item.DateTime.Day<DateTime.Now.Day-2 )
                {
                    ListConfigurationRemove.Add(item);
                }
            }
            foreach(var item in ListConfigurationRemove )
            {
                _databaseServices.DeleteConfigAsync(item);
            }
        }
        //khi khởi động app hiện cái gì
        public void Load ( )
        {
            #region Offical
            if ( ListConfigurationShift2!=null )
            {
                ListConfigurationShift2.Clear( );
            }

            if ( DateTime.Now.Hour>19&&DateTime.Now.Hour<24 )
            {
                var ListConfig =
                            from config in _databaseServices.LoadConfiguration( )
                            where config.DateTime.Hour==18&&config.DateTime.Minute==30
                            &&config.DateTime.Day==DateTime.Now.Day
                            ||config.DateTime.Hour>19
                            select config;
                foreach ( var config in ListConfig )
                {
                    var Item = (from e in ListConfig
                                where e.MachineId==config.MachineId
                                select e).OrderByDescending(e => e.DateTime).FirstOrDefault( );
                    if ( Item!=null&&!ListConfigurationShift2.Contains(Item) )
                    {
                        ListConfigurationShift2.Add(Item);
                    }
                }
            }
            else if (DateTime.Now.Hour<7 )
            {
                var ListConfig =
                            from config in _databaseServices.LoadConfiguration( )
                            where
                            (config.DateTime.Hour==18&&config.DateTime.Minute==30
                            &&config.DateTime.Day==DateTime.Now.Day-1)
                            ||(config.DateTime.Hour>19&&config.DateTime.Hour<24&&config.DateTime.Day==DateTime.Now.Day-1)
                            ||(config.DateTime.Hour>0&&config.DateTime.Hour<7&&config.DateTime.Day==DateTime.Now.Day)
                            select config;
                foreach ( var config in ListConfig )
                {
                    var Item = (from e in ListConfig
                                where e.MachineId==config.MachineId
                                select e).OrderByDescending(e => e.DateTime).FirstOrDefault( );
                    if ( Item!=null&&!ListConfigurationShift2.Contains(Item) )
                    {
                        ListConfigurationShift2.Add(Item);

                    }
                }
            }
            else
            {
                foreach ( var config in _databaseServices.LoadConfiguration( ) )
                {
                    if ( config.DateTime.Hour==18&&config.DateTime.Minute==30&&config.DateTime.Day==DateTime.Now.Day )
                    {
                        ListConfigurationShift2.Add(config);
                    }
                }
            }
            #endregion
        }
        public void StoreEvent (string NameEvent,string MachineId)
        {
            MayEpCHADesktopApp.Core.Database.ModelDatabase.EventMachine eventMachine1 = new Database.ModelDatabase.EventMachine( );
            eventMachine1.NameEvent=NameEvent;
            eventMachine1.Status=0;
            eventMachine1.DateTime=DateTime.Now;
            eventMachine1.Status=0;
            eventMachine1.MachineId=MachineId;
            _databaseServices.InsertEventAsync(eventMachine1);
        }
        public async void SendConfigToESP3219h00 ( )
        {
            var ListConfigurationShift = new List<Configuration>( );
            foreach ( var config in _databaseServices.LoadConfiguration( ) )
            {
                if ( config.DateTime.Hour==18&&config.DateTime.Minute==30&&config.DateTime.Day ==DateTime.Now.Day )
                {
                    ListConfigurationShift.Add(config);
                }
            }
            try
            {
                foreach ( var configuration in ListConfigurationShift )
                {
                    SendConfig(configuration);
                    PostConfig(configuration);
                    StoreEvent("Gửi lệnh cài đặt từng máy",configuration.MachineId);
                }
                StoreEvent("Hoàn thành gửi toàn bộ cài đặt ca2","All Machine");
                ChangeEvent?.Invoke( );
            }
            catch
            {
                StoreEvent("Gửi toàn bộ cài đặt thất bại ca2","All Machine");
                ChangeEvent?.Invoke( );
            }
        }
        public async void SendConfigToESP327h00 ( )
        {
            var ListConfigurationShift = new List<Configuration>( );
            var ListConfig =
            from config in _databaseServices.LoadConfiguration( )
            where
            (config.DateTime.Hour==18&&config.DateTime.Minute==30
            &&config.DateTime.Day==DateTime.Now.Day-1)
            ||(config.DateTime.Hour>19&&config.DateTime.Hour<24&&config.DateTime.Day==DateTime.Now.Day-1)
            ||(config.DateTime.Hour>0&&config.DateTime.Hour<7&&config.DateTime.Day==DateTime.Now.Day)
            select config;
            foreach ( var config in ListConfig )
            {
                var Item = (from e in ListConfig
                            where e.MachineId==config.MachineId
                            select e).OrderByDescending(e => e.DateTime).FirstOrDefault( );
                if ( Item!=null&&!ListConfigurationShift.Contains(Item) )
                {
                    ListConfigurationShift.Add(Item);
                }
            }
            try
            {
                foreach ( var configuration in ListConfigurationShift )
                {
                    configuration.DateTime=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,6,30,00);
                    PostConfig(configuration);
                    SendConfig(configuration);
                 //   AddDatabase(configuration);
                    StoreEvent("Gửi lệnh cài đặt từng máy",configuration.MachineId);
                }
                StoreEvent("Hoàn thành gửi toàn bộ cài đặt ca1","All Machine");
                ChangeEvent?.Invoke( );
            }
            catch
            {
                StoreEvent("Gửi toàn bộ cài đặt thất bại ca1","All Machine");
                ChangeEvent?.Invoke( );
            }
        }
        public async void SendConfig (Configuration configuration)
        {
            var endpoint = await _busControl.GetSendEndpoint(new Uri("http://127.0.0.1:8181/send-config"));
            await endpoint.Send<ConfigurationMessage>(new ConfigurationMessage
            {
                MachineId=configuration.MachineId,
                Timestamp=DateTime.Now,
                MoldId=configuration.MoldId,
                CycleTime=configuration.CycleInjection,
                ProductId=configuration.ProductId
            });
        }
        public void PostConfig (Configuration configuration)
        {
            PreShiftConfiguration preShiftConfiguration = new PreShiftConfiguration( );
            preShiftConfiguration.Date=configuration.DateTime;
            preShiftConfiguration.ShiftNumber=(shift==1) ? EShift.Night : EShift.Day;
            preShiftConfiguration.ProductId=configuration.ProductId;
            preShiftConfiguration.TotalQuantity=configuration.Quantity;
            preShiftConfiguration.InjectionCycle=configuration.CycleInjection;
            preShiftConfiguration.StartTime=configuration.DateTime;
            preShiftConfiguration.StopTime=configuration.DateTime;
            preShiftConfiguration.WorkTime=0;
            preShiftConfiguration.PauseTime=0;
            preShiftConfiguration.Note="";
            preShiftConfiguration.Shots=new List<Shot>( );
            preShiftConfiguration.MachineId=configuration.MachineId;
            foreach ( var item in ListMold )
            {
                if ( item.Id==configuration.MoldId )
                {
                    preShiftConfiguration.Cavity=item.ProductsPerShot;
                }
            }

            _apiServices.PostShiftReportSingle("",preShiftConfiguration);
        }
        //Xú lí khi 19h không mở áp
        public void ActionTimerSendConfig (object? sender,EventArgs e)
        {
            Send( );

        }
        public void ActionTimerDelete (object? sender,EventArgs e)
        {
            DeleteAllConfigLastDay( );
        }

        public void Send ( )
        {
            if ( DateTime.Now.Hour>18&&DateTime.Now.Hour<20 )
            {
                bool check = false;
                foreach ( var item in _databaseServices.LoadEventMachine( ) )
                {
                    if ( item.DateTime.Date==DateTime.Now.Date&&item.NameEvent=="Hoàn thành gửi toàn bộ cài đặt ca2" )
                    {
                        check=true;
                        break;
                    }
                }
                if ( !check )
                {
                    SendConfigToESP3219h00( );
                }
            }
            if ( DateTime.Now.Hour>6&&DateTime.Now.Hour<10 )
            {
                bool check = false;
                foreach ( var item in _databaseServices.LoadEventMachine( ) )
                {
                    if ( item.DateTime.Day==DateTime.Now.Day&&item.NameEvent=="Hoàn thành gửi toàn bộ cài đặt ca1" )
                    {
                        check=true;
                        break;
                    }
                }
                if ( !check )
                {
                    SendConfigToESP327h00( );
                }
            }
        }

        private Task Delete ( )
        {
            //DateTime.Now.Hour > 10 && DateTime.Now.Hour < 20
            if ( true )
            {
                try
                {
                    _databaseServices.DeleteConfigAsync(ConfigurationSelect);
                    ListConfigurationShift2.Remove(ConfigurationSelect);
                    ActionChangeDatabase?.Invoke( );
                }
                catch ( Exception ex ) { }
            }
            return Task.CompletedTask;
        }
        private Task Add ( )
        {
            try
            {

                AddDataGrid( );
                ActionChangeDatabase?.Invoke( );
            }
            catch { }
            return Task.CompletedTask;
        }
        public void AddDataGrid ( )
        {
            if ( DateTime.Now.Hour>18||DateTime.Now.Hour<7 )
            {
                DateTime dateStandard;
                if ( DateTime.Now.Hour>19 )
                {
                    dateStandard=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day+1,6,30,00);
                }
                else
                {
                    dateStandard=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,6,30,00);
                }

                try
                {
                    Configuration configuration = new Configuration( );
                    configuration.Quantity=Quantity;
                    configuration.Shift=1;
                    configuration.MoldId=Mold.Id;
                    configuration.MachineId=Machine.Id;
                    configuration.ProductId=Product.ProductId;
                    configuration.CycleInjection=CycleInjection;
                    configuration.DateTime=dateStandard;
                    ListConfigurationShift2.Add(configuration);
                    AddDatabase(configuration);
                }
                catch
                {
                    CustomMessageBox.Show("Vui lòng nhập đầy đủ thông tin"," Cảnh báo",System.Windows.MessageBoxButton.OKCancel);
                }


            }
            else if ( DateTime.Now.Hour>6&&DateTime.Now.Hour<19 )
            {
                DateTime dateStandard = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,18,30,00);
                try
                {
                    Configuration configuration = new Configuration( );
                    configuration.Quantity=Quantity;
                    configuration.Shift=2;
                    configuration.MoldId=Mold.Id;
                    configuration.MachineId=Machine.Id;
                    configuration.ProductId=Product.ProductId;
                    configuration.CycleInjection=CycleInjection;
                    configuration.DateTime=dateStandard;
                    ListConfigurationShift2.Add(configuration);
                    AddDatabase(configuration);
                }
                catch
                {
                    CustomMessageBox.Show("Vui lòng nhập đầy đủ thông tin"," Cảnh báo",System.Windows.MessageBoxButton.OKCancel);
                }
            }
        }
        public void AddDatabase (Configuration configuration)
        {
            _databaseServices.InsertConfigAsync(configuration);
            ActionChangeDatabase?.Invoke( );
        }
        #region Api
        public async void GetTotalMold ( )
        {
            ListMold=new ObservableCollection<Mold>( );
            ListMold=await _apiServices.GetMoldTotal("");

        }
        public async void GetTotalProduct ( )
        {
            ListProduct=new ObservableCollection<Product>( );
            ListProduct=await _apiServices.GetProductTotal("");
        }
        public async void GetTotalMachine ( )
        {
            ListMachine=new ObservableCollection<Machine>( );
            ListMachine=await _apiServices.GetMachineTotal("");
        }
        public async void GetTotalEmployee ( )
        {
            ListEmployee=new ObservableCollection<Employee>( );
            ListEmployee=await _apiServices.GetEmployeeTotal("");
        }
        #endregion

    }
}
