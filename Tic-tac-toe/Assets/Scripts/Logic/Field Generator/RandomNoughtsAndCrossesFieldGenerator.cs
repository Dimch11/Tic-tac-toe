using System;


public class RandomNoughtsAndCrossesFieldGenerator : IFieldGenerator<NoughtsAndCrossesCell>
{
    Random rnd = new Random();

    public void GenerateField(Field<NoughtsAndCrossesCell> field)
    {
        for (int i = 0; i < field.Height; i++)
        {
            for (int j = 0; j < field.Width; j++)
            {
                field[i, j] = GenerateNoughtOrCross();
            }
        }
    }

    private NoughtsAndCrossesCell GenerateNoughtOrCross()
    {
        const int nought = 0;
        const int cross = 1;

        var randomContent = rnd.Next(nought, cross + 1);

        return randomContent == nought ? NoughtsAndCrossesCell.Nought : NoughtsAndCrossesCell.Cross;
    }
}
