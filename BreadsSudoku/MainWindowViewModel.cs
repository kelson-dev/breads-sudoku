using System.Collections.ObjectModel;
using BreadsSudoku.Events;
using CommunityToolkit.Mvvm.ComponentModel;
using Kelson.Common.Events;

namespace BreadsSudoku;

[INotifyPropertyChanged]
public partial class MainWindowViewModel
{
    public readonly ObservableCollection<CellSelectEvent> Selections = new();

    private readonly IEventManager _events;

    public SudokuGridViewModel Game { get; }

    public MainWindowViewModel(IEventManager events)
    {
        _events = events;
        events.Subscribe<CellSelectEvent>(e => Selections.Add(e));
        Game = new SudokuGridViewModel(events);
    }
}