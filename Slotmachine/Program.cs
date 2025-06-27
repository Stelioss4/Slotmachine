namespace Slotmachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //double money = 0;
            //int gameLines = 0;

            //UIMethods.DisplaySlotMachineIntroduction();

            //money = UIMethods.MakeCredit(money);

            //char[,] symbolGrid = new char[CONSTANTS. MAX_CELL, CONSTANTS.MAX_CELL];

            //gameLines = UIMethods.SelectSlotMachineLines(gameLines);

            //while (true)
            //{
            //    if (UIMethods.AskToPlayAgain() && money >= CONSTANTS.LINE_PRICE)
            //    {
            //        symbolGrid = Logic.GenerateRandomGrid();
            //        UIMethods.DisplayRandomSymbolGrid(symbolGrid);

            //        if (CONSTANTS.MIDDLE_LINE == gameLines)
            //        {
            //            money -= CONSTANTS.MIDDLE_LINE;
            //            money = Logic.HandleMiddleLineMatch(symbolGrid, money);

            //        }
            //        if (CONSTANTS.HORIZONTAL_LINES == gameLines)
            //        {
            //            money -= CONSTANTS.HORIZONTAL_LINES;
            //            money = Logic.HandleHorizontalMatches(symbolGrid, money);
            //        }

            //        if (CONSTANTS.LINES_COLOMNS == gameLines)
            //        {
            //            money -= CONSTANTS.LINES_COLOMNS;
            //            money = Logic.HandleVerticalMatches(symbolGrid, money);
            //            money = Logic.HandleHorizontalMatches(symbolGrid, money);
            //        }

            //        if (CONSTANTS.ALL_LINE == gameLines)
            //        {
            //            money -= CONSTANTS.ALL_LINE;
            //            money = Logic.HandleVerticalMatches(symbolGrid, money);
            //            money = Logic.HandleHorizontalMatches(symbolGrid, money);
            //            money = Logic.HandleDiagonalMatches(symbolGrid, money);
            //        }
            //        money = UIMethods.DisplayRemainingMoney(money);
            //        if (money < CONSTANTS.GAME_PRICE)
            //        {
            //            money = UIMethods.MakeCredit(money);
            //        }
            //    }
            //    else
            //    {
            //        UIMethods.DisplayGoodbuyMessage();
            //        break;
            //    }
            //}
        }
    }
}
