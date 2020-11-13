using System;
using System.Collections.Generic;
using System.Text;

namespace Uni.Academic.Shared.ViewModels
{
    public class CourseViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }
        // public List<SubjectViewModel> Subjects { get; set; }
    }
}
