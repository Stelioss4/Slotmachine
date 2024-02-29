namespace Slotmachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int LINE_PRICE = 1;
            const int GAME_PRICE = 3;
            const int MAX_CELL = 3;
            const int MIDDLE_LINE = 1;
            const int HORIZONTAL_LINES = 2;
            const int LINES_COLOMNS = 3;
            const int ALL_LINE = 4;
           
            double money = 0;
            int gameLines = 0;

            UIMethods.DisplaySlotMachineIntroduction();

            money = UIMethods.MakeCredit(money);

            char[,] symbolGrid = new char[MAX_CELL, MAX_CELL];

            gameLines = UIMethods.SelectSlotMachineLines(gameLines);

            while (true)
            {
                if (UIMethods.AskToPlayAgain() && money >= LINE_PRICE)
                {
                    symbolGrid = Logic.randomGeneretor();
                    UIMethods.DisplayRandomSymbolGrid(symbolGrid);

                    if (MIDDLE_LINE == gameLines)
                    {
                        money -= MIDDLE_LINE;
                        money = Logic.HandleMiddleLineMatch(symbolGrid, money);

                    }
                    if (HORIZONTAL_LINES == gameLines)
                    {
                        money -= HORIZONTAL_LINES;
                        money = Logic.HandleHorizontalMatches(symbolGrid, money);
                    }

                    if (LINES_COLOMNS == gameLines)
                    {
                        money -= LINES_COLOMNS;
                        money = Logic.HandleVerticalMatches(symbolGrid, money);
                        money = Logic.HandleHorizontalMatches(symbolGrid, money);
                    }

                    if (ALL_LINE == gameLines)
                    {
                        money -= ALL_LINE;
                        money = Logic.HandleVerticalMatches(symbolGrid, money);
                        money = Logic.HandleHorizontalMatches(symbolGrid, money);
                        money = Logic.HandleDiagonalMatches(symbolGrid, money);
                    }
                    money = UIMethods.DisplayRemainingMoney(money);
                    if (money < GAME_PRICE)
                    {
                        money = UIMethods.MakeCredit(money);
                    }
                }
                else
                {
                    UIMethods.DisplayGoodbuyMessage();
                    break;
                }
            }
        }
    }
}
