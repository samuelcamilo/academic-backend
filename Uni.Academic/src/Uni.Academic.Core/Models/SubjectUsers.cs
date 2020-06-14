
using System;
using System.Collections.Generic;
using System.Text;


namespace Uni.Academic.Core.Models
{
    public class SubjectUsers
    {
        public long SubjectId { get; private set; }
        public Subject Subject { get; private set; }
        public long StudentId { get; private set; }
        public User Student { get; private set; }

        public SubjectUsers(long subjectId, long studentId)
        {
            this.SubjectId = subjectId;
            this.StudentId = studentId;
        }
    }
}
