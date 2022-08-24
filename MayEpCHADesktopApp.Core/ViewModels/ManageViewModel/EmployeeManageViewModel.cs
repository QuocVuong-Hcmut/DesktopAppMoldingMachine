using MayEpCHADesktopApp.Core.Model;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.ViewModels.ManageViewModel
{
    public class EmployeeManageViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private IApiServices _apiServices;
        private ObservableCollection<Employee> listEmployee;
        public ObservableCollection<Employee> ListEmployee { get => listEmployee; set { listEmployee = value; } }
        
        public EmployeeManageViewModel( IApiServices apiServices)
        {
            _apiServices = apiServices;
            GetTotalEmplyee();
        }
        public async void GetTotalEmplyee()
        {
          ListEmployee = new ObservableCollection<Employee>();
          ListEmployee = await _apiServices.GetEmployeeTotal("");
        }
    }
}
