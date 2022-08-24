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
    public class SettingsPreviousViewModel: ViewModels.BaseViewModels.BaseViewModel
    {
        private IDatabaseServices _databaseServices;
        private IApiServices _apiServices;
        DispatcherTimer TLoad = new DispatcherTimer( );
        private ObservableCollection<ShiftReport> listConfigurationShift;
        public ObservableCollection<ShiftReport> ListConfigurationShift { get => listConfigurationShift; set { listConfigurationShift=value; OnPropertyChanged( ); } }
        private ObservableCollection<ShiftReport> listPreShiftReport;
        public ObservableCollection<ShiftReport> ListPreShiftReport { get => listPreShiftReport; set { listPreShiftReport=value; } }
        public SettingsPreviousViewModel (IApiServices apiServices,IDatabaseServices databaseServices)
        {
            _databaseServices=databaseServices;
            _apiServices=apiServices;
            ListConfigurationShift=new ObservableCollection<ShiftReport>( );
            TLoad.Interval=TimeSpan.FromMinutes(15);
            TLoad.Tick+=TLoad_Tick;
            SettingsNewViewModel.ActionChangeDatabase+=GetTotalPreShiftReport;
            _apiServices.ChangeConfigEvent+=GetTotalPreShiftReport;
            GetTotalPreShiftReport( );
        }
        private void TLoad_Tick (object? sender,EventArgs e)
        {
            GetTotalPreShiftReport( );
        }
        public void Load ( )
        {
            if ( DateTime.Now.Hour>6&&DateTime.Now.Hour<19 )
            {
                var ListEventMachines = from item in _databaseServices.LoadEventMachine( )
                                        where item.NameEvent=="Hoàn thành thay khuôn"
                                        &&item.DateTime.Day==DateTime.Now.Day
                                        &&item.DateTime.Hour>6
                                        &&item.DateTime.Hour<19
                                        select item;
                try
                {
                    ListConfigurationShift.Clear( );
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
                        if ( (item.Date.Day==DateTime.Now.Day&&item.Date.Hour==6&&item.Date.Minute==30||check)

                            )
                        {
                            try
                            {
                                ListConfigurationShift.Add(item);
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
            else if ( DateTime.Now.Hour>0&&DateTime.Now.Hour<7 )
            {
                var ListEventMachines = from item in _databaseServices.LoadEventMachine( )
                                        where item.NameEvent=="Hoàn thành thay khuôn"
                                        &&(((item.DateTime.Day==DateTime.Now.Day&&item.DateTime.Hour>0&&item.DateTime.Hour<7)
                                        ||(item.DateTime.Day==(DateTime.Now.Day-1)&&item.DateTime.Hour>19&&item.DateTime.Hour<24)))
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
                            try
                            {
                                ListConfigurationShift.Add(item);
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
            else
            {
                var ListEventMachines = from item in _databaseServices.LoadEventMachine( )
                                        where item.NameEvent=="Hoàn thành thay khuôn"
                                        &&(item.DateTime.Day==(DateTime.Now.Day)&&item.DateTime.Hour>19&&item.DateTime.Hour<24)
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
                        if ( (item.Date.Day==DateTime.Now.Day&&item.Date.Hour==18&&item.Date.Minute==30||check)

)
                        {
                            try
                            {
                                ListConfigurationShift.Add(item);
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
        #region Load Database

        #endregion
        public async void GetTotalPreShiftReport ( )
        {
            ListPreShiftReport = await _apiServices.GetPreShiftReportTotal("");
            Load( );

        }
    }
}
