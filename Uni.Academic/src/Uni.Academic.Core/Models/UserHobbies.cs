using System;
using System.Collections.Generic;
using System.Text;


namespace Uni.Academic.Core.Models
{
    public class UserHobbies
    {
        public long UserId { get; private set; }
        public User User { get; private set; }
        public long HobbieId { get; private set; }
        public Hobbie Hobbie { get; private set; }

        public UserHobbies(long userId, long hobbieId)
        {
            this.UserId = userId;
            this.HobbieId = hobbieId;
        }
    }
}
