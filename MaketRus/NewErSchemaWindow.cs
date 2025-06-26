using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ErEditorProject
{
    public partial class NewErSchemaWindow : Form
    {
        DialogMediator mediator;
        public string filePath = "";
        public string fileName = "";
        public NewErSchemaWindow(DialogMediator mediator)
        {
            this.mediator = mediator;
            InitializeComponent();
        }
        private void folderDialogButton_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                schemaPathField.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            // здесь все проверки - на то, что файл с таким именем существует, заполнение полей, и т.п.
            filePath = schemaPathField.Text;
            fileName = schemaNameField.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
