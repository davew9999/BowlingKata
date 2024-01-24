namespace BowlingKata.App;

public class Rolls(IReadOnlyList<Roll> rolls)
{
    public int Count => rolls.Count;

    public int Score()
    {
        // TODO: add more test cases
        // TODO: maybe change from 'X' and '/' to numbers?
        // TODO: make this method smaller!

        var score = 0;

        var rollIndex = 0;
        for (var frame = 1; frame <= 10; frame++)
        {
            var currentRoll = GetRollForIndex(rollIndex);
            var nextRoll = GetNextRoll(rollIndex);
            if (currentRoll.StrikeRolled)
            {
                var nextNextRoll = GetNextNextRoll(rollIndex);
                score += 10 + nextRoll.RawScore() + nextNextRoll.RawScore();
                if (nextNextRoll.SpareRolled)
                    score -= nextRoll.RawScore();

                rollIndex++;
            }
            else if (nextRoll.SpareRolled)
            {
                var nextNextRoll = GetNextNextRoll(rollIndex);
                score += 10 + nextNextRoll.RawScore();
                rollIndex += 2;
            }
            else
            {
                score += currentRoll.NumberRolled + nextRoll.NumberRolled;
                rollIndex += 2;
            }
        }

        return score;
    }

    public Roll GetRollForIndex(int index)
    {
        return rolls[index];
    }

    public Roll GetNextRoll(int index)
    {
        return GetRollForIndex(index + 1);
    }

    public Roll GetNextNextRoll(int index)
    {
        return GetRollForIndex(index + 2);
    }

}