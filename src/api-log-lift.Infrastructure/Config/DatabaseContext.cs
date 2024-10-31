using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api_log_lift.Domain.Entities;
using Microsoft.Extensions.Configuration;


namespace api_log_lift.Infrastructure.Config;

public partial class DatabaseContext : DbContext
{
    private readonly IConfiguration _config;

    public DatabaseContext(IConfiguration config)
    {
        _config = config;
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config)
        : base(options)
    {
        _config = config;
    }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Muscle> Muscles { get; set; }

    public virtual DbSet<SetsExercise> SetsExercises { get; set; }

    public virtual DbSet<Training> Training { get; set; }

    public virtual DbSet<TrainingExercise> TrainingExercises { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_config.GetValue<string>("SecretsApi:ConnectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exercise__3213E83FF6B04DE3");

            entity.ToTable("exercise");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MuscleId).HasColumnName("muscle_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Muscle).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.MuscleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__exercise__muscle__3B75D760");
        });

        modelBuilder.Entity<Muscle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__muscle__3213E83F870BA91B");

            entity.ToTable("muscle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SetsExercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sets_exe__3213E83F512472C7");

            entity.ToTable("sets_exercise");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Reps).HasColumnName("reps");
            entity.Property(e => e.TrainingExerciseId).HasColumnName("training_exercise_id");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("weight");

            entity.HasOne(d => d.TrainingExercise).WithMany(p => p.SetsExercises)
                .HasForeignKey(d => d.TrainingExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sets_exer__train__44FF419A");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__training__3213E83F4691DA3D");

            entity.ToTable("training");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("date_register");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Training)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__training__user_i__3E52440B");
        });

        modelBuilder.Entity<TrainingExercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__training__3213E83F46E5BD28");

            entity.ToTable("training_exercise");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("date_register");
            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");
            entity.Property(e => e.TrainingId).HasColumnName("training_id");

            entity.HasOne(d => d.Exercise).WithMany(p => p.TrainingExercises)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__training___exerc__4222D4EF");

            entity.HasOne(d => d.Training).WithMany(p => p.TrainingExercises)
                .HasForeignKey(d => d.TrainingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__training___train__412EB0B6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F1C05A031");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
