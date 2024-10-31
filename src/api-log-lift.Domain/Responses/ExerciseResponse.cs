namespace api_log_lift.Domain.Responses;

public class ExerciseResponse
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public int MuscleId { get; set; }
  public string MuscleName { get; set; } = null!;
}