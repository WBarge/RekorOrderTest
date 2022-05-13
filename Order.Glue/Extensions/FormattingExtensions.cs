using System;
using System.Globalization;

namespace Order.Glue.Extensions
{
    /// <summary>
    /// Class FormattingExtensions.
    /// </summary>
    public static class FormattingExtensions
    {
        /// <summary>
        /// Formats the specified datetime.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns>System.String.</returns>
        public static string Formatted(this DateTime? dt)
        {
            return dt.HasValue ? dt.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
        }

        /// <summary>
        /// Formats the specified boolean.
        /// </summary>
        /// <param name="b">if set to <c>true</c> [b].</param>
        /// <returns>System.String.</returns>
        public static string Formatted(this bool? b)
        {
            return b.HasValue ? b.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
        }

        /// <summary>
        /// Formats the specified integer.
        /// </summary>
        /// <param name="i">The integer to format.</param>
        /// <returns>System.String.</returns>
        public static string Formatted(this int? i)
        {
            return i.HasValue ? i.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
        }

        /// <summary>
        /// Formats the specified decimal.
        /// </summary>
        /// <param name="d">The decimal to format.</param>
        /// <returns>System.String.</returns>
        public static string Formatted(this decimal? d)
        {
            return d.HasValue ? d.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
        }

        /// <summary>
        /// Formats the specified short.
        /// </summary>
        /// <param name="s">The short to format.</param>
        /// <returns>System.String.</returns>
        public static string Formatted(this short? s)
        {
            return s.HasValue ? s.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
        }

    }
}
