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
                new Roll('X'), new Roll('X'), new Roll('X'), new Roll('X'), new Roll('X'), new Roll('X'), new Roll('X'),
                new Roll('X'), new Roll('X'), new Roll('X'), new Roll('X'), new Roll('X')
            };

            var score = new BowlingApp(rolls).Score();

            Assert.That(score, Is.EqualTo(300));
        }

        [Test]
        public void Given9AndMissInEveryFrame_ScoreIs90()
        {
            var rolls = new[]
            {
                new Roll('9'), new Roll('-'), new Roll('9'), new Roll('-'), new Roll('9'), new Roll('-'), new Roll('9'),
                new Roll('-'), new Roll('9'), new Roll('-'), new Roll('9'), new Roll('-'), new Roll('9'), new Roll('-'),
                new Roll('9'), new Roll('-'), new Roll('9'), new Roll('-'), new Roll('9'), new Roll('-')
            };

            var score = new BowlingApp(rolls).Score();

            Assert.That(score, Is.EqualTo(90));
        }

        [Test]
        public void Given5AndSpareWithAFinal5_ScoreIs150()
        {
            var rolls = new[]
            {
                new Roll('5'), new Roll('/'), new Roll('5'), new Roll('/'), new Roll('5'), new Roll('/'), new Roll('5'),
                new Roll('/'), new Roll('5'), new Roll('/'), new Roll('5'), new Roll('/'), new Roll('5'), new Roll('/'),
                new Roll('5'), new Roll('/'), new Roll('5'), new Roll('/'), new Roll('5'), new Roll('/'), new Roll('5')
            };

            var score = new BowlingApp(rolls).Score();

            Assert.That(score, Is.EqualTo(150));
        }
    }
}