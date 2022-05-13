using System;

namespace Order.Glue.Exceptions
{
    /// <summary>
    /// Class RequestException.
    /// Implements the <see cref="BaseException" />
    /// </summary>
    /// <seealso cref="BaseException" />
    /// <seealso cref="BaseException" />
    public class RequestException: BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestException" /> class.
        /// </summary>
        public RequestException() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestException" /> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public RequestException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public RequestException(string message, Exception inner) : base(message, inner) { }

    }
}
