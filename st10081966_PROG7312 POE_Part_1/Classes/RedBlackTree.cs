using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10081966_PROG7312_POE_Part_1.Classes
{
    //Red Black tree structure from Rudolf Holzhausen Available at: https://myvc.iielearn.ac.za/bbcswebdav/pid-19927521-dt-content-rid-108673489_1/xid-108673489_1
    enum legallyNotColor
    {
        Red,
        Black
    }
    internal class RedBlackTree
    {
        public class Node
        {
            public legallyNotColor colour;
            public Node left;
            public Node right;
            public Node parent;
            public int data;
            public string desc;
            int level;

            public Node(int data) { this.data = data; }
            public Node(legallyNotColor colour) { this.colour = colour; }
            public Node(int data, legallyNotColor colour) { this.data = data; this.colour = colour; }
            public Node(int data, string desc, int level) { this.data = data; this.desc = desc; this.level = level; }
        }
   
        private Node root;

        public RedBlackTree()
        {
        }

        
        private void LeftRotate(Node x)
        {
            if (x == null || x.right == null)
                return;

            Node y = x.right;
            x.right = y.left;

            if (y.left != null)
                y.left.parent = x;

            y.parent = x.parent;

            if (x.parent == null)
                root = y;
            else if (x == x.parent.left)
                x.parent.left = y;
            else
                x.parent.right = y;

            y.left = x;
            x.parent = y;
        }

       
        private void RightRotate(Node Y)
        {

            Node X = Y.left;
            Y.left = X.right;
            if (X.right != null)
            {
                X.right.parent = Y;
            }
            if (X != null)
            {
                X.parent = Y.parent;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            if (Y == Y.parent.right)
            {
                Y.parent.right = X;
            }
            if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }

            X.right = Y;
            if (Y != null)
            {
                Y.parent = X;
            }
        }

        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }
            if (root != null)
            {
                InOrderDisplay(root);
            }
        }

        public Node Find(int key)
        {
            bool isFound = false;
            Node temp = root;
            Node item = null;

            while (!isFound && temp != null)
            {
                if (key < temp.data)
                {
                    temp = temp.left;
                }
                else if (key > temp.data)
                {
                    temp = temp.right;
                }
                else
                {
                    isFound = true;
                    item = temp;
                }
            }

            if (isFound)
            {
                
                return item;
            }
            else
            {
                
                return null;
            }
        }


        public void Insert(int item, string desc, int level)
        {
            Node newItem = new Node(item, desc, level);
            if (root == null)
            {
                root = newItem;
                root.colour = legallyNotColor.Black;
                return;
            }
            Node Y = null;
            Node X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.data < X.data)
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }
            newItem.parent = Y;
            if (Y == null)
            {
                root = newItem;
            }
            else if (newItem.data < Y.data)
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }
            newItem.left = null;
            newItem.right = null;
            newItem.colour = legallyNotColor.Red;
            InsertFixUp(newItem);
        }

       
        private void InOrderDisplay(Node current)
        {
            if (current != null)
            {
                InOrderDisplay(current.left);
                Console.Write("({0}) ", current.data);
                InOrderDisplay(current.right);
            }
        }

    
        private void InsertFixUp(Node item)
        {
            
            while (item != root && item.parent.colour == legallyNotColor.Red)
            {
                
                if (item.parent == item.parent.parent.left)
                {
                    Node Y = item.parent.parent.right;
                    if (Y != null && Y.colour == legallyNotColor.Red)
                    {
                        item.parent.colour = legallyNotColor.Black;
                        Y.colour = legallyNotColor.Black;
                        item.parent.parent.colour = legallyNotColor.Red;
                        item = item.parent.parent;
                    }
                    else 
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }
                        
                        item.parent.colour = legallyNotColor.Black;
                        item.parent.parent.colour = legallyNotColor.Red;
                        RightRotate(item.parent.parent);
                    }

                }
                else
                {
                    
                    Node X = null;

                    X = item.parent.parent.left;
                    if (X != null && X.colour == legallyNotColor.Black)
                    {
                        item.parent.colour = legallyNotColor.Red;
                        X.colour = legallyNotColor.Red;
                        item.parent.parent.colour = legallyNotColor.Black;
                        item = item.parent.parent;
                    }
                    else 
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                       
                        item.parent.colour = legallyNotColor.Black;
                        item.parent.parent.colour = legallyNotColor.Red;
                        LeftRotate(item.parent.parent);

                    }

                }
                root.colour = legallyNotColor.Black;
            }
        }

 
        public void Delete(int key)
        {
            
            Node item = Find(key);
            Node X = null;
            Node Y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            else if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.data = Y.data;
            }
            if (Y.colour == legallyNotColor.Black)
            {
                DeleteFixUp(X);
            }

        }

  
        private void DeleteFixUp(Node X)
        {

            while (X != null && X != root && X.colour == legallyNotColor.Black)
            {
                if (X == X.parent.left)
                {
                    Node W = X.parent.right;
                    if (W.colour == legallyNotColor.Red)
                    {
                        W.colour = legallyNotColor.Black;
                        X.parent.colour = legallyNotColor.Red;
                        LeftRotate(X.parent); 
                        W = X.parent.right; 
                    }
                    if (W.left.colour == legallyNotColor.Black && W.right.colour == legallyNotColor.Black)
                    {
                        W.colour = legallyNotColor.Red; 
                        X = X.parent; 
                    }
                    else if (W.right.colour == legallyNotColor.Black)
                    {
                        W.left.colour = legallyNotColor.Black; 
                        W.colour = legallyNotColor.Red; 
                        RightRotate(W); 
                        W = X.parent.right; 
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = legallyNotColor.Black; 
                    W.right.colour = legallyNotColor.Black; 
                    LeftRotate(X.parent);
                    X = root;
                }
                else 
                {
                    Node W = X.parent.left;
                    if (W.colour == legallyNotColor.Red)
                    {
                        W.colour = legallyNotColor.Black;
                        X.parent.colour = legallyNotColor.Red;
                        RightRotate(X.parent);
                        W = X.parent.left;
                    }
                    if (W.right.colour == legallyNotColor.Black && W.left.colour == legallyNotColor.Black)
                    {
                        W.colour = legallyNotColor.Black;
                        X = X.parent;
                    }
                    else if (W.left.colour == legallyNotColor.Black)
                    {
                        W.right.colour = legallyNotColor.Black;
                        W.colour = legallyNotColor.Red;
                        LeftRotate(W);
                        W = X.parent.left;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = legallyNotColor.Black;
                    W.left.colour = legallyNotColor.Black;
                    RightRotate(X.parent);
                    X = root;
                }
            }
            if (X != null)
                X.colour = legallyNotColor.Black;
        }

 

        private Node Minimum(Node X)
        {
            while (X.left.left != null)
            {
                X = X.left;
            }
            if (X.left.right != null)
            {
                X = X.left.right;
            }
            return X;
        }

 
        private Node TreeSuccessor(Node X)
        {
            if (X.left != null)
            {
                return Minimum(X);
            }
            else
            {
                Node Y = X.parent;
                while (Y != null && X == Y.right)
                {
                    X = Y;
                    Y = Y.parent;
                }
                return Y;
            }
        }

    }
}

