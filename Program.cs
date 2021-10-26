using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {        
            BoardConsole b = new BoardConsole(areaSize: 5, timeSleep: 250, displayCurrentCoordinates: false);            
            b.AreaSize = 7;
            b.AddCell(1, 1);
            b.AddCell(1, 2);
            b.AddCell(1, 3);
            b.AddCell(2, 2);
            b.AddCell(2, 3);
            b.AddCell(2, 4);
            b.AddCell(-5, 0);
            b.AddCell(-5, 2);
            b.AddCell(-6, 1);
            b.AddCell(-4, 1);
            b.AddCell(-18, -5);
            b.AddCell(-18, -4);
            b.AddCell(-18, -3);
            b.AddCell(-19, -3);
            b.AddCell(-20, -4);
            b.AddCell(10, 0);
            b.AddCell(11, 0);
            b.AddCell(12, 0);
            b.AddCell(-10, 5);
            b.AddCell(-10, 6);
            b.AddCell(-10, 7);
            Random rnd = new Random();
            int randomX, randomY;
            for (int i = 0; i < 100; i++)
            {
                randomX = rnd.Next(-20, 20);
                randomY = rnd.Next(-20, 20);
                b.AddCell(randomX, randomY);
            }
            b.PlayGame();
            Console.ReadKey();
        }
    }
}