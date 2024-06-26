using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_TESTER
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Initialize the Recipes collection if it is null
            if (AddRecipeWindow.Recipes == null)
            {
                AddRecipeWindow.Recipes = new List<Recipe>();
            }
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow();
            addRecipeWindow.Show();
        }

        private void ViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            var viewRecipeWindow = new ViewRecipeWindow(AddRecipeWindow.Recipes);
            viewRecipeWindow.Show();
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            var scaleRecipeWindow = new ScaleRecipeWindow(AddRecipeWindow.Recipes);
            scaleRecipeWindow.Show();
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            var deleteRecipeWindow = new DeleteRecipeWindow(AddRecipeWindow.Recipes);
            deleteRecipeWindow.Show();
        }

        private void FilterRecipe_Click(object sender, RoutedEventArgs e)
        {
            var filterRecipeWindow = new FilterRecipeWindow(AddRecipeWindow.Recipes);
            filterRecipeWindow.Show();
        }
        //Exit app completely
        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}