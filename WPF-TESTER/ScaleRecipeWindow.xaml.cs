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

      