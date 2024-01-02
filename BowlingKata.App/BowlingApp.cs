namespace BowlingKata.App;

public class BowlingApp(Rolls rolls)
{
    public int Score()
    {
        return rolls.Score();
    }
}