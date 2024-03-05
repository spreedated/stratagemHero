using NUnit.Framework;
using System;
using System.Linq;

namespace HighscoreTests.Models
{
    [TestFixture]
    public class HighscoreTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void HighscoreValidation()
        {
            Highscore.Models.Highscore highscore = new()
            {
                Playername = "foobar",
                Score = 100,
                Date = DateTime.Now
            };

            Assert.That(highscore.IsValid(), Is.True);
            Assert.That(highscore.Validate(new(highscore)), Is.Empty);

            highscore = new()
            {
                Playername = "foobar",
                Date = DateTime.Now
            };

            Assert.That(highscore.IsValid(), Is.False);
            Assert.That(highscore.Validate(new(highscore)), Is.Not.Empty);
            Assert.That(highscore.Validate(new(highscore)).Any(x => x.MemberNames.Any(x => x == "Score")), Is.True);

            highscore = new()
            {
                Playername = "foobar",
                Score = 100
            };

            Assert.That(highscore.IsValid(), Is.False);
            Assert.That(highscore.Validate(new(highscore)), Is.Not.Empty);
            Assert.That(highscore.Validate(new(highscore)).Any(x => x.MemberNames.Any(x => x == "Date")), Is.True);

            highscore = new()
            {
                Score = 100,
                Date = DateTime.Now
            };

            Assert.That(highscore.IsValid(), Is.False);
            Assert.That(highscore.Validate(new(highscore)), Is.Not.Empty);
            Assert.That(highscore.Validate(new(highscore)).Any(x => x.MemberNames.Any(x => x == "Playername")), Is.True);
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
