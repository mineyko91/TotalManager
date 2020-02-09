using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class TotalManager : Form
    {
        public TotalManager()
        {
            InitializeComponent();
            FillTreeNode(treeView1, GetDriveNodes());
        }

        private static void FillTreeNode(TreeView tree, TreeNode[] nodes)
        {
            foreach (TreeNode n in nodes)
            {
                FillNodesToNode(tree.Nodes.Add(n.Text));
            }
        }

        private static void FillNode(TreeNode node, List<string> nodes)
        {
            node.Nodes.Clear();

            foreach (string n in nodes)
            {
                TreeNode newNode = new TreeNode(n);
                FillNodesToNode(node.Nodes.Add(n));
            }
        }

        private static void FillNodesToNode(TreeNode node)
        {
            List<string> dirNodes = GetDirectoryNodes(node.Text);

            foreach (string n in dirNodes)
            {
                node.Nodes.Add(n);
            }
        }

        private static List<string> GetDirectoryNodes(string path)
        {
            List<string> subDirectories = new List<string>();

            try
            {
                subDirectories.AddRange(Directory.GetDirectories(path));
            }
            catch (UnauthorizedAccessException)
            {

            }

            List<string> nodes = new List<string>();

            foreach (string item in subDirectories)
            {
                nodes.Add(item);
            }

            return nodes;
        }

        private TreeNode[] GetDriveNodes()
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            TreeNode[] nodes = new TreeNode[driveInfo.Length];

            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new TreeNode(driveInfo[i].Name);
            }

            return nodes;
        }

        private void TreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            FillNode(e.Node, GetDirectoryNodes(e.Node.Text));
        }
    }
}
