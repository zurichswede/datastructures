using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace googlepractice1.DataStructures
{

    public class binaryTreeNode<T> where T:IComparable
    {
        public T nodeValue { get; }
        public binaryTreeNode<T> leftChild { get; private set; }
        public binaryTreeNode<T> rightChild { get; private set; }

        public binaryTreeNode(T valuetoset)
        {
            nodeValue = valuetoset;
            this.leftChild = null;
            this.rightChild = null;
        }

        /// <summary>
        /// creates binary search tree
        /// </summary>
        /// <param name="node"></param>
        public void insertNode(T node)
        {
            //if value<=this.value and this.left_child!=null
            if((this.leftChild!=null)&&(node.CompareTo(this.nodeValue)<=0))
            {
                //insert on left side
                this.leftChild.insertNode(node);
            } // value<=self.value
            else if(node.CompareTo(this.nodeValue) <= 0)
            {
                //assign as left child
                this.leftChild = new binaryTreeNode<T>(node);
            }
            //value>self.value and we have a right child, insert of right side
            else if((this.rightChild!=null)&&(node.CompareTo(this.nodeValue)>0))
            {
                //insert on right side
                this.rightChild.insertNode(node);
            }
            else
            {
                //assign as right child
                this.rightChild = new binaryTreeNode<T>(node);
            }
        }

        /// <summary>
        /// Searches in binary search tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool findNode(T node)
        {
            if((this.leftChild!=null)&&(node.CompareTo(this.nodeValue)<0))
            {
                //value is smaller, look at the left side
                return this.leftChild.findNode(node);
            }

            if((this.rightChild!=null)&& (node.CompareTo(this.nodeValue) > 0))
            {
                //value is larger, look at the right side
                return this.rightChild.findNode(node);
            }

            //not smaller, not larger, same?
            return (node.CompareTo(this.nodeValue) == 0);
            

        }

        public string printTree(TreePrintOrder treePrintOrder)
        {
            StringBuilder result = new StringBuilder();
            
            switch(treePrintOrder)
            {
                case TreePrintOrder.Ascending:
                    printAscendingInternal(this, ref result);
                    break;
                case TreePrintOrder.DFS_PREORDER:
                    printDFSPreorder(this, ref result);
                    break;
                case TreePrintOrder.BFS:
                    printBFS(this, ref result);
                    break;
                default:
                    break;
            }
            
            return result.ToString();
        }

        public List<T> getTreeAsList()
        {
            List<T> result = new List<T>();

            getTreeAsListInternal(this, result);

            return result;
        }

        private void getTreeAsListInternal(binaryTreeNode<T> node, List<T> result)
        {
            if (node != null)
            {
                getTreeAsListInternal(node.leftChild, result);
                result.Add(node.nodeValue);
                getTreeAsListInternal(node.rightChild, result);

            }
        }

        private void printBFS(binaryTreeNode<T> node, ref StringBuilder result)
        {
            Queue<binaryTreeNode<T>> queue = new Queue<binaryTreeNode<T>>();
            queue.Enqueue(node);

            while(queue.Count>0)
            {
                //take out top node
                binaryTreeNode<T> currentnode = queue.Dequeue();

                //print it
                result.AppendLine(currentnode.nodeValue.ToString());

                //add left 
                if(currentnode.leftChild!=null)
                queue.Enqueue(currentnode.leftChild);
                //add right

                if(currentnode.rightChild!=null)
                queue.Enqueue(currentnode.rightChild);

            }

        }

        private void printDFSPreorder(binaryTreeNode<T> node, ref StringBuilder result)
        {
            result.AppendLine(node.nodeValue.ToString());

            if(node.leftChild!=null)
            {
                printDFSPreorder(node.leftChild, ref result);
            }

            if(node.rightChild!=null)
            {
                printDFSPreorder(node.rightChild, ref result);
            }

        }

        private void printAscendingInternal(binaryTreeNode<T> node, ref StringBuilder result)
        {
            if(node!=null)
            {
                printAscendingInternal(node.leftChild, ref result);

                result.AppendLine(node.nodeValue.ToString());

                printAscendingInternal(node.rightChild, ref result);
            }
        }

        public void insert_left(T valuetoinsert)
        {
            if (leftChild == null)
            {
                this.leftChild = new binaryTreeNode<T>(valuetoinsert);
            }
            else
            {
                binaryTreeNode<T> newnode = new binaryTreeNode<T>(valuetoinsert);
                newnode.leftChild = this.leftChild;
                this.leftChild = newnode;

            }
        }

        public void insert_right(T valuetoinsert)
        {
            if (rightChild == null)
            {
                this.rightChild = new binaryTreeNode<T>(valuetoinsert);
            }
            else
            {
                binaryTreeNode<T> newnode = new binaryTreeNode<T>(valuetoinsert);
                newnode.rightChild = this.rightChild;
                this.rightChild= newnode;

            }
        }
    }
}
