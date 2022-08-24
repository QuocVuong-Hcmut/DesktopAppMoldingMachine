using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Model
{
    public class Employee: ViewModels.BaseViewModels.BaseViewModel
    {
        private Employee()
        {

        }

        public Employee(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        private string id;
        private string firstName { get; set; }
        private string lastName { get; set; }
        //  public string Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Id { get => id; set { id = value; OnPropertyChanged(); } }
        public string FirstName { get => firstName; set { firstName = value; OnPropertyChanged(); } }
        public string LastName { get => lastName; set { lastName = value; OnPropertyChanged(); } }
    }
}
