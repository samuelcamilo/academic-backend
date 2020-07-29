using System;

namespace Uni.Academic.Core.Models
{
    public class Entity
    {
        public long Id { get; protected set; }
        public DateTimeOffset CreateAt { get; protected set; }
        public DateTimeOffset? AlterAt { get; protected set; }
    }
}
