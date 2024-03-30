

namespace Assignment_AB
{
    public partial class FormMain : Form
    {
        private const int MaxRecipes = 200;
        private const int MaxIngredients = 50;
        private RecipeManager recipeManager;
        private Recipe currentRecipe;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            recipeManager = new RecipeManager(MaxRecipes);
            currentRecipe = new Recipe(MaxIngredients);
        }


        /// <summary>
        /// Event handler for the "Add Recipe" button click event.
        /// Validates the input, adds the recipe, and updates the user interface.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    AddRecipe();
                    UpdateUI();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validates the input for the recipe form.
        /// </summary>
        /// <returns>True if the input is valid, otherwise false.</returns>
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtBoxNameOfRecipe.Text))
            {
                MessageBox.Show("Recipe name cannot be null or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds a new recipe to the recipe manager.
        /// </summary>
        private void AddRecipe()
        {
            currentRecipe.Name = txtBoxNameOfRecipe.Text;
            currentRecipe.Instructions = richTxtBoxInstructions.Text;
            currentRecipe.Category = (FoodCategory)comboBoxCategory.SelectedItem;

            recipeManager.AddRecipe(currentRecipe);
            currentRecipe = new Recipe(MaxIngredients); // Reset currentRecipe
        }

        /// <summary>
        /// Updates the user interface by clearing input fields and updating the main form UI.
        /// </summary>
        private void UpdateUI()
        {
            // Clear input fields
            txtBoxNameOfRecipe.Clear();
            richTxtBoxInstructions.Clear();
            comboBoxCategory.SelectedIndex = -1;

            // Update the UI
            UpdateFormMainUI();
        }

        /// <summary>
        /// Event handler for the "Edit Begin" button click event.
        /// Retrieves the selected recipe from the RecipeManager and updates the UI with the selected recipe details.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            int index = lbIngredients.SelectedIndex;
            if (index != -1)
            {
                // Retrieve the selected recipe from the RecipeManager
                currentRecipe = recipeManager.GetRecipe(index);

                // Update the UI with the selected recipe details
                txtBoxNameOfRecipe.Text = currentRecipe.Name;
                richTxtBoxInstructions.Text = currentRecipe.Instructions;
                comboBoxCategory.SelectedItem = currentRecipe.Category;
            }
        }


        /// <summary>
        /// Event handler for the "Edit Finish" button click event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnEditFinish_Click(object sender, EventArgs e)
        {

            try
            {
                int index = lbIngredients.SelectedIndex;
                if (index != -1 && currentRecipe != null)
                {
                    if (ValidateInput())
                    {
                        EditRecipe(index);
                        UpdateUI();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Edits the recipe at the specified index with the values from the input fields.
        /// </summary>
        /// <param name="index">The index of the recipe to edit.</param>
        private void EditRecipe(int index)
        {
            currentRecipe.Name = txtBoxNameOfRecipe.Text;
            currentRecipe.Instructions = richTxtBoxInstructions.Text;
            currentRecipe.Category = (FoodCategory)comboBoxCategory.SelectedItem;

            recipeManager.EditRecipe(index, currentRecipe);
            currentRecipe = new Recipe(MaxIngredients); // Reset currentRecipe
        }


        /// <summary>
        /// Event handler for the "Delete" button click event.
        /// Removes the selected recipe from the recipe manager and updates the UI.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lbIngredients.SelectedIndex;
            if (index != -1)
            {
                recipeManager.RemoveRecipe(index);
                UpdateFormMainUI();
            }
        }

        /// <summary>
        /// Updates the UI of the main form with the recipes from the recipe manager.
        /// </summary>
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
                    string formattedRecipe = string.Format("{0,-15} {1, -9} {2, 10}", recipe.Name, recipe.Category, recipe.GetIngredients().Count(i => i != null));
                    lbIngredients.Items.Add(formattedRecipe);
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with the categories
            comboBoxCategory.DataSource = Enum.GetValues(typeof(FoodCategory));
        }

        /// <summary>
        /// Event handler for double-clicking on an item in lbIngredients ListBox.
        /// Displays the detailed information of the selected recipe in a MessageBox.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void lbIngredients_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int index = lbIngredients.SelectedIndex;
                if (index != -1)
                {
                    Recipe recipe = recipeManager.GetRecipe(index);

                    // Get the detailed information for the recipe
                    string name = recipe.Name;
                    string category = recipe.Category.ToString();
                    string ingredients = string.Join(", ", recipe.GetIngredients().Where(i => i != null));
                    string instructions = recipe.Instructions;

                    // Create the message to display
                    string message = $"Name: {name}\nCategory: {category}\nIngredients: {ingredients}\nInstructions: {instructions}";

                    // Show the complete recipe information in a MessageBox
                    MessageBox.Show(message, "Recipe Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clears the selection and input fields on the main form.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            lbIngredients.Items.Clear();
            txtBoxNameOfRecipe.Clear();
            comboBoxCategory.SelectedIndex = -1;
            richTxtBoxInstructions.Clear();
        }

        /// <summary>
        /// Event handler for the "Add Ingredients" button click event.
        /// Opens the FormIngredients form to add ingredients to the current recipe.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnAddIngredients_Click(object sender, EventArgs e)
        {
            if (currentRecipe == null)
            {
                currentRecipe = new Recipe(MaxIngredients);
            }

            FormIngredients formIngredients = new FormIngredients(currentRecipe);
            if (formIngredients.ShowDialog() == DialogResult.OK)
            {
                currentRecipe = formIngredients.UpdatedRecipe;
                UpdateFormMainUI();
            }
        }
    }
}
