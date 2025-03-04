using System;

namespace MedicineInventoryManagementSystem
{
    public class CustomPriorityQueue
    {
        private class Node
        {
            public Medicine Medicine;
            public Node Next;

            public Node(Medicine medicine)
            {
                Medicine = medicine;
                Next = null;
            }
        }

        private Node head;

        public void Enqueue(Medicine medicine)
        {
            Node newNode = new Node(medicine);

            if (head == null || head.Medicine.ExpiryDate > medicine.ExpiryDate)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node temp = head;
                while (temp.Next != null && temp.Next.Medicine.ExpiryDate <= medicine.ExpiryDate)
                {
                    temp = temp.Next;
                }
                newNode.Next = temp.Next;
                temp.Next = newNode;
            }
        }

        public Medicine Peek()
        {
            return head?.Medicine;
        }
    }
}
