using Newtonsoft.Json;
using System.Collections.Generic;

namespace Compori.Shipping.Shipcloud.Types
{
    public class Addresses
    {
        [JsonIgnore()]
        public List<Address> Items => this._addresses ?? this.DefaultShipFromAdresses;

        [JsonProperty(PropertyName = "addresses", NullValueHandling = NullValueHandling.Ignore)]
        public List<Address> _addresses { get; set; }

        [JsonProperty(PropertyName = "default_ship_from_addresses", NullValueHandling = NullValueHandling.Ignore)]
        public List<Address> DefaultShipFromAdresses { get; set; }
    }
}
