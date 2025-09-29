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

 ------------------------------------------------------------------------------------------------------
 
## 29-09-2025
Work done:
- Refactored the code to remove the `class Program` structure.
- The program now uses **top-level statements with methods and a shared `string[]` array** instead of a class.
- This keeps the same data model chosen on 26-09 (strings and arrays), but makes the overall structure simpler.
- The goal was to make the code easier to read for beginners while still fulfilling the assignment requirements.

Reasoning / Learning:
- Classes are useful in larger projects for organization and scalability, but here they added unnecessary complexity.
- Using only methods and arrays matches the assignment and makes the code more approachable.

