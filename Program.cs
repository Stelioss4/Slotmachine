using Slotmachine;
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

            while (true)
            {

                if (UIMethods.playOrNot() && money >= LINE_PRICE)
                {
                    symbolGrid = Logic.randomGeneretor();
                    UIMethods.randomSymbol(symbolGrid);

                    if (gameLines == MIDDLE_LINE)
                    {
                        money -= MIDDLE_LINE;
                        int middleMatches = Logic.MiddleMatchControl(symbolGrid);
                        if(middleMatches == LINE_PRICE)
                        {
                            UIMethods.CongratHorizontalLine();
                            money += LINE_PRICE;
                        }
                       
                    }
                    if (gameLines == HORIZONTAL_LINES)
                    {
                        money -= HORIZONTAL_LINES;
                        int numHorizontalMatches = Logic.HorizontalControl(symbolGrid);
                        for (int i = 0; i < numHorizontalMatches; i++)
                        {
                            UIMethods.CongratHorizontalLine();
                            money += LINE_PRICE;
                        }
                    }

                    if (gameLines == LINES_COLOMNS)
                    {
                        money -= GAME_PRICE;
                        int numHorizontalMatches = Logic.HorizontalControl(symbolGrid);
                        for (int i = 0; i < numHorizontalMatches; i++)
                        {
                            UIMethods.CongratHorizontalLine();
                            money += LINE_PRICE;
                        }
                        int numVerticalMatches = Logic.VerticalControl(symbolGrid);
                        for (int i = 0; i < numVerticalMatches; i++)
                        {
                            UIMethods.CongatVerticalLine();
                            money += LINE_PRICE;
                        }
                    }

                    if (gameLines == ALL_LINE)
                    {
                        money -= GAME_PRICE + LINE_PRICE;
                        int numDiagonalMatches = Logic.diagonalControl(symbolGrid);
                        for(int i = 0; i < numDiagonalMatches; i++)
                        {
                            UIMethods.CongratDiagonalLine();
                            money += LINE_PRICE;
                        }
                        int numHorizontalMatches = Logic.HorizontalControl(symbolGrid);
                        for (int i = 0; i < numHorizontalMatches; i++)
                        {
                            UIMethods.CongratHorizontalLine();
                            money += LINE_PRICE;
                        }
                        int numVerticalMatches = Logic.VerticalControl(symbolGrid);
                        for (int i = 0; i < numVerticalMatches; i++)
                        {
                            UIMethods.CongatVerticalLine();
                            money += LINE_PRICE;
                        }
                    }

                    money = UIMethods.remainMoney(money);
                    if (money < GAME_PRICE)
                    {
                        money = UIMethods.creditMaker(money);
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
