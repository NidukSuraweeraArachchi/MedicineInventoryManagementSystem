using System;
using System.Collections.Generic;
using System.IO;

namespace MedicineInventoryManagementSystem
{
    public class MedicineInventoryManager : BaseInventoryManager
    {
        private List<Medicine> medicineList = new List<Medicine>();
        private const string filePath = "medicines.txt";

        public MedicineInventoryManager()
        {
            LoadMedicinesFromFile();
        }

        public override void AddMedicine(string name, string batchNumber, DateTime expiryDate, int quantity)
        {
            Medicine newMedicine = new Medicine(name, batchNumber, expiryDate, quantity);
            medicineList.Add(newMedicine);
            SaveMedicinesToFile();
            Console.WriteLine($"✅ Medicine '{name}' added successfully.");
        }

        public override void UpdateMedicine(string batchNumber, int newQuantity)
        {
            foreach (var med in medicineList)
            {
                if (med.BatchNumber == batchNumber)
                {
                    med.UpdateQuantity(newQuantity);
                    SaveMedicinesToFile();
                    Console.WriteLine($"✅ Updated: {med}");
                    return;
                }
            }
            Console.WriteLine("❌ Medicine not found.");
        }

        public override void DeleteMedicine(string batchNumber)
        {
            medicineList.RemoveAll(med => med.BatchNumber == batchNumber);
            SaveMedicinesToFile();
            Console.WriteLine($"✅ Medicine with batch number {batchNumber} deleted.");
        }

        public override void SearchMedicine(string name)
        {
            Console.WriteLine("\n🔍 Searching for medicine...");
            bool found = false;

            foreach (var med in medicineList)
            {
                if (med.Name.ToLower().Contains(name.ToLower()))
                {
                    Console.WriteLine(med);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("❌ Medicine not found.");
            }
        }

        public override void DisplayAll()
        {
            Console.WriteLine("\n📋 Medicine Inventory:");
            foreach (var med in medicineList)
            {
                Console.WriteLine(med);
            }
        }

        public override void ExpiryAlert()
        {
            Console.WriteLine("\n⏳ Checking for expired medicines...");
            DateTime today = DateTime.Today;
            bool hasExpired = false;

            foreach (var med in medicineList)
            {
                if (med.ExpiryDate < today)
                {
                    Console.WriteLine($"⚠️ ALERT: {med.Name} (Batch: {med.BatchNumber}) has expired!");
                    hasExpired = true;
                }
            }

            if (!hasExpired)
            {
                Console.WriteLine("✅ No expired medicines.");
            }
        }

        public override Medicine[] GetMedicineArray()
        {
            return medicineList.ToArray();
        }

        private void SaveMedicinesToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var med in medicineList)
                {
                    writer.WriteLine($"{med.Name},{med.BatchNumber},{med.ExpiryDate:yyyy-MM-dd},{med.Quantity}");
                }
            }
        }

        private void LoadMedicinesFromFile()
        {
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string name = parts[0];
                    string batchNumber = parts[1];
                    DateTime expiryDate = DateTime.Parse(parts[2]);
                    int quantity = int.Parse(parts[3]);

                    medicineList.Add(new Medicine(name, batchNumber, expiryDate, quantity));
                }
            }
        }
    }
}
