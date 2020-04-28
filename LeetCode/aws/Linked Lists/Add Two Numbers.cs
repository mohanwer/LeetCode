using Xunit;

namespace LeetCode.aws.Linked_Lists
{
    
    
    public partial class Solution
    {
        public class ListNode 
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        // https://leetcode.com/explore/interview/card/amazon/77/linked-list/513/
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var carry = 0;
            var resultListNode = new ListNode(0);
            if (l1 == null && l2 == null) return resultListNode;
            var head = resultListNode;
            
            while (l1 != null || l2 != null)
            {
                var l1Val = l1?.val ?? 0;
                var l2Val = l2?.val ?? 0;
                var sum = l1Val + l2Val + carry;

                if (sum > 9)
                {
                    resultListNode.next = new ListNode(sum - 10);
                    carry = 1;
                }
                else
                {
                    resultListNode.next = new ListNode(sum);
                    carry = 0;
                }

                resultListNode = resultListNode.next;
                l1 = l1?.next;
                l2 = l2?.next;
            }
            if (carry == 1)
                resultListNode.next = new ListNode(1);
            return head.next;
        }

        [Fact]
        public void TestAddTwoNumbers()
        {
            var l1 = new ListNode(9);
            var l2 = new ListNode(1);
            l2.next = new ListNode(9);
            l2.next.next = new ListNode(9);
            AddTwoNumbers(l1, l2);
        }
    }
}