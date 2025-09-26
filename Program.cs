using System;

using System.ComponentModel.DataAnnotations;

    class Program
    {
        static string[] slots = new string[100]; // Array to hold slot values 
        static string[] v(string s) => string.IsNullOrEmpty(s) ? Array.Empty<string>() : s.Split('|'); // Split slot string into vehicles
        static bool Empty(int i) => string.IsNullOrEmpty(slots[i]); // Check if slot is empty
        static bool IsCar(int i) => !Empty(i) && slots[i].StartsWith("CÀR#");  // Check if slot contains a car
        static bool IsMc(int i) => !Empty(i) && slots[i].StartsWith("MC"); // Check if slot contains a Mc
        static string Enc(char t, string plate) => (t == 'C' ? "CAR#" : "MC#") + plate; // Encode vehicle string
        static char TypeOf(string v) => v.StartsWith("CAR#") ? 'C' : 'M'; // Find type of vehicle: 'C' for car, 'M' for MC
        static string Plateof(string v) => v.Substring(v.IndexOf("#") + 1); // Extract plate number
        static string N(string s) => (s ?? "").Trim().ToUpperInvariant(); // Normalize plate, trim spaces, make uppercase
        static bool ValidPlate(string p) => p.Length >= 1 && p.Length <= 10 && p.All(char.IsLetterOrDigit);// Validate plate: 1–10 letters or digits
        static bool FindPlate(string plate, out int slot, out int pos) // Method to find plate
    {
        plate = N(plate); // Normalize for consistent comparison
        for (int i = 0; i < slots.Length; i++) // Scans all 100 slots
        {
            var items = v(slots[i]); // Split current slot into vehicles
            for (int j = 0; j < items.Length; j++) // Scan vehicles in this slot
                if (Plateof(items[j]).Equals(plate, StringComparison.OrdinalIgnoreCase)) 
                { slot = i; pos = j; return true; } // Found -> return position
        }
        slot = pos = -1; return false; // not found
    }
        static int FirstEmpty()
    {
        for (int i = 0; i < slots.Length; i++)
            if (IsMc(i) && v(slots[i]).Length == 1) return i;
        return -1; 
    }

}
