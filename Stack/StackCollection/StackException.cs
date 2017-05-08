using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StackCollection
{
    public class StackException : ApplicationException
    {
        public StackException()
        {
        }

        public StackException(string message) : base(message)
        {
        }

        public StackException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
