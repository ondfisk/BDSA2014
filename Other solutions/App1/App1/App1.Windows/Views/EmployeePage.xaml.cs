using App1.ViewModels;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace App1.Views
{
    public sealed partial class EmployeePage
    {
        private EmployeeViewModel _employee;
        private readonly App _app = (Application.Current as App);

        public EmployeePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                _employee = new EmployeeViewModel();
                _employee.EmployeeID = _employee.GetNewEmployeeId();
                PageTitle.Text = "New employee";
            }
            else
            {
                _employee = (EmployeeViewModel)e.Parameter;
                PageTitle.Text = string.Join(" ", _employee.FirstName, _employee.LastName);
            }
            DataContext = _employee;
            _app.CurrentEmployeeId = _employee.EmployeeID;

            base.OnNavigatedTo(e);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var result = _employee.SaveEmployee(_employee);
            if (result)
            {
                Frame.Navigate(typeof(MainPage));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = _employee.DeleteEmployee(_employee.EmployeeID);
            if (result)
            {
                Frame.Navigate(typeof(MainPage));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
