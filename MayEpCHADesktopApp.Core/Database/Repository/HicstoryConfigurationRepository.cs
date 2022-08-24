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
    public class HicstoryConfigurationRepository : IHicstoryConfigurationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private ObservableCollection<HistoryCofiguration> _historyCofiguration;
        public HicstoryConfigurationRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _historyCofiguration = new ObservableCollection<HistoryCofiguration>();
        }
        public async void Clear()
        {
            _applicationDbContext.Database.ExecuteSqlRawAsync("DELETE FROM [HistoryCofigurations]");
            await _applicationDbContext.SaveChangesAsync();
        }

        public async void  DeleteAsync(HistoryCofiguration historyCofiguration)
        {
            Load();
            foreach (var item in _historyCofiguration)
            {
                if (historyCofiguration.Id == item.Id)
                {
                    _applicationDbContext.HistoryCofigurations.Remove(item);
                }

            }


            await _applicationDbContext.SaveChangesAsync();
        }

        public async void InsertAsync(HistoryCofiguration historyCofiguration)
        {
            string a = "4";
            a = "2";
            await _applicationDbContext.HistoryCofigurations.AddAsync(historyCofiguration);
            await _applicationDbContext.SaveChangesAsync();
        }


        public ObservableCollection<HistoryCofiguration> Load()
        {
            if (_historyCofiguration != null)
            {
                _historyCofiguration.Clear();
            }

            foreach (var item in _applicationDbContext.HistoryCofigurations)
            {
                _historyCofiguration.Add(item);
            }

            return _historyCofiguration;
        }
    }
}
