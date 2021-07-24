using System;

public enum NoughtsAndCrossesCell
{
    Empty,
    Nought,
    Cross
}

public class NoughtsAndCrossesField : Field<NoughtsAndCrossesCell>
{
    public override NoughtsAndCrossesCell this[int heightPos, int widthPos]
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
    public override int Height { get => cells.GetLength(0); }
    public override int Width { get => cells.GetLength(1); }

    const int DefaultFieldHeight = 3;
    const int DefaultFieldWidth = 3;

    NoughtsAndCrossesCell[,] cells;


    public NoughtsAndCrossesField()
    {
        cells = new NoughtsAndCrossesCell[DefaultFieldHeight, DefaultFieldWidth];

        Clear();
    }
    public NoughtsAndCrossesField(int height, int width)
    {
        cells = new NoughtsAndCrossesCell[height, width];

        Clear();
    }
    

    public override void Clear()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                ClearCell(i, j);
            }
        }
    }

    public override void ClearCell(int heightPos, int widthPos)
    {
        cells[heightPos, widthPos] = NoughtsAndCrossesCell.Empty;
    }

    private NoughtsAndCrossesCell TryGetCell(int heightPos, int widthPos)
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

    private void TrySetCell(int heightPos, int widthPos, NoughtsAndCrossesCell cellContent)
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
