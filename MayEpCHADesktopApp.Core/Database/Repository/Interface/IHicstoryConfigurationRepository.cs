using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Database.Repository.Interface
{
    public interface IHicstoryConfigurationRepository
    {
        void InsertAsync(HistoryCofiguration historyCofiguration);
        void DeleteAsync(HistoryCofiguration historyCofiguration);
        public ObservableCollection<HistoryCofiguration> Load();
        void Clear();
    }
}
