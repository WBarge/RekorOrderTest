using System;

namespace Order.Glue.Exceptions
{
    /// <summary>
    /// Class RequiredObjectException.
    /// Implements the <see cref="BaseException" />
    /// </summary>
    /// <seealso cref="BaseException" />
    public class RequiredObjectException: BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredObjectException"/> class.
        /// </summary>
        public RequiredObjectException() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredObjectException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public RequiredObjectException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredObjectException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public RequiredObjectException(string message, Exception inner) : base(message, inner) { }
    }
}