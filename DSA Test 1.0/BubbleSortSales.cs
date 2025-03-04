using System;

namespace InventoryManagementSystem
{
    public static class BubbleSortSales
    {
        public static void SortByTotalPrice(CheckedOutItems salesList)
        {
            if (salesList.Head == null || salesList.Head.Next == null) return;

            bool swapped;
            do
            {
                swapped = false;
                CheckedOutItems.CheckedOutNode prev = null;
                CheckedOutItems.CheckedOutNode current = salesList.Head;
                CheckedOutItems.CheckedOutNode next = current.Next;

                while (next != null)
                {
                    double currentTotal = current.Quantity * current.Price;
                    double nextTotal = next.Quantity * next.Price;

                    if (currentTotal < nextTotal) // 🔹 Swap nodes
                    {
                        if (prev == null) // Swapping Head node
                        {
                            salesList.Head = next;
                        }
                        else
                        {
                            prev.Next = next;
                        }

                        current.Next = next.Next;
                        next.Next = current;

                        // 🔹 Update Pointers
                        prev = next;
                        next = current.Next;
                        swapped = true;
                    }
                    else
                    {
                        prev = current;
                        current = next;
                        next = next.Next;
                    }
                }
            } while (swapped);
        }
    }
}
