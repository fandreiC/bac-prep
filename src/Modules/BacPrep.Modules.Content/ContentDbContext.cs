using BacPrep.Modules.Content.Domain;
using BacPrep.Modules.Content.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BacPrep.Modules.Content;

internal sealed class ContentDbContext(DbContextOptions<ContentDbContext> options) : DbContext(options)
{
    public DbSet<Discipline> Disciplines => Set<Discipline>();
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Syllabus> Syllabi => Set<Syllabus>();
    public DbSet<Chapter> Chapters => Set<Chapter>();
    public DbSet<Test> Tests => Set<Test>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<BaremItem> BaremItems => Set<BaremItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.HasDefaultSchema("content");

        modelBuilder.Entity<Discipline>(e =>
        {
            e.Property(x => x.Name).HasMaxLength(100);
            e.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Profile>(e =>
        {
            e.Property(x => x.Name).HasMaxLength(100);
            e.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Syllabus>(e =>
            e.HasIndex(x => new { x.DisciplineId, x.ProfileId }).IsUnique());

        modelBuilder.Entity<Chapter>(e =>
            e.Property(x => x.Title).HasMaxLength(200));

        modelBuilder.Entity<Test>(e =>
        {
            e.Property(x => x.SessionType).HasConversion<string>().HasMaxLength(30);
            e.HasIndex(x => new { x.SyllabusId, x.Year, x.SessionType, x.Variant, x.IsReserve }).IsUnique();
        });

        modelBuilder.Entity<Section>(e =>
            e.HasIndex(x => new { x.TestId, x.Number }).IsUnique());

        modelBuilder.Entity<Exercise>(e =>
        {
            e.Property(x => x.Label).HasMaxLength(10);
            e.Property(x => x.ExerciseType).HasConversion<string>().HasMaxLength(30);
            e.Property(x => x.AnswerKey).HasMaxLength(200);
            e.HasOne(x => x.Chapter).WithMany()
                .HasForeignKey(x => x.ChapterId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<BaremItem>(e =>
        {
            e.Property(x => x.Group).HasMaxLength(50);
            e.Property(x => x.Description).HasMaxLength(1000);
        });
        
        ContentSeedData.Apply(modelBuilder);
    }
}