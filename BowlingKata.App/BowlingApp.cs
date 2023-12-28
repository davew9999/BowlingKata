namespace BowlingKata.App;

public class BowlingApp(IReadOnlyList<char> rolls)
{
    public int Score()
    {
        var score = 0;

        for (var index = 0; index < rolls.Count; index++)
        {
            var roll = rolls[index];

            if (IsANumberRoll(roll))
                score += NumberRolled(roll);

            else if (StrikeRolled(roll))
                score += StrikeScore(index);

            else if (SpareRolled(roll))
                score += SpareScore(index);
        }

        return score;
    }

    private int SpareScore(int index)
    {
        var score = 0;
        score -= LastRollScore(index);
        score += 10;

        if (!ALastFrameBonusRoll(index))
            score += NextRollScore(index);
        return score;
    }

    private int StrikeScore(int index)
    {
        var score = 0;
        if (ALastFrameBonusRoll(index)) return score;
        score += 10;
        score += NextRollScore(index);
        score += NextNextRollScore(index);
        return score;
    }

    private bool ALastFrameBonusRoll(int index)
    {
        return index >= rolls.Count - 2;
    }

    public char GetNextNextRoll(int index)
    {
        return GetNextRoll(index, 2);
    }

    public char GetNextRoll(int index, int increment = 1)
    {
        return rolls[index + increment];
    }

    public static bool StrikeRolled(char roll)
    {
        return roll == 'X';
    }

    private static bool SpareRolled(char roll)
    {
        return roll == '/';
    }

    private int LastRollScore(int index)
    {
        var lastRoll = rolls[index - 1];
        return NumberRolled(lastRoll);
    }

    private int NextRollScore(int index)
    {
        var nextRoll = GetNextRoll(index);

        if (IsANumberRoll(nextRoll))
            return NumberRolled(nextRoll);

        return StrikeRolled(nextRoll) ? 10 : 0;
    }

    private int NextNextRollScore(int index)
    {
        var nextNextRoll = GetNextNextRoll(index);

        if (IsANumberRoll(nextNextRoll))
            return NumberRolled(nextNextRoll);

        return StrikeRolled(nextNextRoll) ? 10 : 0;
    }

    private static bool IsANumberRoll(char roll)
    {
        return int.TryParse(roll.ToString(), out _);
    }

    private static int NumberRolled(char roll)
    {
        return int.Parse(roll.ToString());
    }
}