
namespace Uni.Academic.Core.Models
{
    public class UserQualifications
    {
        public long UserId { get; private set; }
        public User User { get; private set; }
        public long QualificationId { get; private set; }
        public Qualification Qualification { get; private set; }

        public UserQualifications(long userId, long qualificationId) 
        {
            this.UserId = userId;
            this.QualificationId = qualificationId;
        }
    }
}