using Compori.Shipping.Shipcloud.Types;
using RestSharp;
using System.Linq;

namespace Compori.Shipping.Shipcloud.RestSharp
{
    public static class RestResponseExtension
    {

        /// <summary>
        /// Gets the header integer value for a header name.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="name">The header name.</param>
        /// <param name="defaultValue">The default value if name is not found.</param>
        /// <returns>System.Int32.</returns>
        public static int GetHeaderValue(this RestResponse response, string name, int defaultValue)
        {
            if (!int.TryParse(response.GetHeaderValue(name, ""), out var result))
            {
                return defaultValue;
            }
            return result;
        }

        /// <summary>
        /// Gets the header string value for a header name.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="name">The header name.</param>
        /// <param name="defaultValue">The default value if name is not found.</param>
        /// <returns>System.String.</returns>
        public static string GetHeaderValue(this RestResponse response, string name, string defaultValue)
        {
            if (response?.Headers == null)
            {
                return defaultValue;
            }
            name = name.ToUpperInvariant();
            var value = response.Headers.FirstOrDefault(v => name.Equals(v.Name.ToUpperInvariant()));
            if (value == null || value.Value == null)
            {
                return defaultValue;
            }
            return value.Value.ToString();
        }

        /// <summary>
        /// Gets the rate limit from response object.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>RateLimit.</returns>
        public static RateLimit GetRateLimit(this RestResponse response)
        {
            return new RateLimit
            {
                Limit = response.GetHeaderValue("RateLimit-Limit", -1),
                Interval = response.GetHeaderValue("RateLimit-Interval", -1),
                Remaining = response.GetHeaderValue("RateLimit-Remaining", -1),
                Reset = response.GetHeaderValue("RateLimit-Reset", -1),
            };
        }

        /// <summary>
        /// Gets the request identifier.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>System.String.</returns>
        public static string GetRequestId(this RestResponse response)
        {
            return response.GetHeaderValue("X-Request-Id", null);
        }
    }
}
