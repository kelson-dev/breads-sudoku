using System.Collections.Generic;

namespace BreadsSudoku.Sudoku;

/// <summary>
/// Defines a cell by its band/row (1 to 9 inclusive) and stack/column (1 to 9 inclusive)
/// </summary>
/// <param name="Band">The row, numbered 1 to 9 inclusive from top to bottom, of a position on the sudoku grid</param>
/// <param name="Stack">The column, numbered 1 to 9 inclusive from left to right, of a position on the sudoku grid</param>
public record struct BandStackCoordinate(int Band, int Stack)
{
    // "3 * Band / 3" does not simplify to "Band" because integers 
    public int Region => (3 * (Band / 3)) + (Stack / 3);

    public static BandStackCoordinate FromRegionCell(CellValue region, CellValue cell)
    {
        int region_i = (int)region - 1;
        int cell_i = (int)cell - 1;

        int region_row = region_i / 3; // 0 0 0 1 1 1 2 2 2
        int cell_row = cell_i / 3; // 0 1 2 0 1 2 0 1 2

        int region_column = region_i % 3; // 0 0 0 1 1 1 2 2 2
        int cell_column = cell_i % 3; // 0 1 2 0 1 2 0 1 2

        return new(3 * region_row + cell_row, 3 * region_column + cell_column);
    }
};

