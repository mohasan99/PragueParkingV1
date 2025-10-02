using System;
using System.Linq;

string[] slots = new string[100]; // Array of 100 strings(slots)
string[] Vehicles(string slot) => string.IsNullOrEmpty(slot) ? Array.Empty<string>() : slot.Split('|'); // Split slot to vehicles
string EncodeVehicle(char type, string plate) => (type == 'C' ? "CAR#" : "MC#") + plate; // Encode vehicle type and plate
string NormalizePlate(string plate) => (plate ?? "").Trim().ToUpperInvariant(); // Normalize plate, null to empty, trim, uppercase
bool ValidPlate(string plate) => plate.Length >= 1 && plate.Length <= 10 && plate.All(char.IsLetterOrDigit); // Plate validation
bool IsSlotEmpty(int index) => string.IsNullOrEmpty(slots[index]);// Check if slot is empty
bool IsCarSlot(int index) => !IsSlotEmpty(index) && slots[index].StartsWith("CAR#"); // Check if slot has a car
bool isMcSlot(int index) => !IsSlotEmpty(index) && slots[index].StartsWith("MC#"); // Check if slot has a motorcycle
bool FindPlate(string plate, out int slot) // Search for a plate in all slots
{
    plate = NormalizePlate(plate); // Normalize plate, trim spaces, uppercase
    for (int i = 0; i < slots.Length; i++) // Loops through all slots
    {
        if (!string.IsNullOrEmpty(slots[i]) && slots[i].Contains(plate, StringComparison.OrdinalIgnoreCase))
        {
            slot = i;
            return true; // Found plate
        }
    }
    slot = -1;
    return false; // Not found plate
}

int FirstEmpty()
{ 
    for (int i = 0; i <slots.Length; i++)
        if (string.IsNullOrEmpty(slots[i])) return i; // Return first empty slot index
    return -1; // No empty slots
}

int FirstSingleMc()
{ 
 for(int i = 0; i < slots.Length; i++)
    {
        var slot = slots[i];
        if (!string.IsNullOrEmpty(slot) && slot.StartsWith("MC#") && Vehicles(slot).Length == 1)
                return i;
    }
return -1; // No single motorcycle slots
}

bool Park(char type, string plate, out string message)
{
    plate = NormalizePlate(plate); // Normalize plate, trim spaces, uppercase

    if (!ValidPlate(plate))
    { message = "Invalid plate. Must be 1-10 alphanumeric characters."; return false; } // Invalid plate
    if (FindPlate(plate out_))

    { message = $"Vehicle already parked"; return false; } // Plate already parked
    if (type == 'C')
    { int i = FirstEmpty();
        if (i == -1) { message = "No free slots for cars."; return false; } // No empty slots
        slots[i] = EncodeVehicle('C', plate);
        message = $"Car parked in slot {i + 1}."; return true; // Car parked
    }
    