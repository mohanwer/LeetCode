using System.Collections.Generic;
using Xunit;

namespace LeetCode.aws.Trees_and_Graphs
{
    // https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
    public partial class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var order = new List<IList<int>>();
            
            void ReadTree(TreeNode node, int depth)
            {
                if (node == null) return;
                
                if (order.Count >= depth)
                    order[depth - 1].Add(node.val);
                else
                    order.Add(new List<int> {node.val});
                var below = depth + 1;
                ReadTree(node.left, below);
                ReadTree(node.right, below);
            }
            
            ReadTree(root, 1);
            return order;
        }

        [Fact]
        public void TestLevelOrder()
        {
            var tree = new TreeNode(3);
            var seven = new TreeNode(7);
            var fifteen = new TreeNode(15);
            var twenty = new TreeNode(20);
            var nine = new TreeNode(9);
            twenty.left = fifteen;
            twenty.right = seven;
            tree.right = twenty;
            tree.left = nine;
            
            var answer = new List<List<int>>();
            answer.Add(new List<int> {3});
            answer.Add(new List<int> {9, 20});
            answer.Add(new List<int> {15, 7});
            
            Assert.Equal(answer, LevelOrder(tree));
        }
    }
}