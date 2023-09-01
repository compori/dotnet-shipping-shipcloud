using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class CustomsDeclarationItem
    {
        /// <summary>
        /// Gets or sets the origin country as uppercase ISO 3166-1 alpha-2 code.
        /// </summary>
        /// <value>The origin country as uppercase ISO 3166-1 alpha-2 code.</value>
        [JsonProperty(PropertyName = "origin_country", Required = Required.Always)]
        public string OriginCountry { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        /// <value>The description of the item.</value>
        [JsonProperty(PropertyName = "description", Required = Required.Always)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the customs tariff number. 
        /// See https://en.wikipedia.org/wiki/Harmonized_System#Tariffs_by_region for detailed information on region specific tariff numbers.
        /// </summary>
        /// <value>The the customs tariff number.</value>
        [JsonProperty(PropertyName = "hs_tariff_number", NullValueHandling = NullValueHandling.Ignore)]
        public string HsTariffNumber { get; set; }

        /// <summary>
        /// Gets or sets the number that defines how many items of this kind are in the shipment.
        /// </summary>
        /// <value>The number that defines how many items of this kind are in the shipment..</value>
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total value for items of this kind.
        /// </summary>
        /// <value>The total value for items of this kind.</value>
        [JsonProperty(PropertyName = "value_amount", Required = Required.Always)]
        public string ValueAmount { get; set; }

        /// <summary>
        /// Gets or sets the total net weight for a single item of this kind.
        /// </summary>
        /// <value>The total net weight for a single item of this kind.</value>
        [JsonProperty(PropertyName = "net_weight", Required = Required.Always)]
        public double NetWeight { get; set; }

        /// <summary>
        /// Gets or sets the total gross weight for a single item of this kind.
        /// </summary>
        /// <value>The total gross weight for a single item of this kind.</value>
        [JsonProperty(PropertyName = "gross_weight", NullValueHandling = NullValueHandling.Ignore)]
        public string GrossWeight { get; set; }
    }
}
