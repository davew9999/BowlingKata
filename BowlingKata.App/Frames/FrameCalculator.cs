namespace BowlingKata.App.Frames;

public class FrameCalculator()
{
    private readonly IReadOnlyList<char> _rolls;
    private readonly BowlingApp _bowlingApp;

    public FrameCalculator(IReadOnlyList<char> rolls) : this()
    {
        _rolls = rolls;
        _bowlingApp = new BowlingApp(rolls);
    }

    public List<object> ConvertToFrames()
    {
        var frames = new List<object>();

        for (int i = 0; i < _rolls.Count;)
        {
            var roll = _rolls[i];

            if (frames.Count < 9)
            {
                var currentFrame = new Frame
                {
                    FirstRoll = roll
                };

                if (new Roll(roll).StrikeRolled)
                {
                    i++;
                }
                else
                {
                    currentFrame.SecondRoll = _bowlingApp.GetNextRoll(i);
                    i += 2;
                }

                frames.Add(currentFrame);
            }
            else
            {
                var finalFrame = new FinalFrame
                {
                    FirstRoll = roll,
                    SecondRoll = _bowlingApp.GetNextRoll(i)
                };

                if (i + 2 < _rolls.Count)
                {
                    finalFrame.ThirdRoll = _bowlingApp.GetNextNextRoll(i);
                }

                frames.Add(finalFrame);
                break;
            }
        }

        return frames;
    }
}