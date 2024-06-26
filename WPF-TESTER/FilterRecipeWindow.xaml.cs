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
    public partial class FilterRecipeWindow : Window
    {
        private List<Recipe> AllRecipes;

        public FilterRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            AllRecipes = recipes;
            AddText(null, null); // Initialize placeholder text
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var nameQuery = SearchByName.Text.ToLower();
            var ingredientsQuery = SearchByIngredients.Text.ToLower();
            var caloriesQuery = SearchByCalories.Text.ToLower();

            var filteredRecipes = AllRecipes.Where(r =>
                (string.IsNullOrEmpty(nameQuery) || r.Name.ToLower().Contains(nameQuery)) &&
                (string.IsNullOrEmpty(ingredientsQuery) || r.Ingredients.ToLower().Contains(ingredientsQuery)) &&
                (string.IsNullOrEmpty(caloriesQuery) || r.CalorieMeasurements.ToLower().Contains(caloriesQuery))
            ).OrderBy(r => r.Name).ToList();

            RecipeList.ItemsSource = filteredRecipes.Select(r => r.Name).ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoveText(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchByName.Text))
            {
                SearchByName.Text = "";
                SearchByName.Foreground = Brushes.Gray;
            }

            if (string.IsNullOrEmpty(SearchByIngredients.Text))
            {
                SearchByIngredients.Text = "";
                SearchByIngredients.Foreground = Brushes.Gray;
            }

            if (string.IsNullOrEmpty(SearchByCalories.Text))
            {
                SearchByCalories.Text = "";
                SearchByCalories.Foreground = Brushes.Gray;
            }
        }
    }
}