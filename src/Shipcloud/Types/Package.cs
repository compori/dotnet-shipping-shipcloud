using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class Package
    {
        /// <summary>
        /// Gets or sets the height of the parcel in cm.
        /// </summary>
        /// <value>The height of the parcel in cm.</value>
        [JsonProperty(PropertyName = "height", Required = Required.Always)]
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the length of the parcel in cm.
        /// </summary>
        /// <value>The length of the parcel in cm.</value>
        [JsonProperty(PropertyName = "length", Required = Required.Always)]
        public double Length { get; set; }

        /// <summary>
        /// Gets or sets the weight of the parcel in kg.
        /// </summary>
        /// <value>The weight of the parcel in kg.</value>
        [JsonProperty(PropertyName = "weight", Required = Required.Always)]
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the width of the parcel in cm.
        /// </summary>
        /// <value>The width of the parcel in cm.</value>
        [JsonProperty(PropertyName = "width", Required = Required.Always)]
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the declared value.
        /// </summary>
        /// <value>The declared value.</value>
        [JsonProperty(PropertyName = "declared_value", NullValueHandling = NullValueHandling.Ignore)]
        public DeclaredValue DeclaredValue { get; set; }

        /// <summary>
        /// Gets or sets if you're using UPS with service returns this is mandatory otherwise it's optional.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of shipment you would like to book.
        /// 
        /// default: parcel
        /// Values: books, bulk, letter, parcel, parcel_letter
        /// </summary>
        /// <value>The type of shipment you would like to book.</value>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = "parcel";
    }
}
