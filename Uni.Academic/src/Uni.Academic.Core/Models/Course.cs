using System.Collections.Generic;
using System.Linq;
using Uni.Academic.Core.Commons;

namespace Uni.Academic.Core.Models
{
    public class Course : Entity
    {
        public string Description { get; private set; }
        public string Resume { get; private set; }
        public List<CourseSubjects> CourseSubjects { get; private set; }

        public Course() { }

        public Course(string description, string resume)
        {
            this.Description = description;
            this.Resume = resume;
        }

        public void Add(Subject subject)
            => CourseSubjects.Add(new CourseSubjects(Id, subject.Id));

        public void AddSubjectsIds(long[] subjectsIds)
            => CourseSubjects.AddRange(subjectsIds.Select(c => new CourseSubjects(Id, c)));
    }
}
