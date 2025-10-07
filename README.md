PragueParkingV1

Introduction
Prague Parking is a text-based C# console application that simulates a parking garage.  
The system manages 100 parking slots where each slot can contain:
- 1 car, or
- 1 motorcycle, or
- 2 motorcycles (sharing a slot).
The program allows the user to park, move, remove, search, and view the current status of vehicles in the garage.

## Features
- Park a car or motorcycle.
- Support for two motorcycles in the same slot.
- Move vehicles between slots.
- Remove vehicles when they leave.
- Search for vehicles by registration number.
- Print status of the entire garage or a single slot.
- Input validation (registration number: 1–10 alphanumeric characters).

## Technical Details
- Implemented in C# (.NET Console Application).
- Storage is handled by a simple `string[100]` array.
- Vehicles are encoded as:
  - `"CAR#ABC123"` → one car
  - `"MC#AAA111"` → one motorcycle
  - `"MC#AAA111|MC#BBB222"` → two motorcycles
    
## Design Choice
The assignment required us to use a `string[]` to model the parking garage.  
We considered an object-oriented design with `Car`, `Motorcycle`, and `Slot` classes, but this would not follow the specification.

- *String version → simpler, matches assignment, good practice with string methods (`Split`, `Join`, `Substring`).  
- Class version → more flexible for real-world projects, but outside scope of this task.

- ## Update (29-09-2025)
Originally, the program used a `class Program` with static methods.  
To simplify the structure, we refactored to use top-level statements with methods and a shared `string[]` array.  
This makes the code shorter, easier to read, and still fulfills the assignment requirements.

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/<your-username>/PragueParkingV1.git.

## See logbook.md
 For daily notes on progress, problems, and solutions.
