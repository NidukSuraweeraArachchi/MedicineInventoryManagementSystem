using System;

namespace MedicineInventoryManagementSystem
{
    public class CustomLinkedList
    {
        public Medicine Head { get; private set; }

        public void Add(Medicine newMedicine)
        {
            if (Head == null)
            {
                Head = newMedicine;
            }
            else
            {
                Medicine temp = Head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newMedicine;
            }
        }

        public Medicine Find(string batchNumber)
        {
            Medicine temp = Head;
            while (temp != null)
            {
                if (temp.BatchNumber == batchNumber)
                    return temp;
                temp = temp.Next;
            }
            return null;
        }

        public void Delete(string batchNumber)
        {
            if (Head == null)
            {
                Console.WriteLine("❌ No medicines available.");
                return;
            }

            if (Head.BatchNumber == batchNumber)
            {
                Head = Head.Next;
                Console.WriteLine($"🗑 Medicine with batch number {batchNumber} deleted.");
                return;
            }

            Medicine prev = null, current = Head;
            while (current != null && current.BatchNumber != batchNumber)
            {
                prev = current;
                current = current.Next;
            }

            if (current == null)
            {
                Console.WriteLine("❌ Medicine not found.");
                return;
            }

            prev.Next = current.Next;
            Console.WriteLine($"🗑 Medicine with batch number {batchNumber} deleted.");
        }

        public Medicine[] ToArray()
        {
            if (Head == null)
            {
                return new Medicine[0];
            }

            int count = 0;
            Medicine temp = Head;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }

            Medicine[] arr = new Medicine[count];
            temp = Head;
            for (int i = 0; i < count; i++)
            {
                arr[i] = temp;
                temp = temp.Next;
            }

            return arr;
        }

        public void Display()
        {
            Medicine temp = Head;
            if (temp == null)
            {
                Console.WriteLine("❌ No medicines available.");
                return;
            }

            while (temp != null)
            {
                Console.WriteLine(temp);
                temp = temp.Next;
            }
        }
    }
}
