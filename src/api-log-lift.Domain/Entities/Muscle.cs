using System;
using System.Collections.Generic;

namespace api_log_lift.Domain.Entities;

public partial class Muscle
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; private set; } = new List<Exercise>();
}
