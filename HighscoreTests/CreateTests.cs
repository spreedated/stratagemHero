using Highscore;
using Highscore.Models;
using Microsoft.Data.Sqlite;
using Moq;
using NUnit.Framework;
using System;
using static Highscore.Constants;

namespace HighscoreTests
{
    [TestFixture]
    public class CreateTests
    {
        private SqliteConnection sampleDatabase = null;

        [SetUp]
        public void SetUp()
        {
            this.sampleDatabase = new SqliteConnection("Data Source=:memory:");
            this.sampleDatabase.Open();

            using (SqliteCommand cmd = this.sampleDatabase.CreateCommand())
            {
                cmd.CommandText = $"CREATE TABLE \"{MAIN_TABLE}\" ( \"id\"\tINTEGER NOT NULL, \"playername\" TEXT NOT NULL, \"score\" INTEGER, \"date\" TEXT NOT NULL, PRIMARY KEY(\"id\" AUTOINCREMENT));";
                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void InsertTests()
        {
            Mock<IDatabaseConnection> dbConnection = new();
            dbConnection.Setup(x => x.Connection).Returns(this.sampleDatabase);
            dbConnection.Setup(x => x.Open()).Returns(this.sampleDatabase);
            dbConnection.Setup(x => x.Close()).Verifiable();

            Highscore.Models.Highscore highscore = new()
            {
                Score = 100,
                Playername = "foobar",
                Date = DateTime.Now
            };

            InsertResponse insertResponse = null;

            Assert.DoesNotThrowAsync(async () => insertResponse = await dbConnection.Object.NewEntry(highscore));
            Assert.That(insertResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(insertResponse.IsSuccess, Is.True);
                Assert.That(insertResponse.Id, Is.EqualTo(1));
                Assert.That(highscore.Id, Is.EqualTo(1));
            });

            highscore = new()
            {
                Score = 100,
                Date = DateTime.Now
            };

            insertResponse = null;

            Assert.DoesNotThrowAsync(async () => insertResponse = await dbConnection.Object.NewEntry(highscore));
            Assert.That(insertResponse, Is.Not.Null);
            Assert.That(insertResponse.IsSuccess, Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            this.sampleDatabase?.Dispose();
        }
    }
}
