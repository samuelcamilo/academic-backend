using System.Linq;
using Uni.Academic.Core.Interfaces.Repositories;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.Repositories
{
    public class RepositoryCourse : Repository<Course>, IRepositoryCourse
    {
        public RepositoryCourse(AcademicContext academicContext)
            : base(academicContext) { }

        public bool ExistsCourseWithDescription(string description)
            => _currentSet.Any(x => x.Description == description);
    }
}
