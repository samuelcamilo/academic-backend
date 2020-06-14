
namespace Uni.Academic.Core.Models
{
    public class UserSkills
    {
        public long UserId { get; private set; }
        public User User { get; private set; }
        public long SkillId { get; private set; }
        public Skill Skill { get; private set; }

        public UserSkills(long userId, long skillId)
        {
            this.UserId = userId;
            this.SkillId = skillId;
        }
    }
}
