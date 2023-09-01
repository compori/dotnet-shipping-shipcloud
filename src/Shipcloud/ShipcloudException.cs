using System;

namespace Compori.Shipping.Shipcloud
{
    /// <summary>
    /// Class ShipcloudException.
    /// Implements the <see cref="Exception" />
    /// </summary>
    /// <seealso cref="Exception" />
    public class ShipcloudException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipcloudException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ShipcloudException(string message) : base(message)
        {
        }
    }
}
