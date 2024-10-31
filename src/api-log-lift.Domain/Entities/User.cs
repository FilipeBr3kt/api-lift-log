using System;
using System.Collections.Generic;
using api_log_lift.Domain.Exceptions;

namespace api_log_lift.Domain.Entities;

public partial class User
{
    public int Id { get; private set; }

    public string Username { get; private set; } = null!;

    public string Password { get; private set; } = null!;

    public virtual ICollection<Training> Training { get; private set; } = new List<Training>();

    public User(string username, string password, string confirmPassword)
    {
        Id = new Guid().GetHashCode();
        Username = username;
        Password = HashPassword(password);
        if (password != confirmPassword)
            throw new InvalidCredentialsException("Passwords do not match");
    }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
