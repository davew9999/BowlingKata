namespace BowlingKata.App;

public class Roll(char roll)
{
    public int NumberRolled => int.Parse(roll.ToString());

    public bool StrikeRolled => roll == 'X';

    public bool SpareRolled => roll == '/';

    public int RawScore()
    {
        if (StrikeRolled || SpareRolled)
            return 10;

        return NumberRolled;
    }
}
