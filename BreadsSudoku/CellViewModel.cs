using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using BreadsSudoku.Events;
using BreadsSudoku.Sudoku;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kelson.Common.Events;

namespace BreadsSudoku;

[INotifyPropertyChanged]
public partial class CellViewModel
{
    private readonly BandStackCoordinate _location;

    private readonly IEventManager _events;

    public CellViewModel(IEventManager events, CellValue region, CellValue cell)
    {
        _events = events;
        _location = BandStackCoordinate.FromRegionCell(region, cell);
        events.Subscribe<CellSelectEvent>(HandleCellSelection);
        events.Subscribe<TransientCellSelectEvent>(HandleCellSelection);
    }

    void HandleCellSelection(ICellSelectEvent selection)
    {
        var selected = selection.IsSet ? Visibility.Visible : Visibility.Hidden;
        var unselected = selection.IsSet ? Visibility.Hidden : Visibility.Visible;
        if (selection.IsSet && Options == 1)
            return;
        // this cell selected
        if (selection.Location == _location)
            foreach (var cell in CellValues.Each())
                this[cell] = cell == selection.Value ? selected : unselected;
        // row or column matches
        else if (selection.Location.Band == _location.Band || selection.Location.Stack == _location.Stack || selection.Location.Region == _location.Region)
            this[selection.Value] = unselected;
        if (selection.IsSet && Options == 1 && _location != selection.Location)
            _events.Publish(new TransientCellSelectEvent(true, _location, selectedValue!.Value));
    }

    public int Options
    {
        get
        {
            int sum = 0;
            CellValue last_cell = CellValue.C00;
            foreach (var cell in CellValues.Each())
            {
                if (this[cell] == Visibility.Visible)
                {
                    sum++;
                    last_cell = cell;
                }
            }

            if (sum == 1)
            {
                selectedValue = last_cell;
                SelectedValueText = ((int)last_cell).ToString();
            }
            else
            {
                selectedValue = null;
                _selectedValueText = "";
            }

            return sum;
        }
    }
    
    private CellValue? selectedValue;


    public Visibility NumberVisible => _selectedValueText is null ? Visibility.Collapsed : Visibility.Visible;
    
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(NumberVisible))] private string? _selectedValueText;


    [ObservableProperty] [AlsoNotifyChangeFor(nameof(Options))] Visibility option00;
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(Options))] Visibility option01;
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(Options))] Visibility option02;
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(Options))] Visibility option10;
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(Options))] Visibility option11;
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(Options))] Visibility option12;
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(Options))] Visibility option20;
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(Options))] Visibility option21;
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(Options))] Visibility option22;

    private static readonly SolidColorBrush MultipleOptionsFillColor = new(Colors.Gray);
    private static readonly SolidColorBrush SingleOptionFillColor = new(Colors.Black);
    public Visibility this[CellValue cell]
    {
        get => cell switch
        {
            CellValue.C00 => option00,
            CellValue.C01 => option01,
            CellValue.C02 => option02,
            CellValue.C10 => option10,
            CellValue.C11 => option11,
            CellValue.C12 => option12,
            CellValue.C20 => option20,
            CellValue.C21 => option21,
            CellValue.C22 => option22,
            _ => throw new IndexOutOfRangeException()
        };
        
        set
        {
            switch (cell)
            {
                case CellValue.C00: Option00 = value; break;
                case CellValue.C01: Option01 = value; break;
                case CellValue.C02: Option02 = value; break;
                case CellValue.C10: Option10 = value; break;
                case CellValue.C11: Option11 = value; break;
                case CellValue.C12: Option12 = value; break;
                case CellValue.C20: Option20 = value; break;
                case CellValue.C21: Option21 = value; break;
                case CellValue.C22: Option22 = value; break; 
            }
        }
    }

    [ICommand]
    public void CellSelected(string id) => _events.Publish(new CellSelectEvent(true, _location, (CellValue)int.Parse(id)));
}