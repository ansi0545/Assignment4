using System;
using System.Linq;
using System.Windows.Forms;

namespace Assignment_AB
{
    internal partial class FormIngredients : Form
    {
        private Recipe _recipe;

        public FormIngredients()
        {
            InitializeComponent();
            _recipe = new Recipe(50); // Initialize a new Recipe object
        }

        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();
            _recipe = recipe ?? throw new ArgumentNullException(nameof(recipe), "Recipe cannot be null.");
            UpdateGUI();
        }

        // Property to access the updated recipe from FormMain
        public Recipe UpdatedRecipe => _recipe;

        // Event handler for the Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Event handler for the Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxAddIngredients.Text))
            {
                _recipe.AddIngredient(txtBoxAddIngredients.Text);
                UpdateGUI();
            }
        }

        // Event handler for the Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbFormIngredients.SelectedIndex;
            if (selectedIndex != -1)
            {
                _recipe.RemoveIngredient(selectedIndex);
                UpdateGUI();
            }
        }

        // Event handler for the Edit button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbFormIngredients.SelectedIndex;
            if (selectedIndex != -1 && !string.IsNullOrEmpty(txtBoxAddIngredients.Text))
            {
                string newIngredient = txtBoxAddIngredients.Text;
                _recipe.ChangeIngredient(selectedIndex, newIngredient);
                UpdateGUI();
            }
        }

        // Event handler for the OK button
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        // Update the GUI with ingredients from the Recipe object
        private void UpdateGUI()
        {
            lbFormIngredients.Items.Clear();
            string[] ingredients = _recipe.GetIngredients();
            if (ingredients != null && ingredients.Any())
            {
                lbFormIngredients.Items.AddRange(ingredients.Where(ingredient => ingredient != null).ToArray());
            }
        }

        // Load event handler for the FormIngredients form
        private void FormIngredients_Load(object sender, EventArgs e)
        {
            UpdateGUI();
        }

        // Event handler for the rich text box ingredient change
        private void richTxtBoxIngredient_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = !string.IsNullOrEmpty(txtBoxAddIngredients.Text);
        }

        // Event handler for the text box change
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool isItemSelected = lbFormIngredients.SelectedIndex != -1;
            btnEdit.Enabled = isItemSelected;
            btnDelete.Enabled = isItemSelected;
        }

        // Event handler for the selected index change in the list box
        private void lbFormIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
