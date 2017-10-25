using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UMGame.Library
{
    public class GameGrid
    {
        int height;
        int width;

        public CellValue[,] CurrentValue;
        private CellValue[,] nextValue;

        public GameGrid(int h, int w)
        {
            height = h;
            width = w;

            CurrentValue = new CellValue[height, width];
            nextValue = new CellValue[height, width];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    CurrentValue[i, j] = CellValue.Dead;
                }
        }

        public void UpdateValue()
        {
            Parallel.For(0, height, i =>
            {
                for (int j = 0; j < width; j++)
                {
                    var liveNeighbours = GetLiveNeighbours(i, j);
                    nextValue[i, j] =
                        Rules.GetNewValue(CurrentValue[i, j], liveNeighbours);
                }
            });

            CurrentValue = nextValue;
            nextValue = new CellValue[height, width];
        }

        public void Initialize()
        {
            Random random = new Random();

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    var next = random.Next(2);
                    var newValue = next < 1 ? CellValue.Dead : CellValue.Alive;
                    CurrentValue[i, j] = newValue;
                }
        }

        private int GetLiveNeighbours(int positionX, int positionY)
        {
            int liveNeighbours = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborX = positionX + i;
                    int neighborY = positionY + j;

                    if (neighborX >= 0 && neighborX < height &&
                        neighborY >= 0 && neighborY < width)
                    {
                        if (CurrentValue[neighborX, neighborY] == CellValue.Alive)
                            liveNeighbours++;
                    }
                }

            return liveNeighbours;
        }
    }
}
