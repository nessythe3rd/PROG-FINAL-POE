using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_TESTER
{
    public partial class DeleteRecipeWindow : Window
    {
        private List<Recipe> _recipes;

        public DeleteRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            _recipes = recipes;
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            RecipesListView.Items.Clear();
            foreach (var recipe in _recipes)
            {
                RecipesListView.Items.Add(recipe);
            }
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListView.SelectedItem != null)
            {
                var selectedRecipe = (Recipe)RecipesListView.SelectedItem;
                _recipes.Remove(selectedRecipe);
                LoadRecipes();
                MessageBox.Show("Recipe deleted successfully!");
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}