﻿using Uni.Academic.Core.Models;
using Uni.Academic.Data.Repositories;
using Uni.Academic.Data.Test.Infra;
using Xunit;

namespace Uni.Academic.Data.Test
{
    [Collection("DatabaseCollection")]
    public class RepositoryCourseTest : DatabaseTest<RepositoryCourse, Course>
    {
        public RepositoryCourseTest(DatabaseFixture fixture)
            : base(fixture) { }

        [Fact]
        public void ShouldReturnCourseIfExist()
        {
            // arrange
            var course = new Course("Engenharia Civil", "Este curso ajudará a você...");

            _repository.Insert(course);
            _context.SaveChanges();

            // act
            var exists = _repository.ExistsCourse("Engenharia Civil");

            // assert
            Assert.True(exists);
        }

        [Fact]
        public void SholdInsertCourseWithoutSubjects()
        {
            // arrange
            var course = new Course("Psicologia", "Este curso ajudará a você...");

            _repository.Insert(course);
            _context.SaveChanges();

            // act
            var exists = _repository.ExistsCourse("Psicologia");

            // assert
            Assert.True(exists);
        }

        [Fact]
        public void SholdInsertCourseWithSubjects()
        {
            // arrange
            var teacher = new User("Samuel", "Camilo", "123465789");

            _context.Users.Add(teacher);
            _context.SaveChanges();

            var subject1 = new Subject("Engenharia de Software I", "ENGS-I", 1);
            var subject2 = new Subject("Banco de Dados I", "BAD-I", 1);
            var subject3 = new Subject("Construção e Ánalise de Algoritmos", "CANA", 1);

            _context.Subjects.Add(subject1);
            _context.Subjects.Add(subject2);
            _context.Subjects.Add(subject3);
            _context.SaveChanges();

            var course = new Course("Engenharia da Computação", "Este curso ajudará a você...");

            course.Add(subject1);
            course.Add(subject2);
            course.Add(subject3);

            _repository.Insert(course);

            // act
            var exists = _repository.ExistsCourse("Engenharia da Computação");

            // assert
            Assert.True(exists);
        }
    }
}
