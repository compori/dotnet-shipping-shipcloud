namespace Compori.Shipping.Shipcloud.Types
{
    public class RateLimit
    {
        /// <summary>
        /// Gets or sets the number the shows the overall limit of requests this user can send (e.g. 120).
        /// </summary>
        /// <value>The limit of requests this user can send.</value>
        public int Limit { get ; set; }
        
        /// <summary>
        /// Gets or sets the number of seconds the interval for this user is long (e.g. 60).
        /// </summary>
        /// <value>The seconds the interval for this user is long.</value>
        public int Interval { get ; set; }
        
        /// <summary>
        /// Gets or sets the remaining number of request in the current interval (e.g. 111).
        /// </summary>
        /// <value>The remaining number of request.</value>
        public int Remaining { get ; set; }

        /// <summary>
        /// Gets or sets the number of seconds that shows when the request rate limit resets (e.g. 42).
        /// </summary>
        /// <value>The number of seconds the limit resets.</value>
        public int Reset { get ; set; }
    }
}
