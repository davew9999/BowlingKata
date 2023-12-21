namespace BowlingKata
{
    public static class BowlingApp
    {
        public static int Score(char[] rolls)
        {
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
                    if (int.TryParse(roll.ToString(), out var numberRolled))
                    {
                        score += numberRolled;
                    }

                    if (roll == '/')
                    {
                        var lastRoll = rolls[index - 1];
                        var lastRollScore = int.Parse(lastRoll.ToString());
                        score -= lastRollScore;

                        score += 10;
                        var nextRoll = rolls[index + 1];
                        var nextRollScore = int.Parse(nextRoll.ToString());
                        score += nextRollScore;
                    }
                }

                else
                {
                    if (int.TryParse(roll.ToString(), out var numberRolled))
                    {
                        score += numberRolled;
                    }

                    if (roll == '/')
                    {
                        var lastRoll = rolls[index - 1];
                        var lastRollScore = int.Parse(lastRoll.ToString());
                        score -= lastRollScore;

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
    }
}
