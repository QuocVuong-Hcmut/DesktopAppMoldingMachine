using MayEpCHADesktopApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MayEpCHADesktopApp.Core.ViewModels.BaseViewModels
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigationService;
        

        public NavigateCommand(INavigationService navigationService)
        {
           
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
            _navigationService.SelectViewModel();
            _navigationService.Sound(); 
            
        }
    }
}
