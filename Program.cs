using System;

namespace Slotmachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char PLAY = ' ';
            const int GAME_PRICE = 3;
            const char ACE = 'A';
            const char KING = 'K';
            const char QUEEN = 'Q';

            Console.WriteLine("Hello! Lets play the slotmachin!");
            Console.WriteLine("\n*********************************\n");

            Console.WriteLine($"Please insert some money! \nThe game preis is {GAME_PRICE}$");
            double money = Convert.ToDouble(Console.ReadLine());

            char[,] figureList = new char[3, 3];
            figureList[0, 0] = ACE;
            figureList[0, 1] = KING;
            figureList[0, 2] = QUEEN;
            figureList[1, 0] = ACE;
            figureList[1, 1] = KING;
            figureList[1, 2] = QUEEN;
            figureList[2, 0] = ACE;
            figureList[2, 1] = KING;
            figureList[2, 2] = QUEEN;

            Random random = new Random();

            while (true)
            {
                char randomFigure = '0';
                Console.WriteLine("presse (SPACE) to spin! \nOr anything else to leave the game...");
                char replay = char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();

                if (replay == PLAY && money >= GAME_PRICE)
                {
                    money = money - GAME_PRICE;
                    for (int i = 0; i < figureList.GetLength(0); i++)
                    {
                        for (int j = 0; j < figureList.GetLength(0); j++)
                        {
                            int randomrow = random.Next(0, figureList.GetLength(1));
                            randomFigure = figureList[i, randomrow];
                            Console.Write(randomFigure);
                        }
                        Console.WriteLine();

                    }
                    Console.WriteLine($"\nyour remain money is {money}$\n");
                }
                else
                {
                    Console.WriteLine("\nOK! Goodbuy!");
                    break;
                }
                if (money < GAME_PRICE)
                {
                    Console.WriteLine("Please insert more money!");
                    money = Convert.ToDouble(Console.ReadLine());
                    continue;
                }




            }
        }
    }
}
