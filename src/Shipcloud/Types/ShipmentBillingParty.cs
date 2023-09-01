using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShipmentBillingParty
    {
        /// <summary>
        /// Gets or sets the providing the key that will determine, who will pay (receiver, sender, third_party).
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets account number that will be billed.
        /// </summary>
        /// <value>The account number.</value>
        [JsonProperty(PropertyName = "account_number", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the zip code / postalcode associated with the provided account number.
        /// </summary>
        /// <value>The zip code.</value>
        [JsonProperty(PropertyName = "zip_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the country code associated with the provided account number.
        /// </summary>
        /// <value>The country.</value>
        [JsonProperty(PropertyName = "country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
    }
}
