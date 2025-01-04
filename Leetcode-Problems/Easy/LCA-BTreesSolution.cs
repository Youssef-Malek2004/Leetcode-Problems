namespace Leetcode_Problems.Easy;

public class LCA_BTreesSolution
{
   public class BinaryTreeNode<T> {
        public T data;
        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;

        public BinaryTreeNode(T data) {
            this.data = data;
        }
    }

    public class Solution
    {
        public int at { get; set; }
    }
   
    public BinaryTreeNode<int> lcaOfThreeNodes(BinaryTreeNode<int> root, int node1, int node2,
        int node3)
    {

        var solution = lcaOfThreeNodesHelper(root, node1, node2, node3);
        
        return new BinaryTreeNode<int>(solution.at);
    }
    
    public Solution lcaOfThreeNodesHelper(BinaryTreeNode<int> node, int node1, int node2,
        int node3)
    {
        if (node == null) 
            return new Solution
            {
                at = -1
            };

        var node1Left = findNode(node.left,node1);
        var node2Left = findNode(node.left, node2);
        var node3Left = findNode(node.left, node3);

        if (node1Left && node2Left && node3Left)
            return lcaOfThreeNodesHelper(node.left, node1, node2, node3);
        if(!node1Left && !node2Left && !node3Left)
            return lcaOfThreeNodesHelper(node.right, node1, node2, node3);
        
        return new Solution
        {
            at = node.data
        };
    }

    public bool findNode(BinaryTreeNode<int> rootNode, int node)
    {
        if (rootNode == null) return false;

        if (rootNode.data == node) return true;
        
        return findNode(rootNode.left, node) || findNode(rootNode.right, node);
    }
}