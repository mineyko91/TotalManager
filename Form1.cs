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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // FillTreeNodes(treeView1, GetDriveNodes());
            FillTreeNodes(treeView2, GetDirectoryNodes(@"D:\Docs"));
        }

        private static void FillTreeNode(TreeView tree, TreeNode node, string path)
        {

        }

        private static void FillTreeNodes(TreeView tree, TreeNode[] nodes)
        {
            foreach (var n in nodes)
            {
                tree.Nodes.Add(n.Text);
                BuildTree(n, "");
            }
        }

        private static void BuildTree(TreeNode node, string path)
        {
            node = new TreeNode(path);

            foreach (TreeNode n in node.Nodes)
            {
                BuildTree(n, Directory.GetCurrentDirectory());
            }
        }



        private static void Method(TreeNode[] nodes)
        {
            foreach (TreeNode item in nodes)
            {
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

        private void TreeView1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
