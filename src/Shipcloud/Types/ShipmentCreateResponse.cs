using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShipmentCreateResponse
    {
        /// <summary>
        /// Gets or sets the shipment id that can be used for requesting info about a shipment or tracking it.
        /// </summary>
        /// <value>The shipment id that can be used for requesting info about a shipment or tracking it.</value>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the carrier tracking no.
        /// </summary>
        /// <value>The carrier tracking no.</value>
        [JsonProperty(PropertyName = "carrier_tracking_no")]
        public string CarrierTrackingNo { get; set; }

        /// <summary>
        /// Gets or sets the URL you can send your customers so they can track this shipment on carrier website.
        /// </summary>
        /// <value>The URL you can send your customers so they can track this shipment on carrier website.</value>
        [JsonProperty(PropertyName = "carrier_tracking_url")]
        public string CarrierTrackingUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL you can send your customers so they can track this shipment.
        /// </summary>
        /// <value>The URL you can send your customers so they can track this shipment.</value>
        [JsonProperty(PropertyName = "tracking_url")]
        public string TrackingUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL where you can download the label in pdf format.
        /// </summary>
        /// <value>The URL where you can download the label in pdf format.</value>
        [JsonProperty(PropertyName = "label_url")]
        public string LabelUrl { get; set; }

        /// <summary>
        /// Gets or sets the price that you're going to be charged with (exl. VAT). 
        /// You will get a price of 0.0 when using the sandbox or your own carrier contracts..
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
    }
}
