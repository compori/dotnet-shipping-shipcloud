using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShippingPickup
    {
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        [JsonProperty(PropertyName = "pickup_time", Required = Required.Always)]
        public ShippingPickupTime Time { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        [JsonProperty(PropertyName = "pickup_address", Required = Required.Always)]
        public ShippingPickupAddress Address { get; set; }
    }
}
