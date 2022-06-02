using System.Collections.Generic;

namespace BreadsSudoku.Sudoku;

public enum CellValue
{
    C00 = 1,
    C01 = 2,
    C02 = 3,
    C10 = 4,
    C11 = 5,
    C12 = 6,
    C20 = 7,
    C21 = 8,
    C22 = 9,
}

public static class CellValues
{
    public static IEnumerable<CellValue> Each()
    {
        for (int i = 1; i <= 9; i++)
            yield return (CellValue)i;
    }
}