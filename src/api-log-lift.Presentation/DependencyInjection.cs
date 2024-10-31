using api_log_lift.Presentation.Controllers;
using api_log_lift.Presentation.Interfaces;

namespace api_log_lift.Presentation;

public static class DependencyInjection
{
  public static IServiceCollection AddPresentation(this IServiceCollection services)
  {
    services.AddScoped<IMuscleController, MuscleController>();
    services.AddScoped<IExerciseController, ExerciseController>();
    services.AddScoped<IUserController, UserController>();
    services.AddScoped<ITrainingController, TrainingController>();
    services.AddScoped<ITrainingExerciseController, TrainingExerciseController>();

    return services;
  }
}