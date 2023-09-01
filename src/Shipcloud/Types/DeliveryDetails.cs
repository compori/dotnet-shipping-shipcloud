using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class DeliveryDetails
    {
        /// <summary>
        /// Gets or sets the associated name of the person or place, where the package was dropped off.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the additional description of where the package was dropped off.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the first line of the address where the package was dropped off
        /// </summary>
        /// <value>The first line of the address.</value>
        [JsonProperty(PropertyName = "addressline1", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the second line of the address where the package was dropped off
        /// </summary>
        /// <value>The second line of the address.</value>
        [JsonProperty(PropertyName = "addressline2", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine2 { get; set; }
    }
}
