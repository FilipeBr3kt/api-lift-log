namespace api_log_lift.Domain.Responses;

public record TrainingResponse(int Id, string Name, DateTime DateRegister, int UserId) { };