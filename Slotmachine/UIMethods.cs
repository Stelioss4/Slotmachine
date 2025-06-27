namespace Slotmachine
{
    public static class UIMethods
    {
        public static void DisplaySlotMachineIntroduction()
        {
            Console.WriteLine("Hello! Let's play the slot machine!");
            Console.WriteLine("\n**********************************\n");
        }

        public static int SelectSlotMachineLines(int gameline)
        {
            Console.WriteLine
                ($"\nPlease select which combinations of lines you want to play!\n" +
                $"Presse {CONSTANTS.MIDDLE_LINE} to play only on Middle line! Line price is {CONSTANTS.MIDDLE_LINE}$\n" +
                $"Presse {CONSTANTS.HORIZONTAL_LINES}  to play with all horizontal lines! Line price is  {CONSTANTS.HORIZONTAL_LINES}$\n" +
                $"Presse {CONSTANTS.LINES_COLOMNS} to add all vertical lines! Line price is {CONSTANTS.LINES_COLOMNS}$\n" +
                $"Presse {CONSTANTS.ALL_LINE} to add diagonal lines too! Line price is {CONSTANTS.ALL_LINE}$\n");
            while (true)
            {
                try
                {
                    gameline = Convert.ToInt32(Console.ReadLine());
                    if (gameline >= CONSTANTS.MIDDLE_LINE && gameline <= CONSTANTS.ALL_LINE)
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("please enter only valide numbers!");
                }
            }
            return gameline;
        }

        public static void displayCongratsForHorizontalWin()
        {
            Console.WriteLine($"Congratulations! You've got a Horizontal match! You won {CONSTANTS.MIDDLE_LINE}$");
        }

        public static void displayCongratsForVerticalWin()
        {
            Console.WriteLine($"Congratulations! You've got a Vertival match! You won {CONSTANTS.MIDDLE_LINE}$");
        }

        public static void displayCongratsForDiagonalWin()
        {
            Console.WriteLine($"Congratulations! You've got a Diagonal match! You won {CONSTANTS.MIDDLE_LINE}$");
        }

        public static void DisplayGoodbuyMessage()
        {
            Console.WriteLine("Thank you for playing! Goodbye.");
        }

        public static bool AskToPlayAgain()
        {
            Console.WriteLine("\nPress (SPACE) to spin the slot machine or any other key to exit.");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();
            {
                return (keyInfo.Key == ConsoleKey.Spacebar);
            }
        }

        public static double MakeCredit(double money)
        {
            Console.WriteLine("Please please make a credit!\n");
            while (true)
            {
                try
                {
                    money = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("please enter only valide numbers!");
                }
            }
            return money;
        }

        public static void DisplayRandomSymbolGrid(char[,] symbolGrid)
        {
            for (int lineIndex = 0; lineIndex < CONSTANTS.MAX_CELL; lineIndex++)
            {
                for (int verticalIndex = 0; verticalIndex < CONSTANTS.MAX_CELL; verticalIndex++)
                {
                    Console.Write(symbolGrid[lineIndex, verticalIndex]);
                }
                Console.WriteLine();
            }
        }

        public static double DisplayRemainingMoney(double money)
        {
            Console.WriteLine($"Your remaining money is {money}$");
            return money;
        }
    
    }
}
