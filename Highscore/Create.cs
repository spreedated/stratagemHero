using Highscore.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Threading.Tasks;
using static Highscore.Constants;
using static Highscore.HelperFunctions;

namespace Highscore
{
    internal static class Create
    {
        public static async Task<bool> CreateBlankTable(this IDatabaseConnection dbConnection)
        {
            if (await dbConnection.DoesTableExist(MAIN_TABLE))
            {
                return false;
            }

            using (SqliteCommand cmd = dbConnection.Connection.CreateCommand())
            {
                cmd.CommandText = LoadEmbeddedSql("CreateBlankTable");
                await cmd.ExecuteNonQueryAsync();
            }

            return await dbConnection.DoesTableExist(MAIN_TABLE);
        }

        internal static async Task<InsertResponse> NewEntry(this IDatabaseConnection conn, Models.Highscore highscore)
        {
            InsertResponse insertResponse = new();

            if (!highscore.IsValid())
            {
                return insertResponse;
            }

            using (SqliteCommand cmd = conn.Connection.CreateCommand())
            {
                cmd.CommandText = LoadEmbeddedSql("DoesExist");
                cmd.Parameters.AddWithValue("@p", highscore.Playername);
                cmd.Parameters.AddWithValue("@s", highscore.Score);

                using (SqliteDataReader r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        return insertResponse;
                    }
                }
            }

            using (SqliteCommand cmd = conn.Connection.CreateCommand())
            {
                cmd.CommandText = LoadEmbeddedSql("Insert");
                cmd.Parameters.AddWithValue("@p", highscore.Playername);
                cmd.Parameters.AddWithValue("@s", highscore.Score);
                cmd.Parameters.AddWithValue("@d", DateTime.Now.ToSqlDateTime());

                insertResponse.IsSuccess = await cmd.ExecuteNonQueryAsync() > 0;
            }

            if (!insertResponse.IsSuccess)
            {
                return insertResponse;
            }

            using (SqliteCommand cmd = conn.Connection.CreateCommand())
            {
                cmd.CommandText = LoadEmbeddedSql("ReadEntryId");
                cmd.Parameters.AddWithValue("@p", highscore.Playername);
                cmd.Parameters.AddWithValue("@s", highscore.Score);
                cmd.Parameters.AddWithValue("@d", DateTime.Now.ToSqlDateTime());

                insertResponse.Id = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                highscore.Id = insertResponse.Id;
            }

            return insertResponse;
        }
    }
}
