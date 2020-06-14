using Uni.Academic.Core.Commons;

namespace Uni.Academic.Core.Models
{
    public class Material : Entity
    {
        public string Description { get; private set; }
        public string FileBase64 { get; private set; }

        public Material() { }
    }
}
