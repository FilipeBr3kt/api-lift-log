using System;
using System.Collections.Generic;

namespace api_log_lift.Domain.Entities;

public partial class TrainingExercise
{
    public int Id { get; private set; }

    public int TrainingId { get; private set; }

    public int ExerciseId { get; private set; }

    public DateTime DateRegister { get; private set; }

    public virtual Exercise Exercise { get; private set; } = null!;

    public virtual ICollection<SetsExercise> SetsExercises { get; private set; } = new List<SetsExercise>();

    public virtual Training Training { get; private set; } = null!;

    public TrainingExercise(int trainingId, int exerciseId)
    {
        TrainingId = trainingId;
        ExerciseId = exerciseId;
        DateRegister = DateTime.Now;
    }
}
