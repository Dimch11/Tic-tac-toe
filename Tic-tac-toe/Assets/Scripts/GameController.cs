using System.Collections;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject CellDrawerGO;
    public UIController UIController;

    private Field<NoughtsAndCrossesCell> field;
    private FieldDrawer<NoughtsAndCrossesCell> fieldDrawer;

    private void Awake()
    {
        Init();
        fieldDrawer.DrawField();
    }
    private void Init()
    {
        field = new NoughtsAndCrossesField();

        var cellDrawer = CellDrawerGO.GetComponent<CellDrawer>();
        var cellFiller = CellDrawerGO.GetComponent<NoughtsAndCrossesCellFiller>();

        fieldDrawer = new FieldDrawer<NoughtsAndCrossesCell>(field, cellDrawer, cellFiller);
    }
    public void FillField()
    {
        var fieldGenerator = new RandomNoughtsAndCrossesFieldGenerator();
        fieldGenerator.GenerateField(field);
        
        fieldDrawer.UpdateField();
    }
    public void DisplayWinner()
    {
        var winnerFiender = new SquareNoughtsAndCrossesWinnerFinder(field);
        var winner = winnerFiender.FindWinner();

        UIController.DisplayResult(winner);
    }
}
