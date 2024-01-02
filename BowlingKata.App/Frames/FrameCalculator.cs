namespace BowlingKata.App.Frames;

public class FrameCalculator(Rolls rolls)
{
    public List<object> ConvertToFrames()
    {
        var frames = new List<object>();

        for (int i = 0; i < rolls.Count;)
        {
            var roll = rolls.GetRollForIndex(i);

            if (frames.Count < 9)
            {
                var currentFrame = new Frame
                {
                    FirstRoll = roll
                };

                if (roll.StrikeRolled)
                {
                    i++;
                }
                else
                {
                    currentFrame.SecondRoll = rolls.GetNextRoll(i);
                    i += 2;
                }

                frames.Add(currentFrame);
            }
            else
            {
                var finalFrame = new FinalFrame
                {
                    FirstRoll = roll,
                    SecondRoll = rolls.GetNextRoll(i)
                };

                if (i + 2 < rolls.Count)
                {
                    finalFrame.ThirdRoll = rolls.GetNextNextRoll(i);
                }

                frames.Add(finalFrame);
                break;
            }
        }

        return frames;
    }
}