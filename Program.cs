﻿namespace Slotmachine
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
            const char ACE = 'A';
            const char KING = 'K';
            const char QUEEN = 'Q';

            double money = 0;
            int gameLines = 0;

            UIMethods.welcomeMessage();

            money = UIMethods.creditMake(money);

            char[] figures = { ACE, KING, QUEEN };
            char[,] symbolGrid = new char[MAX_CELL, MAX_CELL];

            gameLines = UIMethods.lineSelection(gameLines);

            while (true)
            {
                if (UIMethods.playDecision() && money >= LINE_PRICE)
                {
                    symbolGrid = Logic.randomGeneretor();
                    UIMethods.randomSymbol(symbolGrid);

                    if (gameLines == MIDDLE_LINE)
                    {
                        money -= MIDDLE_LINE;
                        money = Logic.HandleMiddleLineMatch(symbolGrid, money);
                    }
                    if (gameLines == HORIZONTAL_LINES)
                    {
                        money -= HORIZONTAL_LINES;
                        money = Logic.HandleHorizontalMatches(symbolGrid, money);
                    }
                    if (gameLines == LINES_COLOMNS)
                    {
                        money -= GAME_PRICE;
                        money = Logic.HandleVerticalMatches(symbolGrid, money);
                        money = Logic.HandleHorizontalMatches(symbolGrid, money);
                    }
                    if (gameLines == ALL_LINE)
                    {
                        money -= ALL_LINE;
                        money = Logic.HandleVerticalMatches(symbolGrid, money);
                        money = Logic.HandleHorizontalMatches(symbolGrid, money);
                        money = Logic.HandleDiagonalMatches(symbolGrid, money);
                    }
                    money = UIMethods.remainMoney(money);
                    if (money < GAME_PRICE)
                    {
                        money = UIMethods.creditMake(money);
                    }
                }
                else
                {
                    UIMethods.goodbuyMessage();
                    break;
                }
            }
        }
    }
}
