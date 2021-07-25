using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tic_tac_toe_tests
{
    [TestClass]
    public class CheckWinconditionTest
    {
        [TestMethod]
        public void TestVerticalCrossesWin()
        {
            TestWincondition(BuildVerticalCrossesWinField(), NoughtsAndCrossesCell.Cross);
        }
        [TestMethod]
        public void TestHorisontalNoughtsWin()
        {
            TestWincondition(BuildHorisontalNoughtsWinField(), NoughtsAndCrossesCell.Nought);
        }
        [TestMethod]
        public void TestFirstDiagonalCrossesWin()
        {
            TestWincondition(BuildFirstDiagonalCrossesWinField(), NoughtsAndCrossesCell.Cross);
        }
        [TestMethod]
        public void TestSecondDiagonalNougthssWin()
        {
            TestWincondition(BuildSecondDiagonalNougthsWinField(), NoughtsAndCrossesCell.Nought);
        }
        [TestMethod]
        public void TestDraw()
        {
            TestWincondition(BuildDrawField(), NoughtsAndCrossesCell.Empty);
        }
        public void TestWincondition(Field<NoughtsAndCrossesCell> field, NoughtsAndCrossesCell whoShouldWin)
        {
            IFindWinner<NoughtsAndCrossesCell> winnerChecker
                = new SquareNoughtsAndCrossesWinnerFinder(field);

            Assert.AreEqual(winnerChecker.FindWinner(), whoShouldWin);
        }
        private NoughtsAndCrossesField BuildVerticalCrossesWinField()
        {
            var field = new NoughtsAndCrossesField();
            const int vertNum = 2;

            field[0, vertNum] = NoughtsAndCrossesCell.Cross;
            field[1, vertNum] = NoughtsAndCrossesCell.Cross;
            field[2, vertNum] = NoughtsAndCrossesCell.Cross;

            return field;
        }
        private NoughtsAndCrossesField BuildHorisontalNoughtsWinField()
        {
            var field = new NoughtsAndCrossesField();
            const int horisNum = 1;

            field[horisNum, 0] = NoughtsAndCrossesCell.Nought;
            field[horisNum, 1] = NoughtsAndCrossesCell.Nought;
            field[horisNum, 2] = NoughtsAndCrossesCell.Nought;

            return field;
        }
        private NoughtsAndCrossesField BuildFirstDiagonalCrossesWinField()
        {
            var field = new NoughtsAndCrossesField();

            field[0, 0] = NoughtsAndCrossesCell.Cross;
            field[1, 1] = NoughtsAndCrossesCell.Cross;
            field[2, 2] = NoughtsAndCrossesCell.Cross;

            return field;
        }
        private NoughtsAndCrossesField BuildSecondDiagonalNougthsWinField()
        {
            var field = new NoughtsAndCrossesField();

            field[0, 2] = NoughtsAndCrossesCell.Nought;
            field[1, 1] = NoughtsAndCrossesCell.Nought;
            field[2, 0] = NoughtsAndCrossesCell.Nought;

            return field;
        }
        private NoughtsAndCrossesField BuildDrawField()
        {
            var field = new NoughtsAndCrossesField();

            field[0, 0] = NoughtsAndCrossesCell.Cross;
            field[1, 0] = NoughtsAndCrossesCell.Nought;
            field[2, 0] = NoughtsAndCrossesCell.Cross;

            return field;
        }

    }
}