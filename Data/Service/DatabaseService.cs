using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;

namespace Meal_Planner.Data.Service
{
    public class DatabaseService
    {
        private readonly string _dbPath;

        public DatabaseService(string dbPath)
        {
            _dbPath = dbPath;
            DatabaseCreated();
        }

        private async void DatabaseCreated()
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");

            string createTableMeal = @"
                CREATE TABLE IF NOT EXISTS Meal (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    MealCategory TEXT NOT NULL
                );   
            ";

            await connection.ExecuteAsync(createTableMeal);
        }

        public IDbConnection CreateConnection() => new SqliteConnection($"Data Source={_dbPath}");
    }
}
