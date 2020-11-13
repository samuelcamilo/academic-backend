using System;
using System.Collections.Generic;
using System.Text;

namespace Uni.Academic.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity = null)
            : base($"O recurso {entity} não foi encontrado") { }
    }
}
