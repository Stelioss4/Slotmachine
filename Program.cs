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

            Console.WriteLine("Hello! Lets play the slotmachine!");
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
                Console.WriteLine("\nPress (SPACE) to spin! \nOr anything else to leave the game...");
                char play = char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();

                if (play == ' ' && money >= GAME_PRICE)
                {
                    money -= GAME_PRICE;
                    for (int i = 0; i < figureList.GetLength(0); i++)
                    {
                        for (int j = 0; j < figureList.GetLength(0); j++)
                        {
                            int randomrow = random.Next(0, figureList.GetLength(1));
                            char randomFigure = figureList[i, randomrow];
                            Console.Write(randomFigure);
                        }
                        Console.WriteLine();



                    }
                   
                    if (money < GAME_PRICE)
                    {
                        Console.WriteLine("Please insert more money!");
                        money = Convert.ToDouble(Console.ReadLine());
                        continue;
                    }
                    for (int lineindex = 0; lineindex < figureList.GetLength(0); lineindex++)
                    {
                        if (figureList[lineindex, 0] == figureList[lineindex, 1] && figureList[lineindex, 1] == figureList[lineindex, 2])
                        {
                            Console.WriteLine("Congratulations! You've got a match in horizontal line!");
                            money += GAME_PRICE;
                        }

                    }
                    for (int verticalindex = 0; verticalindex < figureList.GetLength(0);  verticalindex++)
                    {
                        if (figureList[0, verticalindex] == figureList[1, verticalindex] && figureList[1, verticalindex] == figureList[2, verticalindex])
                        {
                            Console.WriteLine("Congratulations! You've got a match in horizontal line!");
                            money += GAME_PRICE;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("\nOK! Goodbuy!");
                    break;
                }
                Console.WriteLine($"Your remaining money is {money}$");
            }
        }
    }
}



