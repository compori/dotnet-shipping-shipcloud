using System;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShipmentFilter
    {
        /// <summary>
        /// Gets or sets the carrier. 
        /// e.g. 'dhl'
        /// </summary>
        /// <value>The carrier.</value>
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or sets the carrier tracking number.
        /// </summary>
        /// <value>The carrier tracking number.</value>
        public string CarrierTrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets the created after.
        /// </summary>
        /// <value>The created after.</value>
        public DateTime? CreatedAfter { get; set; }

        /// <summary>
        /// Gets or sets the created before.
        /// </summary>
        /// <value>The created before.</value>
        public DateTime? CreatedBefore { get; set; }

        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>The reference number.</value>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the service. 
        /// e.g. 'returns'
        /// </summary>
        /// <value>The service.</value>
        public string Service { get; set; }

        /// <summary>
        /// Gets or sets the shipcloud tracking number.
        /// </summary>
        /// <value>The shipcloud tracking number.</value>
        public string ShipcloudTrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of a shipment. 
        /// 
        /// The following types are available:
        /// prepared: a shipment which was saved in shipcloud but doesn't have a shipping label yet
        /// label_created: a shipment containing a shipping label.
        /// tracking_only: a shipment that was imported via its carrier tracking number (see trackers for more details)
        /// </summary>
        /// <value>The type of the shipment.</value>
        public string ShipmentType { get; set; }

        /// <summary>
        /// Gets or sets the filter shipments by platform they were created through. 
        /// 
        /// The following keys can be used:
        /// api: a shipment created through our api
        /// webui: a shipment created using the shipcloud ui
        /// return_portal: a shipment created using the shipcloud return portal.
        /// </summary>
        /// <value>The source.</value>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the tracking status.
        /// e.g. out_for_delivery
        /// </summary>
        /// <value>The tracking status.</value>
        public string TrackingStatus { get; set; }

        /// <summary>
        /// Gets or sets the tracking status not.
        /// 
        /// e.g. delivered
        /// </summary>
        /// <value>The tracking status not.</value>
        public string TrackingStatusNot { get; set; }
    }
}
