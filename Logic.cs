namespace Slotmachine
{
    public static class Logic
    {
        public static char[,] GenerateRandomGrid()
        {
            Random rng = new Random();

            char[] figures = { CONSTANTS.ACE, CONSTANTS.KING, CONSTANTS.QUEEN };
            char[,] symbolGrid = new char[CONSTANTS.MAX_CELL, CONSTANTS.MAX_CELL];

            for (int lineIndex = 0; lineIndex < CONSTANTS.MAX_CELL; lineIndex++)
            {
                for (int verticalIndex = 0; verticalIndex < CONSTANTS.MAX_CELL; verticalIndex++)
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
            for (int lineIndex = 0; lineIndex < CONSTANTS.MAX_CELL; lineIndex++)
            {
                bool rowMatch = true;
                char firstChar = symbolGrid[lineIndex, 0];
                for (int verticalIndex = 1; verticalIndex < CONSTANTS.MAX_CELL; verticalIndex++)
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
            for (int verticalIndex = 0; verticalIndex < CONSTANTS.MAX_CELL; verticalIndex++)
            {
                bool colMatch = true;
                char firstChar = symbolGrid[0, verticalIndex];
                for (int lineIndex = 1; lineIndex < CONSTANTS.MAX_CELL; lineIndex++)
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

            for (int i = 1; i < CONSTANTS.MAX_CELL; i++)
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
            char secondaryDiagonalChar = symbolGrid[0, CONSTANTS.MAX_CELL - 1];

            for (int i = 1; i < CONSTANTS.MAX_CELL; i++)
            {
                if (symbolGrid[i, CONSTANTS.MAX_CELL - 1 - i] != secondaryDiagonalChar)
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

        public static int MiddleLineMatchControl(char[,] symbolGrid)
        {
            int middleMatches = 0;
            int lineIndex = CONSTANTS.MIDDLE_LINE;
            bool rowMatch = true;
            char firstChar = symbolGrid[lineIndex, 0];

            for (int verticalIndex = 1; verticalIndex < CONSTANTS.MAX_CELL; verticalIndex++)
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

        public static double HandleDiagonalMatches(char[,] symbolGrid , double money)
        {
            int numDiagonalMatches = diagonalControl(symbolGrid);

            for (int i = 0; i < numDiagonalMatches; i++)
            {
                UIMethods.displayCongratsForDiagonalWin();
                money += CONSTANTS.LINE_PRICE;
            }
            return money;
        }

        public static double HandleVerticalMatches(char[,] symbolGrid, double money)
        {
            
            int numVerticalMatches = VerticalControl(symbolGrid);
            for (int i = 0; i < numVerticalMatches; i++)
            {
                UIMethods.displayCongratsForVerticalWin();
                money += CONSTANTS.LINE_PRICE;
            }
            return money;
        }

        public static double HandleHorizontalMatches(char[,] symbolGrid , double money)
        {
            
            int numHorizontalMatches = HorizontalControl(symbolGrid);
            for (int i = 0; i < numHorizontalMatches; i++)
            {
                UIMethods.displayCongratsForHorizontalWin();
                money += CONSTANTS.LINE_PRICE;
            }
            return money;
        }

        public static double HandleMiddleLineMatch(char[,] symbolGrid , double money)
        {
            int middleMatches = MiddleLineMatchControl(symbolGrid);
            if (middleMatches > 0)
            {
                UIMethods.displayCongratsForHorizontalWin();
                money += middleMatches * CONSTANTS.LINE_PRICE;
            }
            return money;
        }
    }
}
