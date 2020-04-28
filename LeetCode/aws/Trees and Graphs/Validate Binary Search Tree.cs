using System;

namespace LeetCode.aws.Trees_and_Graphs
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    
    public partial class Solution
    {
        // https://leetcode.com/problems/validate-binary-search-tree/
        public bool RootCheck(TreeNode root, long floor = long.MinValue, long ceiling = long.MaxValue) 
        {
            if (root == null) return true;
            if (floor >= root.val || ceiling <= root.val) return false;
            return RootCheck(root.left, floor, Math.Min(ceiling, root.val)) &&
                   RootCheck(root.right, Math.Max(floor, root.val), ceiling);
        }
    
        public bool IsValidBST(TreeNode root) 
        {
            if (root == null) return true;
            return RootCheck(root);
        }
    }
}