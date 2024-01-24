using BowlingKata.App;

namespace BowlingKata.Tests
{
    public class BowlingAppTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenAllStrikes_ScoreIs300()
        {
            var rolls = new Rolls(Roll(12, 'X'));

            var score = new BowlingApp(rolls).Score();

            Assert.That(score, Is.EqualTo(300));
        }

        [Test]
        public void GivenAllStrikesBarLastFrameOnly2NumberBowls()
        {
            var rolls = Roll(9, 'X');
            rolls.AddRange(Roll(2, '2'));

            var score = new BowlingApp(new Rolls(rolls)).Score();

            Assert.That(score, Is.EqualTo(250));
        }

        [Test]
        public void GivenAllStrikesBarLastFrameAsASpareAndStrike()
        {
            var rolls = Roll(9, 'X');
            rolls.Add(new Roll('2'));
            rolls.Add(new Roll('/'));
            rolls.Add(new Roll('X'));

            var score = new BowlingApp(new Rolls(rolls)).Score();

            Assert.That(score, Is.EqualTo(272));
        }

        [Test]
        public void GivenAllStrikesBarLastFrameAsASpareAnd5()
        {
            var rolls = Roll(9, 'X');
            rolls.Add(new Roll('2'));
            rolls.Add(new Roll('/'));
            rolls.Add(new Roll('5'));

            var score = new BowlingApp(new Rolls(rolls)).Score();

            Assert.That(score, Is.EqualTo(267));
        }

        [Test]
        public void Given5AndSpareWithAFinal5_ScoreIs150()
        {
            var rolls = Roll(10, '5', '/');
            rolls.Add(new Roll('5'));

            var score = new BowlingApp(new Rolls(rolls)).Score();

            Assert.That(score, Is.EqualTo(150));
        }

        [Test]
        public void Given9AndMissInEveryFrame_ScoreIs90()
        {
            var rolls = new Rolls(Roll(10, '9', '0'));

            var score = new BowlingApp(rolls).Score();

            Assert.That(score, Is.EqualTo(90));
        }

        [TestCase('1', 20)]
        [TestCase('2', 40)]
        public void GivenAlwaysRollingTheSame_ScoreIsAsExpected(char roll, int expectedScore)
        {
            var rolls = new Rolls(Roll(20, roll));

            var actualScore = new BowlingApp(rolls).Score();

            Assert.That(actualScore, Is.EqualTo(expectedScore));
        }

        private static List<Roll> Roll(int times, char firstRoll, char? secondRoll = null)
        {
            var rolls = new List<Roll>();
            for (var i = 0; i < times; i++)
            {
                rolls.Add(new Roll(firstRoll));
                if (secondRoll.HasValue)
                    rolls.Add(new Roll(secondRoll.Value));
            }

            return rolls;
        }
    }
}