using System;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment_AB
{
    partial class FormIngredients
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox groupBoxFormIngredients;
        private Label lblNoIngredients;
        private TextBox txtBoxAddIngredients;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnOk;
        private Button btnCancel;
        private TextBox txtName;
        private TextBox txtInstructions;
        private ListBox lbFormIngredients;

        protected void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBoxFormIngredients = new GroupBox();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtBoxAddIngredients = new TextBox();
            lbFormIngredients = new ListBox();
            lblNoIngredients = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            txtName = new TextBox();
            txtInstructions = new TextBox();
            groupBoxFormIngredients.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxFormIngredients
            // 
            groupBoxFormIngredients.Controls.Add(btnDelete);
            groupBoxFormIngredients.Controls.Add(btnEdit);
            groupBoxFormIngredients.Controls.Add(btnAdd);
            groupBoxFormIngredients.Controls.Add(txtBoxAddIngredients);
            groupBoxFormIngredients.Controls.Add(lbFormIngredients);
            groupBoxFormIngredients.Location = new Point(38, 49);
            groupBoxFormIngredients.Name = "groupBoxFormIngredients";
            groupBoxFormIngredients.Size = new Size(732, 581);
            groupBoxFormIngredients.TabIndex = 0;
            groupBoxFormIngredients.TabStop = false;
            groupBoxFormIngredients.Text = "Ingredients";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(601, 154);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(601, 99);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(601, 45);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtBoxAddIngredients
            // 
            txtBoxAddIngredients.Location = new Point(10, 36);
            txtBoxAddIngredients.Name = "txtBoxAddIngredients";
            txtBoxAddIngredients.Size = new Size(567, 31);
            txtBoxAddIngredients.TabIndex = 0;
            txtBoxAddIngredients.TextChanged += textBox1_TextChanged;
            // 
            // lbFormIngredients
            // 
            lbFormIngredients.FormattingEnabled = true;
            lbFormIngredients.ItemHeight = 25;
            lbFormIngredients.Location = new Point(10, 86);
            lbFormIngredients.Name = "lbFormIngredients";
            lbFormIngredients.Size = new Size(567, 479);
            lbFormIngredients.TabIndex = 5;
            lbFormIngredients.SelectedIndexChanged += lbFormIngredients_SelectedIndexChanged;
            // 
            // lblNoIngredients
            // 
            lblNoIngredients.AutoSize = true;
            lblNoIngredients.Location = new Point(19, 11);
            lblNoIngredients.Name = "lblNoIngredients";
            lblNoIngredients.Size = new Size(192, 25);
            lblNoIngredients.TabIndex = 1;
            lblNoIngredients.Text = "Number of ingredients";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(160, 647);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(112, 34);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(357, 647);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(0, 0);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 31);
            txtName.TabIndex = 0;
            // 
            // txtInstructions
            // 
            txtInstructions.Location = new Point(0, 0);
            txtInstructions.Name = "txtInstructions";
            txtInstructions.Size = new Size(100, 31);
            txtInstructions.TabIndex = 0;
            // 
            // FormIngredients
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 693);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblNoIngredients);
            Controls.Add(groupBoxFormIngredients);
            Name = "FormIngredients";
            Text = "FormIngredients";
            Load += FormIngredients_Load;
            groupBoxFormIngredients.ResumeLayout(false);
            groupBoxFormIngredients.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}