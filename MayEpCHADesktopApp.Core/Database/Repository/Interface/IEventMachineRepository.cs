using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Database.Repository.Interface
{
    public interface IEventMachineRepository
    {
        void InsertAsync(EventMachine eventMachine);
        void DeleteAsync(EventMachine eventMachine);
        void UpdateAsync (EventMachine eventMachine);
        public ObservableCollection<EventMachine> Load();
        void Clear();
    }
}
