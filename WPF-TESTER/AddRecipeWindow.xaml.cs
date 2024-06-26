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
    public partial class AddRecipeWindow : Window
    {
        public static List<Recipe> Recipes = new List<Recipe>();

        public AddRecipeWindow()
        {
            InitializeComponent();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            var recipeName = RecipeName.Text;
            var howManyIngredients = HowManyIngredients.Text;
            var enterIngredients = EnterIngredients.Text;
            var instructions = Instructions.Text;
            var calorieMeasurements = CalorieMeasurements.Text;
            var recipeMeasurements = RecipeMeasurements.Text;

            if (!string.IsNullOrEmpty(recipeName) && !string.IsNullOrEmpty(howManyIngredients) &&
                !string.IsNullOrEmpty(enterIngredients) && !string.IsNullOrEmpty(instructions) &&
                !string.IsNullOrEmpty(calorieMeasurements) && !string.IsNullOrEmpty(recipeMeasurements))
            {
                var recipe = new Recipe
                {
                    Name = recipeName,
                    NumberOfIngredients = howManyIngredients,
                    Ingredients = enterIngredients,
                    Instructions = instructions,
                    CalorieMeasurements = calorieMeasurements,
                    RecipeMeasurements = recipeMeasurements
                };
                Recipes.Add(recipe);
                Recipes = Recipes.OrderBy(r => r.Name).ToList(); // Sort alphabetically
                MessageBox.Show("Recipe added successfully!");

                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Please fill all fields including Calorie Measurements and Recipe Measurements.");
            }
        }

        private void ClearTextBoxes()
        {
            RecipeName.Text = "";
            HowManyIngredients.Text = "";
            EnterIngredients.Text = "";
            Instructions.Text = "";
            CalorieMeasurements.Text = "";
            RecipeMeasurements.SelectedIndex = 0; // Set the dropdown back to grams
        }

        private void ViewRecipes_Click(object sender, RoutedEventArgs e)
        {
            var filterRecipeWindow = new FilterRecipeWindow(Recipes);
            filterRecipeWindow.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RecipeMeasurements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public string NumberOfIngredients { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string CalorieMeasurements { get; set; }
        public string RecipeMeasurements { get; set; }
    }
}