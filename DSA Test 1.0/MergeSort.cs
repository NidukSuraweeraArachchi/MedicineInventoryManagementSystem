using System;

namespace InventoryManagementSystem
{
    public static class MergeSort
    {
        public static Item Sort(Item head)
        {
            if (head == null || head.Next == null)
                return head;

            Item middle = GetMiddle(head);
            Item nextToMiddle = middle.Next;
            middle.Next = null;

            Item left = Sort(head);
            Item right = Sort(nextToMiddle);

            return Merge(left, right);
        }

        // ✅ Merge Two Sorted Linked Lists (Sort by Quantity DESCENDING)
        private static Item Merge(Item left, Item right)
        {
            if (left == null) return right;
            if (right == null) return left;

            // ✅ Sorting by QUANTITY (Highest first)
            if (left.Quantity >= right.Quantity)
            {
                left.Next = Merge(left.Next, right);
                return left;
            }
            else
            {
                right.Next = Merge(left, right.Next);
                return right;
            }
        }

        // ✅ Get the Middle of the Linked List
        private static Item GetMiddle(Item head)
        {
            if (head == null) return head;

            Item slow = head, fast = head.Next;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }
    }
}
