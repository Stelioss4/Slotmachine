using System;
namespace Slotmachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int GAME_PRICE = 3;
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
                    char[,] figureList = new char[3, 3];

                    for (int lineIndex = 0; lineIndex < 3; lineIndex++)
                    {
                        for (int verticalIndex = 0; verticalIndex < 3; verticalIndex++)
                        {
                            int randomIndex = rng.Next(0, 3);
                            figureList[lineIndex, verticalIndex] = figures[randomIndex];
                            Console.Write(figureList[lineIndex, verticalIndex]);
                        }
                        Console.WriteLine();
                    }

                    for (int lineIndex = 0; lineIndex < 3; lineIndex++)
                    {
                        bool rowMatch = figureList[lineIndex, 0] == figureList[lineIndex, 1] && figureList[lineIndex, 1] == figureList[lineIndex, 2];
                        if (rowMatch)
                        {
                            Console.WriteLine("Congratulations! You've got a Horizontal match!");
                            money += GAME_PRICE;
                            break;
                        }
                    }
                    for (int verticalIndex = 0; verticalIndex < 3; verticalIndex++)
                    {
                        bool colMatch = figureList[0, verticalIndex] == figureList[1, verticalIndex] && figureList[1, verticalIndex] == figureList[2, verticalIndex];
                        if (colMatch)
                        {
                            Console.WriteLine("Congratulations! You've got a Vertical match!");
                            money += GAME_PRICE;
                            break;
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
