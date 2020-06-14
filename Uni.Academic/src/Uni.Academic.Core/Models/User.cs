using System.Collections.Generic;
using Uni.Academic.Core.Commons;

namespace Uni.Academic.Core.Models
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CPF { get; private set; }
        public List<UserQualifications> UserQualifications { get; private set; }
        public List<UserSkills> UserSkills { get; private set; }
        public List<UserHobbies> UserHobbies { get; private set; }

        public User() { }
    }
}
