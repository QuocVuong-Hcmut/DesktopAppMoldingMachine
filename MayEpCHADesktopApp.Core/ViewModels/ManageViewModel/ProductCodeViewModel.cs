using MayEpCHADesktopApp.Core.Model;
using MayEpCHADesktopApp.Core.Services;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.ViewModels.ManageViewModel
{
  
    public class ProductCodeViewModel : ViewModels.BaseViewModels.BaseViewModel
    {
        private IApiServices _apiServices;
      
        private ObservableCollection<Product> listProduct;
        public ObservableCollection<Product> ListProduct { get => listProduct; set { listProduct = value; } }
        public ProductCodeViewModel(IApiServices apiServices)
        {
            _apiServices = apiServices;
            GetTotalProduct();
        }
        public async void GetTotalProduct()
        {
           ListProduct = new ObservableCollection<Product>();
           ListProduct = await _apiServices.GetProductTotal("");
        }
    }
}
