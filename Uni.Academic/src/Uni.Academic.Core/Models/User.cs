﻿using System.Collections.Generic;

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

        public User(string firstName, string lastName, string cpf)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CPF = cpf;
        }
    }
}
