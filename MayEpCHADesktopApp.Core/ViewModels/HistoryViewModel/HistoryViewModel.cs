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

namespace MayEpCHADesktopApp.Core.ViewModels.HistoryViewModel
{
    public class HistoryViewModel: ViewModels.BaseViewModels.BaseViewModel
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
        public ICommand FilterCommand { get; set; }
        public HistoryViewModel (IDatabaseServices databaseServices,IApiServices apiServices)
        {
            _databaseServices=databaseServices;
            _apiServices=apiServices;
            FilterCommand=new RelayCommand(async ( ) => await Filter( ));
            DetailMachineViewModel.UpdateEventTable+=Load;
            SettingsNewViewModel.ChangeEvent+=Load;
            ReportShiftViewModel.ChangeEvent+=Load;
            _apiServices.ChangeEvent+=Load;
            DateTimeStart=DateTime.Now;
            DateTimeStop=DateTime.Now;
            ListEvent=new ObservableCollection<EventMachine>( );
            Load( );
        }

        private void Load ( )
        {
            listEvent.Clear( );
            foreach ( var item in _databaseServices.LoadEventMachine( ) )
            {
                listEvent.Add(item);
            }
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
            }
            OnPropertyChanged("ListEvent");

            return Task.CompletedTask;
        }

    }


}
