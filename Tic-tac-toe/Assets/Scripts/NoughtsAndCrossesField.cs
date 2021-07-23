using System;
using System.Collections;
using System.Collections.Generic;

public enum CellContent
{
    Nought,
    Cross
}

public class NoughtsAndCrossesField
{
    public CellContent this[int heightPos, int widthPos]
    {
        get 
        {
            return TryGetCell(heightPos, widthPos);
        }
        set
        {
            TrySetCell(heightPos, widthPos, value);
        }
    }

    CellContent[,] cells;

    public NoughtsAndCrossesField(int height, int width)
    {
        cells = new CellContent[height, width];
    }


    private CellContent TryGetCell(int heightPos, int widthPos)
    {
        if (CellExists(heightPos, widthPos))
        {
            return cells[heightPos, widthPos];
        }
        else
        {
            throw new ArgumentException();
        }
    }

    private void TrySetCell(int heightPos, int widthPos, CellContent cellContent)
    {
        if (CellExists(heightPos, widthPos))
        {
            cells[heightPos, widthPos] = cellContent;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    private bool CellExists(int heightPos, int widthPos)
    {
        bool heightIsOk = heightPos >= 0 && heightPos < cells.GetLength(0);
        bool widthIsOk = widthPos >= 0 && widthPos < cells.GetLength(1);

        return heightIsOk && widthIsOk;
    }
}
