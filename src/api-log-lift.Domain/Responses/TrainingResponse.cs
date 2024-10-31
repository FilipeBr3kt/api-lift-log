namespace api_log_lift.Domain.Responses;

public class TrainingResponse
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public DateTime DateRegister { get; set; }
  public int UserId { get; set; }
}