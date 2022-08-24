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
    public class MoldCodeViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private  IApiServices _apiServices;
        private ObservableCollection<Mold> listMold;
        public ObservableCollection<Mold> ListMold { get => listMold; set { listMold = value; } }

        public MoldCodeViewModel(IApiServices apiServices)
        {
            _apiServices = apiServices;
            
            GetTotalMold();
        }
        public async void GetTotalMold()
        {
            ListMold = await _apiServices.GetMoldTotal("");
           
        }
    }
}
