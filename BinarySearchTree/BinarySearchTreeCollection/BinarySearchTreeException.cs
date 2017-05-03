using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeCollection
{
    class BinarySearchTreeException : ApplicationException
    {
        public BinarySearchTreeException()
        {
        }

        public BinarySearchTreeException(string message) : base(message)
        {
        }

        public BinarySearchTreeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BinarySearchTreeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
