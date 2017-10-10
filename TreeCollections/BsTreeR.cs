using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeCollections
{
    public class BsTreeR : ITree
    {
        protected class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node(int val)
            {
                this.val = val;
            }
        }

        protected Node root = null;

        public void Init(int[] ini)
        {
            if (ini == null)
                return;

            Clear();
            for (int i = 0; i < ini.Length; i++)
            {
                Add(ini[i]);
            }
        }

        #region Add
        public void Add(int val)
        {
            AddNode(ref root, val);
        }
        private void AddNode(ref Node node, int val)
        {
            if (node == null)
            {
                node = new Node(val);
                return;
            }
            
            if (val < node.val)
            {
                AddNode(ref node.left, val);
            }
            else if (val > node.val)
            {
                AddNode(ref node.right, val);
            }
        }
        #endregion

        #region Del

        //DelRightReplace

        private Node FindNode(Node node, int val)
        {
            if (node == null || val == node.val)
                return node;
            if (val < node.val)
                return FindNode(node.left, val);
            else
                return FindNode(node.right, val);
        }

        private void DeleteRightReplaceNode(ref Node node, int val)
        {
            if (node == null)
                return;

            if (val < node.val)
            {
                DeleteRightReplaceNode(ref node.left, val);
            }
            else if (val > node.val)
            {
                DeleteRightReplaceNode(ref node.right, val);
            }
            else if (node.left != null && node.right != null) 
            {
                node.val = Min(node.right).val;
                DeleteRightReplaceNode(ref node.right, node.val);
            }
            else
            {
                if (node.left != null)
                    node = node.left;
                else
                    node = node.right;
            }
        }


        public void DelRightReplace(int val)
        {
            if (root == null)
                throw new EmptyTreeEx();
            if (FindNode(root, val) == null)
                throw new ValueNotFoundEx();
            if (Size() == 1)
                root = null;

            DeleteRightReplaceNode(ref root, val);
        }

        private Node Min(Node node)
        {
            if (node.left == null)
                return node;

            return Min(node.left);
        }


        // DelLeftReplace

        private void DeleteLeftReplaceNode(ref Node node, int val)
        {
            if (node == null)
                return;

            if (val < node.val)
            {
                DeleteLeftReplaceNode(ref node.left, val);
            }
            else if (val > node.val)
            {
                DeleteLeftReplaceNode(ref node.right, val);
            }
            else if (node.left != null && node.right != null)
            {
                node.val = Max(node.left).val;
                DeleteLeftReplaceNode(ref node.left, node.val);
            }
            else
            {
                if (node.right != null)
                    node = node.right;
                else
                    node = node.left;
            }
        }


        public void DelLeftReplace(int val)
        {
            if (root == null)
                throw new EmptyTreeEx();
            if (FindNode(root, val) == null)
                throw new ValueNotFoundEx();
            if (Size() == 1)
                root = null;

            DeleteLeftReplaceNode(ref root, val);
        }

        private Node Max(Node node)
        {
            if (node.right == null)
                return node;

            return Max(node.right);
        }

        // DelRightRotate

        public void DelRightRotate(int val)
        {
            if (root == null)
                throw new EmptyTreeEx();
            if (FindNode(root, val) == null)
                throw new ValueNotFoundEx();
            if (Size() == 1)
                root = null;
            DelRightRotateNode(ref root, val);
        }
        private void DelRightRotateNode(ref Node node, int val)
        {
            if (node == null)
                return;

            if (val < node.val)
            {
                DelRightRotateNode(ref node.left, val);
            }      
            else if(val > node.val)
            {
                DelRightRotateNode(ref node.right, val);
            }
            else if(node.left != null && node.right != null)
            {
                Node rmin = Min(node.right);
                rmin.left = node.left.right;
                node.val = node.left.val;
                node.left = node.left.left;
            }
            else
            {
                if (node.right != null)
                    node = node.right;
                else
                    node = node.left;
            }                 
        }

        // DelLeftRotate

        public void DelLeftRotate(int val)
        {
            if (root == null)
                throw new EmptyTreeEx();
            if (FindNode(root, val) == null)
                throw new ValueNotFoundEx();
            if (Size() == 1)
                root = null;
            DelLeftRotateNode(ref root, val);
        }
        private void DelLeftRotateNode(ref Node node, int val)
        {
            if (node == null)
                return;

            if (val < node.val)
            {
                DelLeftRotateNode(ref node.left, val);
            }
            else if (val > node.val)
            {
                DelLeftRotateNode(ref node.right, val);
            }
            else if (node.left != null && node.right != null)
            {
                Node rmax = Max(node.left);
                rmax.right = node.right.left;
                node.val = node.right.val;
                node.right = node.right.right;
            }
            else
            {
                if (node.right != null)
                    node = node.right;
                else
                    node = node.left;
            }
        }
        #endregion

        #region Height
        public int Height()
        {
            return GetHeight(root);
        }
        private int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
        }
        #endregion

        #region Width
        public int Width()
        {
            if (root == null)
                return 0;

            int[] ret = new int[Height()];
            GetWidth(root, ret, 0);
            return ret.Max();
        }
        private void GetWidth(Node node, int[] levels, int level)
        {
            if (node == null)
                return;

            GetWidth(node.left, levels, level + 1);
            levels[level]++;
            GetWidth(node.right, levels, level + 1);
        }
        #endregion

        #region Leaves
        public int Leaves()
        {
            return GetLeaves(root);
        }
        private int GetLeaves(Node node)
        {
            if (node == null)
                return 0;

            int leaves = 0;
            leaves += GetLeaves(node.left);
            if (node.left == null && node.right == null)
                leaves++;
            leaves += GetLeaves(node.right);
            return leaves;
        }
        #endregion

        #region Nodes
        public int Nodes()
        {
            return GetNodes(root);
        }
        private int GetNodes(Node node)
        {
            if (node == null)
                return 0;

            int nodes = 0;
            nodes += GetNodes(node.left);
            if (node.left != null || node.right != null)
                nodes++;
            nodes += GetNodes(node.right);
            return nodes;
        }
        #endregion

        #region Reverse
        public void Reverse()
        {
            SwapSides(root);
        }
        private void SwapSides(Node node)
        {
            if (node == null)
                return;

            SwapSides(node.left);
            Node temp = node.right;
            node.right = node.left;
            node.left = temp;
            SwapSides(node.left);
        }
        #endregion

        #region Size
        public int Size()
        {
            return GetSize(root);
        }
        private int GetSize(Node node)
        {
            if (node == null)
                return 0;

            int count = 0;
            count += GetSize(node.left);
            count++;
            count += GetSize(node.right);
            return count;
        }
        #endregion

        #region ToArray
        public int[] ToArray()
        {
            if (root == null)
                return new int[] { };

            int[] ret = new int[Size()];
            int i = 0;
            NodeToArray(root, ret, ref i);
            return ret;


        }
        private void NodeToArray(Node node, int[] ini, ref int n)
        {
            if (node == null)
                return;

            NodeToArray(node.left, ini, ref n);
            ini[n++] = node.val;
            NodeToArray(node.right, ini, ref n);

        }
        #endregion

        #region ToString
        public override String ToString()
        {
            return NodeToString(root).TrimEnd(new char[] { ',', ' ' });
        }

        private String NodeToString(Node node)
        {
            if (node == null)
                return "";

            String str = "";
            str += NodeToString(node.left);
            str += node.val + ", ";
            str += NodeToString(node.right);
            return str;
        }

        public void Clear()
        {
            root = null;
        }
        #endregion

        #region Equal

        public bool Equal(ITree tree)
        {
            return CompareNodes(root, (tree as BsTreeR).root);
        }

        private bool CompareNodes(Node curTree, Node tree)
        {
            if (curTree == null && tree == null)
                return true;
            if (curTree == null || tree == null)
                return false;

            bool equal = true;
            equal &= CompareNodes(curTree.left, tree.left);
            equal &= (curTree.val == tree.val);
            equal &= CompareNodes(curTree.right, tree.right);
            return equal;
        }

        #endregion
    }
}
