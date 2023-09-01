using Newtonsoft.Json;
using System;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShippingPackageTrackingEvents
    {
        /// <summary>
        /// Gets or sets the timestamp of when this event occured.
        /// </summary>
        /// <value>The timestamp.</value>
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the location of the package at this moment.
        /// </summary>
        /// <value>The location.</value>
        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the key that is describing the status.
        /// 
        /// Values: awaits_pickup_by_receiver, canceled, delayed, delivered, destroyed, exception, 
        /// label_created, not_delivered, notification, out_for_delivery, picked_up, transit, unknown 
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the message the carrier sent to describe the package status.
        /// </summary>
        /// <value>The details.</value>
        [JsonProperty(PropertyName = "details", NullValueHandling = NullValueHandling.Ignore)]
        public string Details { get; set; }

        [JsonProperty(PropertyName = "delivery_details", NullValueHandling = NullValueHandling.Ignore)]
        public DeliveryDetails DeliveryDetails { get; set; }        
    }
}
