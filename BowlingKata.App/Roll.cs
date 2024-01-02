namespace BowlingKata.App;

public class Roll(char roll)
{
    public bool IsANumberRoll => int.TryParse(roll.ToString(), out _);

    public int NumberRolled => int.Parse(roll.ToString());

    public bool StrikeRolled => roll == 'X';

    public bool SpareRolled => roll == '/';
}
