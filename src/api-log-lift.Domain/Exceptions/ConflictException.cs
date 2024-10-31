namespace api_log_lift.Domain.Exceptions;

public class ConflictException : Exception
{
  public ConflictException() : base("Conflict between data")
  {
  }
  public ConflictException(string message) : base(message)
  {
  }
}