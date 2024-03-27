using System;
using System.Linq;
using System.Windows.Forms;

namespace Assignment_AB
{
    internal partial class FormIngredients : Form
    {
        private Recipe _recipe;
        private bool isDoubleClick = false;

        public FormIngredients()
        {
            InitializeComponent();
            _recipe = new Recipe(50); // Initialize a new Recipe object
            lbFormIngredients.DoubleClick += lbFormIngredients_DoubleClick; // Add the event handler
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

                // Clear the TextBox after adding the ingredient
                txtBoxAddIngredients.Clear();
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
            btnEdit.Enabled = false; // Disable the Edit button initially

            // Add click event handler to the ListBox and groupBoxFormIngredients
            lbFormIngredients.Click += lbFormIngredients_Click;
            groupBoxFormIngredients.MouseDown += groupBoxFormIngredients_MouseDown;
        }

        // Event handler for the rich text box ingredient change
        private void richTxtBoxIngredient_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = !string.IsNullOrEmpty(txtBoxAddIngredients.Text);
        }

        // Event handler for the text box change
        private void txtBoxAddIngredients_TextChanged(object sender, EventArgs e)
        {
            bool isItemSelected = lbFormIngredients.SelectedIndex != -1;
            bool isTextBoxEmpty = string.IsNullOrEmpty(txtBoxAddIngredients.Text);

            // Enable the Edit button only if an item is selected in the ListBox and the text box is not empty
            btnEdit.Enabled = isItemSelected && !isTextBoxEmpty;
        }


        // Double-click event handler for the ListBox
        private void lbFormIngredients_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = lbFormIngredients.SelectedIndex;
            if (selectedIndex != -1)
            {
                txtBoxAddIngredients.Text = lbFormIngredients.SelectedItem.ToString(); // Populate the text box with the selected ingredient
                btnEdit.Enabled = true; // Enable the Edit button when an ingredient is double-clicked
            }
        }

        private void FormIngredients_Click(object sender, EventArgs e)
        {
            // Disable the Edit button when the user clicks outside the ListBox
            // Enable the Edit button when the user clicks inside the ListBox
            btnEdit.Enabled = lbFormIngredients.SelectedIndex != -1;
        }

        private void groupBoxFormIngredients_MouseDown(object sender, MouseEventArgs e)
        {
            // Disable the Edit button when the user clicks inside the groupBoxFormIngredients
            btnEdit.Enabled = false;
        }

        // Event handler for the ListBox's click event
        private void lbFormIngredients_Click(object sender, EventArgs e)
        {
            // Enable the Edit button when the user clicks inside the ListBox
            btnEdit.Enabled = lbFormIngredients.SelectedIndex != -1;
        }

        // Event handler for the selected index change in the list box
        private void lbFormIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lbFormIngredients.SelectedIndex;
            if (selectedIndex != -1)
            {
                // Populate the text box with the selected ingredient
                txtBoxAddIngredients.Text = lbFormIngredients.SelectedItem.ToString();
                btnEdit.Enabled = true; // Enable the Edit button when an item is selected in the ListBox
            }
            else
            {
                txtBoxAddIngredients.Clear(); // Clear the text box when no item is selected
                btnEdit.Enabled = false; // Disable the Edit button when no item is selected
            }
        }
    }
}
