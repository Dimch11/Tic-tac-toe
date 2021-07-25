using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tic_tac_toe_tests
{
    [TestClass]
    public class FieldGeneratorTest
    {
        [TestMethod]
        public void TestGeneratedFieldDoesntContainsEmptyCells()
        {
            var rndFieldGenerator = new RandomNoughtsAndCrossesFieldGenerator();

            var field = rndFieldGenerator.GenerateField();

            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (field.CellIsEmpty(i, j))
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}
