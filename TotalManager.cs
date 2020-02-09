using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            FillTreeNode(treeView1, GetDirectoryNodes(@"D:\MUSIC\"));
        }

        private static void FillTreeNode(TreeView tree, TreeNode[] nodes)
        {
            foreach (TreeNode n in nodes)
            {
                FillNodesToNode(tree.Nodes.Add(n.Text));
            }
        }

        private static void FillNode(TreeNode node, TreeNode[] nodes)
        {
            node.Nodes.Clear();

            foreach (TreeNode n in nodes)
            {
                FillNodesToNode(node.Nodes.Add(n.Text));
            }
        }

        private static void FillNodesToNode(TreeNode node)
        {
            TreeNode[] dirNodes = GetDirectoryNodes(node.Text);

            foreach (TreeNode n in dirNodes)
            {
                node.Nodes.Add(n);
            }
        }


        private static TreeNode[] GetDirectoryNodes(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] subDirectories = directory.GetDirectories();

            TreeNode[] nodes = new TreeNode[subDirectories.Length];

            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new TreeNode(subDirectories[i].FullName);
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
