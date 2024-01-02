namespace BowlingKata.App;

public class BowlingApp(IReadOnlyList<Roll> rolls)
{
    public int Score()
    {
        var score = 0;

        for (var index = 0; index < rolls.Count; index++)
        {
            var roll = rolls[index];

            if (roll.IsANumberRoll)
                score += roll.NumberRolled;

            else if (roll.StrikeRolled)
                score += StrikeScore(index);

            else if (roll.SpareRolled)
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

    public Roll GetNextNextRoll(int index)
    {
        return GetNextRoll(index, 2);
    }

    public Roll GetNextRoll(int index, int increment = 1)
    {
        return rolls[index + increment];
    }

    private int LastRollScore(int index)
    {
        var lastRoll = rolls[index - 1];
        return lastRoll.NumberRolled;
    }

    private int NextRollScore(int index)
    {
        var nextRoll = GetNextRoll(index);

        if (nextRoll.IsANumberRoll)
            return nextRoll.NumberRolled;

        return nextRoll.StrikeRolled ? 10 : 0;
    }

    private int NextNextRollScore(int index)
    {
        var nextNextRoll = GetNextNextRoll(index);

        if (nextNextRoll.IsANumberRoll)
            return nextNextRoll.NumberRolled;

        return nextNextRoll.StrikeRolled ? 10 : 0;
    }
}