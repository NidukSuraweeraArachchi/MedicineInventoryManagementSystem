using System;
using MedicineInventoryManagementSystem;

class Program
{
    static void Main()
    {
        MedicineInventoryManager inventory = new MedicineInventoryManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("      MEDICINE INVENTORY SYSTEM   ");
            Console.WriteLine("====================================");
            Console.WriteLine("1  Add Medicine");
            Console.WriteLine("2  Update Medicine Quantity");
            Console.WriteLine("3  Delete Medicine");
            Console.WriteLine("4  Search Medicine");
            Console.WriteLine("5  Show Expiry Alert");
            Console.WriteLine("6  Display All Medicines");
            Console.WriteLine("7  Exit");
            Console.Write(" Enter choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine("------------------------------------");

            switch (choice)
            {
                case "1":
                    Console.Write("\nEnter Medicine Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Batch Number: ");
                    string batch = Console.ReadLine();
                    Console.Write("Enter Expiry Date (yyyy-MM-dd): ");
                    DateTime expiryDate;
                    while (!DateTime.TryParse(Console.ReadLine(), out expiryDate))
                    {
                        Console.Write("Invalid date format. Please enter again (yyyy-MM-dd): ");
                    }
                    Console.Write("Enter Quantity: ");
                    int quantity;
                    while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 1)
                    {
                        Console.Write("Invalid quantity. Please enter a valid number: ");
                    }
                    inventory.AddMedicine(name, batch, expiryDate, quantity);
                    break;

                case "2":
                    Console.Write("\nEnter Batch Number of the Medicine to Update: ");
                    string batchToUpdate = Console.ReadLine();
                    Console.Write("Enter New Quantity: ");
                    int newQuantity;
                    while (!int.TryParse(Console.ReadLine(), out newQuantity) || newQuantity < 0)
                    {
                        Console.Write("Invalid quantity. Please enter a valid number: ");
                    }
                    inventory.UpdateMedicine(batchToUpdate, newQuantity);
                    break;

                case "3":
                    Console.Write("\nEnter Batch Number of the Medicine to Delete: ");
                    string batchToDelete = Console.ReadLine();
                    inventory.DeleteMedicine(batchToDelete);
                    break;

                case "4":
                    Console.Write("\nEnter Medicine Name to Search: ");
                    string searchName = Console.ReadLine();
                    inventory.SearchMedicine(searchName);
                    break;

                case "5":
                    inventory.ExpiryAlert();
                    break;

                case "6":
                    inventory.DisplayAll();
                    break;

                case "7":
                    Console.WriteLine("\n🚪 Exiting the system... Goodbye!");
                    return;

                default:
                    Console.WriteLine("\n❌ Invalid choice! Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
