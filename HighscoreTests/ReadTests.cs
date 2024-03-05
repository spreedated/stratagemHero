using Highscore;
using Microsoft.Data.Sqlite;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using static Highscore.Constants;

namespace HighscoreTests
{
    [TestFixture]
    public class ReadTests
    {
        private SqliteConnection sampleDatabase = null;

        private static string GetRandomDate(DateTime startDate, DateTime endDate)
        {
            Random randomTest = new(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));

            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
            return (startDate + newSpan).ToString("dd-MM-yyyy HH:mm:ss");
        }

        private static int GetRandomScore(int from, int to)
        {
            Random randomTest = new(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));

            return randomTest.Next(from, to);
        }

        private void AddSampleData()
        {
            for (int i = 0; i < 108; i++)
            {
                using (SqliteCommand cmd = this.sampleDatabase.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO {MAIN_TABLE} (playername, score, date) VALUES ('foobar', {GetRandomScore(100, 999999)},'{GetRandomDate(new DateTime(2010, 1, 1), new DateTime(2020, 1, 1))}');";
                    cmd.ExecuteNonQuery();
                }
            }
        }

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

            this.AddSampleData();
        }

        [Test]
        public void Read100Tests()
        {
            Mock<IDatabaseConnection> dbConnection = new();
            dbConnection.Setup(x => x.Connection).Returns(this.sampleDatabase);
            dbConnection.Setup(x => x.Open()).Returns(this.sampleDatabase);
            dbConnection.Setup(x => x.Close()).Verifiable();

            Highscore.Models.Highscore[] highscores = null;

            Assert.DoesNotThrowAsync(async () => highscores = (await dbConnection.Object.ReadLast100Entries()).ToArray());
            Assert.That(highscores, Has.Length.EqualTo(100));
            Assert.That(highscores.OrderByDescending(x => x.Score).SequenceEqual(highscores), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            this.sampleDatabase?.Dispose();
        }
    }
}
