using System;
using System.Runtime.Serialization;

namespace Order.Glue.Exceptions
{
    /// <summary>
    /// Class BaseException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
	public class BaseException : Exception
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException" /> class.
        /// </summary>
        public BaseException() : base() {}
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException" /> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public BaseException(string message) : base(message) {}
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public BaseException(string message, System.Exception inner) : base(message, inner) {}
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException" /> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        public BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
