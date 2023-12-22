namespace BowlingKata;

public class BowlingApp
{
    private char[] _rolls;

    public int Score(char[] rolls)
    {
        _rolls = rolls;

        var score = 0;

        for (var index = 0; index < rolls.Length; index++)
        {
            var roll = rolls[index];
            
            if (roll == 'X')
            {
                if (index < rolls.Length - 2)
                {
                    score += 10;
                    score += NextRollScore(index);
                    score += NextNextRollScore(index);
                }
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

        return score;
    }

    private int LastRollScore(int index)
    {
        var lastRoll = _rolls[index - 1];
        return NumberRolled(lastRoll);
    }

    private int NextRollScore(int index)
    {
        if (index > _rolls.Length - 2)
        {
            return 0;
        }

        var nextRoll = _rolls[index + 1];

        if (IsANumberRoll(nextRoll))
        {
            return NumberRolled(nextRoll);
        }
        else if (nextRoll == 'X')
        {
            return 10;
        }

        return 0;
    }

    private int NextNextRollScore(int index)
    {
        if (index > _rolls.Length - 3)
        {
            return 0;
        }

        var nextRoll = _rolls[index + 2];

        if (IsANumberRoll(nextRoll))
        {
            return NumberRolled(nextRoll);
        }
        else if (nextRoll == 'X')
        {
            return 10;
        }

        return 0;
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