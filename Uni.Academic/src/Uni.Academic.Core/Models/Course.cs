using System.Collections.Generic;
using Uni.Academic.Core.Commons;

namespace Uni.Academic.Core.Models
{
    public class Course : Entity
    {
        public string Description { get; private set; }
        public string Resume { get; private set; }
        public List<CourseSubjects> CourseSubjects { get; private set; }

        public Course() { }
    }   
}