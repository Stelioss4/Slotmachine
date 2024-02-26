using Slotmachine;
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
            double money = 0;
            int gameLines = 0;

            UIMethods.welcomeMessage();

            money = UIMethods.creditMaker(money);

            char[] figures = { ACE, KING, QUEEN };
            char[,] symbolGrid = new char[MAX_CELL, MAX_CELL];

            gameLines = UIMethods.lineSelection(gameLines);

            Random rng = new Random();

            while (true)
            {
                if (UIMethods.playOrNot() && money >= LINE_PRICE)
                {
                    for (int lineIndex = 0; lineIndex < MAX_CELL; lineIndex++)
                    {
                        for (int verticalIndex = 0; verticalIndex < MAX_CELL; verticalIndex++)
                        {
                            int randomIndex = rng.Next(figures.Length);
                            symbolGrid[lineIndex, verticalIndex] = figures[randomIndex];
                        }
                    }
                    UIMethods.randomSymbol(symbolGrid);
                    if (gameLines == MIDDLE_LINE)
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
                            UIMethods.CongratHorizontalLine();
                            money += LINE_PRICE;
                        }
                    }

                    if (gameLines == VERTICAL_LINES)
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
                                UIMethods.CongratHorizontalLine();
                                money += LINE_PRICE;
                            }
                        }
                    }

                    if (gameLines == LINES_COLOMNS)
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
                                UIMethods.CongratHorizontalLine();
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
                                UIMethods.CongatVerticalLine();
                                money += LINE_PRICE;

                            }
                        }
                    }
                    if (gameLines == ALL_LINE)
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
                            UIMethods.CongratDiagonalLine();
                            money += LINE_PRICE;
                        }
                        if (secondaryDiagonalMatch)
                        {
                            UIMethods.CongratDiagonalLine();
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
                                UIMethods.CongratHorizontalLine();
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
                                UIMethods.CongatVerticalLine();
                                money += LINE_PRICE;
                            }
                        }
                    }
                }
                else
                {
                    UIMethods.goodbuyMessage();
                    break;
                }

                if (money < GAME_PRICE)
                {
                    money = UIMethods.creditMaker(money);
                }

                money = UIMethods.remainMoney(money);


            }
        }
    }
}