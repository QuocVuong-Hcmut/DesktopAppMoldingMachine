using ImmServiceContainers;
using InjectionMoldingMachineDataAcquisitionService.Communication.Consumers;
using MassTransit;
using MayEpCHADesktopApp.Core.Components;
using MayEpCHADesktopApp.Core.Services.Communication.ModelMQTT;
//using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using MayEpCHADesktopApp.Core.Model;
using MayEpCHADesktopApp.Core.Services.Communication.Consumer;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using EventMachine = MayEpCHADesktopApp.Core.Services.Communication.ModelMQTT.EventMachine;

namespace MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels
{
    public class DetailMachineViewModel: ViewModels.BaseViewModels.BaseViewModel
    {

        #region var
        private string content { get; set; }
        public string Content { get => content; set { content=value; OnPropertyChanged( ); } }


        private bool animation1;
        public bool Animation1 { get => animation1; set { animation1=value; OnPropertyChanged( ); } }

        private bool animation2;
        public bool Animation2 { get => animation2; set { animation2=value; OnPropertyChanged( ); } }
        //so luong
        private string count { get; set; }
        public string Count { get => count; set { count=value; OnPropertyChanged( ); } }
        //
        private string moldId { get; set; }
        public string MoldId { get => moldId; set { moldId=value; OnPropertyChanged( ); } }


        //
        private string productId { get; set; }
        public string ProductId { get => productId; set { productId=value; OnPropertyChanged( ); } }

        //
        private string cycle { get; set; }
        public string Cycle { get => cycle; set { cycle=value; OnPropertyChanged( ); } }
        //CountConfigurationProduct
        private string countConfigurationProduct { get; set; }
        public string CountConfigurationProduct { get => countConfigurationProduct; set { countConfigurationProduct=value; OnPropertyChanged( ); } }

        //
        private string cycleStandard { get; set; }
        public string CycleStandard { get => cycleStandard; set { cycleStandard=value; OnPropertyChanged( ); } }
        private string mode;
        public string Mode { get => mode; set { mode=value; OnPropertyChanged( ); } }
        private bool a;
        public bool A { get => a; set { a=value; OnPropertyChanged( ); } }
        private bool b;
        public bool B { get => b; set { b=value; OnPropertyChanged( ); } }
        private string status;
        public string Status { get => status; set { status=value; OnPropertyChanged( ); } }
        #endregion var
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
        private ObservableCollection<EventMachine> listEvent;
        public ObservableCollection<EventMachine> ListEvent { get => listEvent; set { listEvent=value; OnPropertyChanged( ); } }

        private string setCycle;
        public string SetCycle { get => setCycle; set { setCycle=value; OnPropertyChanged( ); } }
        private string setMold;
        public string SetMold { get => setMold; set { setMold=value; OnPropertyChanged( ); } }
        private Product product;
        public Product Product
        {
            get => product; set
            {
                product=value; OnPropertyChanged( );
                try
                {
                    foreach ( var item in ListMold )
                    {
                        if ( Product.MoldId==item.Id )
                        {
                            Mold=item;
                            SetMold=Mold.Id;
                            SetCycle=Mold.StandardInjectionCycle.ToString( );
                            break;
                        }
                    }

                    Cycle=Mold.StandardInjectionCycle.ToString( );
                }
                catch ( Exception ex )
                {

                }

            }
        }
        private Mold mold;
        public Mold Mold { get => mold; set { mold=value; OnPropertyChanged( ); } }
        private IBusControl _bus;
        private IDatabaseServices _databaseServices;
        private IApiServices _apiServices; 
        public static event Action UpdateEventTable;
        public static event Action ActionChangeDatabase;
        public ICommand ChangeMoldCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public DetailMachineViewModel (IBusControl bus,IDatabaseServices databaseServices,IApiServices apiServices)
        {
            _bus=bus;
            _databaseServices=databaseServices;
            _apiServices=apiServices;
            Content="Tạm dừng";
            Animation1=true;
            Animation2=false;
            ListMold=new ( );
            ListMachine=new ( );
            ListEmployee=new ( );
            ListEvent=new ( );
            GetTotalMold( );
            GetTotalProduct( );
            #region int
            Status="1";
            A=true;
            B=false;
            Content="Tạm dừng";

            #endregion int
            ChangeMoldCommand=new RelayObjectCommand<object>((p) => { return true; },async (p) => Pause(p));
            BackCommand=new RelayCommand(async ( ) => Back( ));
        }
        private void Back ( )
        {
            Content="Tạm dừng";
            A=true;
            B=false;
        }
        public async void Command (CommandMessage commandMessage)
        {
            //var endpoint = await _bus.GetSendEndpoint(new Uri("http://127.0.0.1:8181/send-config"));
            //await endpoint.Send<CommandMessage>(commandMessage);
        }
        public async void ConfigCommand (ConfigurationMessage configMessage)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("http://127.0.0.1:8181/send-config"));
            await endpoint.Send<ConfigurationMessage>(configMessage);
        }
        public void GetInforConfiguration (Configuration configuration )
        {
            MoldId=configuration.MoldId;
            ProductId=configuration.ProductId;
            SetCycle=configuration.CycleInjection.ToString();
            Count = configuration.Quantity.ToString();
        }
        public void GetMachineStatus (MachineMessage Message)
        {
            EventMachine eventMachine = new EventMachine( );

            switch ( Message.MachineStatus )
            {
                case EMachineStatus.PowerOff:
                    Status="1";

                    eventMachine.NameEvent="Power off";
                    eventMachine.Status=0;
                    eventMachine.DateTime=DateTime.Now;
                    ListEvent.Add(eventMachine);
                    break;
                case EMachineStatus.PowerOn:
                    Status="2";
                    break;
                case EMachineStatus.Disconnect:
                    Status="3";

                    eventMachine.NameEvent="Ngắt kết nối";
                    eventMachine.Status=0;
                    eventMachine.DateTime=DateTime.Now;
                    ListEvent.Add(eventMachine);
                    break;
                case EMachineStatus.Connected:
                    Status="4";
                    break;
                case EMachineStatus.OnProduction:
                    Status="5";
                    break;
                case EMachineStatus.Idle:
                    Status="6";
                    break;
                case EMachineStatus.ErrorOnGoing:
                    Status="7";

                    eventMachine.NameEvent="ErrorOnGoing";
                    eventMachine.Status=0;
                    eventMachine.DateTime=DateTime.Now;
                    ListEvent.Add(eventMachine);
                    break;
                case EMachineStatus.ErrorOutGoing:
                    Status="8";
                    break;
            }

        }
        public int TemptCycle;
        public void GetCycleMessage (CycleMessage Message)
        {


            Count=Message.CounterShot.ToString( );
            ProductId=Message.ProductId.ToString( );
            CycleStandard=Message.SetCycle.ToString( );
            Cycle=Message.CycleTime.ToString( );
            MoldId=Message.MoldId.ToString( );
            if ( Message.Mode==1 )
            {
                Mode="Tự động";
            }
            else
            {
                Mode="Bán Tự động";
            }

            // if(Math.Abs((Convert.ToInt32(Cycle)-Convert.ToInt32(CycleStandard))*10) > (Convert.ToInt32(CycleStandard)) || true ){
            Application.Current.Dispatcher.Invoke(new Action(( ) =>
            {
                EventMachine eventMachine = new EventMachine( );
                eventMachine.NameEvent="Lỗi chu kì ép";
                eventMachine.Status=0;
                eventMachine.DateTime=DateTime.Now;
                eventMachine.CycleTime=Cycle;
                ListEvent.Add(eventMachine);
                CollectionViewSource.GetDefaultView(ListEvent).Refresh( );
                OnPropertyChanged("ListEvent");
                StoreEvent(eventMachine,Message.MachineId);
                UpdateEventTable?.Invoke( );
            }));

            A=false;
            B=true;
            A=true;
            B=false;

            //   }
            TemptCycle=Convert.ToInt32(Cycle);
        }
        public void ReiceverBoolUaAction (UaBooleanData message)
        {
            string[] Data = message.Name.Split('.');
            switch ( Data[1] )
            {
                case "GreenAlarm":
                    if ( message.Value )
                    {
                        Status="5";
                    }

                    break;
                case "YellowAlarm":
                    if ( message.Value )
                    {
                        Status="6";
                    }
                    break;
                case "RedAlarm":
                    if ( message.Value )
                    {
                        Status="3";
                    }
                    break;
                case "SafetyDoor":

                    Status="6";

                    break;
            }
        }

        public void ReiceverIntUaAction (UaIntegerData message)
        {
            string[] Data = message.Name.Split('.');
            switch ( Data[1] )
            {
                case "LastCycle":
                    Cycle=message.Value.ToString( );

                    break;
                case "CounterShot":
                    Count=message.Value.ToString( );
                    break;
                case "CycleTime":
                    Cycle=message.Value.ToString( );
                    break;
                    //case "bRedAlarm":

                    // break;

            }
            //foreach (var item in _databaseServices.LoadConfiguration())
            //{
            //    if(Data[1] == item.MachineId)
            //    {
            //        MoldId = item.MoldId;
            //        ProductId = item.ProductId;
            //        foreach(var item2 in listMold)
            //        {
            //            CycleStandard = item.MoldId;
            //        }
            //    }
            //}
            Application.Current.Dispatcher.Invoke(new Action(( ) =>
            {
                EventMachine eventMachine = new EventMachine( );
                eventMachine.NameEvent="Lỗi chu kì ép";
                eventMachine.Status=0;
                eventMachine.DateTime=DateTime.Now;
                eventMachine.CycleTime=Cycle;
                ListEvent.Add(eventMachine);
                CollectionViewSource.GetDefaultView(ListEvent).Refresh( );
                OnPropertyChanged("ListEvent");
            }));
        }

        private void Pause (object p)
        {
            string Namemachine = (p as UserControl).Name.ToString( );
            try
            {
                if ( Content=="Tạm dừng" )
                {//result==MessageBoxResult.OK
                 // MessageBoxResult result = CustomMessageBox.Show("Bạn có chắc dừng lại thay khuôn không ??","Cảnh báo",MessageBoxButton.OKCancel,MessageBoxImage.Information);
                    if ( true )
                    {
                        Command(new CommandMessage
                        {
                            MachineId=Namemachine,
                            Timestamp=DateTime.Now,
                            Command=ECommand.ChangeMold,

                        });
                        Application.Current.Dispatcher.Invoke(new Action(( ) =>
                        {
                            EventMachine eventMachine = new EventMachine( );
                            eventMachine.NameEvent="Thay khuôn";
                            eventMachine.Status=0;
                            eventMachine.DateTime=DateTime.Now;
                            ListEvent.Add(eventMachine);
                            CollectionViewSource.GetDefaultView(ListEvent).Refresh( );
                            OnPropertyChanged("ListEvent");
                            StoreEvent(eventMachine,Namemachine);
                            UpdateEventTable?.Invoke( );
                        }));
                        A=false;
                        B=true;
                        Content="Tiếp tục";
                    }
                }
                else if ( Content=="Tiếp tục" )
                {
                    // MessageBoxResult result = CustomMessageBox.Show("Bạn muốn máy hoạt động với thông số đã nhập??","Cảnh báo",MessageBoxButton.OKCancel,MessageBoxImage.Information);
                    var dateTime = DateTime.Now;
                    if ( true )
                    {
                        Command(new CommandMessage
                        {
                            MachineId=Namemachine,
                            Timestamp=dateTime,
                            Command=ECommand.ChangeMoldDone,
                        });
                        CycleStandard=SetCycle;
                        MoldId=SetMold;
                        ProductId=Product.ProductId;
                        Count="0";
                        ConfigCommand(new ConfigurationMessage( ) { MachineId=Namemachine,Timestamp=DateTime.Now,CycleTime=Convert.ToDouble(SetCycle),ProductId=Product.ProductId,MoldId=SetMold , });
                        Application.Current.Dispatcher.Invoke(new Action(( ) =>
                        {
                            EventMachine eventMachine = new EventMachine( );
                            eventMachine.NameEvent="Hoàn thành thay khuôn";
                            eventMachine.Status=0;
                            eventMachine.DateTime=dateTime;
                            ListEvent.Add(eventMachine);
                            CollectionViewSource.GetDefaultView(ListEvent).Refresh( );
                            OnPropertyChanged("ListEvent");
                            Configuration configuration = new Configuration( );
                            configuration.Quantity=50;
                            configuration.Shift=(dateTime.Hour>7&&dateTime.Hour<19) ? 1 : 2;
                            configuration.MoldId=SetMold;
                            configuration.MachineId=Namemachine;
                            configuration.ProductId=Product.ProductId;
                            configuration.CycleInjection=Convert.ToDouble(SetCycle);
                            configuration.DateTime=dateTime;
                            AddDatabase(configuration);
                            StoreEvent(eventMachine,Namemachine);
                            ActionChangeDatabase?.Invoke( );
                            UpdateEventTable?.Invoke( );
                            PostConfigChangMold(Namemachine,dateTime);
                        }));


                        Content="Tạm dừng";
                        A=true;
                        B=false;
                    }
                }
            }
            catch
            {

            }
        }
        public void StoreEvent (EventMachine eventMachine,string nameMachine)
        {
            MayEpCHADesktopApp.Core.Database.ModelDatabase.EventMachine eventMachine1 = new Database.ModelDatabase.EventMachine( );
            eventMachine1.NameEvent=eventMachine.NameEvent;
            eventMachine1.Status=eventMachine.Status;
            eventMachine1.DateTime=eventMachine.DateTime;
            eventMachine1.Status=0;
            eventMachine1.MachineId=nameMachine;
            _databaseServices.InsertEventAsync(eventMachine1);
        }
        public void AddDatabase (Configuration configuration)
        {
            _databaseServices.InsertConfigAsync(configuration);
            ActionChangeDatabase?.Invoke( );
        }
        ///api
        public async void GetTotalMold ( )
        {
            ListMold=await _apiServices.GetMoldTotal("");
        }
        public async void GetTotalProduct ( )
        {
            ListProduct=await _apiServices.GetProductTotal("");
        }
        public async void PostConfigChangMold (string Namemachine,DateTime dateTime)
        {

            PreShiftConfiguration preShiftConfiguration = new PreShiftConfiguration( );
            preShiftConfiguration.Date=dateTime;
            preShiftConfiguration.ShiftNumber=(DateTime.Now.Hour >19 ||DateTime.Now.Hour <7 ) ? EShift.Night : EShift.Day;
            preShiftConfiguration.ProductId=Product.ProductId;
            preShiftConfiguration.TotalQuantity=0;
            preShiftConfiguration.InjectionCycle=Convert.ToDouble( SetCycle);
            preShiftConfiguration.StartTime=dateTime;
            preShiftConfiguration.StopTime=dateTime;
            preShiftConfiguration.WorkTime=0;
            preShiftConfiguration.PauseTime=0;
            preShiftConfiguration.Note="";
            preShiftConfiguration.Shots=new List<Shot>( );
            preShiftConfiguration.MachineId=Namemachine;
            foreach ( var item in ListMold )
            {
                if ( item.Id==Product.MoldId )
                {
                    preShiftConfiguration.Cavity=item.ProductsPerShot;
                }
            }
            _apiServices.PostShiftReportSingle("",preShiftConfiguration);

            ConfigCommand(new ConfigurationMessage
            {
                MachineId=Namemachine,
                Timestamp=dateTime,
                MoldId=SetMold,
                CycleTime=Convert.ToInt32(SetCycle),
                ProductId=Product.ProductId
            }); ;
        }


    }
}
