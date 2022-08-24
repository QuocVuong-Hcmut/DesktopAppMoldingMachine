using MayEpCHADesktopApp.Core.Components;
using MayEpCHADesktopApp.Core.Model;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MayEpCHADesktopApp.Core.ViewModels.ReportViewModels
{
  
    public class ReportObservateViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private IApiServices _apiServices;
        private ObservableCollection<ShiftReport> listShiftReport;
        public ObservableCollection<ShiftReport> ListShiftReport { get => listShiftReport; set { listShiftReport = value; } }
        public ObservableCollection<Employee> ListEmployee { get => listEmployee; set { listEmployee = value; OnPropertyChanged(); } }
        private ObservableCollection<Employee> listEmployee;
        private DateTime dateTimeStart;
        public DateTime DateTimeStart { get => dateTimeStart; set { dateTimeStart = value; OnPropertyChanged(); } }
        private DateTime dateTimeStop;
        public DateTime DateTimeStop { get => dateTimeStop; set { dateTimeStop = value; OnPropertyChanged(); } }
        private Employee employee;
        public Employee Employee { get => employee; set { employee = value; OnPropertyChanged(); } }
        public ICommand LoadChartCommand { get; set; }
        public ReportObservateViewModel(IApiServices apiService)
        {
            _apiServices = apiService;
            GetTotalShiftReport();
            LoadChartCommand = new RelayObjectCommand<StackPanel>((p) => { return p == null ? false : true; }, async (p) => LoadChart(p));
            DateTimeStart = DateTime.UtcNow;
            DateTimeStop = DateTime.UtcNow;
            GetTotalEmplyee();
        }
        public async void LoadChart(StackPanel p)
        {
            int j = 0;
            ListShiftReport = await _apiServices.GetShiftReportTotal("");
            foreach (var Shift in ListShiftReport)
            {
                if(( Shift.Date.Day ) < ( DateTime.Now.Day +1 ))
                {
                    ChartObservationEmployee chart = new ChartObservationEmployee();
                    chart.Title = "Ngày " + (DateTime.Now.Day - j) + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                        ;
                    if(Shift.Shots.Count > 10)
                    {
                        foreach (var shot in Shift.Shots)
                        {
                            //if (shot.InjectionTime > 80 && shot.InjectionTime < 200)
                            //{
                            //    chart.CycleStandard.Add(Shift.Product.Mold.StandardInjectionCycle);
                            //    //chart.CycleStandard.Add(120);
                            //    chart.Cycle.Add(shot.InjectionTime);
                            //    chart.Labels.Add(shot.TimeStamp.ToString());
                            //}

                        }
                    }

                    j++;
                    p.Children.Add(chart);
                }
            }
 



        }
        public async void GetTotalShiftReport()
        {
            //ListShiftReport = new ObservableCollection<ShiftReport>();
            //ListShiftReport = await _apiServices.GetShiftReportTotal("");
        }
        public async void GetTotalEmplyee()
        {
            ListEmployee = await _apiServices.GetEmployeeTotal("");
        }
    }
}
