using System;
using System.Threading;

namespace GameOfLife
{
    class BoardConsole : Board
    {
        public int AreaSize { get; set; }
        public int TimeSleep;        
        public bool DisplayCurrentCoordinates;

        public BoardConsole(int? areaSize = null, int timeSleep = 250, bool displayCurrentCoordinates = false) 
        {
            AreaSize = areaSize == null ? 5 : (int)areaSize;
            TimeSleep = timeSleep > 0 ? timeSleep : throw new ArgumentException("timeSleep must be bigger then zero");
            DisplayCurrentCoordinates = displayCurrentCoordinates;
        }

        public void PlayGame()
        {
            DisplayCurrentStateOfBoard();
            if (DisplayCurrentCoordinates)
            {
                PrintCurrentStateCoordinates();
            }
            Thread.Sleep(TimeSleep);
            while (true)
            {
                Console.SetCursorPosition(1, 0);
                NextState();
                DisplayCurrentStateOfBoard();
                if (DisplayCurrentCoordinates)
                {
                    PrintCurrentStateCoordinates();
                }
                Thread.Sleep(TimeSleep);
            }
        }

        public void DisplayCurrentStateOfBoard()
        {
            Console.WriteLine();
            for (int i = -AreaSize; i < AreaSize * 2; i++)
            {
                for (int j = -AreaSize * 4; j < AreaSize * 4; j++)
                {
                    Console.Write(IsCellExist(j, i) ? "■" : " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Cells on board: " + Convert.ToString(_currentState.Count).PadLeft(10, '0') + "\n");
        }

        public void PrintCurrentStateCoordinates()
        {
            Console.WriteLine();
            foreach (Cell cell in _currentState)
            {
                Console.WriteLine("X: " + cell.X + ", Y: " + cell.Y);
            }
            Console.WriteLine("Cells on board: " + Convert.ToString(_currentState.Count).PadLeft(10, '0') + "\n");
        }
    }
}