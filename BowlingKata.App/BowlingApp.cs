namespace BowlingKata.App;

public class BowlingApp(IReadOnlyList<char> rolls)
{
    public int Score()
    {
        var score = 0;

        for (var index = 0; index < rolls.Count; index++)
        {
            var roll = new Roll(rolls[index]);

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

    public char GetNextNextRoll(int index)
    {
        return GetNextRoll(index, 2);
    }

    public char GetNextRoll(int index, int increment = 1)
    {
        return rolls[index + increment];
    }

    private int LastRollScore(int index)
    {
        var lastRoll = rolls[index - 1];
        return new Roll(lastRoll).NumberRolled;
    }

    private int NextRollScore(int index)
    {
        var nextRoll = GetNextRoll(index);

        if (new Roll(nextRoll).IsANumberRoll)
            return new Roll(nextRoll).NumberRolled;

        return new Roll(nextRoll).StrikeRolled ? 10 : 0;
    }

    private int NextNextRollScore(int index)
    {
        var nextNextRoll = GetNextNextRoll(index);

        if (new Roll(nextNextRoll).IsANumberRoll)
            return new Roll(nextNextRoll).NumberRolled;

        return new Roll(nextNextRoll).StrikeRolled ? 10 : 0;
    }
}