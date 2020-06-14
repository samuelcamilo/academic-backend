using System;
using System.Collections.Generic;
using System.Text;

namespace Uni.Academic.Shared.Exceptions
{
    public class NameAlreadyExistsException : Exception
    {
        public long ExistingId { get; private set; }

        public NameAlreadyExistsException(long id = -1)
            => ExistingId = id;
    }
}
