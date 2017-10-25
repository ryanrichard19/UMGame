using System;
using NUnit.Framework;

namespace UMGame.Library.Tests
{
    [TestFixture]
    public class RulesTests
    {

        [Test]
        [TestCase(0, CellValue.Dead)]
        [TestCase(1, CellValue.Dead)]
        [TestCase(2, CellValue.Alive)]
        [TestCase(3, CellValue.Alive)]
        [TestCase(4, CellValue.Dead)]
        [TestCase(5, CellValue.Dead)]
        [TestCase(6, CellValue.Dead)]
        [TestCase(7, CellValue.Dead)]
        [TestCase(8, CellValue.Dead)]
        public void TestLiveCellValues(int liveNeighbors,CellValue expected)
        {
            // Arrange
            CellValue currentValue = CellValue.Alive;

            // Act
            CellValue result = Rules.GetNewValue(currentValue, liveNeighbors);

            // Assert
            Assert.AreEqual(expected, result);
        }

 

        [TestCase(3, CellValue.Alive)]
        [TestCase(0, CellValue.Dead)]
        [TestCase(1, CellValue.Dead)]
        [TestCase(2, CellValue.Dead)]
        [TestCase(4, CellValue.Dead)]
        [TestCase(5, CellValue.Dead)]
        [TestCase(6, CellValue.Dead)]
        [TestCase(7, CellValue.Dead)]
        [TestCase(8, CellValue.Dead)]
        public void TestDeadCellValues(int liveNeighbors, CellValue expected)
        {
            // Arrange
            CellValue currentValue = CellValue.Dead;

            // Act
            CellValue result = Rules.GetNewValue(currentValue, liveNeighbors);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
