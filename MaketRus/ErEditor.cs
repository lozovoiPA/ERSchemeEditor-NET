using FontAwesome.Sharp;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ErEditorProject
{
    public partial class ErEditor : Form
    {
        DialogMediator dialog;
        private void Initialize()
        {
            // general toolbar
            toolStripButton1.Image = IconChar.FileAlt.ToBitmap(48, 48); // new
            toolStripSplitButton1.Image = IconChar.FolderOpen.ToBitmap(48, 48, Color.Orange); // open
            toolStripButton2.Image = IconChar.FloppyDisk.ToBitmap(100, 100, Color.Black); // save

            // navigator toolbar
            toolStripButton3.Image = IconChar.E.ToBitmap(100, 100); // copy
            toolStripButton4.Image = IconChar.R.ToBitmap(100, 100); // copy
            toolStripButton5.Image = IconChar.V.ToBitmap(100, 100); // copy
            //
            toolStripButton6.Image = IconChar.Copy.ToBitmap(100, 100); // copy
            toolStripButton7.Image = IconChar.Paste.ToBitmap(100, 100); // paste
            toolStripSeparator3.Image = IconChar.Clone.ToBitmap(100, 100, Color.Black); // duplicate selected
            //
            toolStripButton9.Image = IconChar.Trash.ToBitmap(100, 100); // copy
            toolStripButton10.Image = IconChar.Plus.ToBitmap(100, 100); // copy
        }
        public ErEditor()
        {
            InitializeComponent();
            Initialize();

            dialog = new DialogMediator(this, navigatorPanel1, propertiesPanel1);
        }

        private void newErSchemaItem_Click(object sender, EventArgs e)
        {
            dialog.NewErSchema();
        }

        public void ActivateControls()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            toolStripButton2.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        private void openErSchemaItem_Click(object sender, EventArgs e)
        {
            dialog.OpenSchema();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog.SaveSchema(navigatorPanel1.GetSchema());
        }
    }
}
