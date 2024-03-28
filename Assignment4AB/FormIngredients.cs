using System;
using System.Linq;
using System.Windows.Forms;

namespace Assignment_AB
{
    internal partial class FormIngredients : Form
    {
        private Recipe _recipe;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormIngredients"/> class.
        /// </summary>
        public FormIngredients()
        {
            InitializeComponent();
            _recipe = new Recipe(50); // Initialize a new Recipe object
            lbFormIngredients.DoubleClick += lbFormIngredients_DoubleClick; // Add the event handler
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormIngredients"/> class.
        /// </summary>
        /// <param name="recipe">The recipe object to be passed to the form.</param>
        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();
            _recipe = recipe ?? throw new ArgumentNullException(nameof(recipe), "Recipe cannot be null.");
            UpdateGUI();
        }

        
        public Recipe UpdatedRecipe => _recipe;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        /// <summary>
        /// Event handler for the "Add" button click event.
        /// Adds the ingredient from the text box to the recipe and updates the GUI.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxAddIngredients.Text))
            {
                _recipe.AddIngredient(txtBoxAddIngredients.Text);
                UpdateGUI();

              
                txtBoxAddIngredients.Clear();
            }
        }

        
        /// <summary>
        /// Event handler for the delete button click event.
        /// Removes the selected ingredient from the recipe and updates the GUI.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbFormIngredients.SelectedIndex;
            if (selectedIndex != -1)
            {
                _recipe.RemoveIngredient(selectedIndex);
                UpdateGUI();
            }
        }

       
        /// <summary>
        /// Event handler for the "Edit" button click event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
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

        
        /// <summary>
        /// Event handler for the click event of the 'Ok' button.
        /// Sets the DialogResult to OK and closes the form.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        
        /// <summary>
        /// Updates the graphical user interface (GUI) with the ingredients of the recipe.
        /// </summary>
        private void UpdateGUI()
        {
            lbFormIngredients.Items.Clear();
            string[] ingredients = _recipe.GetIngredients();
            if (ingredients != null && ingredients.Any())
            {
                lbFormIngredients.Items.AddRange(ingredients.Where(ingredient => ingredient != null).ToArray());
            }
        }

       
        /// <summary>
        /// Event handler for the FormIngredients Load event.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void FormIngredients_Load(object sender, EventArgs e)
        {
            UpdateGUI();
            btnEdit.Enabled = false; // Disable the Edit button initially

           
            lbFormIngredients.Click += lbFormIngredients_Click;
            groupBoxFormIngredients.MouseDown += groupBoxFormIngredients_MouseDown;
        }

       
        /// <summary>
        /// Event handler for the TextChanged event of the richTxtBoxIngredient control.
        /// Enables or disables the btnAdd button based on whether the txtBoxAddIngredients is empty or not.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void richTxtBoxIngredient_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = !string.IsNullOrEmpty(txtBoxAddIngredients.Text);
        }

       
        /// <summary>
        /// Event handler for the TextChanged event of the txtBoxAddIngredients TextBox.
        /// Updates the state of the btnEdit button based on the selected item in the ListBox and the text in the TextBox.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void txtBoxAddIngredients_TextChanged(object sender, EventArgs e)
        {
            bool isItemSelected = lbFormIngredients.SelectedIndex != -1;
            bool isTextBoxEmpty = string.IsNullOrEmpty(txtBoxAddIngredients.Text);

            // Enable the Edit button only if an item is selected in the ListBox and the text box is not empty
            btnEdit.Enabled = isItemSelected && !isTextBoxEmpty;
        }


       
        /// <summary>
        /// Event handler for the DoubleClick event of the lbFormIngredients ListBox.
        /// Populates the text box with the selected ingredient and enables the Edit button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private void lbFormIngredients_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = lbFormIngredients.SelectedIndex;
            if (selectedIndex != -1)
            {
                txtBoxAddIngredients.Text = lbFormIngredients.SelectedItem.ToString(); // Populate the text box with the selected ingredient
                btnEdit.Enabled = true; // Enable the Edit button when an ingredient is double-clicked
            }
        }

        /// <summary>
        /// Event handler for the click event of the FormIngredients button.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void FormIngredients_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = lbFormIngredients.SelectedIndex != -1;
        }

        /// <summary>
        /// Event handler for the MouseDown event of the groupBoxFormIngredients control.
        /// Disables the btnEdit button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        private void groupBoxFormIngredients_MouseDown(object sender, MouseEventArgs e)
        {
            btnEdit.Enabled = false;
        }

       
        /// <summary>
        /// Event handler for the lbFormIngredients Click event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void lbFormIngredients_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = lbFormIngredients.SelectedIndex != -1;
        }

        /// <summary>
        /// Event handler for the lbFormIngredients.SelectedIndexChanged event.
        /// Updates the text of txtBoxAddIngredients with the selected item from lbFormIngredients,
        /// and enables the btnEdit button if an item is selected.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void lbFormIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lbFormIngredients.SelectedIndex;
            if (selectedIndex != -1)
            {
                txtBoxAddIngredients.Text = lbFormIngredients.SelectedItem.ToString();
                btnEdit.Enabled = true;
            }
            else
            {
                txtBoxAddIngredients.Clear();
                btnEdit.Enabled = false;
            }
        }
    }
}
