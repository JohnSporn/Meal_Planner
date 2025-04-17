using Meal_Planner.Model;
using Dapper;

namespace Meal_Planner.Data.Service
{
    public class MealService : IMealService
    {
        private readonly DatabaseService _databaseService;
        public MealService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public async Task<List<Meal>> GetMealsAsync()
        {
            using var connection = _databaseService.CreateConnection();
            string query = "SELECT * FROM Meal";
            return (await connection.QueryAsync<Meal>(query)).ToList();
        }
        public async Task<Meal?> GetMealByIdAsync(int id)
        {
            using var connection = _databaseService.CreateConnection();
            string query = "SELECT * FROM Meal WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Meal>(query, new { Id = id });
        }
        public async Task<int> AddMealAsync(Meal meal)
        {
            using var connection = _databaseService.CreateConnection();
            string query = @"INSERT INTO Meal (Name, MealCategory) 
                             VALUES (@Name, @MealCategory);

                             SELECT LAST_INSERT_ROWID();";
            return await connection.QuerySingleAsync<int>(query, meal);
        }
        public async Task<int> UpdateMealAsync(Meal meal)
        {
            using var connection = _databaseService.CreateConnection();
            string query = @"UPDATE Meal 
                             SET Name = @Name, 
                                 MealCategory = @MealCategory 
                             WHERE Id = @Id";
            return await connection.ExecuteAsync(query, meal);
        }
        public async Task<int> DeleteMealAsync(int id)
        {
            using var connection = _databaseService.CreateConnection();
            string query = "DELETE FROM Meal WHERE Id = @Id";
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
