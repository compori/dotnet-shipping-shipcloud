using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class DeclaredValue
    {
        /// <summary>
        /// Gets or sets the total amount of the goods value that an additional insurance should be booked for.
        /// </summary>
        /// <value>The total amount of the goods value that an additional insurance should be booked for.</value>
        [JsonProperty(PropertyName = "amount", Required = Required.Always)]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency used. Currently only EUR is applicable.
        /// </summary>
        /// <value>The currency used. Currently only EUR is applicable.</value>
        [JsonProperty(PropertyName = "currency", Required = Required.Always)]
        public string Currency { get; set; } = "EUR";
    }
}
