namespace BowlingKata.App;

public class Roll(char roll)
{
    public int TotalScore(Roll lastRoll, Roll nextRoll, Roll nextNextRoll, bool aLastFrameBonusRoll)
    {
        var score = 0;
        if (IsANumberRoll)
            score += RawScore();

        else if (StrikeRolled)
            score += StrikeScore(aLastFrameBonusRoll, nextRoll, nextNextRoll);

        else if (SpareRolled)
            score += SpareScore(aLastFrameBonusRoll, lastRoll, nextRoll);

        return score;
    }

    private bool IsANumberRoll => int.TryParse(roll.ToString(), out _);

    private int NumberRolled => int.Parse(roll.ToString());

    public bool StrikeRolled => roll == 'X';

    private bool SpareRolled => roll == '/';

    private int RawScore()
    {
        if (IsANumberRoll)
            return NumberRolled;

        return StrikeRolled || SpareRolled ? 10 : 0;
    }

    private int SpareScore(bool aLastFrameBonusRoll, Roll lastRoll, Roll nextRoll)
    {
        var score = 0;
        score -= lastRoll.RawScore();
        score += RawScore();

        if (!aLastFrameBonusRoll)
            score += nextRoll.RawScore();
        return score;
    }

    private int StrikeScore(bool aLastFrameBonusRoll, Roll nextRoll, Roll nextNextRoll)
    {
        var score = 0;
        if (aLastFrameBonusRoll) return score;

        score += RawScore();
        score += nextRoll.RawScore();
        score += nextNextRoll.RawScore();
        return score;
    }
}
