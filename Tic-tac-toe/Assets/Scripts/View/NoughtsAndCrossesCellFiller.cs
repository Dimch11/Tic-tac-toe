using System;
using System.Collections.Generic;
using UnityEngine;

public class NoughtsAndCrossesCellFiller : MonoBehaviour, ICellFiller<NoughtsAndCrossesCell>
{
    public Sprite Nought;
    public Sprite Cross;

    public void FillCell(GameObject cell, NoughtsAndCrossesCell content)
    {
        if (content == NoughtsAndCrossesCell.Nought)
        {
            SetCellImage(cell, Nought);
        }
        else if (content == NoughtsAndCrossesCell.Cross)
        {
            SetCellImage(cell, Cross);
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public void ClearCell(GameObject cell)
    {
        SetCellImage(cell, null);
    }
    protected void SetCellImage(GameObject cell, Sprite sprite)
    {
        cell.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
