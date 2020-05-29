using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Uni.Academic.Core.Models;
using Uni.Academic.Shared.Extensions;

namespace Uni.Academic.Infrastructure
{
    public class AcademicContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubjects> CourseSubjects { get; set; }
        public DbSet<Hobbie> Hobbies { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectMaterials> SubjectMaterials { get; set; }
        public DbSet<SubjectUsers> SubjectUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserHobbies> UserHobbies { get; set; }
        public DbSet<UserQualifications> UserQualifications { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }

        public AcademicContext(DbContextOptions<AcademicContext> options)
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();

            var baseType = typeof(IEntityTypeConfiguration<>);

            typeof(AcademicContext)
                .Assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == baseType))
                .Select(t => (dynamic)Activator.CreateInstance(t))
                .ForEach(configurationInstace => modelBuilder.ApplyConfiguration(configurationInstace));

            base.OnModelCreating(modelBuilder);

        }
    }
}
