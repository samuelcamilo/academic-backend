
namespace Uni.Academic.Core.Models
{
    public class SubjectMaterials
    {
        public long SubjectId { get; private set; }
        public Subject Subject { get; private set; }
        public long MaterialId { get; private set; }
        public Material Material { get; private set; }

        public SubjectMaterials(long subjectId, long materialId)
        {
            this.SubjectId = subjectId;
            this.MaterialId = materialId;
        }
    }
}
