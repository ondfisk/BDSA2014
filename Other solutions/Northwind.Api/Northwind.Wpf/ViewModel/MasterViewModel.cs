using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using System.Threading.Tasks;
using Northwind.Wpf.Models;

namespace Northwind.Wpf.ViewModel
{
    public class MasterViewModel : ViewModelBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly ObservableCollection<EmployeeViewModel> _employees;
        private readonly ICollectionView _collectionView;
        private ICommand _addCommand;
        private ICommand _saveCommand;
        private ICommand _removeCommand;
        private ICommand _previousCommand;
        private ICommand _nextCommand;

        public MasterViewModel(IEmployeeRepository repository)
        {
            _repository = repository;
            _employees = new ObservableCollection<EmployeeViewModel>();

            // foreach Employee in the database, create a EmployeeViewModel that wrap it
            foreach (var employee in _repository.Read())
            {
                _employees.Add(new EmployeeViewModel(employee));
            }

            // retrieve the ICollectionView associated to the ObservableCollection of EmployeeViewMode
            _collectionView = CollectionViewSource.GetDefaultView(_employees);
            if (_collectionView == null)
            {
                throw new NullReferenceException("collectionView");
            }

            // listen to the CurrentChanged event to be notified when the selection changes
            _collectionView.CurrentChanged += OnCollectionViewCurrentChanged;
        }

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get { return _employees; }
        }

        public EmployeeViewModel SelectedEmployee
        {
            get { return _collectionView.CurrentItem as EmployeeViewModel; }
        }

        public string SearchText
        {
            set
            {
                _collectionView.Filter = item =>
                 {
                     if (item as EmployeeViewModel == null)
                     {
                         return false;
                     }
                     var employeeViewModel = (EmployeeViewModel) item;
                     return employeeViewModel.GivenName.Contains(value) || 
                            employeeViewModel.Surname.Contains(value);
                 };

                OnPropertyChanged("SearchContainsNoMatch");
            }
        }

        public bool SearchContainsNoMatch
        {
            get
            {
                return _collectionView.IsEmpty;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new Command(() => AddEmployee(), _ => CanAddEmployee());
                }
                return _addCommand;
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new AsyncCommand(async _ => await RemoveEmployee(),_ => CanRemoveEmployee());
                }
                return _removeCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new AsyncCommand(async _ => await SaveEmployee(), _ => CanSaveEmployee());
                }
                return _saveCommand;
            }
        }

        public ICommand PreviousCommand
        {
            get
            {
                if (_previousCommand == null)
                {
                    _previousCommand = new Command(() => GoPrevious(), _ => CanGoPrevious());
                }
                return _previousCommand;
            }
        }

        public ICommand NextCommand
        {
            get
            {
                if (_nextCommand == null)
                {
                    _nextCommand = new Command(() => GoNext(), _ => CanGoNext());
                }
                return _nextCommand;
            }
        }

        private bool CanAddEmployee()
        {
            return _employees.Count < 20;
        }

        private void AddEmployee()
        {
            var employee = new Employee();
            var employeeViewModel = new EmployeeViewModel(employee);
            _employees.Add(employeeViewModel);
            _collectionView.MoveCurrentTo(employeeViewModel);
        }

        private bool CanSaveEmployee()
        {
            return SelectedEmployee != null;
        }

        private async Task SaveEmployee()
        {
            var employee = SelectedEmployee.Employee;

            if (employee.Id != 0)
            {
                await _repository.Update(employee);
            }
            else
            {
                var created = await _repository.Create(employee);
                SelectedEmployee.Employee.Id = created.Id;
            }
        }

        private bool CanRemoveEmployee()
        {
            return SelectedEmployee != null;
        }

        private async Task RemoveEmployee()
        {
            var selectedEmployee = SelectedEmployee;
            await _repository.Delete(selectedEmployee.Employee.Id);
            _employees.Remove(selectedEmployee);
        }

        private bool CanGoPrevious()
        {
            return _collectionView.CurrentPosition >= 1;
        }

        private void GoPrevious()
        {
            _collectionView.MoveCurrentToPrevious();
        }

        private bool CanGoNext()
        {
            return _collectionView.CurrentPosition < _employees.Count - 1;
        }

        private void GoNext()
        {
            _collectionView.MoveCurrentToNext();
        }

        private void OnCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("SelectedEmployee");
        }
    }
}
