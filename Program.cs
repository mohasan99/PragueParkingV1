using System;
using System.Collections.Generic;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

string[] Slots = new string[100]; // Array to hold 100 parking slots
string[] Vehicles(string slot) // Function to get vehicles in a slot
{
    if (string.IsNullOrEmpty(slot))
        return Array.Empty<string>();
            return slot.Split('|');  
}
string EncodeVehicle(char type, string plate)   //Encode vehicles
{
    if (type == 'C')
        return "Car#" + plate;
    else                                     
        return "MC#" + plate;
}
string NormalizePlate( string plate)// Normalize plate, trim and uppercase
{
    if (plate == null)
        return "";                       
    return plate.Trim().ToUpper();
}
bool ValidPlate(string plate) // Validate plate format
{
    if (plate.Length < 1 || plate.Length > 10)
        return false;

    if (!plate.All(char.IsLetterOrDigit))
        return false;

    return true;
}
string PlateOf(string vehicle) // Extract plate from encoded vehicle
{
    int index = vehicle.IndexOf('#');
    if (index == -1) return vehicle; 
    return vehicle.Substring(index + 1);
}
int FirstEmpty() // Return first empty slot index
{
    for (int i = 0; i < Slots.Length; i++)
        if (string.IsNullOrEmpty(Slots[i])) return i;  
    return -1;
}
int FirstSingleMc() // first slot with exactly one MC, or -1 if none
{
    for (int i = 0; i < Slots.Length; i++)
    {
        string slot = Slots[i];
        if (string.IsNullOrEmpty(slot))
            continue;

        if (slot.StartsWith("MC#") && Vehicles(slot).Length == 1)
            return i;
    }
    return -1;
}
bool FindPlate(string plate, out int slot) // Find slot containing the plate
{ 
    plate = NormalizePlate(plate);
    for (int i = 0; i < Slots.Length; i++)
    {
        if (!string.IsNullOrEmpty(Slots[i]) && Slots[i].Contains(plate, StringComparison.OrdinalIgnoreCase))
        {
            slot = i;
            return true;
        }
    }
    slot = -1;
    return false;
}
bool Park ( char type, string plate, out string message)
{
    plate = NormalizePlate(plate);




















}