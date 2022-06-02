using BreadsSudoku.Sudoku;
using CommunityToolkit.Mvvm.ComponentModel;
using Kelson.Common.Events;

namespace BreadsSudoku;

[INotifyPropertyChanged]
public partial class SudokuGridViewModel
{
    [ObservableProperty] RegionViewModel _region00;
    [ObservableProperty] RegionViewModel _region01;
    [ObservableProperty] RegionViewModel _region02;
    [ObservableProperty] RegionViewModel _region10;
    [ObservableProperty] RegionViewModel _region11;
    [ObservableProperty] RegionViewModel _region12;
    [ObservableProperty] RegionViewModel _region20;
    [ObservableProperty] RegionViewModel _region21;
    [ObservableProperty] RegionViewModel _region22;

    public SudokuGridViewModel(IEventManager events)
    {
        _region00 = new(events, CellValue.C00);
        _region01 = new(events, CellValue.C01);
        _region02 = new(events, CellValue.C02);
        _region10 = new(events, CellValue.C10);
        _region11 = new(events, CellValue.C11);
        _region12 = new(events, CellValue.C12);
        _region20 = new(events, CellValue.C20);
        _region21 = new(events, CellValue.C21);
        _region22 = new(events, CellValue.C22);
    }
}