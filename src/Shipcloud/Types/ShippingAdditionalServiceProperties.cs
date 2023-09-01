using Newtonsoft.Json;

namespace Compori.Shipping.Shipcloud.Types
{
    public class ShippingAdditionalServiceProperties
    {
        /// <summary>
        /// Gets or sets the amount that should be payed (cash_on_delivery).
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty(PropertyName = "amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the name of the person the bank account belongs to (cash_on_delivery).
        /// </summary>
        /// <value>The bank account holder.</value>
        [JsonProperty(PropertyName = "bank_account_holder", NullValueHandling = NullValueHandling.Ignore)]
        public string BankAccountHolder { get; set; }

        /// <summary>
        /// Gets or sets the iban (cash_on_delivery).
        /// </summary>
        /// <value>The iban.</value>
        [JsonProperty(PropertyName = "bank_account_number", NullValueHandling = NullValueHandling.Ignore)]
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the bank code (cash_on_delivery).
        /// </summary>
        /// <value>The bank code.</value>
        [JsonProperty(PropertyName = "bank_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BankCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank (cash_on_delivery).
        /// </summary>
        /// <value>The name of the bank.</value>
        [JsonProperty(PropertyName = "bank_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the currency as uppercase ISO 4217 code (cash_on_delivery).
        /// </summary>
        /// <value>The currency.</value>
        [JsonProperty(PropertyName = "currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the date (angel_de_delivery_date_time, delivery_date).
        /// </summary>
        /// <value>The date.</value>
        [JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
        public string date { get; set; }

        /// <summary>
        /// Gets or sets the recipients date of birth (dhl_ident_check).
        /// </summary>
        /// <value>The recipients date of birth.</value>
        [JsonProperty(PropertyName = "date_of_birth", NullValueHandling = NullValueHandling.Ignore)]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the email address (advanced_notice).
        /// </summary>
        /// <value>The email address.</value>
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the persons first name (dhl_ident_check).
        /// </summary>
        /// <value>The persons first name (dhl_ident_check).</value>
        [JsonProperty(PropertyName = "first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the type of ID document that should be used for verifying (hermes_ident_check) 
        /// 
        /// Values: german_identity_card, german_passport, international_passport.
        /// </summary>
        /// <value>The type of ID document that should be used for verifying (hermes_ident_check).</value>
        [JsonProperty(PropertyName = "id_type", NullValueHandling = NullValueHandling.Ignore)]
        public string IdType { get; set; }

        /// <summary>
        /// Gets or sets the number of the ID document (hermes_ident_check).
        /// </summary>
        /// <value>The number of the ID document (hermes_ident_check).</value>
        [JsonProperty(PropertyName = "id_number", NullValueHandling = NullValueHandling.Ignore)]
        public string IdNumber { get; set; }

        /// <summary>
        /// Gets or sets the language (in ISO-639-1 format) the customer should be notified in (advanced_notice).
        /// </summary>
        /// <value>The language (in ISO-639-1 format) the customer should be notified in (advanced_notice).</value>
        [JsonProperty(PropertyName = "language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the last name (dhl_ident_check).
        /// </summary>
        /// <value>The last name.</value>
        [JsonProperty(PropertyName = "last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the minimum age that should be checked (dhl_ident_check, visual_age_check).
        /// </summary>
        /// <value>The minimum age that should be checked (dhl_ident_check, visual_age_check).</value>
        [JsonProperty(PropertyName = "minimum_age", NullValueHandling = NullValueHandling.Ignore)]
        public string MinimumAge { get; set; }

        /// <summary>
        /// Gets or sets the phone number that can be called for making the delivery (advanced_notice).
        /// </summary>
        /// <value>The phone number that can be called for making the delivery (advanced_notice).</value>
        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the text that should be displayed as the reason for transfer (cash_on_delivery).
        /// </summary>
        /// <value>The text that should be displayed as the reason for transfer (cash_on_delivery).</value>
        [JsonProperty(PropertyName = "reference1", NullValueHandling = NullValueHandling.Ignore)]
        public string Reference1 { get; set; }

        /// <summary>
        /// Gets or sets the SMS phone number that can be texted for making the delivery (advanced_notice).
        /// </summary>
        /// <value>The SMS phone  number that can be texted for making the delivery (advanced_notice).</value>
        [JsonProperty(PropertyName = "sms", NullValueHandling = NullValueHandling.Ignore)]
        public string Sms { get; set; }

        /// <summary>
        /// Gets or sets the earliest pickup date and time (angel_de_delivery_date_time).
        /// </summary>
        /// <value>The earliest pickup date and time (angel_de_delivery_date_time).</value>
        [JsonProperty(PropertyName = "time_of_day_earliest", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeOfDayEarliest { get; set; }

        /// <summary>
        /// Gets or sets the latest pickup date and time(angel_de_delivery_date_time)
        /// </summary>
        /// <value>The latest pickup date and time(angel_de_delivery_date_time).</value>
        [JsonProperty(PropertyName = "time_of_day_latest", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeOfDayLatest { get; set; }
    }
}
