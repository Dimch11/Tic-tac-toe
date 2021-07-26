using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ResultText;

    private const string crossesWinnerText = "Crosses win!";
    private const string noughtsWinnerText = "Nougths win!";
    private const string drawText = "Draw!";

    public void DisplayResult(NoughtsAndCrossesCell winner)
    {
        if (winner == NoughtsAndCrossesCell.Cross) 
        {
            ResultText.text = crossesWinnerText;
        }
        else if (winner == NoughtsAndCrossesCell.Nought)
        {
            ResultText.text = noughtsWinnerText;
        }
        else
        {
            ResultText.text = drawText;
        }
    }

    public void ClearResult()
    {
        ResultText.text = String.Empty;
    }
}
