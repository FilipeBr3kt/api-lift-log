using System;
using System.Collections.Generic;

namespace api_log_lift.Domain.Entities;

public partial class Training
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public DateTime DateRegister { get; private set; }

    public int UserId { get; private set; }

    public virtual ICollection<TrainingExercise> TrainingExercises { get; private set; } = new List<TrainingExercise>();

    public virtual User User { get; private set; } = null!;

    public Training(string name, int userId)
    {
        Name = name;
        DateRegister = DateTime.Now;
        UserId = userId;
    }
}
