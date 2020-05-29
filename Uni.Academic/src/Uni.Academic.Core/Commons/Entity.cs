using System;

namespace Uni.Academic.Core.Commons
{
    public class Entity
    {
        public long Id { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public DateTime AlterAt { get; protected set; }
    }
}