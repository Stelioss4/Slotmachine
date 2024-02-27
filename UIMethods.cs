namespace Slotmachine
{
    public static class UIMethods
    {
        const int LINE_PRICE = 1;
        const int GAME_PRICE = 3;
        const int MAX_CELL = 3;
        const int MIDDLE_LINE = 1;
        const int HORIZONTAL_LINES = 2;
        const int LINES_COLOMNS = 3;
        const int ALL_LINE = 4;
        const char ACE = 'A';
        const char KING = 'K';
        const char QUEEN = 'Q';

        public static void welcomeMessage()
        {
            Console.WriteLine("Hello! Let's play the slot machine!");
            Console.WriteLine("\n**********************************\n");
        }
        public static int lineSelection(int gameline)
        {
            Console.WriteLine
                ($"\nPlease select which combinations of lines you want to play!\n" +
                $"Presse {MIDDLE_LINE} to play only on Middle line! Line price is {MIDDLE_LINE}$\n" +
                $"Presse {HORIZONTAL_LINES} to play with all horizontal lines! Line price is {HORIZONTAL_LINES}$\n" +
                $"Presse {LINES_COLOMNS} to add all vertical lines! Line price is {LINES_COLOMNS}$\n" +
                $"Presse {ALL_LINE} to add diagonal lines too! Line price is {ALL_LINE}$\n");
            while (true)
            {
                try
                {
                    gameline = Convert.ToInt32(Console.ReadLine());
                    if (gameline >= MIDDLE_LINE && gameline <= ALL_LINE)
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
            Console.WriteLine($"Congratulations! You've got a Horizontal match! You won {MIDDLE_LINE}$");
        }
        public static void displayCongratsForVerticalWin()
        {
            Console.WriteLine($"Congratulations! You've got a Vertival match! You won {MIDDLE_LINE}$");
        }
        public static void displayCongratsForDiagonalWin()
        {
            Console.WriteLine($"Congratulations! You've got a Diagonal match! You won {MIDDLE_LINE}$");
        }
        public static void goodbuyMessage()
        {
            Console.WriteLine("Thank you for playing! Goodbye.");
        }
        public static bool playDecision()
        {
            Console.WriteLine("\nPress (SPACE) to spin the slot machine or any other key to exit.");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();
            {
                return (keyInfo.Key == ConsoleKey.Spacebar);
            }
        }
        public static double creditMake(double money)
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
        public static void randomSymbol(char[,] symbolGrid)
        {
            for (int lineIndex = 0; lineIndex < MAX_CELL; lineIndex++)
            {
                for (int verticalIndex = 0; verticalIndex < MAX_CELL; verticalIndex++)
                {
                    Console.Write(symbolGrid[lineIndex, verticalIndex]);
                }
                Console.WriteLine();
            }
        }
        public static double remainMoney(double money)
        {
            Console.WriteLine($"Your remaining money is {money}$");
            return money;
        }
    }
}
