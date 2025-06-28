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

            string[,] finalGrid = new string[CONSTANTS.MAX_CELL, CONSTANTS.MAX_CELL];

            // Simulate spinning animation
            for (int spin = 0; spin < CONSTANTS.SPIN_DELAY; spin++)
            {
                for (int row = 0; row < CONSTANTS.MAX_CELL; row++)
                {
                    for (int col = 0; col < CONSTANTS.MAX_CELL; col++)
                    {
                        string symbol = symbols[random.Next(symbols.Length)];
                        var reel = (TextBlock)this.FindName($"Reel{row * CONSTANTS.MAX_CELL + col + 1}");
                        reel.Text = symbol;

                        if (spin == CONSTANTS.FINAL_SPIN)
                        {
                            finalGrid[row, col] = symbol;
                        }
                    }
                }

                await Task.Delay(CONSTANTS.SPIN_FRAME_DELAY);
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

            await Task.Delay(CONSTANTS.BANNER_DISPLAY_TIME);

            WinningsBanner.Visibility = Visibility.Collapsed;
        }

        private int CalculateWinnings(string[,] grid)
        {
            int total = 0;

            // Horizontal lines
            for (int row = 0; row < CONSTANTS.MAX_CELL; row++)
            {
                if (grid[row, 0] == grid[row, CONSTANTS.MIDDLE_LINE] &&
                    grid[row, CONSTANTS.MIDDLE_LINE] == grid[row, CONSTANTS.HORIZONTAL_LINES])
                {
                    total += CONSTANTS.MAX_WIN;
                }
            }

            // Vertical lines
            for (int col = 0; col < CONSTANTS.MAX_CELL; col++)
            {
                if (grid[0, col] == grid[CONSTANTS.MIDDLE_LINE, col] &&
                    grid[CONSTANTS.MIDDLE_LINE, col] == grid[CONSTANTS.HORIZONTAL_LINES, col])
                {
                    total += CONSTANTS.MAX_WIN;
                }
            }

            // Diagonals
            if (grid[0, 0] == grid[CONSTANTS.MIDDLE_LINE, CONSTANTS.MIDDLE_LINE] &&
                grid[CONSTANTS.MIDDLE_LINE, CONSTANTS.MIDDLE_LINE] == grid[CONSTANTS.HORIZONTAL_LINES, CONSTANTS.HORIZONTAL_LINES])
            {
                total += CONSTANTS.MAX_WIN;
            }

            if (grid[0, CONSTANTS.HORIZONTAL_LINES] == grid[CONSTANTS.MIDDLE_LINE, CONSTANTS.MIDDLE_LINE] &&
                grid[CONSTANTS.MIDDLE_LINE, CONSTANTS.MIDDLE_LINE] == grid[CONSTANTS.HORIZONTAL_LINES, 0])
            {
                total += CONSTANTS.MAX_WIN;
            }

            // Middle row line
            if (grid[CONSTANTS.MIDDLE_LINE, 0] == grid[CONSTANTS.MIDDLE_LINE, CONSTANTS.MIDDLE_LINE] &&
                grid[CONSTANTS.MIDDLE_LINE, CONSTANTS.MIDDLE_LINE] == grid[CONSTANTS.MIDDLE_LINE, CONSTANTS.HORIZONTAL_LINES])
            {
                total += CONSTANTS.MAX_WIN;
            }

            return total;
        }
    }
}
