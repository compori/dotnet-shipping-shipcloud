using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShipmentLabel
    {
        /// <summary>
        /// Gets or sets the format that the returned label should have.
        /// </summary>
        /// <value>The label format.</value>
        [JsonProperty(PropertyName = "format", Required = Required.Always)]
        public string Format { get; set; }
    }
}
