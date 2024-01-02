namespace BowlingKata.App;

public class Rolls(IReadOnlyList<Roll> rolls)
{
    public int Count => rolls.Count;

    public int Score()
    {
        var score = 0;

        for (var index = 0; index < rolls.Count; index++)
        {
            var roll = GetRollForIndex(index);

            if (roll.IsANumberRoll)
                score += roll.NumberRolled;

            else if (roll.StrikeRolled)
                score += StrikeScore(index);

            else if (roll.SpareRolled)
                score += SpareScore(index);
        }

        return score;
    }

    public Roll GetRollForIndex(int index)
    {
        return rolls[index];
    }

    public Roll GetNextRoll(int index, int increment = 1)
    {
        return rolls[index + increment];
    }

    public Roll GetNextNextRoll(int index)
    {
        return GetNextRoll(index, 2);
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

    private int LastRollScore(int index)
    {
        var lastRoll = GetRollForIndex(index - 1);
        return lastRoll.NumberRolled;
    }

    private bool ALastFrameBonusRoll(int index)
    {
        return index >= rolls.Count - 2;
    }

    private int NextRollScore(int index)
    {
        var nextRoll = GetNextRoll(index);
        return nextRoll.Score();
    }

    private int NextNextRollScore(int index)
    {
        var nextNextRoll = GetNextNextRoll(index);
        return nextNextRoll.Score();
    }
}