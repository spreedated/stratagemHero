using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static Highscore.Constants;

namespace Highscore
{
    public class HighscoreManager
    {
        internal string databaseFilepath = null;

        /// <summary>
        /// Filecheck for the database file
        /// </summary>
        /// <returns>Absolute filepath</returns>
        internal static string IntegrityFilecheck()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string myAppData = Path.Combine(localAppData, "Helldivers 2 Stratagem Hero");

            if (!Directory.Exists(myAppData))
            {
                Directory.CreateDirectory(myAppData);
            }

            return Path.Combine(myAppData, DB_FILENAME);
        }

        #region Constructor
        public HighscoreManager()
        {
            this.databaseFilepath = IntegrityFilecheck();
        }
        #endregion

        public async Task Load()
        {
            using (DatabaseConnection conn = new(this.databaseFilepath))
            {
                if (!await conn.DoesTableExist(MAIN_TABLE))
                {
                    await conn.CreateBlankTable();
                }
            }
        }

        public async Task<IEnumerable<Models.Highscore>> Get100()
        {
            using (DatabaseConnection conn = new(this.databaseFilepath))
            {
                return await conn.ReadLast100Entries();
            }
        }

        public async Task<bool> Insert(Models.Highscore highscore)
        {
            using (DatabaseConnection conn = new(this.databaseFilepath))
            {
                return (await conn.NewEntry(highscore)).IsSuccess;
            }
        }
    }
}
