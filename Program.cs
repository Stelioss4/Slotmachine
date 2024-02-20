using System;
namespace Slotmachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int GAME_PRICE = 3;
            const int MAX_CELL = 3;
            const char ACE = 'A';
            const char KING = 'K';
            const char QUEEN = 'Q';

            Console.WriteLine("Hello! Let's play the slot machine!");
            Console.WriteLine("\n*********************************\n");

            Console.WriteLine($"Please insert some money! \nThe game price is {GAME_PRICE}$");
            double money = Convert.ToDouble(Console.ReadLine());

            Random rng = new Random();

            while (true)
            {
                Console.WriteLine("\nPress (SPACE) to spin! \nOr anything else to leave the game...");
                char play = char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();

                if (play == ' ' && money >= GAME_PRICE)
                {
                    money -= GAME_PRICE;

                    char[] figures = { ACE, KING, QUEEN };
                    char[,] figureList = new char[MAX_CELL, MAX_CELL];

                    for (int lineIndex = 0; lineIndex < MAX_CELL; lineIndex++)
                    {
                        for (int verticalIndex = 0; verticalIndex < MAX_CELL; verticalIndex++)
                        {
                            int randomIndex = rng.Next(0, MAX_CELL);
                            figureList[lineIndex, verticalIndex] = figures[randomIndex];
                            Console.Write(figureList[lineIndex, verticalIndex]);
                        }
                        Console.WriteLine();
                    }

                    int numRows = figureList.GetLength(0);

                    for (int lineIndex = 0; lineIndex < numRows; lineIndex++)
                    {
                        bool rowMatch = true;
                        char firstChar = figureList[lineIndex, 0];

                        for (int verticalIndex = 1; verticalIndex < MAX_CELL; verticalIndex++)
                        {
                            if (figureList[lineIndex, verticalIndex] != firstChar)
                            {
                                rowMatch = false;
                                break;
                            }
                        }
                        if (rowMatch)
                        {
                            Console.WriteLine($"Congratulations! You've got a Horizontal match! You won {GAME_PRICE}");
                            money += GAME_PRICE;
                        }
                    }

                    int numCols = figureList.GetLength(1);

                    for (int verticalIndex = 0; verticalIndex < numCols; verticalIndex++)
                    {
                        bool colMatch = true;
                        char firstChar = figureList[0, verticalIndex];

                        for (int lineIndex = 1; lineIndex < MAX_CELL; lineIndex++)
                        {
                            if (figureList[lineIndex, verticalIndex] != firstChar)
                            {
                                colMatch = false;
                                break;
                            }
                        }
                        if (colMatch)
                        {
                            Console.WriteLine($"Congratulations! You've got a Vertical match! You won {GAME_PRICE}");
                            money += GAME_PRICE;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nOK! Goodbye!");
                    break;
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
