using BreadsSudoku.Sudoku;

namespace BreadsSudoku.Events;

public interface ICellSelectEvent
{
    bool IsSet { get; }
    BandStackCoordinate Location { get; }
    CellValue Value { get; }
}

public record CellSelectEvent(bool IsSet, BandStackCoordinate Location, CellValue Value) : ICellSelectEvent;

public record TransientCellSelectEvent(bool IsSet, BandStackCoordinate Location, CellValue Value) : ICellSelectEvent;