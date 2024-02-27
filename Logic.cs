using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace Slotmachine
{
    public static class Logic
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
        public static char[,] randomGeneretor()
        {
            Random rng = new Random();
            char[] figures = { ACE, KING, QUEEN };
            char[,] symbolGrid = new char[MAX_CELL, MAX_CELL];

            for (int lineIndex = 0; lineIndex < MAX_CELL; lineIndex++)
            {
                for (int verticalIndex = 0; verticalIndex < MAX_CELL; verticalIndex++)
                {
                    int randomIndex = rng.Next(figures.Length);
                    symbolGrid[lineIndex, verticalIndex] = figures[randomIndex];
                }
            }
            return symbolGrid;
        }
        public static int HorizontalControl(char[,] symbolGrid)
        {
            int horizontalMatches = 0;
           // char[] figures = { ACE, KING, QUEEN };


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
                    horizontalMatches++;
                }
            }

            return horizontalMatches;
        }




        public static int VerticalControl(char[,] symbolGrid)
        {
            int verticalMatches = 0;
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
                    verticalMatches++;
                }
            }
            return verticalMatches;
        }

        public static int diagonalControl(char[,] symbolGrid)
        {
            int diagonalMatches = 0;
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
            if (mainDiagonalMatch)
            {
                diagonalMatches++;
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
            if (secondaryDiagonalMatch)
            {
                diagonalMatches++;
            }

            return diagonalMatches;
        }

        public static int MiddleMatchControl(char[,] symbolGrid)
        {
            int middleMatches = 0; 
            int lineIndex = MIDDLE_LINE;
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
               middleMatches++;
            }
            return middleMatches;
        }

    }
}
