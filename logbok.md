# Prague Parking – Log Book

This log book documents my progress, problems, and solutions during the Prague Parking project.

---
## 2025-09-26
Work done:
Compared two possible implementations:  
  1. Using `string[]` with format `"CAR#PLATE"` and `"MC#PLATE|MC#PLATE"`.  - As the assigment wanted.
  2. Using classes (`Car`, `Motorcycle`, `Slot`) with object-oriented design.  - Makes it easier to use.
     
Decision:
- We decided to use the **string version** with `string[]` because the assignment requires storing everything in a string array.  
- The class version would be more flexible and realistic, but it does not follow the given instructions.

  Reasoning / Learning:
- Using strings matches the project document and makes it easier to demonstrate string handling (`Split`, `Join`, `Substring`).  
- Learned the pros and cons:  
  - Strings → simpler, matches assignment, but less flexible.  
  - Classes → more maintainable in real projects, but outside the scope of this task.
 ------------------------------------------------------------------------------------------------------
 
