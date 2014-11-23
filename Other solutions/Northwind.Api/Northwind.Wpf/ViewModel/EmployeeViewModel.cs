using System;
using Northwind.Wpf.Models;

namespace Northwind.Wpf.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly Employee _employee;

        public EmployeeViewModel(Employee employee)
        {
            if (employee == null)
            {
                throw new NullReferenceException("employee");
            }
            
            _employee = employee;
        }

        public string Title
        {
            get
            {
                return _employee.Title;
            }
            set
            {
                if (_employee.Title != value)
                {
                    _employee.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string TitleOfCourtesy
        {
            get
            {
                return _employee.TitleOfCourtesy;
            }
            set
            {
                if (_employee.TitleOfCourtesy != value)
                {
                    _employee.TitleOfCourtesy = value;
                    OnPropertyChanged("TitleOfCourtesy");
                }
            }
        }

        public string GivenName
        {
            get
            {
                return _employee.GivenName;
            }
            set
            {
                if (_employee.GivenName != value)
                {
                    _employee.GivenName = value;
                    OnPropertyChanged("GivenName");
                }
            }
        }

        public string Surname
        {
            get
            {
                return _employee.Surname;
            }
            set
            {
                if (_employee.Surname != value)
                {
                    _employee.Surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }

        public Employee Employee
        {
            get
            {
                return _employee;
            }
        }
    }
}
