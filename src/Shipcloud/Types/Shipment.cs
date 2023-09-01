using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Compori.Shipping.Shipcloud.Types
{
    public class Shipment
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the acronym of the carrier.
        /// </summary>
        /// <value>The acronym of the carrier.</value>
        [JsonProperty(PropertyName = "carrier", NullValueHandling = NullValueHandling.Ignore)]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or sets the recipient address.
        /// </summary>
        /// <value>The recipient address.</value>
        [JsonProperty(PropertyName = "to", NullValueHandling = NullValueHandling.Ignore)]
        public Address To { get; set; }

        /// <summary>
        /// Gets or sets sender addresse.
        /// </summary>
        /// <value>From.</value>
        [JsonProperty(PropertyName = "from", NullValueHandling = NullValueHandling.Ignore)]
        public Address From { get; set; }

        /// <summary>
        /// Gets or sets the cover address.
        /// </summary>
        /// <value>The cover address.</value>
        [JsonProperty(PropertyName = "cover_address", NullValueHandling = NullValueHandling.Ignore)]
        public Address CoverAddress { get; set; }

        /// <summary>
        /// Gets or sets a reference number (max. 30 characters) that you want this shipment to be identified with. 
        /// You can use this afterwards to easier find the shipment in the shipcloud.io backoffice.
        /// </summary>
        /// <value>The reference number.</value>
        [JsonProperty(PropertyName = "reference_number", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// Text that describes the contents of the shipment. 
        /// This parameter is mandatory if you're using UPS and the following conditions are true: 
        /// from and to countries are not the same; from and/or to countries are not in the EU;
        /// from and to countries are in the EU and the shipments service is not standard. 
        /// The parameter is also mandatory when using DHL Express as carrier.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the format that the returned label should have.
        /// </summary>
        /// <value>The format label.</value>
        [JsonProperty(PropertyName = "label", NullValueHandling = NullValueHandling.Ignore)]
        public ShipmentLabel Label { get; set; }

        /// <summary>
        /// Gets or sets the email address that we should notify once there's an update for this shipment (usually the recipients').
        /// </summary>
        /// <value>The notification email.</value>
        [JsonProperty(PropertyName = "notification_email", NullValueHandling = NullValueHandling.Ignore)]
        public string NotificationEmail { get; set; }

        /// <summary>
        /// Gets or sets the incoterm.
        /// </summary>
        /// <value>The incoterm.</value>
        [JsonProperty(PropertyName = "incoterm", NullValueHandling = NullValueHandling.Ignore)]
        public string Incoterm { get; set; }

        /// <summary>
        /// Gets or sets the billing.
        /// </summary>
        /// <value>The billing.</value>
        [JsonProperty(PropertyName = "billing", NullValueHandling = NullValueHandling.Ignore)]
        public ShipmentBilling Billing { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        /// <value>The metadata.</value>
        [JsonProperty(PropertyName = "metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Gets or sets the additional services.
        /// 
        /// advance_notice, angel_de_delivery_date_time, asendia_bonus_tracking, cash_on_delivery, 
        /// delivery_date, delivery_note, delivery_time, dhl_endorsement, dhl_gogreen, 
        /// dhl_ident_check, dhl_named_person_only, dhl_no_neighbor_delivery, dhl_parcel_outlet_routing, 
        /// dhl_preferred_neighbor, dpd_food, drop_authorization, gls_guaranteed24service, 
        /// hazardous_goods, hermes_identservice, hermes_next_day, premium_international, 
        /// saturday_delivery, ups_access_point_notification, ups_adult_signature, ups_carbon_neutral, 
        /// ups_direct_delivery_only, ups_signature_required, visual_age_check
        /// </summary>
        /// <value>The additional services.</value>
        [JsonProperty(PropertyName = "additional_services", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ShippingAdditionalServiceProperties> AdditionalServices { get; set; }

        /// <summary>
        /// Gets or sets the pickup.
        /// </summary>
        /// <value>The pickup.</value>
        [JsonProperty(PropertyName = "pickup", NullValueHandling = NullValueHandling.Ignore)]
        public ShippingPickup Pickup { get; set; }

        /// <summary>
        /// Gets or sets the customs declaration.
        /// </summary>
        /// <value>The customs declaration.</value>
        [JsonProperty(PropertyName = "customs_declaration", NullValueHandling = NullValueHandling.Ignore)]
        public CustomsDeclaration CustomsDeclaration { get; set; }

        /// <summary>
        /// Gets or sets the order identifier a previously created order.
        /// </summary>
        /// <value>The order identifier a previously created order.</value>
        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets list of items that get returned with this shipment.
        /// </summary>
        /// <value>The list of items that get returned with this shipment.</value>
        [JsonProperty(PropertyName = "returned_items", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingReturnedItem> ReturndItems { get; set; }

        /// <summary>
        /// Gets or sets a value determines if a shipping label should be created at the carrier 
        /// (this means you will be charged when using the production api key).
        /// </summary>
        /// <value><c>true</c> if a shipping label should be created; otherwise, <c>false</c>.</value>
        [JsonProperty(PropertyName = "create_shipping_label", NullValueHandling = NullValueHandling.Ignore)]
        public bool CreateShippingLabel { get; set; }

        /// <summary>
        /// Gets or sets the packages.
        /// </summary>
        /// <value>The packages.</value>
        [JsonProperty(PropertyName = "packages", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingPackageWithTrackingEvents> Packages { get; set; }

        /// <summary>
        /// Gets or sets the original tracking number that can be used on the carriers website.
        /// </summary>
        /// <value>The carrier tracking no.</value>
        [JsonProperty(PropertyName = "carrier_tracking_no", NullValueHandling = NullValueHandling.Ignore)]
        public string CarrierTrackingNo { get; set; }

        /// <summary>
        /// Gets or sets the timestamp the shipment was created.
        /// </summary>
        /// <value>The timestamp the shipment was created.</value>
        [JsonProperty(PropertyName = "created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the URL where you can download the label in pdf format.
        /// </summary>
        /// <value>The URL where you can download the label in pdf format.</value>
        [JsonProperty(PropertyName = "label_url", NullValueHandling = NullValueHandling.Ignore)]
        public string LabelUrl { get; set; }

        /// <summary>
        /// Gets or sets the price that is going to be charged (exl. VAT).
        /// </summary>
        /// <value>The price.</value>
        [JsonProperty(PropertyName = "price", NullValueHandling = NullValueHandling.Ignore)]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the email address of the shipper who should be notified of a change of shipment status by shipcloud.
        /// </summary>
        /// <value>The shipper notification email.</value>
        [JsonProperty(PropertyName = "shipper_notification_email", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipperNotificationEmail { get; set; }

        /// <summary>
        /// Gets or sets the URL you can send your customers so they can track this shipment.
        /// </summary>
        /// <value>The tracking URL.</value>
        [JsonProperty(PropertyName = "tracking_url", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL you can send your customers so they can track this shipment on carrier website.
        /// </summary>
        /// <value>The URL you can send your customers so they can track this shipment on carrier website.</value>
        [JsonProperty(PropertyName = "carrier_tracking_url")]
        public string CarrierTrackingUrl { get; set; }
    }
}
