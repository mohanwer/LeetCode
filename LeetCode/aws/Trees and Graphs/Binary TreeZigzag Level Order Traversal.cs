using System.Collections.Generic;

namespace LeetCode.aws.Trees_and_Graphs
{
    public partial class Solution
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var order = new List<IList<int>>();
            
            void ReadTree(TreeNode node, int depth)
            {
                if (node == null) return;

                if (order.Count >= depth)
                {
                    if (depth % 2 == 0)
                        order[depth - 1].Insert(0, node.val);
                    else
                        order[depth - 1].Add(node.val);
                }
                else
                {
                    order.Add(new List<int> {node.val});
                }
                    
                var below = depth + 1;
                ReadTree(node.left, below);
                ReadTree(node.right, below);    
            }
            
            ReadTree(root, 1);
            return order;
        }
    }
}