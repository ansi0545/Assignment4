namespace Assignment_AB
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpBoxAddNewRecipe = new GroupBox();
            btnAddIngredients = new Button();
            btnAddRecipe = new Button();
            richTxtBoxInstructions = new RichTextBox();
            lblCategory = new Label();
            txtBoxNameOfRecipe = new TextBox();
            lblNameOfRecipe = new Label();
            comboBoxCategory = new ComboBox();
            lblName = new Label();
            lblNoIngredients = new Label();
            lblCategoryAtLargeTxtBox = new Label();
            btnEditBegin = new Button();
            btnEditFinish = new Button();
            btnDelete = new Button();
            btnClearSelection = new Button();
            lbIngredients = new ListBox();
            grpBoxAddNewRecipe.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxAddNewRecipe
            // 
            grpBoxAddNewRecipe.Controls.Add(btnAddIngredients);
            grpBoxAddNewRecipe.Controls.Add(btnAddRecipe);
            grpBoxAddNewRecipe.Controls.Add(richTxtBoxInstructions);
            grpBoxAddNewRecipe.Controls.Add(lblCategory);
            grpBoxAddNewRecipe.Controls.Add(txtBoxNameOfRecipe);
            grpBoxAddNewRecipe.Controls.Add(lblNameOfRecipe);
            grpBoxAddNewRecipe.Controls.Add(comboBoxCategory);
            grpBoxAddNewRecipe.Location = new Point(12, 12);
            grpBoxAddNewRecipe.Name = "grpBoxAddNewRecipe";
            grpBoxAddNewRecipe.Size = new Size(751, 654);
            grpBoxAddNewRecipe.TabIndex = 0;
            grpBoxAddNewRecipe.TabStop = false;
            grpBoxAddNewRecipe.Text = "Add New Recipe";
            // 
            // btnAddIngredients
            // 
            btnAddIngredients.AutoSize = true;
            btnAddIngredients.Location = new Point(565, 93);
            btnAddIngredients.Name = "btnAddIngredients";
            btnAddIngredients.Size = new Size(170, 50);
            btnAddIngredients.TabIndex = 3;
            btnAddIngredients.Text = "Add Ingredients";
            btnAddIngredients.Click += btnAddIngredients_Click_1;
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Location = new Point(19, 598);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(716, 50);
            btnAddRecipe.TabIndex = 1;
            btnAddRecipe.Text = "Add Recipe";
            btnAddRecipe.Click += btnAddRecipe_Click;
            // 
            // richTxtBoxInstructions
            // 
            richTxtBoxInstructions.Location = new Point(19, 156);
            richTxtBoxInstructions.Name = "richTxtBoxInstructions";
            richTxtBoxInstructions.Size = new Size(716, 436);
            richTxtBoxInstructions.TabIndex = 2;
            richTxtBoxInstructions.Text = "";
            richTxtBoxInstructions.TextChanged += richTxtBoxInstructions_TextChanged;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(6, 106);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(84, 25);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Category";
            // 
            // txtBoxNameOfRecipe
            // 
            txtBoxNameOfRecipe.Location = new Point(194, 30);
            txtBoxNameOfRecipe.Name = "txtBoxNameOfRecipe";
            txtBoxNameOfRecipe.Size = new Size(541, 31);
            txtBoxNameOfRecipe.TabIndex = 4;
            txtBoxNameOfRecipe.TextChanged += txtBoxNameOfRecipe_TextChanged;
            // 
            // lblNameOfRecipe
            // 
            lblNameOfRecipe.AutoSize = true;
            lblNameOfRecipe.Location = new Point(6, 36);
            lblNameOfRecipe.Name = "lblNameOfRecipe";
            lblNameOfRecipe.Size = new Size(137, 25);
            lblNameOfRecipe.TabIndex = 7;
            lblNameOfRecipe.Text = "Name of Recipe";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Location = new Point(96, 103);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(452, 33);
            comboBoxCategory.TabIndex = 6;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(797, 12);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblNoIngredients
            // 
            lblNoIngredients.AutoSize = true;
            lblNoIngredients.Location = new Point(1227, 12);
            lblNoIngredients.Name = "lblNoIngredients";
            lblNoIngredients.Size = new Size(130, 25);
            lblNoIngredients.TabIndex = 0;
            lblNoIngredients.Text = "No Ingredients";
            // 
            // lblCategoryAtLargeTxtBox
            // 
            lblCategoryAtLargeTxtBox.AutoSize = true;
            lblCategoryAtLargeTxtBox.Location = new Point(1020, 12);
            lblCategoryAtLargeTxtBox.Name = "lblCategoryAtLargeTxtBox";
            lblCategoryAtLargeTxtBox.Size = new Size(84, 25);
            lblCategoryAtLargeTxtBox.TabIndex = 1;
            lblCategoryAtLargeTxtBox.Text = "Category";
            // 
            // btnEditBegin
            // 
            btnEditBegin.AutoSize = true;
            btnEditBegin.Location = new Point(797, 610);
            btnEditBegin.Name = "btnEditBegin";
            btnEditBegin.Size = new Size(101, 50);
            btnEditBegin.TabIndex = 3;
            btnEditBegin.Text = "Edit Begin";
            btnEditBegin.Click += btnEditBegin_Click_1;
            // 
            // btnEditFinish
            // 
            btnEditFinish.AutoSize = true;
            btnEditFinish.Location = new Point(931, 610);
            btnEditFinish.Name = "btnEditFinish";
            btnEditFinish.Size = new Size(102, 50);
            btnEditFinish.TabIndex = 4;
            btnEditFinish.Text = "Edit Finish";
            btnEditFinish.Click += btnEditFinish_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(1072, 610);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 50);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnClearSelection
            // 
            btnClearSelection.AutoSize = true;
            btnClearSelection.Location = new Point(1211, 610);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(137, 50);
            btnClearSelection.TabIndex = 6;
            btnClearSelection.Text = "Clear Selection";
            btnClearSelection.Click += btnClearSelection_Click_1;
            // 
            // lbIngredients
            // 
            lbIngredients.FormattingEnabled = true;
            lbIngredients.ItemHeight = 25;
            lbIngredients.Location = new Point(792, 47);
            lbIngredients.Name = "lbIngredients";
            lbIngredients.Size = new Size(556, 554);
            lbIngredients.TabIndex = 7;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 678);
            Controls.Add(lbIngredients);
            Controls.Add(lblNoIngredients);
            Controls.Add(lblCategoryAtLargeTxtBox);
            Controls.Add(btnEditBegin);
            Controls.Add(btnEditFinish);
            Controls.Add(btnDelete);
            Controls.Add(btnClearSelection);
            Controls.Add(grpBoxAddNewRecipe);
            Controls.Add(lblName);
            Name = "FormMain";
            Text = "Fias receptbok";
            Load += FormMain_Load;
            grpBoxAddNewRecipe.ResumeLayout(false);
            grpBoxAddNewRecipe.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpBoxAddNewRecipe;
        private Label lblNameOfRecipe;
        private ComboBox comboBoxCategory;
        private Label lblCategory;
        private TextBox txtBoxNameOfRecipe;
        private Button btnAddIngredients;
        private RichTextBox richTxtBoxInstructions;
        private Button btnAddRecipe;
        private Label lblName;
        private Label lblNoIngredients;
        private Label lblCategoryAtLargeTxtBox;
        private Button btnEditBegin;
        private Button btnEditFinish;
        private Button btnDelete;
        private Button btnClearSelection;
        private ListBox lbIngredients;
    }
}