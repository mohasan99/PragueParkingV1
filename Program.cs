using System;
using System.Linq;

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
bool IsSlotEmpty(int index) // Check if a slot is empty
{
    return string.IsNullOrEmpty(Slots[index]);
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
bool Park ( char type, string plate, out string message) // Park vehicle logic
{
    plate = NormalizePlate(plate);

    if (!ValidPlate(plate))
    {
        message = "Invalid plate format. Use 1-10 letters/digits";
        return false;

    }
    if (FindPlate(plate, out _))
    {
        message = "Vehicle already parked";
        return false;
    }

    if (type == 'C') // Car parking logic
    {

        int i = FirstEmpty();
        if (i == -1)
        {
            message = "No free slots for cars";
            return false;

        }
        Slots[i] = EncodeVehicle('C', plate);
        message = $"Car {plate} parked in slot {i + 1}";
        return true;
    }

    // Motorcycle parking logic, prefers sharing
    int share = FirstSingleMc(); //Looks for a slot that already has one motorcycle, to share it
    int target = (share != -1) ? share : FirstEmpty(); // If we found a slot to share, use it; otherwise, look for an empty slot
    if (target == -1) // No availiabe slots at all
    {
        message = "No free slots for motorcycles";
        return false;
    }
    if (string.IsNullOrEmpty(Slots[target])) // If the target slot is empty, just add the motorcycle   
    {
        Slots[target] = EncodeVehicle('M', plate);
    }
    else
    {
        Slots[target] = Slots[target] + "|" + EncodeVehicle('M', plate); //
    }

    // Create message depending on if we shared a slot or not.
    if (share != -1)
        message = $"MC {plate} parked in slot {target + 1} (shared).";
    else
        message = $"MC {plate} parked in slot {target + 1}.";

    return true;
}
    bool Remove(string plate, out string message) // Remove vehicle logic
{
    plate = NormalizePlate(plate);

    if (!FindPlate(plate, out int slot)) 
    {
        message = "Vehicle not found";
        return false; 
    }   
    string current = Slots[slot]; 
    
    current = current.Replace($"CAR#{plate}", ""); 
    current = current.Replace($"MC#{plate}", "");

    current = current.Replace("||", "|").Trim('|'); // Clean up any double separators or leading/trailing '|'
    Slots[slot] = string.IsNullOrEmpty(current) ? null : current;  // If slot is empty after removal, set to null
                                                                  
    message = $"Removed {plate} from slot {slot + 1}.";
    return true;

}
char AskType() // Ask user for vehicle type
{
    while (true)
    {
        Console.Write("Type (car/mc): ");
        string type = (Console.ReadLine() ?? "").Trim().ToLowerInvariant(); // Normalize input

        if (type == "car")
            return 'C';

        if (type == "mc")
            return 'M';
        
        Console.WriteLine("Please type exactly 'car' or 'mc'."); // Input validation
    }
}
bool Move(string plate, int targetSlot1to100, out string message) // Move vehicle logic
{
    plate = NormalizePlate(plate); 
    FindPlate(plate, out int from); //
    int to = targetSlot1to100 - 1; 

    // Check if the target slot is empty before moving
    if (!IsSlotEmpty(to))
    {
        message = $"Slot {to + 1} is not empty!";
        return false;
    }
    // Move vehicle text from source to target
    Slots[to] = Slots[from];
    Slots[from] = null;

    message = $"Moved {plate} to slot {to + 1}.";
    return true;
}
string AskPlate()
{
    while (true)
    {
        Console.Write("License plate (1–10 letters/digits): ");
        var plate = NormalizePlate(Console.ReadLine()); // cleans spaces + makes uppercase

        if (ValidPlate(plate))
            return plate; // stop asking when plate is valid

        Console.WriteLine("Invalid plate."); // otherwise ask again
    }
}
void PrintStatus()
{
    for (int i = 0; i < Slots.Length; i++)
        Console.WriteLine($"{i + 1}: {Slots[i] ?? "[empty]"}");
}

while (true)
{ // Main loop
    Console.WriteLine("""
    Prague Parking V1
    1 - Park vehicle
    2 - Move vehicle
    3 - Remove vehicle
    4 - Find vehicle
    5 - Show status
    0 - Exit
    """);
    Console.Write("Choice: ");

    switch ((Console.ReadLine() ?? "").Trim())
    {
        case "1":
            {
                if (Park(AskType(), AskPlate(), out var message))
                    Console.WriteLine(message);
                else
                    Console.WriteLine("Error: " + message);
                break;
            }
        case "2":
            {
                Console.Write("Target slot (1–100): ");
                int.TryParse(Console.ReadLine(), out int slot);
                if (Move(AskPlate(), slot, out var message))
                    Console.WriteLine(message);
                else
                    Console.WriteLine("Error: " + message);
                break;
            }
        case "3":
            {
                var plate = AskPlate();
                if (Remove(plate, out var message)) Console.WriteLine(message);
                else Console.WriteLine("Error: " + message);
                break;
            }
        case "4":
            {
                Console.WriteLine(FindPlate(AskPlate(), out int i)
                    ? $"Vehicle is at slot {i + 1}."
                    : "Vehicle not found.");
                break;
            }
        case "5":
            PrintStatus();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Invalid choice.\n");
            break;
    }
}