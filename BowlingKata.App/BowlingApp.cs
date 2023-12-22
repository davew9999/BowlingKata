namespace BowlingKata.App;

public class BowlingApp
{
    private char[] _rolls;
    private int _frame = 1;

    public int Score(char[] rolls)
    {
        _rolls = rolls;

        var score = 0;

        var frames = ConvertToFrames();

        for (var index = 0; index < rolls.Length; index++)
        {
            var roll = rolls[index];

            if (roll == 'X')
            {
                // If not last frame OR first roll in last frame
                if (index < rolls.Length - 2)
                {
                    score += 10;
                    score += NextRollScore(index);
                    score += NextNextRollScore(index);
                }
            }

            if (IsANumberRoll(roll))
            {
                score += NumberRolled(roll);
            }

            if (index < 18)
            {
                if (roll == '/')
                {
                    score -= LastRollScore(index);
                    score += 10;
                    score += NextRollScore(index);
                }
            }

            else
            {
                if (roll == '/')
                {
                    score -= LastRollScore(index);
                    score += 10;
                }
            }

        }

        return score;
    }

    private List<object> ConvertToFrames()
    {
        var frames = new List<object>();

        for (int i = 0; i < _rolls.Length;)
        {
            var roll = _rolls[i];

            if (frames.Count < 9)
            {
                var currentFrame = new Frame
                {
                    FirstRoll = roll
                };

                if (IsStrike(roll))
                {
                    i++;
                }
                else
                {
                    currentFrame.SecondRoll = GetNextRoll(i);
                    i += 2;
                }

                frames.Add(currentFrame);
            }
            else
            {
                var finalFrame = new FinalFrame
                {
                    FirstRoll = roll,
                    SecondRoll = GetNextRoll(i)
                };

                if (i + 2 < _rolls.Length)
                {
                    finalFrame.ThirdRoll = GetNextNextRoll(i);
                }

                frames.Add(finalFrame);
                break;
            }
        }

        return frames;
    }

    private char GetNextNextRoll(int index)
    {
        return GetNextRoll(index, 2);
    }

    private char GetNextRoll(int index, int increment = 1)
    {
        return _rolls[index + increment];
    }

    private bool IsStrike(char roll)
    {
        return roll == 'X';
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