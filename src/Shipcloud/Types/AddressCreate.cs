using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class AddressCreate
    {
        /// <summary>
        /// Gets or sets the persons first name.
        /// </summary>
        /// <value>The persons first name.</value>
        [JsonProperty(PropertyName = "first_name", NullValueHandling = NullValueHandling.Include, Required = Required.AllowNull)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// 
        /// Either company or last name must be set.
        /// </summary>
        /// <value>The last name.</value>
        [JsonProperty(PropertyName = "last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// 
        /// Either company or last name must be set.
        /// </summary>
        /// <value>The company.</value>
        [JsonProperty(PropertyName = "company", NullValueHandling = NullValueHandling.Ignore)]
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the additional care of field.
        /// </summary>
        /// <value>The additional care of field.</value>
        [JsonProperty(PropertyName = "care_of", NullValueHandling = NullValueHandling.Include, Required = Required.AllowNull)]
        public string CareOf { get; set; }

        /// <summary>
        /// Gets or sets the name of the street. Can hold the house number.
        /// </summary>
        /// <value>The name of the street.</value>
        [JsonProperty(PropertyName = "street", Required = Required.Always)]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the house number of the address (when a carrier requires it separately).
        /// </summary>
        /// <value>The house number of the address (when a carrier requires it separately).</value>
        [JsonProperty(PropertyName = "street_no", NullValueHandling = NullValueHandling.Include, Required = Required.AllowNull)]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        [JsonProperty(PropertyName = "zip_code", Required = Required.Always)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets name of the city.
        /// </summary>
        /// <value>The name of the city.</value>
        [JsonProperty(PropertyName = "city", Required = Required.Always)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The Country as uppercase ISO 3166-1 alpha-2 code.</value>
        [JsonProperty(PropertyName = "country", Required = Required.Always)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state the address is in.
        /// </summary>
        /// <value>The state the address is in.</value>
        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Include, Required = Required.AllowNull)]
        public string State { get; set; }


        /// <summary>
        /// Gets or sets the telephone number.
        /// (mandatory when using UPS and the following terms apply: service is one_day or one_day_early or ship to country is different than ship from country).
        /// </summary>
        /// <value>The telephone number.</value>
        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the email address for this person. Some carrier are using the email address to send notifications.
        /// </summary>
        /// <value>The email address for this person. Some carrier are using the email address to send notifications.</value>
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    }
}
