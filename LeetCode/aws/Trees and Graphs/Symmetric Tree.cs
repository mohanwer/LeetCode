namespace LeetCode.aws.Trees_and_Graphs
{
    public partial class Solution
    {
        public bool IsEqual(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            else if (left == null ^ right == null) return false;
            else if (left.val != right.val) return false;
            else return IsEqual(left.right, right.left) && IsEqual(left.left, right.right);
        }
        
        //https://leetcode.com/explore/interview/card/amazon/78/trees-and-graphs/507/
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return IsEqual(root.left, root.right);
        }
    }
}