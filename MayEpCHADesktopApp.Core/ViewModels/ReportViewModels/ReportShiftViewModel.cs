using MayEpCHADesktopApp.Core.Components;
using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using MayEpCHADesktopApp.Core.Model;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace MayEpCHADesktopApp.Core.ViewModels.ReportViewModels
{

    public class ReportShiftViewModel: ViewModels.BaseViewModels.BaseViewModel
    {
        //Biến tạo shiftreport
        #region Var
        private DateTime date;
        private int id;
        private EShift ShiftNumber;
        private int shift;
        private Employee employee;
        private Machine machine;
        private Product product;
        private int totalQuantity;

        private DateTime stopTime;
        private double workTime;
        private double pauseTime;
        private string note;
        private Mold mold;
        private int unit;
        private string totalQuantityStandard;
        public string TotalQuantityStandard { get => totalQuantityStandard; set { totalQuantityStandard=value; OnPropertyChanged( ); } }
        private string moldId;
        public string MoldId { get => moldId; set { moldId=value; OnPropertyChanged( ); } }
        private ShiftReport selectShiftReport;
        public DateTime Date { get => date; set { date=value; OnPropertyChanged( ); } }
        public int Id { get => id; set { id=value; OnPropertyChanged( ); } }
        public int Shift { get => shift; set { shift=value; OnPropertyChanged( ); } }
        public Employee Employee { get => employee; set { employee=value; OnPropertyChanged( ); } }
        public Machine Machine { get => machine; set { machine=value; OnPropertyChanged( ); } }
        public Product Product { get => product; set { product=value; OnPropertyChanged( ); Unit=(Product.Unit==EUnit.Kilogram) ? 1 : 0; MoldId=Product.MoldId; Mold=Product.Mold; } }
        public int TotalQuantity { get => totalQuantity; set { totalQuantity=value; OnPropertyChanged( ); } }



        public DateTime StopTime { get => stopTime; set { stopTime=value; OnPropertyChanged( ); } }
        public double WorkTime { get => workTime; set { workTime=value; OnPropertyChanged( ); } }
        private int cavity;
        public int Cavity { get => cavity; set { cavity=value; OnPropertyChanged( ); } }
        public double PauseTime { get => pauseTime; set { pauseTime=value; OnPropertyChanged( ); } }
        public string Note { get => note; set { note=value; OnPropertyChanged( ); } }
        public Mold Mold { get => mold; set { mold=value; OnPropertyChanged( ); } }
        public int Unit { get => unit; set { unit=value; OnPropertyChanged( ); } }
        public static event Action ChangeEvent;
        #endregion
        public string Url = "";
        public ShiftReport SelectShiftReport
        {
            get => selectShiftReport;
            set
            {
                selectShiftReport=value;
                OnPropertyChanged( );
                if ( SelectShiftReport!=null )
                {
                    if ( SelectShiftReport.Date!=null )
                    {
                        Date=SelectShiftReport.Date;
                    }
                    if ( SelectShiftReport.ShiftNumber!=null )
                    {
                        Shift=(SelectShiftReport.ShiftNumber==EShift.Night) ? 0 : 1;
                    }
                    if ( SelectShiftReport.EmployeeId!=null )
                    {
                        Employee=(from item in ListEmployee
                                  where item.Id==SelectShiftReport.EmployeeId
                                  select item).FirstOrDefault( );
                    }
                    if ( SelectShiftReport.MachineId!=null )
                    {
                        Machine=(from item in ListMachine
                                 where item.Id==SelectShiftReport.MachineId
                                 select item).FirstOrDefault( );
                    }
                    if ( SelectShiftReport.ProductId!=null )
                    {
                        Product=(from item in ListProduct
                                 where item.ProductId==SelectShiftReport.ProductId
                                 select item).FirstOrDefault( );
                        Mold=Product.Mold;
                        MoldId=Mold.Id;
                        Unit=(Product.Unit==EUnit.Kilogram) ? 0 : 1;
                    }


                    if ( SelectShiftReport.TotalQuantity!=null )
                    {
                        TotalQuantity=SelectShiftReport.TotalQuantity;
                    }
                    if ( SelectShiftReport.StopTime!=null )
                    {
                        StopTime=SelectShiftReport.StopTime;
                    }
                    if ( SelectShiftReport.WorkTime!=null )
                    {
                        WorkTime=SelectShiftReport.WorkTime;
                        TotalQuantityStandard=(WorkTime*60/Convert.ToDouble(Mold.StandardInjectionCycle)+100).ToString( );
                    }

                    if ( SelectShiftReport.PauseTime!=null )
                    {
                        PauseTime=SelectShiftReport.PauseTime;
                    }
                    if ( SelectShiftReport.Note!=null )
                    {
                        Note=SelectShiftReport.Note;
                    }
                }
            }
        }
        private IApiServices _apiServices;
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
        private ObservableCollection<ShiftReport> listPreShiftReport;
        public ObservableCollection<ShiftReport> ListPreShiftReport { get => listPreShiftReport; set { listPreShiftReport=value; OnPropertyChanged( ); } }
        private ObservableCollection<Employee> listEmployee;
        public ObservableCollection<Employee> ListEmployee { get => listEmployee; set { listEmployee=value; OnPropertyChanged( ); } }
        private ObservableCollection<Machine> listMachine;
        public ObservableCollection<Machine> ListMachine { get => listMachine; set { listMachine=value; OnPropertyChanged( ); } }
        private List<Shot> listShot;
        public ObservableCollection<ShiftReport> ListShiftReportTempt = new ObservableCollection<ShiftReport>( );
        public List<Shot> ListShot { get => listShot; set { listShot=value; } }
        //
        public ICommand SaveExcelCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand SaveDatagridCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private IDatabaseServices _databaseServices;

        private ObservableCollection<ShiftReport> listShiftReport;
        public ObservableCollection<ShiftReport> ListShiftReport { get => listShiftReport; set { listShiftReport=value; } }
        public ReportShiftViewModel (IApiServices apiServices,IDatabaseServices databaseServices)
        {
            _apiServices=apiServices;
            _databaseServices=databaseServices;
            SaveExcelCommand=new RelayCommand(async ( ) => SaveExcel( ));
            SaveDatagridCommand=new RelayCommand(async ( ) => SaveDatagrid( ));
            ChangeCommand=new RelayCommand(async ( ) => ChangeShiftReport( ));
            DeleteCommand=new RelayCommand(async ( ) => DeleteShiftReport( ));
            LoadCommand=new RelayCommand(async ( ) => GetTotalPreShiftReport( ));
            ListShiftReport=new ObservableCollection<ShiftReport>( );
            ListShot=new List<Shot>( );
            GetTotalEmplyee( );
            GetTotalMold( );
            GetTotalProduct( );
            GetTotalMachinne( );
            GetTotalPreShiftReport( );
            // SettingsNewViewModel.ActionChangeDatabase+=Load;
            Date=DateTime.Now;

        }


        private async void DeleteShiftReport ( )
        {
            MessageBoxResult result = CustomMessageBox.Show("Chỉnh sửa thành công","Thông báo",System.Windows.MessageBoxButton.YesNo,System.Windows.MessageBoxImage.Asterisk);
            if ( result==MessageBoxResult.OK )
            {
                ListShiftReport.Remove(SelectShiftReport);
                OnPropertyChanged("ListShiftReport");
            }
        }
        private async Task<string[]> LoadCSVCycle (string machineId)
        {
            var dataCycle = new string[] { };
            try
            {
                var shift = (DateTime.Now.Hour>4&&DateTime.Now.Hour<9) ? 1 : 2;
                string month = (DateTime.Now.Month>9&&DateTime.Now.Month<13) ? DateTime.Now.Month.ToString( ) : "0"+DateTime.Now.Month;
                string year = (DateTime.Now.Year%2000).ToString( );
                string day = (DateTime.Now.Day>9&&DateTime.Now.Month<40) ? DateTime.Now.Day.ToString( ) : "0"+DateTime.Now.Day;
                dataCycle=File.ReadAllLines(@$"{Url}{machineId}\C{shift}{day+month+year}");

            }
            catch
            {

            }
            return dataCycle;
        }
        private async Task<double> LoadWorkTime (string machineId)
        {
            var shift = (DateTime.Now.Hour>4&&DateTime.Now.Hour<9) ? 1 : 2;
            string month = (DateTime.Now.Month>9&&DateTime.Now.Month<13) ? DateTime.Now.Month.ToString( ) : "0"+DateTime.Now.Month;
            string year = (DateTime.Now.Year%2000).ToString( );
            string day = (DateTime.Now.Day>9&&DateTime.Now.Month<40) ? DateTime.Now.Day.ToString( ) : "0"+DateTime.Now.Day;

            int count = 0;
            double TimeTotal = 0;
            string[] ContentCurrent;
            string[] ContentFuture;
            try
            {
                var statusData = File.ReadAllLines(@$"{Url}{machineId}\C{shift}{day+month+year}");
                for ( int i = 0;i<statusData.Length-2;i++ )
                {

                    ContentCurrent=statusData[i].Split(',');
                    ContentFuture=statusData[i+1].Split(',');
                    if ( ContentCurrent[1]==ContentFuture[1]&&ContentCurrent[1]=="4" )
                    {
                        while ( true )
                        {
                            ContentCurrent=statusData[i+count].Split(',');
                            ContentFuture=statusData[i+1+count].Split(',');
                            if ( ContentCurrent[1]==ContentFuture[1] )
                            {
                                count++;

                            }
                            else
                            {
                                ContentCurrent=statusData[i].Split(',');
                                ContentFuture=statusData[i+count].Split(',');
                                TimeTotal+=(Convert.ToDateTime(ContentFuture[0])-Convert.ToDateTime(ContentCurrent[0])).TotalMinutes;
                                break;
                            }

                        }
                        i=i+count;
                    }
                    count=0;
                }

            }
            catch
            {
                TimeTotal=0;
            }
            return TimeTotal;

        }
        private async void Load ( )
        {
            if ( ListShiftReport!=null )
            {
                ListShiftReport.Clear( );
            }
            if ( DateTime.Now.Hour>15&&DateTime.Now.Hour<20 )
            {
                try
                {
                    foreach ( var item in ListPreShiftReport )
                    {

                        if ( ((item.Date.Day==DateTime.Now.Day&&item.Date.Hour==6&&item.Date.Minute==30)||
                            (item.Date.Day==DateTime.Now.Day&&item.Date.Hour>6&&item.Date.Hour<19&&
                            !(item.Date.Hour==18&&item.Date.Date.Minute==30)))
                            )
                        {
                            // ShiftReport shiftReport = new ShiftReport( );
                            var ListCycle = await LoadCSVCycle(item.MachineId);
                            item.TotalQuantity=ListCycle.Length-1;
                            item.ShiftNumber=(DateTime.Now.Hour>7&&DateTime.Now.Hour<11) ? EShift.Day : EShift.Night;
                           // item.StopTime=Convert.ToDateTime(ListCycle[ListCycle.Length-1].Split(',')[0]); ;
                            item.WorkTime=await LoadWorkTime(item.MachineId);
                            item.PauseTime=720-item.WorkTime;
                            item.Shots=GetListShot(item.MachineId);
                            
                            try
                            {
                                ListShiftReport.Add(item);
                            }
                            catch ( Exception ex )
                            {
                            }
                        }

                    }
                }
                catch ( Exception ex )
                { }
            }
            else if ( DateTime.Now.Hour>5&&DateTime.Now.Hour<9 )
            {
                var ListEventMachines = from item in _databaseServices.LoadEventMachine( )
                                        where item.NameEvent=="Hoàn thành thay khuôn"
                                        &&((item.DateTime.Day==DateTime.Now.Day&&item.DateTime.Hour>0&&item.DateTime.Hour<7)
                                        ||(item.DateTime.Day==(DateTime.Now.Day-1)&&item.DateTime.Hour>19&&item.DateTime.Hour<24))
                                        select item;
                try
                {
                    foreach ( var item in ListPreShiftReport )
                    {
                        bool check = false;
                        if ( ListEventMachines.Count( )>0 )
                        {
                            foreach ( var item1 in ListEventMachines )
                            {
                                if ( item.Date==item1.DateTime )
                                {
                                    check=true;

                                }
                            }
                        }
                        if ( (item.Date.Day==DateTime.Now.Day-1&&item.Date.Hour==18&&item.Date.Minute==30||check)

                            )
                        {
                            var ListCycle = await LoadCSVCycle(item.MachineId);
                            item.TotalQuantity=ListCycle.Length-1;
                            item.ShiftNumber=(DateTime.Now.Hour>7&&DateTime.Now.Hour<11) ? EShift.Day : EShift.Night;
                         //   item.StopTime=Convert.ToDateTime(ListCycle[ListCycle.Length-1].Split(',')[0]); ;
                            item.WorkTime=await LoadWorkTime(item.MachineId);
                            item.PauseTime=720-item.WorkTime;
                            item.Shots=GetListShot(item.MachineId);
                            try
                            {
                                ListShiftReport.Add(item);
                            }
                            catch ( Exception ex )
                            {
                            }

                        }
                        check=false;
                    }

                }
                catch ( Exception ex )
                { }
            }
        }

        private async void ChangeShiftReport ( )
        {
            Application.Current.Dispatcher.Invoke(new Action(( ) =>
            {
                SelectShiftReport.StartTime=SelectShiftReport.Date;
                SelectShiftReport.Date=Date;
                SelectShiftReport.ShiftNumber=(shift==1) ? EShift.Night : EShift.Day;
                SelectShiftReport.EmployeeId=Employee.Id;
                SelectShiftReport.ProductId=Product.ProductId;
                SelectShiftReport.TotalQuantity=TotalQuantity;
                SelectShiftReport.StopTime=StopTime;
                SelectShiftReport.WorkTime=WorkTime;
                SelectShiftReport.PauseTime=PauseTime;
                SelectShiftReport.Note=Note;
                SelectShiftReport.Shots=ListShot;
                SelectShiftReport.MachineId=Machine.Id;
                SelectShiftReport.Cavity=Cavity;
                CollectionViewSource.GetDefaultView(ListShiftReport).Refresh( );
                OnPropertyChanged(nameof(ListShiftReport));
                CustomMessageBox.Show("Chỉnh sửa thành công","Thông báo",System.Windows.MessageBoxButton.YesNo,System.Windows.MessageBoxImage.Asterisk);
            }));
        }

        private async void SaveDatagrid ( )
        {
            ShiftReport shiftReport = new ShiftReport( );
            shiftReport.StartTime=shiftReport.Date;
            shiftReport.Date=Date;
            shiftReport.ShiftNumber=(shift==1) ? EShift.Night : EShift.Day;
            shiftReport.EmployeeId=Employee.Id;
            shiftReport.ProductId=Product.ProductId;
            shiftReport.TotalQuantity=TotalQuantity;

            shiftReport.StopTime=StopTime;
            shiftReport.WorkTime=WorkTime;
            shiftReport.PauseTime=PauseTime;
            shiftReport.Note=Note;
            shiftReport.Shots=ListShot;
            shiftReport.MachineId=Machine.Id;
            shiftReport.MachineId=Machine.Id;
            try
            {
                ListShiftReport.Add(shiftReport);
            }
            catch ( Exception ex )
            {
                CustomMessageBox.Show("Vui lòng điền đầy đủ thông tin","Thông báo",System.Windows.MessageBoxButton.YesNo,System.Windows.MessageBoxImage.Asterisk);

            }
        }

        private async void SaveExcel ( )
        {

            ExcelPackage.LicenseContext=OfficeOpenXml.LicenseContext.NonCommercial;
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog( );

            if ( dialog.ShowDialog( )==true )
            {
                filePath=dialog.FileName;
            }
            try
            {
                using ( ExcelPackage p = new ExcelPackage(new FileInfo(filePath)) )
                {
                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[3];

                    int rowIndex = 10;
                    while ( ws.Cells["E"+rowIndex.ToString( )].Value!=null||ws.Cells["E"+(rowIndex+1).ToString( )].Value!=null||
                            ws.Cells["E"+(rowIndex+2).ToString( )].Value!=null||ws.Cells["E"+(rowIndex+3).ToString( )].Value!=null||
                            ws.Cells["E"+(rowIndex+4).ToString( )].Value!=null||ws.Cells["E"+(rowIndex+5).ToString( )].Value!=null||
                            ws.Cells["E"+(rowIndex+6).ToString( )].Value!=null||ws.Cells["E"+(rowIndex+7).ToString( )].Value!=null||
                            ws.Cells["E"+(rowIndex+8).ToString( )].Value!=null||ws.Cells["E"+(rowIndex+9).ToString( )].Value!=null
                        )
                    {
                        rowIndex++;
                    }

                    foreach ( ShiftReport item in ListShiftReport )
                    {
                        var product = (from item1 in ListProduct
                                       where item1.ProductId==item.ProductId
                                       select item1).FirstOrDefault( );
                        ws.Cells["B"+rowIndex.ToString( )].Value=item.Date.ToShortDateString( );
                        ws.Cells["C"+rowIndex.ToString( )].Value=(item.ShiftNumber==EShift.Night) ? 1 : 2;
                        ws.Cells["E"+rowIndex.ToString( )].Value=item.EmployeeId;
                        ws.Cells["G"+rowIndex.ToString( )].Value=item.MachineId;
                        ws.Cells["H"+rowIndex.ToString( )].Value=product.MoldId;
                        Mold=Product.Mold;
                        MoldId=Mold.Id;
                        Unit=(Product.Unit==EUnit.Kilogram) ? 0 : 1;
                        ws.Cells["K"+rowIndex.ToString( )].Value=item.ProductId;
                        if ( product.Unit==EUnit.Pieces )
                        {
                            ws.Cells["S"+rowIndex.ToString( )].Value=item.TotalQuantity;
                        }
                        else
                        {
                            ws.Cells["T"+rowIndex.ToString( )].Value=item.TotalQuantity;
                        }
                        ws.Cells["X"+rowIndex.ToString( )].Value=item.StartTime;
                        ws.Cells["Y"+rowIndex.ToString( )].Value=item.StopTime;
                        ws.Cells["Q"+rowIndex.ToString( )].Value=item.Cavity;
                        ws.Cells["AB"+rowIndex.ToString( )].Value=item.Note;
                        ws.Cells["AA"+rowIndex.ToString( )].Value=item.PauseTime.ToString( );
                        rowIndex++;
                        _apiServices.PutShiftReport("",item);
                        StoreEvent("Xuất báo cáo từng máy",item.MachineId);
                    }
                    p.Save( );
                }
                MessageBox.Show("Xuất excel thành công!");
                StoreEvent("Xuất báo cáo thành công","All Machine");
                //Xóa hết các lệnh change mold và config trước đó
                DeleteAllConfigLastDay( );
                ChangeEvent?.Invoke( );
            }
            catch ( Exception e )
            {
                MessageBox.Show("Có lỗi khi lưu file!");
                StoreEvent("Lỗi khi xuất báo cáo","All Machine");
                ChangeEvent?.Invoke( );
            }

            Load( );
            CustomMessageBox.Show("Bạn muốn Load file báo cáo?","Thông báo",MessageBoxButton.OKCancel);
        }

        public void DeleteAllConfigLastDay ( )
        {
            var ListConfigurationRemove = new ObservableCollection<Configuration>( );
            var ListEventMachines = from item in _databaseServices.LoadEventMachine( )
                                    where item.NameEvent=="Hoàn thành thay khuôn"
                                    &&item.DateTime.Day==DateTime.Now.Day
                                    &&item.DateTime.Hour>7
                                    &&item.DateTime.Hour<19
                                    select item;
            if ( DateTime.Now.Hour>18&&DateTime.Now.Hour<20 )
            {
                foreach ( var item in _databaseServices.LoadConfiguration( ) )
                {
                    bool check = false;
                    if ( ListEventMachines.Count( )>0 )
                    {
                        foreach ( var item1 in ListEventMachines )
                        {
                            if ( item.DateTime==item1.DateTime )
                            {
                                check=true;
                            }
                        }
                    }
                    if ( (item.DateTime.Day==DateTime.Now.Day&&item.DateTime.Hour<7&&item.DateTime.Minute<0)
                        ||(item.DateTime.Day<DateTime.Now.Day||check
                        ) )
                    {
                        ListConfigurationRemove.Add(item);
                    }
                }
                if ( ListConfigurationRemove.Count>0 )
                {
                    foreach ( var item in ListConfigurationRemove )
                    {
                        _databaseServices.DeleteConfigAsync(item);
                    }
                }
            }
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
        public List<Shot> GetListShot (string machineId)
        {
            ListShot=new List<Shot>( );
            try
            {
                var shift = (DateTime.Now.Hour>4&&DateTime.Now.Hour<9) ? 1 : 2;
                string month = (DateTime.Now.Month>9&&DateTime.Now.Month<13) ? DateTime.Now.Month.ToString( ) : "0"+DateTime.Now.Month;
                string year = (DateTime.Now.Year%2000).ToString( );
                string day = (DateTime.Now.Day>9&&DateTime.Now.Month<40) ? DateTime.Now.Day.ToString( ) : "0"+DateTime.Now.Day;
                var dataCycle = File.ReadAllLines(@$"{Url}{machineId}\C{shift}{day+month+year}");
                for ( int i = 1;i<dataCycle.Length-1;i++ )
                {
                    string[] Content = dataCycle[i].Split(',');
                    if ( Convert.ToDouble(Content[1])>10 )
                    {
                        Shot shot = new Shot(Convert.ToDateTime(Convert.ToDateTime(Content[0])),Convert.ToDouble(Content[1]),Convert.ToDouble(Content[2]));
                        ListShot.Add(shot);
                    }
                }
            }
            catch
            {
                return new List<Shot>( );
            }

            return ListShot;
        }
        #region Api
        public async void GetTotalEmplyee ( )
        {
            ListEmployee=await _apiServices.GetEmployeeTotal("");
        }
        public async void GetTotalMold ( )
        {
            ListMold=await _apiServices.GetMoldTotal("");

        }
        public async void GetTotalProduct ( )
        {
            ListProduct=await _apiServices.GetProductTotal("");
        }
        public async void GetTotalMachinne ( )
        {
            ListMachine=await _apiServices.GetMachineTotal("");

        }
        public async void GetTotalPreShiftReport ( )
        {
            ListPreShiftReport=await _apiServices.GetPreShiftReportTotal("");
            Load( );

        }
        #endregion
    }

}
