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
            var searchText = SearchByName.Text.ToLower();

            var filteredRecipes = AllRecipes
                .Where(r => r.Name.ToLower().Contains(searchText))
                .OrderBy(r => r.Name)
                .ToList();

            RecipeList.ItemsSource = filteredRecipes.Select(r => $"{r.Name} - {r.NumberOfIngredients} ingredients, {r.CalorieMeasurements} calories").ToList();
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void AddText(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchByName.Text))
            {
                SearchByName.Text = "Search by name";
                SearchByName.Foreground = Brushes.Gray;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}