using Uni.Academic.Core.Models;

namespace Uni.Academic.Core.Interfaces.Repositories
{
    public interface IRepositoryCourse : IRepository<Course>
    {
        bool ExistsCourse(string description);
        void RemoveAllSubjects(long courseId);
        void ReplaceCurrentSubjects(long courseId, long[] subjects);
    }
}
