using Northwind.Wpf.Models;
using Northwind.Wpf.ViewModel;

namespace Northwind.Wpf
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //var context = new NorthwindContext();
            //var repository = new EmployeeRepository(context);
            var repository = new WebEmployeeRepository();
            var masterViewModel = new MasterViewModel(repository);
            MasterView.DataContext = masterViewModel;
            DetailView.DataContext = masterViewModel;
        }
    }
}
