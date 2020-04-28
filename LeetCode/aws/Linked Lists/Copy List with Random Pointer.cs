using System.Collections.Generic;

namespace LeetCode.aws.Linked_Lists
{
    public class Node 
    {
        public int val;
        public Node next;
        public Node random;
    
        public Node(int _val) {
            val = _val;
            next = null;
            random = null;
        }
    }

    public partial class Solution
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;
            Node root = null, newNode, node = head;
            Dictionary<Node, Node> dictionary = new Dictionary<Node, Node>();

            while (node != null)
            {
                newNode = new Node(0);
                newNode.val = node.val;
                newNode.random = node.random;
                if (root == null) root = newNode;
                dictionary.Add(node, newNode);
                node = node.next;
            }

            node = root;
            while (node != null)
            {
                if (node.random != null)
                    node.random = dictionary[node.random];
                if (node.next != null)
                    node.next = dictionary[node.next];
                node = node.next;
            }

            return root;
        }
    }
}