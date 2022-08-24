using MayEpCHADesktopApp.Core.Database.DBContext;
using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using MayEpCHADesktopApp.Core.Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Database.Repository
{
    public class EventMachineRepository:IEventMachineRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private ObservableCollection<EventMachine> _eventMachine;
        public EventMachineRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _eventMachine = new ObservableCollection<EventMachine>();
        }
        public async void DeleteAsync(EventMachine eventMachine)
        {

            Load();
            foreach (var item in _eventMachine)
            {
                if (eventMachine.Id == item.Id)
                {
                    _applicationDbContext.EventMachines.Remove(item);
                }

            }


            await _applicationDbContext.SaveChangesAsync();
        }

        public async void InsertAsync(EventMachine eventMachine)
        {

            await _applicationDbContext.EventMachines.AddAsync(eventMachine);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async void UpdateAsync (EventMachine eventMachine)
        {

             _applicationDbContext.EventMachines.Update(eventMachine);
            await _applicationDbContext.SaveChangesAsync( );
        }
        public async void Clear()
        {
            _applicationDbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Configurations]");
            await _applicationDbContext.SaveChangesAsync();
        }
        public ObservableCollection<EventMachine> Load()
        {
            if (_eventMachine != null)
            {
                _eventMachine.Clear();
            }

            foreach (var item in _applicationDbContext.EventMachines)
            {
                _eventMachine.Add(item);
            }

            return _eventMachine;
        }
    }
}
