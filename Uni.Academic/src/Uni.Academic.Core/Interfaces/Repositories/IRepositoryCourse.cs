﻿using Uni.Academic.Core.Models;

namespace Uni.Academic.Core.Interfaces.Repositories
{
    public interface IRepositoryCourse : IRepository<Course>
    {
        bool ExistsCourseWithDescription(string description);
    }
}