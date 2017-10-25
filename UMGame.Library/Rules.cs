using System;

namespace UMGame.Library
{
    public enum CellValue
    {
        Alive,
        Dead,
    }
    public class Rules
    {
        public static CellValue GetNewValue(CellValue currentValue, int aliveNeighbours)
        {
            switch (currentValue)
            {
                case CellValue.Alive:
                    if (aliveNeighbours < 2 || aliveNeighbours > 3)
                        return CellValue.Dead;
                    break;
                case CellValue.Dead:
                    if (aliveNeighbours == 3)
                        return CellValue.Alive;
                    break;
            }
            return currentValue;
        }
    }
   
}
