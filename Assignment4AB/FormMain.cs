using System;
using System.Linq;
using System.Windows.Forms;

namespace Assignment_AB
{
    public partial class FormMain : Form
    {
        private const int MaxRecipes = 200;
        private const int MaxIngredients = 50;
        private RecipeManager recipeManager;
        private Recipe currentRecipe;
        private FoodCategory category;

        public FormMain()
        {
            InitializeComponent();
            recipeManager = new RecipeManager(MaxRecipes);
            currentRecipe = new Recipe(MaxIngredients);
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (currentRecipe == null)
            {
                currentRecipe = new Recipe(MaxIngredients);
            }
            currentRecipe.Name = txtBoxNameOfRecipe.Text;
            currentRecipe.Instructions = richTxtBoxInstructions.Text;
            currentRecipe.Category = (FoodCategory)comboBoxCategory.SelectedItem;
            recipeManager.AddRecipe(currentRecipe);
            currentRecipe = null; // Set currentRecipe to null after adding it to the RecipeManager

            // Clear the input fields and update the UI
            txtBoxNameOfRecipe.Clear();
            richTxtBoxInstructions.Clear();
            comboBoxCategory.SelectedIndex = -1;
            UpdateFormMainUI(); // Update the UI
        }

        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            int index = lbIngredients.SelectedIndex;
            if (index != -1)
            {
                // Retrieve the recipe from the RecipeManager based on the selected index
                currentRecipe = recipeManager.GetRecipe(index);

                // Update the UI to display the selected recipe details
                txtBoxNameOfRecipe.Text = currentRecipe.Name;
                richTxtBoxInstructions.Text = currentRecipe.Instructions;
                comboBoxCategory.SelectedItem = currentRecipe.Category;
            }
        }

        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            int index = lbIngredients.SelectedIndex;
            if (index != -1 && currentRecipe != null)
            {
                if (!string.IsNullOrEmpty(txtBoxNameOfRecipe.Text))
                {
                    currentRecipe.Name = txtBoxNameOfRecipe.Text;
                    currentRecipe.Instructions = richTxtBoxInstructions.Text;
                    currentRecipe.Category = (FoodCategory)comboBoxCategory.SelectedItem;
                    recipeManager.EditRecipe(index, currentRecipe);
                    UpdateFormMainUI();
                }
                else
                {
                    MessageBox.Show("Recipe name cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lbIngredients.SelectedIndex;
            if (index != -1)
            {
                recipeManager.RemoveRecipe(index);
                UpdateFormMainUI();
            }
        }


        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            lbIngredients.Items.Clear();
        }

        private void btnAddIngredients_Click(object sender, EventArgs e)
        {
            // Check if currentRecipe is null
            if (currentRecipe == null)
            {
                // Create a new Recipe object
                currentRecipe = new Recipe(MaxIngredients);
            }

            // Create a new instance of the FormIngredients form
            FormIngredients formIngredients = new FormIngredients(currentRecipe);

            // Show the form
            if (formIngredients.ShowDialog() == DialogResult.OK)
            {
                // Update currentRecipe with the updated recipe from FormIngredients
                currentRecipe = formIngredients.UpdatedRecipe;

                // Update the FormMain UI
                UpdateFormMainUI();
            }
        }

        private void UpdateFormMainUI()
        {
            // Clear the existing items
            lbIngredients.Items.Clear();

            // Add all recipes to the lbIngredients ListBox
            Recipe[] recipes = recipeManager.GetRecipes();
            foreach (Recipe recipe in recipes)
            {
                if (recipe != null)
                {
                    lbIngredients.Items.Add($"{recipe.Name}, {recipe.Category}, {recipe.GetIngredients().Count(i => i != null)}");
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with the categories
            comboBoxCategory.DataSource = Enum.GetValues(typeof(FoodCategory));
        }

        private void lbIngredients_DoubleClick(object sender, EventArgs e)
        {
            int index = lbIngredients.SelectedIndex;
            if (index != -1)
            {
                Recipe recipe = recipeManager.GetRecipe(index);
                MessageBox.Show($"Ingredients: {string.Join(", ", recipe.GetIngredients().Where(i => i != null))}\nDescription: {recipe.Instructions}");
            }
        }

        private void txtBoxNameOfRecipe_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddIngredients_Click_1(object sender, EventArgs e)
        {
            // Check if currentRecipe is null
            if (currentRecipe == null)
            {
                // Create a new Recipe object
                currentRecipe = new Recipe(MaxIngredients);
            }

            // Create a new instance of the FormIngredients form
            FormIngredients formIngredients = new FormIngredients(currentRecipe);

            // Show the form
            if (formIngredients.ShowDialog() == DialogResult.OK)
            {
                // Update currentRecipe with the updated recipe from FormIngredients
                currentRecipe = formIngredients.UpdatedRecipe;

                // Update the FormMain UI
                UpdateFormMainUI();
            }
        }

        private void richTxtBoxInstructions_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditBegin_Click_1(object sender, EventArgs e)
        {
            int index = lbIngredients.SelectedIndex;
            if (index != -1)
            {
                currentRecipe = recipeManager.GetRecipe(index);
                // Update the UI
                UpdateFormMainUI();
            }

        }

        private void btnEditFinish_Click_1(object sender, EventArgs e)
        {
            int index = lbIngredients.SelectedIndex;
            if (index != -1)
            {
                currentRecipe.Name = txtBoxNameOfRecipe.Text;
                currentRecipe.Instructions = richTxtBoxInstructions.Text;
                currentRecipe.Category = (FoodCategory)comboBoxCategory.SelectedItem;
                recipeManager.EditRecipe(index, currentRecipe);
                // Update the UI
                UpdateFormMainUI();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int index = lbIngredients.SelectedIndex;
            if (index != -1)
            {
                recipeManager.RemoveRecipe(index);
                // Update the UI
                UpdateFormMainUI();
            }
        }

        private void btnClearSelection_Click_1(object sender, EventArgs e)
        {
            // Clear the selection in the UI
            lbIngredients.Items.Clear();
            txtBoxNameOfRecipe.Clear();
            comboBoxCategory.SelectedIndex = -1;
        }
    }
}
