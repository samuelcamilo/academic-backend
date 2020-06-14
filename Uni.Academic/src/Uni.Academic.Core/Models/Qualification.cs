using System;
using Uni.Academic.Core.Commons;

namespace Uni.Academic.Core.Models
{
    public class Qualification : Entity
    {
        public string Description { get; private set; }
        public string Resume { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinishedDate { get; private set; }

    }
}
