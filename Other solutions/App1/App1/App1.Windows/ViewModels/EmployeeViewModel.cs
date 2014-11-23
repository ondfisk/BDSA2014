using System;
using System.Linq;
using Windows.UI.Xaml;
using App1.Models;

namespace App1.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        #region Properties

        private int _employeeId;
        public int EmployeeID
        {
            get
            {
                return _employeeId;
            }
            set
            {
                if (_employeeId == value)
                {
                    return;
                }
                _employeeId = value;
                RaisePropertyChanged("Id");
            }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName == value)
                {
                    return;
                }
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        private string _firstName = string.Empty;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName == value)
                {
                    return;
                }
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string _title = string.Empty;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title == value)
                {
                    return;
                }
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string _titleOfCourtesy = string.Empty;
        public string TitleOfCourtesy
        {
            get
            {
                return _titleOfCourtesy;
            }
            set
            {
                if (_titleOfCourtesy == value)
                {
                    return;
                }
                _titleOfCourtesy = value;
                RaisePropertyChanged("TitleOfCourtesy");
            }
        }

        private string _address = string.Empty;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address == value)
                {
                    return;
                }
                _address = value;
                RaisePropertyChanged("Address");
            }
        }

        private string _postalCode = string.Empty;
        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            set
            {
                if (_postalCode == value)
                {
                    return;
                }
                _postalCode = value;
                RaisePropertyChanged("PostalCode");
            }
        }

        private string _city = string.Empty;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (_city == value)
                {
                    return;
                }
                _city = value;
                RaisePropertyChanged("City");
            }
        }

        private string _country = string.Empty;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                if (_country == value)
                {
                    return;
                }
                _country = value;
                RaisePropertyChanged("Country");
            }
        }

        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                if (_birthDate == value)
                {
                    return;
                }
                _birthDate = value;
                RaisePropertyChanged("BirthDate");
            }
        }

        private DateTime? _hireDate;
        public DateTime? HireDate
        {
            get
            {
                return _hireDate;
            }
            set
            {
                if (_hireDate == value)
                {
                    return;
                }
                _hireDate = value;
                RaisePropertyChanged("HireDate");
            }
        }

        public string FullName
        {
            get { return string.Join(" ", TitleOfCourtesy, FirstName, LastName); }
        }

        #endregion "Properties"

        private readonly App _app = (Application.Current as App);

        public EmployeeViewModel GetEmployee(int employeeId)
        {
            using (var db = new SQLite.SQLiteConnection(_app.DbPath))
            {
                var employee = db.Table<Employee>().First(e => e.Id == employeeId);

                return new EmployeeViewModel
                {
                    EmployeeID = employee.Id,
                    LastName = employee.LastName,
                    FirstName = employee.FirstName,
                    Title = employee.Title,
                    TitleOfCourtesy = employee.TitleOfCourtesy,
                    Address = employee.Address,
                    PostalCode = employee.PostalCode,
                    City = employee.City,
                    Country = employee.Country,
                    BirthDate = employee.BirthDate,
                    HireDate = employee.HireDate
                };
            }
        }

        public string GetEmployeeName(int employeeId)
        {
            using (var db = new SQLite.SQLiteConnection(_app.DbPath))
            {
                var employee = db.Table<Employee>().FirstOrDefault(e => e.Id == employeeId);

                return employee == null ? "Unknown" : string.Join(" ", employee.FirstName, employee.LastName);
            }
        }

        public bool SaveEmployee(EmployeeViewModel employee)
        {
            var result = false;

            using (var db = new SQLite.SQLiteConnection(_app.DbPath))
            {
                try
                {
                    var existingEmployee = db.Table<Employee>().FirstOrDefault(e => e.Id == employee.EmployeeID);

                    if (existingEmployee != null)
                    {
                        existingEmployee.LastName = employee.LastName;
                        existingEmployee.FirstName = employee.FirstName;
                        existingEmployee.Title = employee.Title;
                        existingEmployee.TitleOfCourtesy = employee.TitleOfCourtesy;
                        existingEmployee.Address = employee.Address;
                        existingEmployee.PostalCode = employee.PostalCode;
                        existingEmployee.City = employee.City;
                        existingEmployee.Country = employee.Country;
                        existingEmployee.BirthDate = employee.BirthDate;
                        existingEmployee.HireDate = employee.HireDate;

                        db.Update(existingEmployee);

                        result = true;
                    }
                    else
                    {
                        db.Insert(new Employee
                        {
                            Id = employee.EmployeeID,
                            LastName = employee.LastName,
                            FirstName = employee.FirstName,
                            Title = employee.Title,
                            TitleOfCourtesy = employee.TitleOfCourtesy,
                            Address = employee.Address,
                            PostalCode = employee.PostalCode,
                            City = employee.City,
                            Country = employee.Country,
                            BirthDate = employee.BirthDate,
                            HireDate = employee.HireDate
                        });

                        result = true;
                    }
                }
                catch
                {
                }
            }

            return result;
        }

        public bool DeleteEmployee(int employeeId)
        {
            var result = false;

            using (var db = new SQLite.SQLiteConnection(_app.DbPath))
            {
                var existingEmployee = db.Table<Employee>().FirstOrDefault(e => e.Id == employeeId);

                if (db.Delete(existingEmployee) > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public int GetNewEmployeeId()
        {
            int employeeId;
            using (var db = new SQLite.SQLiteConnection(_app.DbPath))
            {
                var employees = db.Table<Employee>();
                if (employees.Any())
                {
                    employeeId = db.Table<Employee>().Max(e => e.Id) + 1;
                }
                else
                {
                    employeeId = 1;
                }
            }
            return employeeId;
        }
    }
}
