using System;

public enum NoughtsAndCrossesCell
{
    Empty,
    Nought,
    Cross
}

public class NoughtsAndCrossesField : Field<NoughtsAndCrossesCell>
{
    const int DefaultFieldHeight = 3;
    const int DefaultFieldWidth = 3;

    public NoughtsAndCrossesField() : base(DefaultFieldHeight, DefaultFieldWidth)
    {
    }
    public NoughtsAndCrossesField(int height, int width) : base(height, width)
    {
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
    public override bool CellIsEmpty(int heightPos, int widthPos)
    {
        return cells[heightPos, widthPos] == NoughtsAndCrossesCell.Empty ? true : false;
    }
}
