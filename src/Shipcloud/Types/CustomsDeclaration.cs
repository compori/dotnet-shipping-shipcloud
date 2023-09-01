using Newtonsoft.Json;
using System.Collections.Generic;

namespace Compori.Shipping.Shipcloud.Types
{
    public class CustomsDeclaration
    {
        /// <summary>
        /// Gets or sets the type of contents.
        /// 
        /// Values: commercial_goods, commercial_sample, documents, gift, returned_goods
        /// </summary>
        /// <value>The type of contents.</value>
        [JsonProperty(PropertyName = "contents_type", Required = Required.Always)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the description of contents. 
        /// Mandatory if contents_type is commercial_goods. Max 256 characters, when using DHL as your carrier.
        /// </summary>
        /// <value>The explanation.</value>
        [JsonProperty(PropertyName = "contents_explanation", NullValueHandling = NullValueHandling.Ignore)]
        public string Explanation { get; set; }

        /// <summary>
        /// Gets or sets a valid ISO 4217 curreny code.
        /// </summary>
        /// <value>The valid ISO 4217 curreny code.</value>
        [JsonProperty(PropertyName = "currency", Required = Required.Always)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the additional custom fees to be payed.
        /// </summary>
        /// <value>The additional custom fees to be payed.</value>
        [JsonProperty(PropertyName = "additional_fees", NullValueHandling = NullValueHandling.Ignore)]
        public double? AdditionalFees { get; set; }

        /// <summary>
        /// Gets or sets the location where the package will be dropped of with the carrier.
        /// </summary>
        /// <value>The location where the package will be dropped of with the carrier.</value>
        [JsonProperty(PropertyName = "drop_off_location", NullValueHandling = NullValueHandling.Ignore)]
        public string DropOffLocation { get; set; }

        /// <summary>
        /// Gets or sets a note for the exporter.
        /// </summary>
        /// <value>The note for the exporter.</value>
        [JsonProperty(PropertyName = "exporter_reference", NullValueHandling = NullValueHandling.Ignore)]
        public string ExporterReference { get; set; }

        /// <summary>
        /// Gets or sets a note for the importer.
        /// </summary>
        /// <value>The note for the importer.</value>
        [JsonProperty(PropertyName = "importer_reference", NullValueHandling = NullValueHandling.Ignore)]
        public string ImporterReference { get; set; }

        /// <summary>
        /// Gets or sets the date of commital at carrier.
        /// </summary>
        /// <value>The date of commital at carrier.</value>
        [JsonProperty(PropertyName = "posting_date", NullValueHandling = NullValueHandling.Ignore)]
        public string PostingDate { get; set; }

        /// <summary>
        /// Gets or sets the invoice number for the order.
        /// </summary>
        /// <value>The invoice number for the order.</value>
        [JsonProperty(PropertyName = "invoice_number", NullValueHandling = NullValueHandling.Ignore)]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the overall value of the shipments' contents.
        /// 
        /// minimum: 0
        /// maximum: 1000
        /// </summary>
        /// <value>The overall value of the shipments' contents.</value>
        [JsonProperty(PropertyName = "total_value_amount", Required = Required.Always)]
        public double TotalValueAmount { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [JsonProperty(PropertyName = "items", Required = Required.Always)]
        public List<CustomsDeclarationItem> Items { get; set; } = new List<CustomsDeclarationItem> { };
    }
}
