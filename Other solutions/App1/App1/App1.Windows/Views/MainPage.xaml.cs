using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using App1.ViewModels;

namespace App1.Views
{
    public sealed partial class MainPage
    {
        private EmployeesViewModel _employeesViewModel;
        private ObservableCollection<EmployeeViewModel> _employees;

        public MainPage()
        {
            Initializer.Initialize().Wait();
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _employeesViewModel = new EmployeesViewModel();
            _employees = _employeesViewModel.GetEmployees();
            EmployeesViewSource.Source = _employees;
            EmployeesGridView.SelectedItem = null;

            base.OnNavigatedTo(e);
        }

        private void EmployeesGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(EmployeePage), e.ClickedItem);
        }

        private void EmployeesGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesGridView.SelectedItems.Any())
            {
                MainPageAppBar.IsOpen = true;
                MainPageAppBar.IsSticky = true;
                AddButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Visible;
            }
            else
            {
                MainPageAppBar.IsOpen = false;
                MainPageAppBar.IsSticky = false;
                AddButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeePage));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeePage), EmployeesGridView.SelectedItem);
        }
    }
}
