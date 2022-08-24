using MayEpCHADesktopApp.Core.Components;
using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using MayEpCHADesktopApp.Core.ViewModels.BaseViewModels;
using MayEpCHADesktopApp.Core.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MayEpCHADesktopApp.Core.ViewModels.HelpViewModel
{
    public class HelpViewModel: ViewModels.BaseViewModels.BaseViewModel
    {
        public ICommand StopCommand { get; set; }
        public ICommand StartCommand { get; set; }
        public ICommand PauseCommand { get; set; }
        public ICommand PDFCommand { get; set; }
        public ICommand VideoCommand { get; set; }
        public ICommand DurationChangeCommand { get; set; }
        private int duration;
        public int Duration { get => duration; set { duration=value; OnPropertyChanged( ); } }
        private TimeSpan position;
        public TimeSpan Position { get => position; set { position=value; OnPropertyChanged( ); } }
        private string stateVideo;
        public string StateVideo { get => stateVideo; set { stateVideo=value; OnPropertyChanged( ); } }
        private bool isVideo;
        public bool IsVideo { get => isVideo; set { isVideo=value; OnPropertyChanged( ); } }
        private bool isPDF;
        public bool IsPDF { get => isPDF; set { isPDF=value; OnPropertyChanged( ); } }
        public HelpViewModel ( )
        {
            StopCommand=new RelayCommand(async ( ) => await Stop( ));
            StartCommand=new RelayCommand(async ( ) => await Start( ));
            PDFCommand=new RelayCommand(async ( ) => await PDF( ));
            VideoCommand=new RelayCommand(async ( ) => await Video( ));
            PauseCommand=new RelayCommand(async ( ) => await Pause( ));
            
            DurationChangeCommand=new RelayObjectCommand<System.Windows.Controls.MediaElement>((p) => { return true; },async (p) => DurationChange(p));
            StateVideo="Stop";
            IsPDF=true;
            IsVideo=false;
            
        }
        private Task Stop ( )
        {
            
            StateVideo="Stop";
            Duration=0;
            return Task.CompletedTask;
        }
        private Task DurationChange (System.Windows.Controls.MediaElement p )
        {
            (p as System.Windows.Controls.MediaElement).Position=TimeSpan.FromSeconds(Duration);
        
            return Task.CompletedTask;
        }
        private Task Start ( )
        {
            StateVideo="Play";
            Duration=0;
            return Task.CompletedTask;
        }
        private Task Pause ( )
        {
            StateVideo="Pause";
            
            return Task.CompletedTask;
        }
        private Task PDF ( )
        {
            IsPDF=true;
            IsVideo=false;
            return Task.CompletedTask;
        }
        private Task Video ( )
        {
            IsPDF=false;
            IsVideo=true;
            return Task.CompletedTask;
        }

    }
}
