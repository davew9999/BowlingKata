namespace BowlingKata.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenAllStrikes_ScoreIs300()
        {
            var rolls = new[] { 'X', ' ', 'X', ' ', 'X', ' ', 'X', ' ', 'X', ' ', 'X', ' ', 'X', ' ', 'X', ' ', 'X', ' ', 'X', 'X', 'X' };

            int score = new BowlingApp().Score(rolls);

            Assert.That(score, Is.EqualTo(300));
        }

        [Test]
        public void Given9AndMissInEveryFrame_ScoreIs90()
        {
            var rolls = new[]
                {'9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-'};

            int score = new BowlingApp().Score(rolls);

            Assert.That(score, Is.EqualTo(90));
        }

        [Test]
        public void Given5AndSpareWithAFinal5_ScoreIs150()
        {
            var rolls = new[]
            {
                '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5'
            };

            int score = new BowlingApp().Score(rolls);

            Assert.That(score, Is.EqualTo(150));
        }
    }
}