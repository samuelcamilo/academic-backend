using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using Uni.Academic.Core.Models;
using Uni.Academic.Infrastructure.EntityTypeConfiguration;

namespace Uni.Academic.Data.EntityTypeConfiguration
{
    public class CourseTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Resume).HasMaxLength(255);
            builder.Ignore(x => x.CourseSubjects);

            builder.ToTable("Courses");

            builder.ApplyDefaultConfig();

            SeedCourse(builder);
        }

        private static void SeedCourse(EntityTypeBuilder<Course> builder)
            => builder.HasData(
                    new
                    {
                        Id = 1L,
                        Description = "Ciência Da Computação",
                        Resume = "O curso de Ciência da Computação forma profissionais qualificados " +
                                 "para desenvolver programas e sistemas de informática, " +
                                 "desde o planejamento do projeto até a implantação e gerenciamento do software. " +
                                 "Por ser da área de ciências exatas, o aluno precisa ter uma boa base matemática e raciocínio lógico desenvolvido.",
                        CourseSubjects = new List<CourseSubjects>()
                    }
               );
    }
}
