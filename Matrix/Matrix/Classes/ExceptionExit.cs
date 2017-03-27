using System;
using System.Runtime.Serialization;

namespace Matrix
{
    [Serializable]
    internal class ExceptionExit : Exception
    {
        public ExceptionExit()
        {
        }

        public ExceptionExit(string message) : base(message)
        {
        }

        public ExceptionExit(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExceptionExit(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}