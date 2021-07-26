using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellDrawer : MonoBehaviour
{
    public GameObject CellPrefab;
    public float CellSize
    {
        get => CellPrefab.GetComponent<Renderer>().bounds.size.x;
    }
    public GameObject this[int heightPos, int widthPos]
    {
        get => displayedCells[(heightPos + 1) * widthPos];
    }

    protected List<GameObject> displayedCells = new List<GameObject>();

    public void DrawCell(Vector3 position)
    {
        var newCell = Instantiate(CellPrefab);
        newCell.transform.SetParent(transform);
        newCell.transform.localPosition = position;
        displayedCells.Add(newCell);
    }
    public void RemoveAllCells()
    {
        foreach (var cell in displayedCells)
        {
            Destroy(cell);
        }
        displayedCells.Clear();
    }
}
