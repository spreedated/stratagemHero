using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Highscore.HelperFunctions;

namespace Highscore
{
    internal static class Read
    {
        internal static Models.Highscore DatareaderToHighscore(SqliteDataReader reader)
        {
            return new Models.Highscore
            {
                Id = reader.GetInt32(0),
                Playername = reader.GetString(1),
                Score = reader.GetInt32(2),
#pragma warning disable S6580
                Date = DateTime.ParseExact(reader.GetString(3), "dd-MM-yyyy HH:mm:ss", null)
#pragma warning restore S6580
            };
        }

        internal static async Task<bool> DoesTableExist(this IDatabaseConnection conn, string tablename)
        {
            using (SqliteCommand cmd = conn.Connection.CreateCommand())
            {
                cmd.CommandText = LoadEmbeddedSql("DoesTableExist");
                cmd.Parameters.AddWithValue("@tablename", tablename);

                using (SqliteDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    return dr.HasRows;
                }
            }
        }

        internal static async Task<IEnumerable<Models.Highscore>> ReadLast100Entries(this IDatabaseConnection conn)
        {
            List<Models.Highscore> highscores = [];

            using (SqliteCommand cmd = conn.Connection.CreateCommand())
            {
                cmd.CommandText = LoadEmbeddedSql("Read100");

                using (SqliteDataReader r = await cmd.ExecuteReaderAsync())
                {
                    while (r.Read())
                    {
                        highscores.Add(DatareaderToHighscore(r));
                    }
                }
            }

            return highscores;
        }
    }
}
