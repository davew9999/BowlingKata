namespace BowlingKata;

public class BowlingApp
{
    private char[] _rolls;

    public int Score(char[] rolls)
    {
        _rolls = rolls;

        var strikeCount = 0;
        var score = 0;

        for (var index = 0; index < rolls.Length; index++)
        {
            var roll = rolls[index];
            if (roll == 'X')
            {
                strikeCount++;
            }

            if (index < 18)
            {
                if (IsANumberRoll(roll))
                {
                    score += NumberRolled(roll);
                }

                if (roll == '/')
                {
                    score -= LastRollScore(index);
                    score += 10;
                    score += NextRollScore(index);
                }
            }

            else
            {
                if (IsANumberRoll(roll))
                {
                    score += NumberRolled(roll);
                }

                if (roll == '/')
                {
                    score -= LastRollScore(index);
                    score += 10;
                }
            }

        }

        if (strikeCount == 12)
        {
            return 300;
        }

        return score;
    }

    private int LastRollScore(int index)
    {
        var lastRoll = _rolls[index - 1];
        return NumberRolled(lastRoll);
    }

    private int NextRollScore(int index)
    {
        var nextRoll = _rolls[index + 1];
        return NumberRolled(nextRoll);

    }

    private bool IsANumberRoll(char roll)
    {
        return int.TryParse(roll.ToString(), out _);
    }

    private int NumberRolled(char roll)
    {
        return int.Parse(roll.ToString());
    }
}