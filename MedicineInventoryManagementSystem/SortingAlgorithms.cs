namespace MedicineInventoryManagementSystem
{
    public static class SortingAlgorithms
    {
        public static void BubbleSort(Medicine[] medicines)
        {
            int n = medicines.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (medicines[j].ExpiryDate > medicines[j + 1].ExpiryDate)
                    {
                        Medicine temp = medicines[j];
                        medicines[j] = medicines[j + 1];
                        medicines[j + 1] = temp;
                    }
                }
            }
        }
    }
}
