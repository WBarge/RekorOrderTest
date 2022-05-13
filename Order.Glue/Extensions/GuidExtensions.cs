using System;
using Order.Glue.Exceptions;

namespace Order.Glue.Extensions
{
    /// <summary>
    /// Class GuidExtensions.
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Checks is the input Guid is empty
        /// </summary>
        /// <param name="g">guid to be checked</param>
        /// <returns>true if the g is null or == Guid.Empty</returns>
        public static bool IsEmpty(this Guid g)
        {
            return ((object)g).IsEmpty() || g == Guid.Empty;
        }

        /// <summary>
        /// Checks if the input System.DateTime is not empty.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>true if the Guid is not empty.</returns>
        public static bool IsNotEmpty(this Guid obj)
        {
            return (!obj.IsEmpty());
        }

        public static void Required(this Guid o,string name = "")
        {
            if (o.IsEmpty())
            {
                string msg = name.IsEmpty() ? "" : $"{name} is required";
                throw new RequiredObjectException(msg);
            }
        }
    }
}
