﻿using System.Collections.Generic;

namespace Uni.Academic.Core.Models
{
    public class Subject : Entity
    {
        public string Description { get; private set; }
        public string Code { get; private set; }
        public User Teacher { get; private set; }
        public long TeacherId { get; private set; }
        public List<SubjectUsers> SubjectStudents { get; private set; }
        public List<SubjectMaterials> SubjectMaterials { get; private set; }
        public string Period { get; private set; }

        public Subject() { }

        public Subject(string description, string code, long teacherId)
        {
            this.Description = description;
            this.Code = code;
            this.TeacherId = teacherId;
        }
    }
}
