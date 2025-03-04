namespace MedicineInventoryManagementSystem
{
    public class Medicine
    {
        public string Name { get; private set; }
        public string BatchNumber { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public int Quantity { get; private set; }
        public Medicine Next { get; set; }

        public Medicine(string name, string batchNumber, DateTime expiryDate, int quantity)
        {
            Name = name;
            BatchNumber = batchNumber;
            ExpiryDate = expiryDate;
            Quantity = quantity;
            Next = null;
        }

        public void UpdateQuantity(int quantity) => Quantity = quantity;

        public override string ToString()
        {
            return $"{Name} (Batch: {BatchNumber}, Expiry: {ExpiryDate.ToShortDateString()}, Quantity: {Quantity})";
        }
    }
}
