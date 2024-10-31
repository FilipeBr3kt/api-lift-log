namespace api_log_lift.Domain.Exceptions;

public class InvalidCredentialsException : Exception
{
  public InvalidCredentialsException() : base("Invalid credentials")
  {
  }
  public InvalidCredentialsException(string message) : base(message)
  {
  }
}