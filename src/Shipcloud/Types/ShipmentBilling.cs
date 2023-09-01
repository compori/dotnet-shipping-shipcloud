using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShipmentBilling
    {
        /// <summary>
        /// Gets or sets the providing information that will determine, who will pay for transportation.
        /// </summary>
        /// <value>The transportation payer.</value>
        [JsonProperty(PropertyName = "transportation", NullValueHandling = NullValueHandling.Ignore)]
        public ShipmentBillingParty Transportation { get; set; }

        /// <summary>
        /// Gets or sets the providing information that will determine, who will pay for duties and taxes.
        /// </summary>
        /// <value>The duties and taxes payer.</value>
        [JsonProperty(PropertyName = "duties_and_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public ShipmentBillingParty DutiesAndTaxes { get; set; }
    }
}
