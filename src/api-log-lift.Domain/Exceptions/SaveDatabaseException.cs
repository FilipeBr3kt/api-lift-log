namespace api_log_lift.Domain.Exceptions;

public class SaveDatabaseException : Exception
{
  public SaveDatabaseException() : base("Error in saved data on database")
  {
  }
  public SaveDatabaseException(string message) : base(message)
  {
  }
}