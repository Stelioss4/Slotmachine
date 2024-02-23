using System;
using System.Diagnostics;
namespace Slotmachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int LINE_PRICE = 1;
            const int GAME_PRICE = 3;
            const int MAX_CELL = 3;
            const int MIDDLE_LINE = 1;
            const int VERTICAL_LINES = 2;
            const int LINES_COLOMNS = 3;
            const int ALL_LINE = 4;
            const char ACE = 'A';
            const char KING = 'K';
            const char QUEEN = 'Q';

            Console.WriteLine("Hello! Let's play the slot machine!");
            Console.WriteLine("\n**********************************\n");

            Console.WriteLine($"Please please make a credit!\n");
            double money = Convert.ToDouble(Console.ReadLine());

            char[] figures = { ACE, KING, QUEEN };
            char[,] symbolGrid = new char[MAX_CELL, MAX_CELL];

            Console.WriteLine
                ($"\nPlease select which combinations of lines you want to play!\n" +
                $"Presse {MIDDLE_LINE} to play only on Middle line! Line price is {MIDDLE_LINE}$\n" +
                $"Presse {VERTICAL_LINES} to play with all horizontal lines! Line price is {VERTICAL_LINES}$\n" +
                $"Presse {LINES_COLOMNS} to add all vertical lines! Line price is {LINES_COLOMNS}$\n" +
                $"Presse {ALL_LINE} to add diagonal lines too! Line price is {ALL_LINE}$\n");

            int lineSelection = Convert.ToInt32(Console.ReadLine());

            Random rng = new Random();

            while (true)
            {
                Console.WriteLine("\nPress (SPACE) to spin the slot machine or any other key to exit.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                Console.Clear();

                if (keyInfo.Key == ConsoleKey.Spacebar && money >= LINE_PRICE)
                {
                    for (int lineIndex = 0; lineIndex < MAX_CELL; lineIndex++)
                    {
                        for (int verticalIndex = 0; verticalIndex < MAX_CELL; verticalIndex++)
                        {
                            int randomIndex = rng.Next(figures.Length);
                            symbolGrid[lineIndex, verticalIndex] = figures[randomIndex];
                            Console.Write(symbolGrid[lineIndex, verticalIndex]);
                        }
                        Console.WriteLine();
                    }
                    if (lineSelection == MIDDLE_LINE)
                    {
                        int lineIndex = MIDDLE_LINE;

                        money -= LINE_PRICE;

                        bool rowMatch = true;
                        char firstChar = symbolGrid[lineIndex, 0];


                        for (int verticalIndex = 1; verticalIndex < MAX_CELL; verticalIndex++)
                        {
                            if (symbolGrid[lineIndex, verticalIndex] != firstChar)
                            {
                                rowMatch = false;
                                break;
                            }
                        }

                        if (rowMatch)
                        {
                            Console.WriteLine($"Congratulations! You've got a Horizontal match on the middle line! You won {LINE_PRICE}$");
                            money += LINE_PRICE;
                        }
                    }

                    if (lineSelection == VERTICAL_LINES)
                    {
                        money -= VERTICAL_LINES;
                        for (int lineIndex = 0; lineIndex < MAX_CELL; lineIndex++)
                        {
                            bool rowMatch = true;
                            char firstChar = symbolGrid[lineIndex, 0];

                            for (int verticalIndex = 1; verticalIndex < MAX_CELL; verticalIndex++)
                            {
                                if (symbolGrid[lineIndex, verticalIndex] != firstChar)
                                {
                                    rowMatch = false;
                                    break;
                                }
                            }
                            if (rowMatch)
                            {
                                Console.WriteLine($"Congratulations! You've got a Horizontal match! You won {LINE_PRICE}$");
                                money += LINE_PRICE;
                            }
                        }
                    }

                    if (lineSelection == LINES_COLOMNS)
                    {
                        money -= GAME_PRICE;
                        for (int lineIndex = 0; lineIndex < MAX_CELL; lineIndex++)
                        {
                            bool rowMatch = true;
                            char firstChar = symbolGrid[lineIndex, 0];

                            for (int verticalIndex = 1; verticalIndex < MAX_CELL; verticalIndex++)
                            {
                                if (symbolGrid[lineIndex, verticalIndex] != firstChar)
                                {
                                    rowMatch = false;
                                    break;
                                }
                            }
                            if (rowMatch)
                            {
                                Console.WriteLine($"Congratulations! You've got a Horizontal match! You won {LINE_PRICE}$");
                                money += LINE_PRICE;

                            }
                        }
                        for (int verticalIndex = 0; verticalIndex < MAX_CELL; verticalIndex++)
                        {
                            bool colMatch = true;
                            char firstChar = symbolGrid[0, verticalIndex];

                            for (int lineIndex = 1; lineIndex < MAX_CELL; lineIndex++)
                            {
                                if (symbolGrid[lineIndex, verticalIndex] != firstChar)
                                {
                                    colMatch = false;
                                    break;
                                }
                            }
                            if (colMatch)
                            {
                                Console.WriteLine($"Congratulations! You've got a Vertical match! You won {LINE_PRICE}$");
                                money += LINE_PRICE;

                            }
                        }
                    }
                    if (lineSelection == ALL_LINE)
                    {
                        money -= GAME_PRICE + LINE_PRICE;
                        bool mainDiagonalMatch = true;
                        char mainDiagonalChar = symbolGrid[0, 0];
                        for (int i = 1; i < MAX_CELL; i++)
                        {
                            if (symbolGrid[i, i] != mainDiagonalChar)
                            {
                                mainDiagonalMatch = false;
                                break;
                            }
                        }
                        bool secondaryDiagonalMatch = true;
                        char secondaryDiagonalChar = symbolGrid[0, MAX_CELL - 1];
                        for (int i = 1; i < MAX_CELL; i++)
                        {
                            if (symbolGrid[i, MAX_CELL - 1 - i] != secondaryDiagonalChar)
                            {
                                secondaryDiagonalMatch = false;
                                break;
                            }
                        }
                        if (mainDiagonalMatch)
                        {
                            Console.WriteLine($"Congratulations! You've got a Main Diagonal match! You won {LINE_PRICE}$");
                            money += LINE_PRICE;
                        }
                        if (secondaryDiagonalMatch)
                        {
                            Console.WriteLine($"Congratulations! You've got a Secondary Diagonal match! You won {LINE_PRICE}$");
                            money += LINE_PRICE;
                        }
                        for (int lineIndex = 0; lineIndex < MAX_CELL; lineIndex++)
                        {
                            bool rowMatch = true;
                            char firstChar = symbolGrid[lineIndex, 0];
                            for (int verticalIndex = 1; verticalIndex < MAX_CELL; verticalIndex++)
                            {
                                if (symbolGrid[lineIndex, verticalIndex] != firstChar)
                                {
                                    rowMatch = false;
                                    break;
                                }
                            }
                            if (rowMatch)
                            {
                                Console.WriteLine($"Congratulations! You've got a Horizontal match! You won {LINE_PRICE}$");
                                money += LINE_PRICE;
                            }
                        }
                        for (int verticalIndex = 0; verticalIndex < MAX_CELL; verticalIndex++)
                        {
                            bool colMatch = true;
                            char firstChar = symbolGrid[0, verticalIndex];
                            for (int lineIndex = 1; lineIndex < MAX_CELL; lineIndex++)
                            {
                                if (symbolGrid[lineIndex, verticalIndex] != firstChar)
                                {
                                    colMatch = false;
                                    break;
                                }
                            }
                            if (colMatch)
                            {
                                Console.WriteLine($"Congratulations! You've got a Vertical match! You won {LINE_PRICE}$");
                                money += LINE_PRICE;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Thank you for playing! Goodbye.");
                    Environment.Exit(0);
                }

                if (money < GAME_PRICE)
                {
                    Console.WriteLine("Please insert more money!");
                    money = Convert.ToDouble(Console.ReadLine());
                }

                Console.WriteLine($"Your remaining money is {money}$");

            }
        }
    }
}