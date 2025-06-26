namespace ErEditorProject
{
    partial class NewErSchemaWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            schemaNameField = new TextBox();
            groupBox2 = new GroupBox();
            folderDialogButton = new Button();
            schemaPathField = new TextBox();
            createButton = new Button();
            cancelButton = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(schemaNameField);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 48);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Название схемы";
            // 
            // schemaNameField
            // 
            schemaNameField.Location = new Point(12, 19);
            schemaNameField.Name = "schemaNameField";
            schemaNameField.Size = new Size(182, 23);
            schemaNameField.TabIndex = 0;
            schemaNameField.Text = "newdb";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(folderDialogButton);
            groupBox2.Controls.Add(schemaPathField);
            groupBox2.Location = new Point(12, 66);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(315, 56);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Путь";
            // 
            // folderDialogButton
            // 
            folderDialogButton.Location = new Point(284, 22);
            folderDialogButton.Name = "folderDialogButton";
            folderDialogButton.Size = new Size(25, 23);
            folderDialogButton.TabIndex = 2;
            folderDialogButton.Text = "...";
            folderDialogButton.UseVisualStyleBackColor = true;
            folderDialogButton.Click += folderDialogButton_Click;
            // 
            // schemaPathField
            // 
            schemaPathField.Location = new Point(12, 22);
            schemaPathField.Name = "schemaPathField";
            schemaPathField.Size = new Size(269, 23);
            schemaPathField.TabIndex = 1;
            // 
            // createButton
            // 
            createButton.Location = new Point(246, 147);
            createButton.Name = "createButton";
            createButton.Size = new Size(75, 23);
            createButton.TabIndex = 2;
            createButton.Text = "Создать";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(165, 147);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 182);
            Controls.Add(cancelButton);
            Controls.Add(createButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form2";
            Text = "Создать ER-схему";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox schemaNameField;
        private GroupBox groupBox2;
        private Button folderDialogButton;
        private TextBox schemaPathField;
        private Button createButton;
        private Button cancelButton;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}