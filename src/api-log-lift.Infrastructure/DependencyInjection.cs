using api_log_lift.Domain.Interfaces;
using api_log_lift.Infrastructure.Config;
using api_log_lift.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api_log_lift.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
  {
    services.AddDbContext<DatabaseContext>(
      opt => opt.UseSqlServer(
       config.GetValue<string>("SecretsApi:ConnectionString")
      )
    );

    services.AddScoped<IMuscleRepository, MuscleRepository>();
    services.AddScoped<IExerciseRepository, ExerciseRepository>();
    services.AddScoped<ISetsExerciseRepository, SetsExerciseRepository>();
    services.AddScoped<ITrainingExerciseRepository, TrainingExerciseRepository>();
    services.AddScoped<ITrainingRepository, TrainingRepository>();
    services.AddScoped<IUserRepository, UserRepository>();

    return services;
  }
}