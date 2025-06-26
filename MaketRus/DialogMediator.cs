using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ErEditorProject
{
    public class DialogMediator
    {
        ErSchemaDbManager erManager;

        ErEditor erEditor;
        NavigatorTree navigator;
        PropertiesPanel properties;
        public DialogMediator(ErEditor erEditor, NavigatorTree navigator, PropertiesPanel properties)
        {
            this.erEditor = erEditor;
            this.navigator = navigator;
            this.properties = properties;

            navigator.dialog = this;
            properties.dialog = this;

            erManager = ErSchemaDbManager.Manager();
        }

        public void NewErSchema()
        {
            NewErSchemaWindow window1 = new NewErSchemaWindow(this);
            DialogResult dr = window1.ShowDialog();
            switch (dr)
            {
                case DialogResult.OK:
                    var schema = erManager.NewErSchema(window1.filePath, window1.fileName);
                    erEditor.ActivateControls();
                    navigator.OpenSchema(schema);
                    break;
            }
        }

        public void OpenSchema()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            ErSchema schema;
            switch (dr)
            {
                case DialogResult.OK:
                    schema = erManager.OpenErSchema(ofd.FileName);
                    erEditor.ActivateControls();
                    navigator.OpenSchema(schema);
                    break;
            }
        }

        public void SaveSchema(ErSchema schema)
        {
            erManager.SaveSchema(schema);
        }

        public void ViewElement(ErEntitySet es)
        {
            EntitySetView esv = new EntitySetView(es);
            properties.ViewElement(esv);
        }

        public void ViewElement(ErRelationshipSet rs)
        {
            RelationshipSetView esv = new RelationshipSetView(rs);
            properties.ViewElement(esv);
        }

        public void ViewElement(ErValueSet vs)
        {
            ValueSetView esv = new ValueSetView(vs);
            properties.ViewElement(esv);
        }

        public void ViewElement(ErAttribute attr)
        {
            AttributeView esv = new AttributeView(attr);
            properties.ViewElement(esv);
        }

        public void ViewElement(ErRole role)
        {
            RoleView esv = new RoleView(role);
            properties.ViewElement(esv);
        }

    }
}
