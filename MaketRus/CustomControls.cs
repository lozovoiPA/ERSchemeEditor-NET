using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ErEditorProject
{
    public abstract class ElementView : TableLayoutPanel, Observer
    {
        public void Initialize()
        {
            Controls.Clear();
            ColumnStyles.Clear();
            RowStyles.Clear();

            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            RowStyle rs = new RowStyle();
            ColumnCount = 2;
            ColumnStyle cs = new ColumnStyle();
            cs.SizeType = SizeType.Absolute;
            cs.Width = 200;
            ColumnStyles.Add(cs);
            cs = new ColumnStyle();
            cs.SizeType = SizeType.AutoSize;
            ColumnStyles.Add(cs);

            Label label1 = new Label();
            label1.Text = "Название";
            Controls.Add(label1);

            TextBox textBox1 = new TextBox();
            Controls.Add(textBox1);
        }

        public abstract void SaveElement();
        public abstract void ObsUpdate();
    }

    public class EntitySetView : ElementView
    {
        public ErEntitySet entitySet;
        public EntitySetView(ErEntitySet _entitySet)
        {
            entitySet = _entitySet;
            entitySet.Attach(this);
            Initialize();
        }

        new public void Initialize()
        {
            base.Initialize();
            Controls[1].Text = entitySet.name;
            if(entitySet.attributes.Count != 0)
            {
                Label l = new Label();
                l.Text = "Атрибуты";
                Controls.Add(l);
                SetColumnSpan(l, 2);
                TextBox tb;
                foreach(ErAttribute attr in entitySet.attributes)
                {
                    tb = new TextBox();
                    tb.Text = attr.name;
                    Controls.Add(tb);
                    SetColumnSpan(tb, 2);
                }
                
            }
            if(entitySet.roles.Count != 0)
            {
                Label l = new Label();
                l.Text = "Роли";
                Controls.Add(l);
                SetColumnSpan(l, 2);
                TextBox tb;
                foreach (ErRole role in entitySet.roles)
                {
                    tb = new TextBox();
                    tb.Text = role.name;
                    Controls.Add(tb);
                    SetColumnSpan(tb, 2);
                }
            }
        }

        public override void ObsUpdate()
        {
            Initialize();
        }

        public override void SaveElement()
        {
            entitySet.SetName(((TextBox)Controls[1]).Text);
        }
    }

    public class RelationshipSetView : ElementView
    {
        public ErRelationshipSet relationshipSet;
        public RelationshipSetView(ErRelationshipSet _relationshipSet)
        {
            relationshipSet = _relationshipSet;
            relationshipSet.Attach(this);
            Initialize();
        }

        new public void Initialize()
        {
            base.Initialize();
            Controls[1].Text = relationshipSet.name;
            if (relationshipSet.attributes.Count != 0)
            {
                Label l = new Label();
                l.Text = "Атрибуты";
                Controls.Add(l);
                SetColumnSpan(l, 2);
                TextBox tb;
                foreach (ErAttribute attr in relationshipSet.attributes)
                {
                    tb = new TextBox();
                    tb.Text = attr.name;
                    Controls.Add(tb);
                    SetColumnSpan(tb, 2);
                }

            }
            if (relationshipSet.roles.Count != 0)
            {
                Label l = new Label();
                l.Text = "Роли";
                Controls.Add(l);
                SetColumnSpan(l, 2);
                TextBox tb;
                foreach (ErRole role in relationshipSet.roles)
                {
                    tb = new TextBox();
                    tb.Text = role.name;
                    Controls.Add(tb);
                    SetColumnSpan(tb, 2);
                }
            }
        }

        public override void ObsUpdate()
        {
            Initialize();
        }

        public override void SaveElement()
        {
            relationshipSet.SetName(((TextBox)Controls[1]).Text);
        }
    }

    public class ValueSetView : ElementView
    {
        public ErValueSet valueSet;
        public ValueSetView(ErValueSet _valueSet)
        {
            valueSet = _valueSet;
            valueSet.Attach(this);
            Initialize();
        }

        new public void Initialize()
        {
            base.Initialize();
            Controls[1].Text = valueSet.name;
        }

        public override void ObsUpdate()
        {
            Initialize();
        }

        public override void SaveElement()
        {
            valueSet.SetName(((TextBox)Controls[1]).Text); // Notify() об обновлении в конце всего обновления
        }
    }

    public class AttributeView : ElementView
    {
        public ErAttribute attribute;
        public AttributeView(ErAttribute _attribute)
        {
            attribute = _attribute;
            attribute.Attach(this);
            Initialize();
        }

        new public void Initialize()
        {
            base.Initialize();
            Controls[1].Text = attribute.name;

            Label label1 = new Label();
            label1.Text = "Ключ сущности";
            Controls.Add(label1);

            CheckBox chb = new CheckBox();
            chb.Checked = attribute.isKey;
            Controls.Add(chb);

            label1 = new Label();
            label1.Text = "Минимальное значение";
            label1.Width = 200;
            Controls.Add(label1);

            TextBox tb = new TextBox();
            if(attribute.minValue != null)
            {
                tb.Text = attribute.minValue.ToString();
            }
            Controls.Add(tb);

            label1 = new Label();
            label1.Text = "Максимальное значение";
            label1.Width = 200;
            Controls.Add(label1);

            tb = new TextBox();
            if (attribute.maxValue != null)
            {
                tb.Text = attribute.maxValue.ToString();
            }
            Controls.Add(tb);

            label1 = new Label();
            label1.Text = "Допустимые значения";
            label1.Width = 200;
            Controls.Add(label1);

            tb = new TextBox();
            if (attribute.allowedValues != null)
            {
                tb.Text = attribute.allowedValues;
            }
            Controls.Add(tb);

            label1 = new Label();
            label1.Text = "Множество значений";
            label1.Width = 200;
            Controls.Add(label1);

            tb = new TextBox();
            if (attribute.valueSets.Count != 0)
            {
                string t = "";
                foreach (ErValueSet valueSet in attribute.valueSets)
                {
                    t += valueSet.name + " ";
                }
                tb.Text = t;
            }
            Controls.Add(tb);
        }

        public override void ObsUpdate()
        {
            Initialize();
        }

        public override void SaveElement()
        {
            
            attribute.isKey = ((CheckBox)Controls[3]).Checked;
            if(((TextBox)Controls[5]).Text != "")
            {
                attribute.minValue = Convert.ToDouble(((TextBox)Controls[5]).Text);
            }
            if (((TextBox)Controls[7]).Text != "")
            {
                attribute.maxValue = Convert.ToDouble(((TextBox)Controls[7]).Text);
            }
            attribute.allowedValues = ((TextBox)Controls[9]).Text;
            ErValueSet? vs = attribute.schema.FindValueSet(((TextBox)Controls[11]).Text);
            if(vs != null)
            {
                attribute.valueSets.Add(vs);
            }
            attribute.SetName(((TextBox)Controls[1]).Text);
        }
    }

    public class RoleView : ElementView
    {
        public ErRole role;
        public RoleView(ErRole _role)
        {
            role = _role;
            role.Attach(this);
            Initialize();
        }

        new public void Initialize()
        {
            base.Initialize();
            Controls[1].Text = role.name;
            Label label1 = new Label();
            label1.Text = "Множество сущностей";
            label1.Width = 200;
            Controls.Add(label1);

            TextBox tb = new TextBox();
            if(role.entitySet != null)
            {
                tb.Text = role.entitySet.name;
            }
            Controls.Add(tb);

            label1 = new Label();
            label1.Text = "Ключевая сущность";
            Controls.Add(label1);

            CheckBox chb = new CheckBox();
            chb.Checked = role.isKey;
            Controls.Add(chb);
        }

        public override void ObsUpdate()
        {
            Initialize();
        }

        public override void SaveElement()
        {
            
            ErEntitySet? vs = role.schema.FindEntitySet(((TextBox)Controls[3]).Text);
            Console.WriteLine(((TextBox)Controls[3]).Text);
            if (vs != null)
            {
                if(role.entitySet != null && role.entitySet != vs)
                {
                    role.entitySet.RemoveRole(role);
                }
                if(role.entitySet != vs)
                {
                    role.AddEntitySet(vs);
                    vs.AddRole(role);
                }
            }
            role.isKey = ((CheckBox)Controls[5]).Checked;
            role.SetName(((TextBox)Controls[1]).Text);
        }
    }

    public class PropertiesPanel : Panel
    {
        public DialogMediator? dialog;
        public ElementView? view;

        public PropertiesPanel()
        {
            Leave += new EventHandler(LoseFocus);
        }

        public void LoseFocus(object sender, EventArgs e)
        {
            if (view != null)
            {
                view.SaveElement();
                view.Dispose();
                view = null;
            }

            Controls.Clear();
        }
        public void ViewElement(ElementView _view)
        {
            if(view != null)
            {
                view.SaveElement();
                view.Dispose();
            }
            
            Controls.Clear();
            view = _view;
            view.ObsUpdate();
            Controls.Add(view);
            view.Dock = DockStyle.Fill;
        }
    }

    public partial class ExpandedTreeView : TreeView
    {
        protected TreeNode? editingNode;
        public ExpandedTreeView()
        {
            Initialize();
        }

        // Useful handlers setup
        private void Initialize()
        {
            LabelEdit = false;
            ImageList = new ImageList();
            ImageList.Images.Add(new Bitmap(1, 1));

            NodeMouseClick += new TreeNodeMouseClickEventHandler(ClickNode);
            AfterLabelEdit += new NodeLabelEditEventHandler(EndRenamingNode);
        }

        // Useful handlers (that extend TreeView's behavior)
        protected void ClickNode(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNode = e.Node;
        }

        private void __BeginRenamingSelectedNode()
        {
            LabelEdit = true;
            if(SelectedNode != null)
            {
                editingNode = SelectedNode;
                editingNode.BeginEdit();
            }
        }

        public void BeginRenamingNode(TreeNode node)
        {
            SelectedNode = node;
            __BeginRenamingSelectedNode();
        }

        protected void BeginRenamingNode(object sender, EventArgs e)
        {
            __BeginRenamingSelectedNode();
        }

        protected void EndRenamingNode(object sender, NodeLabelEditEventArgs e)
        {
            if(editingNode != null)
            {
                editingNode.EndEdit(false);
                SelectedNode = null;
                editingNode = null;
            }
            LabelEdit = false;
        }

        public ContextMenuStrip AddContextMenu(TreeNode node, List<string> items, List<EventHandler> clickHandlers)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripItem strip;
            for(int i = 0; i < items.Count; i++)
            {
                strip = menu.Items.Add(items[i]);
                if(i < clickHandlers.Count)
                {
                    strip.Click += clickHandlers[i];
                }
            }
            node.ContextMenuStrip = menu;
            return menu;
        }

        private TreeNode __AddNode(TreeNodeCollection nodes, TreeNode newNode, string name, int iconIndex = 0, int selectedIconIndex = 0)
        {
            newNode = nodes.Add(name);
            newNode.Name = name;
            newNode.ImageIndex = iconIndex;
            newNode.SelectedImageIndex = selectedIconIndex;

            
            return newNode;
        }
    }

    public partial class NavigatorTree : ExpandedTreeView, Observer
    {
        public DialogMediator? dialog;
        public Dictionary<TreeNode, ErSchema> schemaNodes; // костыльно
        public Dictionary<TreeNode, ErEntitySet> esNodes; // костыльно
        public Dictionary<TreeNode, ErRelationshipSet> rsNodes; // костыльно
        public Dictionary<TreeNode, ErValueSet> vsNodes; // костыльно
        public Dictionary<TreeNode, ErAttribute> attrNodes; // костыльно
        public Dictionary<TreeNode, ErRole> roleNodes; // костыльно
        
        public NavigatorTree()
        {
            schemaNodes = new Dictionary<TreeNode, ErSchema>();
            esNodes = new Dictionary<TreeNode, ErEntitySet>();
            rsNodes = new Dictionary<TreeNode, ErRelationshipSet>();
            vsNodes = new Dictionary<TreeNode, ErValueSet>();
            attrNodes = new Dictionary<TreeNode, ErAttribute>();
            roleNodes = new Dictionary<TreeNode, ErRole>();

            NodeMouseClick += new TreeNodeMouseClickEventHandler(ClickNode);
            AfterLabelEdit -= base.EndRenamingNode;
            AfterLabelEdit += new NodeLabelEditEventHandler(EndRenamingNode);
        }

        protected void EndRenamingNode(object sender, NodeLabelEditEventArgs e)
        {
            if (editingNode != null)
            {
                editingNode.EndEdit(false);
            }
            LabelEdit = false;
            if (e.Node != null)
            {
                if (esNodes.ContainsKey(e.Node))
                {
                    esNodes[e.Node].SetName(e.Label);
                }
                else if (rsNodes.ContainsKey(e.Node))
                {
                    rsNodes[e.Node].SetName(e.Label);
                }
                else if (vsNodes.ContainsKey(e.Node))
                {
                    vsNodes[e.Node].SetName(e.Label);
                }
                else if (attrNodes.ContainsKey(e.Node))
                {
                    attrNodes[e.Node].SetName(e.Label);
                }
                else if (roleNodes.ContainsKey(e.Node))
                {
                    roleNodes[e.Node].SetName(e.Label);
                }
            }
            if (editingNode != null)
            {
                SelectedNode = null;
                editingNode = null;
            }
            

        }
        public void OpenSchema(ErSchema schema)
        {
            Nodes.Clear();
            InitializeIconList();

            var newRoot     = AddRoot(schema.name);
            var node        = AddNode(newRoot, "Множества сущностей", 1, 1);
            node            = AddNode(newRoot, "Множества связей", 1, 1);
            node            = AddNode(newRoot, "Множества значений", 1, 1);

            InitializeRootContextMenus(newRoot);

            schemaNodes.Add(newRoot, schema);
            OpenNodes(schema);
            newRoot.Expand();
        }

        public void OpenNodes(ErSchema schema)
        {
            int i = 0;
            foreach (var es in schema.entitySets)
            {
                __AddEntitySetNode(Nodes[0].Nodes[0], es);
                int j = 0;
                foreach (var attr in es.attributes)
                {
                    __AddAttributeNode(Nodes[0].Nodes[0].Nodes[i].Nodes[0], attr);
                    j++;
                }
                j = 0;
                for (j = 0; j < es.roles.Count; j++)
                {
                    __AddRoleNode(Nodes[0].Nodes[0].Nodes[i].Nodes[1], es.roles[j], true);
                }
                i++;
            }
            i = 0;
            foreach (var es in schema.relationshipSets)
            {
                __AddRelationshipSetNode(Nodes[0].Nodes[1], es);
                int j = 0;
                foreach (var attr in es.attributes)
                {
                    __AddAttributeNode(Nodes[0].Nodes[1].Nodes[i].Nodes[0], attr);
                    j++;
                }
                j = 0;
                foreach (var role in es.roles)
                {
                    __AddRoleNode(Nodes[0].Nodes[1].Nodes[i].Nodes[1], role);
                    j++;
                }
                i++;
            }
            i = 0;
            foreach (var es in schema.valueSets)
            {
                __AddValueSetNode(Nodes[0].Nodes[2], es);
                i++;
            }
        }

        public ErSchema GetSchema()
        {
            return schemaNodes[Nodes[0]];
        }

        public void UpdateNodeNames(ErSchema schema)
        {
            int i = 0;
            foreach (var es in schema.entitySets)
            {
                Nodes[0].Nodes[0].Nodes[i].Text = es.name;
                Nodes[0].Nodes[0].Nodes[i].Name = es.name;
                int j = 0;
                foreach(var attr in es.attributes)
                {
                    Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Name = attr.name;
                    Nodes[0].Nodes[0].Nodes[i].Nodes[0].Nodes[j].Text = attr.name;
                    j++;
                }
                j = 0;
                for(j = 0; j < es.roles.Count; j++)
                {
                    if(j < Nodes[0].Nodes[0].Nodes[i].Nodes[1].Nodes.Count)
                    {
                        Nodes[0].Nodes[0].Nodes[i].Nodes[1].Nodes[j].Name = es.roles[j].name;
                        Nodes[0].Nodes[0].Nodes[i].Nodes[1].Nodes[j].Text = es.roles[j].name;
                    }
                    else
                    {
                        __AddRoleNode(Nodes[0].Nodes[0].Nodes[i].Nodes[1], es.roles[j], true);
                    }
                }
                i++;
            }
            i = 0;
            foreach (var es in schema.relationshipSets)
            {
                Nodes[0].Nodes[1].Nodes[i].Name = es.name;
                Nodes[0].Nodes[1].Nodes[i].Text = es.name;
                int j = 0;
                foreach (var attr in es.attributes)
                {
                    Nodes[0].Nodes[1].Nodes[i].Nodes[0].Nodes[j].Name = attr.name;
                    Nodes[0].Nodes[1].Nodes[i].Nodes[0].Nodes[j].Text = attr.name;
                    j++;
                }
                j = 0;
                foreach (var role in es.roles)
                {
                    Nodes[0].Nodes[1].Nodes[i].Nodes[1].Nodes[j].Name = role.name;
                    Nodes[0].Nodes[1].Nodes[i].Nodes[1].Nodes[j].Text = role.name;
                    j++;
                }
                i++;
            }
            i = 0;
            foreach (var es in schema.valueSets)
            {
                Nodes[0].Nodes[2].Nodes[i].Name = es.name;
                Nodes[0].Nodes[2].Nodes[i].Text = es.name;
                i++;
            }
        }

        public void ObsUpdate()
        {
            UpdateNodeNames(schemaNodes[Nodes[0]]);
        }

        private void InitializeIconList()
        {
            var imageList = new ImageList();

            imageList.AddIcon(IconChar.WindowMaximize);         // 0
            imageList.AddIcon(IconChar.Folder, Color.Orange);   // 1
            imageList.AddIcon(IconChar.CodeCompare);            // 2
            imageList.AddIcon(IconChar.E);                      // 3
            imageList.AddIcon(IconChar.R);                      // 4
            imageList.AddIcon(IconChar.V);                      // 5
            imageList.AddIcon(IconChar.Wrench);                 // 6
            imageList.AddIcon(IconChar.UserPlus);               // 7
            imageList.AddIcon(IconChar.ArrowLeft);              // 8

            ImageList = imageList;
        }
        private void InitializeRootContextMenus(TreeNode root) // init schema nodes
        {
            ContextMenuStrip menu;
            //menu = AddContextMenu(root, [ "Переименовать" ], [new EventHandler(BeginRenamingNode)]);

            menu = AddContextMenu(root.Nodes[0], ["Создать"], [new EventHandler(AddEntitySetNode)]);
            menu = AddContextMenu(root.Nodes[1], ["Создать"], [new EventHandler(AddRelationshipSetNode)]);
            menu = AddContextMenu(root.Nodes[2], ["Создать"], [new EventHandler(AddValueSetNode)]);
        }

        new protected void ClickNode(object sender, TreeNodeMouseClickEventArgs e)
        {
            //base.ClickNode(sender, e);
            if (esNodes.ContainsKey(e.Node))
            {
                dialog.ViewElement(esNodes[e.Node]);
            }
            else if(rsNodes.ContainsKey(e.Node))
            {
                dialog.ViewElement(rsNodes[e.Node]);
            }
            else if (vsNodes.ContainsKey(e.Node))
            {
                dialog.ViewElement(vsNodes[e.Node]);
            }
            else if (attrNodes.ContainsKey(e.Node))
            {
                dialog.ViewElement(attrNodes[e.Node]);
            }
            else if (roleNodes.ContainsKey(e.Node))
            {
                dialog.ViewElement(roleNodes[e.Node]);
            }
        }

        private void __AddEntitySetNode(TreeNode parentNode)
        {
            TreeNode newNode; TreeNode childNode; ContextMenuStrip menu;
            newNode = AddNode(parentNode, "", 3, 3);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);
            childNode = AddNode(newNode, "Атрибуты", 1, 1);
            menu = AddContextMenu(childNode, ["Создать"], [new EventHandler(AddAttributeNode)]);
            childNode = AddNode(newNode, "Роли", 2, 2);

            parentNode.Expand();
            newNode.Expand();

            ErEntitySet es = new ErEntitySet();
            es.schema = schemaNodes[parentNode.Parent];
            schemaNodes[parentNode.Parent].entitySets.Add(es);
            esNodes.Add(newNode, es);
            es.Attach(this);
            BeginRenamingNode(newNode);
        }

        private void __AddEntitySetNode(TreeNode parentNode, ErEntitySet es)
        {
            TreeNode newNode; TreeNode childNode; ContextMenuStrip menu;
            newNode = AddNode(parentNode, es.name, 3, 3);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);
            childNode = AddNode(newNode, "Атрибуты", 1, 1);
            menu = AddContextMenu(childNode, ["Создать"], [new EventHandler(AddAttributeNode)]);
            childNode = AddNode(newNode, "Роли", 2, 2);

            parentNode.Expand();
            newNode.Expand();

            esNodes.Add(newNode, es);
            es.Attach(this);
        }

        private void __AddRelationshipSetNode(TreeNode parentNode)
        {
            TreeNode newNode; TreeNode childNode; ContextMenuStrip menu;
            newNode = AddNode(parentNode, "", 4, 4);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);
            childNode = AddNode(newNode, "Атрибуты", 1, 1);
            menu = AddContextMenu(childNode, ["Создать"], [new EventHandler(AddAttributeNode)]);
            childNode = AddNode(newNode, "Роли", 1, 1);
            menu = AddContextMenu(childNode, ["Создать"], [new EventHandler(AddRoleNode)]);

            parentNode.Expand();
            newNode.Expand();

            ErRelationshipSet es = new ErRelationshipSet();
            es.schema = schemaNodes[parentNode.Parent];
            schemaNodes[parentNode.Parent].relationshipSets.Add(es);
            rsNodes.Add(newNode, es);
            es.Attach(this);
            BeginRenamingNode(newNode);
        }

        private void __AddRelationshipSetNode(TreeNode parentNode, ErRelationshipSet es)
        {
            TreeNode newNode; TreeNode childNode; ContextMenuStrip menu;
            newNode = AddNode(parentNode, es.name, 4, 4);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);
            childNode = AddNode(newNode, "Атрибуты", 1, 1);
            menu = AddContextMenu(childNode, ["Создать"], [new EventHandler(AddAttributeNode)]);
            childNode = AddNode(newNode, "Роли", 1, 1);
            menu = AddContextMenu(childNode, ["Создать"], [new EventHandler(AddRoleNode)]);

            parentNode.Expand();
            newNode.Expand();

            rsNodes.Add(newNode, es);
            es.Attach(this);
        }

        private void __AddValueSetNode(TreeNode parentNode)
        {
            TreeNode newNode; TreeNode childNode; ContextMenuStrip menu;
            newNode = AddNode(parentNode, "", 5, 5);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);
            childNode = AddNode(newNode, "Атрибуты", 2, 2);

            parentNode.Expand();
            newNode.Expand();

            ErValueSet es = new ErValueSet();
            es.schema = schemaNodes[parentNode.Parent];
            schemaNodes[parentNode.Parent].valueSets.Add(es);
            vsNodes.Add(newNode, es);
            es.Attach(this);
            BeginRenamingNode(newNode);
        }

        private void __AddValueSetNode(TreeNode parentNode, ErValueSet es)
        {
            TreeNode newNode; TreeNode childNode; ContextMenuStrip menu;
            newNode = AddNode(parentNode, es.name, 5, 5);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);
            childNode = AddNode(newNode, "Атрибуты", 2, 2);

            parentNode.Expand();
            newNode.Expand();

            vsNodes.Add(newNode, es);
            es.Attach(this);
        }

        private void __AddAttributeNode(TreeNode parentNode)
        {
            TreeNode newNode; ContextMenuStrip menu;
            newNode = AddNode(parentNode, "", 6, 6);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);

            parentNode.Expand();
            newNode.Expand();

            ErAttribute es = new ErAttribute();
            if (esNodes.ContainsKey(parentNode.Parent))
            {
                es.schema = esNodes[parentNode.Parent].schema;
                (esNodes[parentNode.Parent]).attributes.Add(es);
            }
            else if (rsNodes.ContainsKey(parentNode.Parent))
            {
                es.schema = rsNodes[parentNode.Parent].schema;
                (rsNodes[parentNode.Parent]).attributes.Add(es);
            }
            attrNodes.Add(newNode, es);
            es.Attach(this);
            BeginRenamingNode(newNode);
        }

        private void __AddAttributeNode(TreeNode parentNode, ErAttribute es)
        {
            TreeNode newNode; ContextMenuStrip menu;
            newNode = AddNode(parentNode, es.name, 6, 6);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);

            parentNode.Expand();
            newNode.Expand();

            attrNodes.Add(newNode, es);
            es.Attach(this);
        }

        private void __AddRoleNode(TreeNode parentNode, bool fake = false)
        {
            TreeNode newNode; ContextMenuStrip menu;
            if (fake)
            {
                newNode = AddNode(parentNode, "", 8, 8);
                parentNode.Expand();
                return;
            }
            
            newNode = AddNode(parentNode, "", 7, 7);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);

            parentNode.Expand();
            newNode.Expand();

            ErRole es = new ErRole();
            es.schema = rsNodes[parentNode.Parent].schema;
            (rsNodes[parentNode.Parent]).roles.Add(es);
            roleNodes.Add(newNode, es);
            es.Attach(this);
            BeginRenamingNode(newNode);
        }

        private void __AddRoleNode(TreeNode parentNode, ErRole es, bool fake = false)
        {
            TreeNode newNode; ContextMenuStrip menu;

            if (fake)
            {
                newNode = AddNode(parentNode, es.name, 8, 8);
                parentNode.Expand();
                return;
            }

            newNode = AddNode(parentNode, es.name, 7, 7);
            menu = AddContextMenu(newNode, ["Переименовать"], [new EventHandler(BeginRenamingNode)]);

            parentNode.Expand();
            newNode.Expand();

            roleNodes.Add(newNode, es);
            es.Attach(this);
        }

    }


}
