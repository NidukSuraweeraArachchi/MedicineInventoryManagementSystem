namespace MedicineInventoryManagementSystem
{
    public abstract class BaseInventoryManager
    {
        public abstract void AddMedicine(string name, string batchNumber, DateTime expiryDate, int quantity);
        public abstract void UpdateMedicine(string batchNumber, int newQuantity);
        public abstract void DeleteMedicine(string batchNumber);
        public abstract void SearchMedicine(string name);
        public abstract void DisplayAll();
        public abstract void ExpiryAlert();
        public abstract Medicine[] GetMedicineArray();
    }
}
