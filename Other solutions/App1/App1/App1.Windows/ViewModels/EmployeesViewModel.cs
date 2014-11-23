using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using App1.Models;

namespace App1.ViewModels
{
    public class EmployeesViewModel : ViewModelBase
    {
        private ObservableCollection<EmployeeViewModel> _employees;
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get
            {
                return _employees;
            }

            set
            {
                _employees = value;
                RaisePropertyChanged("Employees");
            }
        }
        private readonly App _app = (Application.Current as App);
       

        public ObservableCollection<EmployeeViewModel> GetEmployees()
        {
            _employees = new ObservableCollection<EmployeeViewModel>();
            using (var db = new SQLite.SQLiteConnection(_app.DbPath))
            {
                var query = db.Table<Employee>().OrderBy(e => e.FirstName).ThenBy(e => e.LastName);
                foreach (var employee in query)
                {
                    var employeeViewModel = new EmployeeViewModel()
                    {
                        EmployeeID = employee.Id,
                        LastName = employee.LastName,
                        FirstName = employee.FirstName,
                        Title = employee.Title,
                        TitleOfCourtesy = employee.TitleOfCourtesy,
                        Address = employee.Address,
                        PostalCode = employee.PostalCode,
                        City = employee.City,
                        Country = employee.Country
                    };
                    _employees.Add(employeeViewModel);
                }
            }
            return _employees;
        }
    }
}
