using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.EntityTypeConfiguration
{
    public class CourseTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Resume).HasMaxLength(500);

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
                        Resume = @"O curso de Ciência da Computação forma profissionais qualificados
                                 para desenvolver programas e sistemas de informática
                                 desde o planejamento do projeto até a implantação e gerenciamento do software.
                                 Por ser da área de ciências exatas, o aluno precisa ter uma boa base matemática e raciocínio lógico desenvolvido.",
                        CreateAt = new DateTimeOffset(2020, 1, 1, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                        AlterAt = new DateTimeOffset(2020, 1, 1, 0, 0, 0, 0, new TimeSpan(0, 0, 0, 0, 0)),
                        CourseSubjects = new List<CourseSubjects>()
                    }
               );
    }
}
