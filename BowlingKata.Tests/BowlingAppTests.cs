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
            var rolls = new[]
                        {
                            'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'
                        };

            var score = new BowlingApp(rolls).Score();

            Assert.That(score, Is.EqualTo(300));
        }

        [Test]
        public void Given9AndMissInEveryFrame_ScoreIs90()
        {
            var rolls = new[]
                        {
                            '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-', '9', '-'
                        };

            var score = new BowlingApp(rolls).Score();

            Assert.That(score, Is.EqualTo(90));
        }

        [Test]
        public void Given5AndSpareWithAFinal5_ScoreIs150()
        {
            var rolls = new[]
                        {
                            '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5', '/', '5'
                        };

            var score = new BowlingApp(rolls).Score();

            Assert.That(score, Is.EqualTo(150));
        }
    }
}