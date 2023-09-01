using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShippingReturnedItem
    {
        /// <summary>
        /// Gets or sets the UUID of the corresponding order line item within an order.
        /// </summary>
        /// <value>The UUID of the corresponding order line item within an order.</value>
        [JsonProperty(PropertyName = "order_line_item_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderLineItemId { get; set; }

        /// <summary>
        /// Gets or sets the number that defines how many items of this kind are in the shipment.
        /// </summary>
        /// <value>The number that defines how many items of this kind are in the shipment.</value>
        [JsonProperty(PropertyName = "quantity", NullValueHandling = NullValueHandling.Ignore)]
        public double? Quantity { get; set; }

        /// <summary>
        /// Gets or sets a key that represents the reason why the item(s) will be returned.
        /// 
        /// delivery_too_late, delivery_wrong_product, garment_expectation_failed_style, 
        /// garment_too_large, garment_too_long, garment_too_short, garment_too_small, 
        /// ordered_choices, other, product_description_differing, product_expectation_failed_color, 
        /// product_expectation_failed_material, product_expectation_failed_price, product_faulty
        /// </summary>
        /// <value>The reason for return.</value>
        [JsonProperty(PropertyName = "reason_for_return", NullValueHandling = NullValueHandling.Ignore)]
        public string ReasonForReturn { get; set; }
    }
}
