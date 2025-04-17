using Meal_Planner.Model;

namespace Meal_Planner.Data.Service
{
    public interface IMealService
    {
        Task<List<Meal>> GetMealsAsync();
        Task<Meal?> GetMealByIdAsync(int id);
        Task<int> AddMealAsync(Meal meal);
        Task<int> UpdateMealAsync(Meal meal);
        Task<int> DeleteMealAsync(int id);
    }
}
