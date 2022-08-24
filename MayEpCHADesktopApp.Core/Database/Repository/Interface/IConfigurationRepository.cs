using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Database.Repository.Interface
{
    public interface IConfigurationRepository
    {
        void InsertAsync(Configuration configution);
        void DeleteAsync(Configuration configution);
        public ObservableCollection<Configuration> Load();
        void Clear();
    }
}
