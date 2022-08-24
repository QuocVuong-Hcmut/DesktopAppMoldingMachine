using MayEpCHADesktopApp.Core.Components;
using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ReportViewModels;
using MayEpCHADesktopApp.Core.ViewModels.SettingsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MayEpCHADesktopApp.Core.ViewModels.AlertViewModel
{
    public class AlertViewModel: ViewModels.BaseViewModels.BaseViewModel
    {
        private IDatabaseServices _databaseServices;
        private IApiServices _apiServices;
        private DateTime dateTimeStart;
        public DateTime DateTimeStart { get => dateTimeStart; set { dateTimeStart=value; OnPropertyChanged( ); } }
        private DateTime dateTimeStop;
        public DateTime DateTimeStop { get => dateTimeStop; set { dateTimeStop=value; OnPropertyChanged( ); } }
        public EventMachine EventMachine { set; get; }
        private ObservableCollection<EventMachine> listEvent;
        public ObservableCollection<EventMachine> ListEvent { get => listEvent; set { listEvent=value; OnPropertyChanged( ); } }
        public ICommand StatusChangeCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        public AlertViewModel (IDatabaseServices databaseServices, IApiServices apiServices)
        {
            _databaseServices=databaseServices;
            _apiServices=apiServices;
            StatusChangeCommand =new RelayCommand(async ( ) => await StatusChanged( ));
            FilterCommand=new RelayCommand(async ( ) => await Filter( ));
            DetailMachineViewModel.UpdateEventTable+=Load;
            SettingsNewViewModel.ChangeEvent+=Load;
            ReportShiftViewModel.ChangeEvent+=Load;
            _apiServices.ChangeEvent+=Load;
            listEvent = new ObservableCollection<EventMachine>();
            DateTimeStart = DateTime.Now;
            DateTimeStop=DateTime.Now;
            Load( );
        }

        private void Load ( )
        {
            listEvent.Clear();
            foreach ( var item in _databaseServices.LoadEventMachine( ) )
            {
                if ( item.NameEvent=="Lỗi chu kì ép"
                   ||item.NameEvent=="Thay khuôn"
                   ||item.NameEvent=="Gửi toàn bộ cài đặt thất bại"
                   ||item.NameEvent=="Lỗi gửi dữ liệu"
                   ||item.NameEvent=="Lỗi khi xuất báo cáo"
                   ||item.NameEvent=="Lỗi lấy dữ liệu tên máy ép"
                   ||item.NameEvent=="Lỗi lấy dữ liệu tên nhân viên"
                   ||item.NameEvent=="Lỗi lấy dữ liệu tên khuôn"
                   ||item.NameEvent=="Lỗi lấy dữ liệu tên sản phẩm"
                   )
                {
                    listEvent.Add(item);
                }

            }
        }
        private Task StatusChanged ( )
        {
            MessageBoxResult messageBoxResult = CustomMessageBox.Show("Xác nhận đã xử lí xong cáo báo");
            if ( messageBoxResult==MessageBoxResult.OK )
            {
                Application.Current.Dispatcher.Invoke(new Action(( ) =>
                {
                    EventMachine.Status=1;
                    _databaseServices.UpdateEventAsync(EventMachine);
                }));
            }
            CollectionViewSource.GetDefaultView(ListEvent).Refresh( );
            OnPropertyChanged("ListEvent");
            return Task.CompletedTask;
        }
        private Task Filter ( )
        {
            ListEvent.Clear( );
            int Count = _databaseServices.LoadEventMachine( ).Count;
            foreach ( var item in _databaseServices.LoadEventMachine( ) )
            {
                if ( item.DateTime>DateTimeStart&&item.DateTime<=DateTimeStop )
                {
                    ListEvent.Add(item);
                }
                else
                {
                }
            }
            MessageBox.Show(ListEvent.Count( ).ToString( ));
            //for ( int i = 0;i<=Count-1;i++ )
            //{
            //    ListEvent.RemoveAt(0);
            //}
            OnPropertyChanged("ListEvent");
            return Task.CompletedTask;
        }

    }
}
