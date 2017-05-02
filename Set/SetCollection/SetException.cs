using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SetCollection
{
    class SetException : ApplicationException
    {
        public SetException()
        {
        }

        public SetException(string message) : base(message)
        {
        }

        public SetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
