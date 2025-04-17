using Meal_Planner.Data.Service;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace Meal_Planner
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Meal_Planner.db");

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.AddSingleton(new DatabaseService(dbPath));
            builder.Services.AddSingleton<IMealService, MealService>();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
