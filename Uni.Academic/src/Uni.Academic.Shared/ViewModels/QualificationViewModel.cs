using System;
using System.Collections.Generic;
using System.Text;

namespace Uni.Academic.Shared.ViewModels
{
    public class QualificationViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishedDate { get; set; }
    }
}
