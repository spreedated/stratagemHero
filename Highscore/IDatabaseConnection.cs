using Microsoft.Data.Sqlite;
using System;

namespace Highscore
{
    public interface IDatabaseConnection : IDisposable
    {
        public SqliteConnection Connection { get; }
        public SqliteConnection Open();
        public void Close();
    }
}
