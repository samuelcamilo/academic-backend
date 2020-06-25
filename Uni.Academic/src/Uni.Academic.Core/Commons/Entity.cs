using System;
using System.Collections.Generic;
using System.Text;

namespace Uni.Academic.Core.Commons
{
    public class Entity
    {
        public long Id { get; protected set; }
        public DateTimeOffset CreateAt { get; protected set; }
        public DateTimeOffset? AlterAt { get; protected set; }
    }
}
