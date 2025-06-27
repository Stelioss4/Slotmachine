using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SlotMachine.UI.WPF.ViewModels
{
    public class SlotMachineViewModel : INotifyPropertyChanged
    {
        private Random _random = new Random();

        public ObservableCollection<ObservableCollection<string>> SlotGrid { get; set; }

        private double _credit;
        public double Credit
        {
            get => _credit;
            set { _credit = value; OnPropertyChanged(); }
        }

        public ICommand SpinCommand { get; }

        private readonly string[] _availableSymbols = new[]
        {
            "🍒", "🍋", "🔔", "🍉", "⭐", "💎"
        };

        public SlotMachineViewModel()
        {
            Credit = 10;
            SlotGrid = new ObservableCollection<ObservableCollection<string>>();
            InitializeGrid();
            SpinCommand = new RelayCommand(Spin, () => Credit >= 1);
        }

        private void InitializeGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                var row = new ObservableCollection<string>();
                for (int j = 0; j < 3; j++)
                {
                    row.Add("❔"); // Default symbol
                }
                SlotGrid.Add(row);
            }
        }

        private void Spin()
        {
            if (Credit < 1)
                return;

            Credit -= 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string symbol = _availableSymbols[_random.Next(_availableSymbols.Length)];
                    SlotGrid[i][j] = symbol;
                }
            }

            // TODO: Add win-check logic here
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
