using System;
using System.Collections.Generic;
using System.Text;

namespace Uni.Academic.Shared.ViewModels
{
    public class SubjectViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public UserViewModel Teacher { get; set; }
        public List<UserViewModel> Students { get; set; }
        public List<MaterialViewModel> Materials { get; set; }
        public string Period { get; set; }
    }
}
