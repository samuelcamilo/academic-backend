using System;
using System.Collections.Generic;
using System.Text;

namespace Uni.Academic.Shared.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public List<QualificationViewModel> Qualifications { get; set; }
        public List<SkillViewModel> Skills { get; set; }
        public List<HobbieViewModel> Hobbies { get; set; }
    }
}
