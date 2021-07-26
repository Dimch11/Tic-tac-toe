using System.Collections.Generic;
using UnityEngine;

public class FieldDrawer<T>
{
    protected Field<T> field;
    protected CellDrawer cellDrawer;
    protected ICellFiller<T> cellFiller;

    public FieldDrawer(Field<T> field, CellDrawer cellDrawer, ICellFiller<T> cellFiller)
    {
        this.field = field;
        this.cellDrawer = cellDrawer;
        this.cellFiller = cellFiller;
    }

    public void DrawField()
    {
        RemoveField();
        BuildField();
        FillField();
    }
    public void UpdateField()
    {
        ClearField();
        FillField();
    }
    protected void RemoveField()
    {
        cellDrawer.RemoveAllCells();
    }
    protected void BuildField()
    {
        for (int i = 0; i < field.Height; i++)
        {
            for (int j = 0; j < field.Width; j++)
            {
                cellDrawer.DrawCell(CalcCellPosition(i, j));
            }
        }
    }
    protected Vector3 CalcCellPosition(int heightPos, int widthPos)
    {
        var startPosX = cellDrawer.CellSize * (field.Width - 1) * -0.5f;
        var startPosY = cellDrawer.CellSize * (field.Height - 1) * 0.5f;

        return new Vector3(startPosX + cellDrawer.CellSize * widthPos, 
            startPosY - cellDrawer.CellSize * heightPos, 0);
    }
    protected void FillField()
    {
        for (int i = 0; i < field.Height; i++)
        {
            for (int j = 0; j < field.Width; j++)
            {
                cellFiller.FillCell(cellDrawer[i, j], field[i, j]);
            }
        }
    }
    protected void ClearField()
    {
        for (int i = 0; i < field.Height; i++)
        {
            for (int j = 0; j < field.Width; j++)
            {
                cellFiller.ClearCell(cellDrawer[i, j]);
            }
        }
    }
}
