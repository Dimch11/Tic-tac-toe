using System;
using System.Collections.Generic;

public class SquareNoughtsAndCrossesWinnerFinder : IFindWinner<NoughtsAndCrossesCell>
{
    protected Field<NoughtsAndCrossesCell> field;
    protected NoughtsAndCrossesCell curPotentialWinner = NoughtsAndCrossesCell.Empty;
    protected int crossesScore;
    protected int noughtsScore;

    public SquareNoughtsAndCrossesWinnerFinder(Field<NoughtsAndCrossesCell> field)
    {
        this.field = field;
    }

    public NoughtsAndCrossesCell FindWinner()
    {
        curPotentialWinner = NoughtsAndCrossesCell.Cross;
        crossesScore = CountWinCombinationsForCurPotentialWinner();

        curPotentialWinner = NoughtsAndCrossesCell.Nought;
        noughtsScore = CountWinCombinationsForCurPotentialWinner();

        return DetermineWinner();
    }
    protected NoughtsAndCrossesCell DetermineWinner()
    {
        if (crossesScore > noughtsScore)
        {
            return NoughtsAndCrossesCell.Cross;
        }
        else if(noughtsScore > crossesScore)
        {
            return NoughtsAndCrossesCell.Nought;
        }
        else
        {
            return NoughtsAndCrossesCell.Empty;
        }
    }
    protected int CountWinCombinationsForCurPotentialWinner()
    {
        var numOfCombinations = 0;

        numOfCombinations += CheckDiagonalLines();
        numOfCombinations += CountVerticalLineMatches();
        numOfCombinations += CheckHorisontalLines();

        return numOfCombinations;
    }
    protected int CheckDiagonalLines()
    {
        var numOfCombinations = 0;
        var firstDiagonalMatch = true;
        var secondDiagonalMatch = true;

        for (int i = 0; i < field.Height; i++)
        {
            if (field[i, i] != curPotentialWinner)
            {
                firstDiagonalMatch = false;
            }
            
            if (field[i, field.Height - 1 - i] != curPotentialWinner)
            {
                secondDiagonalMatch = false;
            }
        }

        if (firstDiagonalMatch) numOfCombinations++;
        if (secondDiagonalMatch) numOfCombinations++;

        return numOfCombinations;
    }
    protected int CountVerticalLineMatches()
    {
        var numOfCombinations = 0;

        for (int i = 0; i < field.Width; i++)
        {
            if (VerticalLineMatch(i))
            {
                numOfCombinations++;
            }
        }

        return numOfCombinations;
    }
    protected bool VerticalLineMatch(int lineNum)
    {
        var lineMatch = true;

        for (int i = 0; i < field.Height; i++)
        {
            if (field[i, lineNum] != curPotentialWinner)
            {
                lineMatch = false;
                break;
            }
        }

        return lineMatch;
    }
    protected int CheckHorisontalLines()
    {
        var numOfCombinations = 0;

        for (int i = 0; i < field.Height; i++)
        {
            if (HorisontalLineMatch(i))
            {
                numOfCombinations++;
            }
        }

        return numOfCombinations;
    }
    protected bool HorisontalLineMatch(int lineNum)
    {
        var lineMatch = true;

        for (int i = 0; i < field.Width; i++)
        {
            if (field[lineNum, i] != curPotentialWinner)
            {
                lineMatch = false;
                break;
            }
        }

        return lineMatch;
    }
}
