using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICellFiller<T>
{
    void FillCell(GameObject cell, T content);
    void ClearCell(GameObject cell);
}
