using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShippingPickupTime
    {
        /// <summary>
        /// Gets or sets the earliest pickup date and time.
        /// </summary>
        /// <value>The earliest pickup date and time.</value>
        [JsonProperty(PropertyName = "earliest", Required = Required.Always)]
        public string Earliest { get; set; }

        /// <summary>
        /// Gets or sets the latest pickup date and time.
        /// </summary>
        /// <value>The latest pickup date and time.</value>
        [JsonProperty(PropertyName = "latest", Required = Required.Always)]
        public string Latest { get; set; }
    }
}
