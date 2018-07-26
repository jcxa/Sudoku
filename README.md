# Sudoku
Simple Sudoku game made as a hobby, using .NET C# in Visual Studio 2015.

Windows Form app
.NET Framework 4.6.1

The algorithm to fill the Sudoku table is simple: I would call it a “controlled brute-force” algorithm. See the method GenerateSudokuTable() in the code; it is commented so you can follow it. But the idea is: for each column and row it tries to set a random value (from 1 to 9) which is not defined yet, in that column, row and cell. The “controlled” part is because it avoids infinite loops by resetting the iteration on each row.
