using System;
using System.Collections.Generic;

namespace api_log_lift.Domain.Entities;

public partial class Exercise
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public int MuscleId { get; private set; }

    public virtual Muscle Muscle { get; private set; } = null!;

    public virtual ICollection<TrainingExercise> TrainingExercises { get; private set; } = new List<TrainingExercise>();
}
