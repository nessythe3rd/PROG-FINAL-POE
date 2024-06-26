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
    public partial class ScaleRecipeWindow : Window
    {
        private List<Recipe> recipes;
        private Recipe selectedRecipe;

        public ScaleRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            RecipeList.ItemsSource = recipes.Select(r => r.Name).ToList();
        }

        private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeList.SelectedItem != null)
            {
                string selectedRecipeName = RecipeList.SelectedItem.ToString();
                selectedRecipe = recipes.FirstOrDefault(r => r.Name == selectedRecipeName);

                if (selectedRecipe != null)
                {
                    RecipeDetails.Text = $"Name: {selectedRecipe.Name}\n" +
                                         $"Ingredients: {selectedRecipe.Ingredients}\n" +
                                         $"Instructions: {selectedRecipe.Instructions}\n" +
                                         $"Calorie Measurements: {selectedRecipe.CalorieMeasurements}\n" +
                                         $"Recipe Measurements: {selectedRecipe.RecipeMeasurements}";
                }
            }
        }
        //Scales recipe ingredients and measurements
        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe first.");
                return;
            }

            Button button = sender as Button;
            double scaleFactor = double.Parse(button.Content.ToString());

            string scaledRecipe = $"Name: {selectedRecipe.Name}\n" +
                                  $"Ingredients: {ScaleMeasurements(selectedRecipe.Ingredients, scaleFactor)}\n" +
                                  $"Instructions: {selectedRecipe.Instructions}\n" +
                                  $"Calorie Measurements: {ScaleMeasurements(selectedRecipe.CalorieMeasurements, scaleFactor)}\n" +
                                  $"Recipe Measurements: {ScaleMeasurements(selectedRecipe.RecipeMeasurements, scaleFactor)}";

            ScaledRecipeDetails.Text = scaledRecipe;
        }

        private string ScaleMeasurements(string measurements, double scaleFactor)
        {
            //Measurements are numebric
            string[] parts = measurements.Split(' ');
            if (parts.Length > 0 && double.TryParse(parts[0], out double value))
            {
                return (value * scaleFactor) + " " + string.Join(" ", parts.Skip(1));
            }
            return measurements;
        }
        //Back Button
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}