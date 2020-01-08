using RecipeApp.UI.Interfaces.ViewModels.Dashboard;
using RecipeApp.UI.WPF.ViewModels;
using System.Windows.Controls;

namespace RecipeApp.UI.WPF.Views.Dashboard
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Page
    {
        private DashboardView() { }

        public DashboardView(IDashboardViewModel dashboardViewModel) : this()
        {
            InitializeComponent();
            DataContext = dashboardViewModel;
        }
    }
}
