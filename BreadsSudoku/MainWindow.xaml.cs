using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kelson.Common.Events;
using EventManager = Kelson.Common.Events.EventManager;

namespace BreadsSudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new EventManager());
        }


        private void FrameworkElement_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            BoardColumn.Width = new (BoardRow.ActualHeight);
        }
    }
}