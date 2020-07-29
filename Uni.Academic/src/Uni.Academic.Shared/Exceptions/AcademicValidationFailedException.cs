using System;
using System.Collections.Generic;
using System.Text;

namespace Uni.Academic.Shared.Exceptions
{
    public class AcademicValidationFailedException : Exception
    {
        public Dictionary<string, IEnumerable<string>> Errors { get; }
        public AcademicValidationFailedException(Dictionary<string, IEnumerable<string>> errors)
            : base("Invalid data") => Errors = errors;
    }
}
