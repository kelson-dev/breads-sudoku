using BreadsSudoku.Sudoku;
using CommunityToolkit.Mvvm.ComponentModel;
using Kelson.Common.Events;

namespace BreadsSudoku;

[INotifyPropertyChanged]
public partial class RegionViewModel
{
    [ObservableProperty] CellViewModel cell00;
    [ObservableProperty] CellViewModel cell01;
    [ObservableProperty] CellViewModel cell02;
    [ObservableProperty] CellViewModel cell10;
    [ObservableProperty] CellViewModel cell11;
    [ObservableProperty] CellViewModel cell12;
    [ObservableProperty] CellViewModel cell20;
    [ObservableProperty] CellViewModel cell21;
    [ObservableProperty] CellViewModel cell22;

    public RegionViewModel(IEventManager events, CellValue region)
    {
        cell00 = new(events, region, CellValue.C00);
        cell01 = new(events, region, CellValue.C01);
        cell02 = new(events, region, CellValue.C02);
        cell10 = new(events, region, CellValue.C10);
        cell11 = new(events, region, CellValue.C11);
        cell12 = new(events, region, CellValue.C12);
        cell20 = new(events, region, CellValue.C20);
        cell21 = new(events, region, CellValue.C21);
        cell22 = new(events, region, CellValue.C22);
    }
}