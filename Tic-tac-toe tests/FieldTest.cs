using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tic_tac_toe_tests
{
    [TestClass]
    public class FieldTest
    {
        [TestMethod]
        public void TestFieldBounds()
        {
            Field<NoughtsAndCrossesCell> field = new NoughtsAndCrossesField();
            field[field.Height - 1, field.Width - 1] = NoughtsAndCrossesCell.Cross;

            Assert.AreEqual(field[field.Height - 1, field.Width - 1], NoughtsAndCrossesCell.Cross);
            Assert.ThrowsException<ArgumentException>(() => field[field.Height, field.Width - 1]);
            Assert.ThrowsException<ArgumentException>(() => field[field.Height - 1, field.Width]);
        }

        [TestMethod]
        public void TestFieldClear()
        {
            Field<NoughtsAndCrossesCell> field = new NoughtsAndCrossesField();
            field[0, 0] = NoughtsAndCrossesCell.Cross;
            field.Clear();

            Assert.AreEqual(field[0, 0], NoughtsAndCrossesCell.Empty);
        }

        [TestMethod]
        public void TestGeneratedFieldDoesntContainsEmptyCells()
        {
            var rndFieldGenerator = new RandomNoughtsAndCrossesFieldGenerator();

            var field = rndFieldGenerator.GenerateField();

            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (field[i, j] == NoughtsAndCrossesCell.Empty)
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}
