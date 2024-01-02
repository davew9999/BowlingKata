namespace BowlingKata.App;

public class Rolls(IReadOnlyList<Roll> rolls)
{
    public int Count => rolls.Count;

    public int Score()
    {
        var score = 0;

        for (var index = 0; index < rolls.Count; index++)
        {
            var currentRoll = GetRollForIndex(index);
            var lastRoll = GetLastRoll(index);
            var nextRoll = GetNextRoll(index);
            var nextNextRoll = GetNextNextRoll(index);
            var aLastFrameBonusRoll = ALastFrameBonusRoll(index);

            score += currentRoll.TotalScore(lastRoll, nextRoll, nextNextRoll, aLastFrameBonusRoll);
        }

        return score;
    }

    public Roll GetRollForIndex(int index)
    {
        // Better here instead of `new Roll('0')` to instead use the Null Object Pattern
        return index < rolls.Count && index >= 0 ? rolls[index] : new Roll('-');
    }

    public Roll GetNextRoll(int index)
    {
        return GetRollForIndex(index + 1);
    }

    public Roll GetNextNextRoll(int index)
    {
        return GetRollForIndex(index + 2);
    }

    private Roll GetLastRoll(int index)
    {
        return GetRollForIndex(index - 1);
    }

    private bool ALastFrameBonusRoll(int index)
    {
        return index >= rolls.Count - 2;
    }
}