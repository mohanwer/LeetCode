namespace LeetCode.aws.Linked_Lists
{
    // https://leetcode.com/problems/reverse-nodes-in-k-group/
    public partial class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k) 
        {
            if (head == null)
            {
                return null;
            }

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            int count = 0;
            ListNode pre = dummy;
            ListNode cur = head;
            while (cur != null)
            {
                count++;
                ListNode next = cur.next;
                if (count == k)
                {
                    pre = reverse(pre, next);
                    count = 0;
                }
                cur = next;
            }
            return dummy.next;
        }

        private  ListNode reverse(ListNode pre, ListNode end)
        {
            if (pre == null || pre.next == null)
                return pre;

            ListNode head = pre.next;
            ListNode cur = pre.next.next;
            while (cur != end)
            {
                ListNode next = cur.next;
                cur.next = pre.next;
                pre.next = cur;
                cur = next;
            }

            head.next = end;
            return head;
        }  
    }
}