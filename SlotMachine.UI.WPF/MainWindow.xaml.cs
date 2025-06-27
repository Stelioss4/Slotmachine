using System;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;
using Slotmachine;

namespace SlotMachine.UI.WPF
{
    public partial class MainWindow : Window
    {
        private int coins = 0;
        private readonly string[] symbols = { "🍒", "🍋", "🔔", "🍀", "💎" };
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CoinInput.Text, out int startCoins) && startCoins > 0)
            {
                coins = startCoins;
                CoinDisplay.Text = $"💰 Coins: {coins}";
                SpinButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid positive number of coins.");
            }
        }

        private async void Spin_Click(object sender, RoutedEventArgs e)
        {
            if (coins <= 0)
            {
                MessageBox.Show("You are out of coins!");
                return;
            }

            coins--;
            CoinDisplay.Text = $"💰 Coins: {coins}";
            SpinButton.IsEnabled = false;

            string[,] finalGrid = new string[3, 3];

            // Simulate spinning animation
            for (int spin = 0; spin < 10; spin++) // 10 quick flashes
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        string symbol = symbols[random.Next(symbols.Length)];
                        var reel = (TextBlock)this.FindName($"Reel{row * 3 + col + 1}");
                        reel.Text = symbol;

                        if (spin == 9) // Final spin
                        {
                            finalGrid[row, col] = symbol;
                        }
                    }
                }

                await Task.Delay(100); // 100ms delay between spins
            }

            int winnings = CalculateWinnings(finalGrid);
            coins += winnings;
            CoinDisplay.Text = $"💰 Coins: {coins}";

            if (winnings > 0)
            {
                ShowWinningsBanner(winnings);
            }

            if (coins <= 0)
            {
                MessageBox.Show("Game Over! You're out of coins.");
                SpinButton.IsEnabled = false;
            }
            else
            {
                SpinButton.IsEnabled = true;
            }
        }

        private async void ShowWinningsBanner(int winnings)
        {
            WinningsBanner.Text = $"🎉 You won {winnings} coins!";
            WinningsBanner.Visibility = Visibility.Visible;

            await Task.Delay(2000); // Show for 2 seconds

            WinningsBanner.Visibility = Visibility.Collapsed;
        }


        private int CalculateWinnings(string[,] grid)
        {
            int total = 0;

            for (int row = 0; row < 3; row++)
            {
                if (grid[row, 0] == grid[row, 1] && grid[row, 1] == grid[row, 2])
                    total += CONSTANTS.MAX_WIN;
            }

            for (int col = 0; col < 3; col++)
            {
                if (grid[0, col] == grid[1, col] && grid[1, col] == grid[2, col])
                    total += CONSTANTS.MAX_WIN;
            }

            if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
                total += CONSTANTS.MAX_WIN;

            if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
                total += CONSTANTS.MAX_WIN;

            if (grid[1, 0] == grid[1, 1] && grid[1, 1] == grid[1, 2])
                total += CONSTANTS.MAX_WIN;

            return total;
        }
    }
}
