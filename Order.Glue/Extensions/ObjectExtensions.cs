using System;
using Order.Glue.Exceptions;

namespace Order.Glue.Extensions
{
    /// <summary>
    /// Class ObjectExtensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Convert an object to integer.
        /// </summary>
        /// <param name="o">Object to be converted.</param>
        /// <returns>Integer value of the object or DefaultValues.DEFAULT_INT if object is not a valid int</returns>
        public static int ToInt(this object o)
        {
            return (o.ToInt(int.MinValue));
        }

        /// <summary>
        /// Convert an object to integer.
        /// </summary>
        /// <param name="o">Object to be converted.</param>
        /// <param name="defaultValue">the value if object is not a valid int</param>
        /// <returns>Integer value of the object or defaultValue</returns>
        public static int ToInt(this object o, int defaultValue)
        {
            int returnValue = defaultValue;
            if ((o.IsNotEmpty() && o.ToString() != string.Empty))
            {
                try
                {
                    returnValue = Convert.ToInt32(o.ToString());
                }
                catch
                {
                    // ignored
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Convert an object to decimal.  Returns 0 if the type conversion fails.
        /// </summary>
        /// <param name="o">Object to be converted.</param>
        /// <returns>decimal value of the object or DefaultValues.DEFAULT_DECIMAL if o is not a valid decimal</returns>
        public static decimal ToDecimal(this object o)
        {
            return o.ToDecimal(decimal.Zero);
        }

        /// <summary>
        /// Convert an object to a decimal.
        /// </summary>
        /// <param name="o">Object to be converted.</param>
        /// <param name="defaultValue">Value to be returned if object is not a valid decimal</param>
        /// <returns>Decimal value of the object.</returns>
        public static decimal ToDecimal(this object o, decimal defaultValue)
        {
            decimal returnValue = defaultValue;
            if (o.IsNotEmpty() && ((o is string s && IsEmpty(s)) == false))
            {
                try
                {
                    returnValue = Convert.ToDecimal(o);
                }
                catch
                {
                    // ignored
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Checks if the input variable is null or empty.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>true if the object is null else false.</returns>
        public static bool IsEmpty(this object obj)
        {
            return (obj == null);
        } //Empty

        /// <summary>
        /// Checks if the input variable is not empty.
        /// </summary>
        /// <param name="o">Object to be checked.</param>
        /// <returns>true if the object is not empty, else false.</returns>
        public static bool IsNotEmpty(this object o)
        {
            return !o.IsEmpty();
        } //NotEmpty

        /// <summary>
        /// Checks if the input variable is an integer.  Caller can ask this function to treat a null or empty
        /// value as a valid integer.
        /// </summary>
        /// <param name="o">Object to be checked</param>
        /// <param name="allowNull">true if null or empty value is to be treated as a valid integer.</param>
        /// <returns>true if the object is a valid integer.</returns>
        public static bool IsInt(this object o, bool allowNull)
        {
            bool returnValue = false;
            if (allowNull)
            {
                if (o.IsEmpty() || (o.ToString() == string.Empty))
                {
                    returnValue = true;
                }
            }
            else if (o.IsEmpty() || (o.ToString() == string.Empty))
            {
                 return false;
            }
            try
            {
                int unused = Convert.ToInt32(o.ToString());
                returnValue = true;
            }
            catch
            {
                // ignored
            }

            return returnValue;
        }

        /// <summary>
        /// Checks if the input variable is an integer.  Null or empty value is not considered a valid integer.
        /// </summary>
        /// <param name="o">Object to be checked</param>
        /// <returns>true if the object is a valid integer.</returns>
        public static bool IsInt(this object o)
        {
            return o.IsInt(false);
        }

        /// <summary>
        /// Checks if the input variable is a positive integer.  Zero is a valid positive integer.
        /// Caller can ask this function to treat a null or empty value as a valid positive integer.
        /// </summary>
        /// <param name="o">Object to be checked</param>
        /// <param name="allowNull">true if null or empty value is to be treated as a valid positive integer.</param>
        /// <returns>true if the object is a valid positive integer.</returns>
        public static bool IsPositiveInt(this object o, bool allowNull)
        {
            bool returnValue = false;
            if (allowNull)
            {
                if (o.IsEmpty() || (o.ToString() == string.Empty))
                {
                    returnValue = true;
                }
            }
            else if (o.IsEmpty() || (o.ToString() == string.Empty))
            {
                return false;
            }
            try
            {
                returnValue = Convert.ToInt32(o.ToString()) > 0;
            }
            catch
            {
                // ignored
            }
            return returnValue;
        }

        /// <summary>
        /// Checks if the input variable is an integer.  Null or empty value is not considered a valid integer.
        /// </summary>
        /// <param name="o">Object to be checked</param>
        /// <returns>true if the object is a valid integer.</returns>
        public static bool IsPositiveInt(this object o)
        {
            return o.IsPositiveInt(false);
        }

        /// <summary>
        /// Checks the object it ensure it is not null.  If so an exceptions is thrown
        /// 
        /// </summary>
        /// <param name="o">The object to check</param>
        /// <param name="name">When set, it will cause the message in the exception to {name} is required</param>
        /// <exception cref="RequiredObjectException"></exception>
        public static void Required(this object o,string name = "")
        {
            if (o.IsEmpty())
            {
                string msg = name.IsEmpty() ? "" : $"{name} is required";
                throw new RequiredObjectException(msg);
            }
        }
    }
}
