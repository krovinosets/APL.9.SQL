using System.Text.RegularExpressions;
using DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext;

public class Database : DbContext
{
    private const string SqlServer = "Host=localhost; Port=5432; Database=postgres; Username=postgres; Password=root";
    
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Certificate> Certificates { get; set; } = null!;
    public DbSet<Specialization> Specializations { get; set; } = null!;
    
    public Database()
    {
        Database.EnsureCreated();        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(SqlServer);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
        modelBuilder.Entity<Doctor>().Property(d => d.Name).IsRequired(true);
        
        modelBuilder.Entity<Specialization>().HasKey(s => s.Id);
        modelBuilder.Entity<Specialization>().Property(s => s.Name).IsRequired(true);
        
        modelBuilder.Entity<Certificate>().HasKey(c => c.Id);
        modelBuilder.Entity<Certificate>().Property(c => c.Description).IsRequired(true);
        modelBuilder.Entity<Certificate>().Property(c => c.Date).IsRequired(true);
        
        modelBuilder.Entity<Specialization>().HasMany<Doctor>().WithOne(d => d.Specialization).IsRequired(true).HasForeignKey(doc => doc.SpecializationId);
        modelBuilder.Entity<Doctor>().HasMany<Certificate>().WithOne(c => c.Doctor).IsRequired(true).HasForeignKey(cert => cert.DoctorId);
        
        modelBuilder.Entity<Certificate>().Property(g => g.Date).HasConversion(
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc));
    }
}