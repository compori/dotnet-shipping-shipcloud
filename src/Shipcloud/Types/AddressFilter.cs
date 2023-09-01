namespace Compori.Shipping.Shipcloud.Types
{
    public class AddressFilter
    {
        /// <summary>
        /// Gets or sets the persons first name.
        /// </summary>
        /// <value>The persons first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>The company.</value>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the additional care of field.
        /// </summary>
        /// <value>The additional care of field.</value>
        public string CareOf { get; set; }

        /// <summary>
        /// Gets or sets the name of the street. Can hold the house number.
        /// </summary>
        /// <value>The name of the street.</value>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the house number of the address (when a carrier requires it separately).
        /// </summary>
        /// <value>The house number of the address (when a carrier requires it separately).</value>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets name of the city.
        /// </summary>
        /// <value>The name of the city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The Country as uppercase ISO 3166-1 alpha-2 code.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>The telephone number.</value>
        public string Phone { get; set; }
    }
}
