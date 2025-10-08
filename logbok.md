# Prague Parking – Log Book

This log book documents my progress, problems, and solutions during the Prague Parking project.

---

## 26-09-2025
Work done:
- Compared two possible implementations for storing vehicles:
  1. Using `string[]` with format `"CAR#PLATE"` and `"MC#PLATE|MC#PLATE"` (as the assignment requires).
  2. Using classes (`Car`, `Motorcycle`, `Slot`) with an object-oriented design.
- Decided to use the **string[] approach** because the assignment explicitly requires all data to be stored in an array.
- At this stage, the program still used a `class Program` wrapper with static methods, but the internal data model was based on strings and arrays.

Reasoning / Learning:
- Using strings matches the project document and makes it easier to demonstrate string handling (`Split`, `Join`, `Substring`).
- Learned the pros and cons:
  - Strings → simpler, matches assignment, but less flexible.
  - Classes → more maintainable in real projects, but outside the scope of this task.

 -------------------------------------------------------------------
 
## 29-09-2025
Work done:
- Refactored the code to remove the `class Program` structure.
- The program now uses **top-level statements with methods and a shared `string[]` array** instead of a class.
- This keeps the same data model chosen on 26-09 (strings and arrays), but makes the overall structure simpler.
- The goal was to make the code easier to read for beginners while still fulfilling the assignment requirements.

Reasoning / Learning:
- Classes are useful in larger projects for organization and scalability, but here they added unnecessary complexity.
- Using only methods and arrays matches the assignment and makes the code more approachable.

--------------------------------------------------------------------
## 02/10/2025
Work done:
Added helper methods to handle vehicles and slots more cleanly (Vehicles, EncodeVehicle, NormalizePlate, etc.).
Chose to keep code beginner-friendly and simple, even if it sacrifices some advanced features (e.g., ignoring MC position inside the slot).
Kept working on the code.

Reasoning / Learning:
Writing many small helper methods makes the code easier to read and maintain.
It’s more important in this assignment to show understanding of arrays and strings than to build a complex solution.
--------------------------------------------------------------------
## 07-10-2015
Work done:
Changed a lot of the code to a simpler and more readably program using If -statment.

Reasoning / Learning:
Simplifying methods improves readability and makes debugging easier.
Learned to test and validate helper functions individually before integrating them.

## 08-10-2025
Final development phase

Work done:

Continued simplifying and refining the program to make it more stable, readable, and user-friendly.

Focused on improving menu navigation, input validation, and message feedback for all main functions (park, move, remove, find, and show status).

Debugged several logic issues to ensure consistent behavior across all features.

Verified that helper methods like IsSlotEmpty(), NormalizePlate(), and FindPlate() work together correctly.

Reasoning / Learning:

Learned the importance of testing functions both individually and as part of the full program flow.

Realized how small changes, such as clearer messages and simpler logic, make the program easier to understand for the user.

The final version balances functionality and simplicity while following the assignment’s requirements.
--------------------------------------------------------------------------
