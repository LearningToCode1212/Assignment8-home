using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8.Services
{
    internal class ProfileDatabase
    {
        private SQLiteConnection _dbConnection;
        public string GetDatabasePath()
        {
            string fileName = "profiledatabase.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return pathToDb + fileName;
        }
        public ProfileDatabase()
        {
            _dbConnection = new SQLiteConnection(GetDatabasePath());
        }
    }
}
