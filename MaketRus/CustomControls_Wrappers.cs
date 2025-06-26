using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErEditorProject
{
    public partial class ExpandedTreeView
    {
        public TreeNode AddRoot(string name, int iconIndex = 0, int selectedIconIndex = 0)
        {
            TreeNode root = new TreeNode();
            root = __AddNode(Nodes, root, name, iconIndex, selectedIconIndex);
            
            return root;
        }

        public TreeNode AddNode(TreeNode parent, string name, int iconIndex = 0, int selectedIconIndex = 0)
        {
            TreeNode node = new TreeNode();
            node = __AddNode(parent.Nodes, node, name, iconIndex, selectedIconIndex);

            return node;
        }
    }

    public partial class NavigatorTree
    {
        public void AddEntitySetNode(ErSchema schema)
        {
            //TreeNode? parentNode = GetErSchemaNode(schema);
            //if (parentNode == null)
            //{
            //    return;
            //}
            //parentNode = parentNode.Nodes[0]; // entity set folder
            TreeNode parentNode = Nodes[0];
            __AddEntitySetNode(parentNode);
        }

        /*public void AddEntitySetNode(DataNode<ErSchema> schemaNode)
        {
            TreeNode parentNode = schemaNode.Nodes[0]; // entity set folder
            __AddEntitySetNode(parentNode);
        }*/

        private void AddEntitySetNode(object sender, EventArgs e)
        {
            __AddEntitySetNode(SelectedNode);
        }

        private void AddRelationshipSetNode(object sender, EventArgs e)
        {
            __AddRelationshipSetNode(SelectedNode);
        }

        private void AddValueSetNode(object sender, EventArgs e)
        {
            __AddValueSetNode(SelectedNode);
        }

        private void AddAttributeNode(object sender, EventArgs e)
        {
            __AddAttributeNode(SelectedNode);
        }

        private void AddRoleNode(object sender, EventArgs e)
        {
            __AddRoleNode(SelectedNode);
        }
    }
}
