using MayEpCHADesktopApp.Core.Database.DBContext;
using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using MayEpCHADesktopApp.Core.Database.Repository.Interface;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Services
{
    public class DatabaseService:IDatabaseServices
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IEventMachineRepository _eventMachineRepository;
        private readonly IHicstoryConfigurationRepository _historyConfigurationRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        public DatabaseService(IConfigurationRepository configurationRepository,
                               IEventMachineRepository eventMachineRepository,
                               IHicstoryConfigurationRepository hicstoryConfigurationRepository
                              )
        {
            _configurationRepository = configurationRepository;
            _eventMachineRepository = eventMachineRepository;
            _historyConfigurationRepository = hicstoryConfigurationRepository;
        }

        public void ClearConfig()
        {
          //  _configurationRepository.Clear();
        }

        public void ClearEvent()
        {
            //_eventMachineRepository.Clear();
        }
        public void ClearHicstory()
        {
                _historyConfigurationRepository.Clear();
        }

        public void DeleteConfigAsync(Configuration configution)
        {
            _configurationRepository.DeleteAsync(configution);
        }

        public void DeleteEventAsync(EventMachine eventMachine)
        {
            _eventMachineRepository.DeleteAsync(eventMachine);
        }
        public void DeleteHicstoryAsync(HistoryCofiguration historyCofiguration)
        {
            _historyConfigurationRepository.DeleteAsync(historyCofiguration);
        }

        public void InsertConfigAsync(Configuration configution)
        {
            _configurationRepository.InsertAsync(configution);
        }

        public void InsertEventAsync(EventMachine eventMachine)
        {
            _eventMachineRepository.InsertAsync(eventMachine);
        }
        public void UpdateEventAsync (EventMachine eventMachine)
        {
            _eventMachineRepository.UpdateAsync(eventMachine);
        }
        public async void InsertHicstoryAsync(HistoryCofiguration historyCofiguration)
        {

            _historyConfigurationRepository.InsertAsync(historyCofiguration);
        }
        public ObservableCollection<Configuration> LoadConfiguration()
        {
            return _configurationRepository.Load();
        }
        public ObservableCollection<EventMachine> LoadEventMachine()
        {
            return _eventMachineRepository.Load();
        }
        public ObservableCollection<HistoryCofiguration> LoadHicstoryMachine()
        {
            return _historyConfigurationRepository.Load();
        }
    }
}
