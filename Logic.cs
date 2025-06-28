namespace Slotmachine
{
    public class Logic
    {
        public string[,] GenerateRandomGrid()
        {
            Random rng = new Random();

            string[] figures = { CONSTANTS.CHERRY, CONSTANTS.WATERMELON, CONSTANTS.DIAMOND, CONSTANTS.STAR, CONSTANTS.BELL, CONSTANTS.LEMON };
            string[,] symbolGrid = new string[CONSTANTS.MAX_CELL, CONSTANTS.MAX_CELL];

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

        public static int HorizontalControl(string[,] symbolGrid)
        {
            int horizontalMatches = 0;
            for (int lineIndex = 0; lineIndex < CONSTANTS.MAX_CELL; lineIndex++)
            {
                bool rowMatch = true;
                string firstChar = symbolGrid[lineIndex, 0];
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

        public static int VerticalControl(string[,] symbolGrid)
        {
            int verticalMatches = 0;
            for (int verticalIndex = 0; verticalIndex < CONSTANTS.MAX_CELL; verticalIndex++)
            {
                bool colMatch = true;
                string firstChar = symbolGrid[0, verticalIndex];
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

        public static int diagonalControl(string[,] symbolGrid)
        {
            int diagonalMatches = 0;
            bool mainDiagonalMatch = true;
            string mainDiagonalChar = symbolGrid[0, 0];

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
            string secondaryDiagonalChar = symbolGrid[0, CONSTANTS.MAX_CELL - 1];

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

        public static int MiddleLineMatchControl(string[,] symbolGrid)
        {
            int middleMatches = 0;
            int lineIndex = CONSTANTS.MIDDLE_LINE;
            bool rowMatch = true;
            string firstChar = symbolGrid[lineIndex, 0];

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

        public static double HandleDiagonalMatches(string[,] symbolGrid , double money)
        {
            int numDiagonalMatches = diagonalControl(symbolGrid);

            for (int i = 0; i < numDiagonalMatches; i++)
            {
                UIMethods.displayCongratsForDiagonalWin();
                money += CONSTANTS.LINE_PRICE;
            }
            return money;
        }

        public static double HandleVerticalMatches(string[,] symbolGrid, double money)
        {
            
            int numVerticalMatches = VerticalControl(symbolGrid);
            for (int i = 0; i < numVerticalMatches; i++)
            {
                UIMethods.displayCongratsForVerticalWin();
                money += CONSTANTS.LINE_PRICE;
            }
            return money;
        }

        public static double HandleHorizontalMatches(string[,] symbolGrid , double money)
        {
            
            int numHorizontalMatches = HorizontalControl(symbolGrid);
            for (int i = 0; i < numHorizontalMatches; i++)
            {
                UIMethods.displayCongratsForHorizontalWin();
                money += CONSTANTS.LINE_PRICE;
            }
            return money;
        }

        public static double HandleMiddleLineMatch(string[,] symbolGrid , double money)
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
