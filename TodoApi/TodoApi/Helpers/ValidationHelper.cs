using System;
using System.Runtime.Serialization;

namespace TodoApi.Helpers
{
    [Serializable]
    public class ValidationHelper : Exception
    {
        public ValidationHelper()
        {
        }

        public ValidationHelper(string message) : base(message)
        {
        }

        public ValidationHelper(string message, Exception inner) : base(message, inner)
        {
        }

        protected ValidationHelper(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string Result()
        {
            return "";
        }
    }
}