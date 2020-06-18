using Uni.Academic.Core.Models;
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
    }
}
