
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
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private ObservableCollection<Configuration> _configurations;
        public ConfigurationRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _configurations = new ObservableCollection<Configuration>();
        }

        public async void Clear()
        {
            _applicationDbContext.Database.ExecuteSqlRawAsync("DELETE FROM [Configurations]");
            await _applicationDbContext.SaveChangesAsync();
        }

        public async void DeleteAsync(Configuration configution)
        {
             Load();
            foreach (var item in _configurations)
            {
                if(configution.Id == item.Id)
                {
                    _applicationDbContext.Configurations.Remove(item);
                }
                
            }

            
            await _applicationDbContext.SaveChangesAsync();
        }

        public async void InsertAsync(Configuration configution)
        {

            await _applicationDbContext.Configurations.AddAsync(configution);
            await _applicationDbContext.SaveChangesAsync();
        }

        public ObservableCollection<Configuration> Load()
        {
            if(_configurations != null)
            {
                _configurations.Clear();
            }
               
            foreach (var configuration in _applicationDbContext.Configurations)
            {
                _configurations.Add(configuration);
            }
            
           return _configurations;
        }
    }
}
