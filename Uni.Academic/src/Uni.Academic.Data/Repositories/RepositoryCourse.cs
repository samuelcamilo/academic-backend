using System.Linq;
using Uni.Academic.Core.Interfaces.Repositories;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.Repositories
{
    public class RepositoryCourse : Repository<Course>, IRepositoryCourse
    {
        public RepositoryCourse(AcademicContext academicContext)
            : base(academicContext) { }

        public bool ExistsCourse(string description)
            => _currentSet.Any(x => x.Description == description);

        public void RemoveAllSubjects(long courseId)
        {
            _context.CourseSubjects.RemoveRange(_context.CourseSubjects.Where(cs => cs.CourseId == courseId));
            _context.SaveChanges();
        }

        public void ReplaceCurrentSubjects(long courseId, long[] subjects)
        {
            RemoveAllSubjects(courseId);
            var courseSubjects = subjects.Select(x => new CourseSubjects(courseId, x));
            _context.CourseSubjects.AddRange(courseSubjects);
            _context.SaveChanges();
        }
    }
}
