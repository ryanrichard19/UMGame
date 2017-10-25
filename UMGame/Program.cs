using System;
using System.Text;
using UMGame.Library;

namespace UMGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new GameGrid(50, 160);
            grid.Initialize();

            DisplayGrid(grid.CurrentValue);
            Console.Write("Press Enter for Next move or enter in q to quit:");
            while (Console.ReadLine() != "q")
            {
                grid.UpdateValue();
                DisplayGrid(grid.CurrentValue);
                Console.Write("Press Enter for Next move or enter in q to quit:");
            }
        }

        private static void DisplayGrid(CellValue[,] currentValue)
        {
            Console.Clear();
            int x = 0;
            int rowLength = currentValue.GetUpperBound(1) + 1;

            var output = new StringBuilder();

            foreach (var state in currentValue)
            {
                output.Append(state == CellValue.Alive ? "X" : "·");
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    output.AppendLine();
                }
            }
            Console.Write(output.ToString());
        }
    }
}
