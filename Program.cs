using System;

class Program
{

    static string[] slots = new string[100]; // Array to hold slot values
    static string[] v(String s) => string.IsNullOrEmpty(s) ? Array.Empty<string>() : s.Split(('|'); //Split slots into vehicles
    static bool Empty(int i) => string.IsNullOrEmpty(slots[i]); // Check if a slot is empty
    static bool IsCar(int i) => !Empty(i) && slots[i].StartsWith("CAR#"); // Check if slot contain a car
    static bool IsMc(int i) => !Empty(i) && slots[i].StartsWith("MC#"); // Check if slot contain a Mc




}
