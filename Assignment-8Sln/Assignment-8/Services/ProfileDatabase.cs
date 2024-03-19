using Assignment_8.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
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
            _dbConnection.CreateTable<UserProfile>();
        }


        //Methods
        public void UpdateUser(UserProfile profile)
        {
            _dbConnection.Update(profile); // Updating the database with new information passed through
        }

        public UserProfile GetUserByID(int id) // Getting the ID of the user
        {
            UserProfile user = _dbConnection.Table<UserProfile>().Where(x => x.UserId == id).FirstOrDefault();

            if (user != null)
                _dbConnection.GetChildren(user, true);

            return user;
        }
    }
}
