namespace Meal_Planner.Model
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category MealCategory { get; set; }
    }
    public enum Category
    {
        Chicken,
        Beef,
        Pork,
        Pasta,
        Fish
    }
}
