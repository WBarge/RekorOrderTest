using Order.Glue.Exceptions;

namespace Order.Glue.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Checks if the input decimal is 0.
        /// </summary>
        /// <param name="o">decimal to be checked.</param>
        /// <returns>true if the decimal is 0 or equals DefaultValues.DEFAULT_DECIMAL, else false.</returns>
        public static bool IsEmpty(this decimal d)
        {
            return d == 0.0M || d == decimal.Zero;
        }//Empty

        /// <summary>
        /// Checks if the input decimal is not 0.
        /// </summary>
        /// <param name="o">decimal to be checked.</param>
        /// <returns>true if the decimal is not empty, else false.</returns>
        public static bool IsNotEmpty(this decimal d)
        {
            return (!d.IsEmpty());
        }//Empty

        /// <summary>
        /// Converts a nullable decimal to a decimal
        /// </summary>
        /// <param name="d">the nullable decimal</param>
        /// <returns>
        /// If the nullable decimal is null then decimal.Zero else the value passed in
        /// </returns>
        public static decimal ToDecimal(this decimal? d)
        {
            decimal returnValue = decimal.Zero;
            try
            {
                if (d.HasValue)
                {
                    returnValue = d.Value;
                }
            }
            catch {  }
            return (returnValue);
        }

        /// <summary>
        /// Requires the specified name.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="name">The name.</param>
        /// <exception cref="RequiredObjectException"></exception>
        public static void Required(this decimal o,string name = "")
        {
            if (o.IsEmpty())
            {
                string msg = name.IsEmpty() ? "" : $"{name} is required";
                throw new RequiredObjectException(msg);
            }
        }
    }
}