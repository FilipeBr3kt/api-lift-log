using System.Text.Json;
using api_log_lift.Application.Queries;
using api_log_lift.Infrastructure;
using api_log_lift.Presentation;
using api_log_lift.Presentation.Middleware;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddInfrastructure(builder.Configuration)
        .AddMemoryCache()
        .AddDistributedMemoryCache()
        .AddControllers();

    builder.Services
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddProblemDetails()
    .AddExceptionHandler<ExceptionToProblemDetailsHandler>();

    builder.Services.AddMediatR(typeof(GetMuscleQueryHandler).Assembly);
}
{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseExceptionHandler();
    app.UseHttpsRedirection();
    app.Run();
}




