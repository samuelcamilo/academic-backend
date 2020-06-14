
namespace Uni.Academic.Core.Models
{
    public class CourseSubjects
    {
        public long CourseId { get; private set; }
        public Course Course { get; private set; }
        public long SubjectId { get; private set; }
        public Subject Subject { get; private set; }

        public CourseSubjects(long courseId, long subjectId)
        {
            this.CourseId = courseId;
            this.SubjectId = subjectId;
        }
    }
}
