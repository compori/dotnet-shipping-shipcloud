using Newtonsoft.Json;
using System.Collections.Generic;

namespace Compori.Shipping.Shipcloud.Types
{
    public class Carrier
    {
        /// <summary>
        /// Gets key for referencing the carrier within shipcloud.
        /// </summary>
        /// <value>key for referencing the carrier.</value>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Gets name of the carrier you can use to display it in your application.
        /// </summary>
        /// <value>The display name.</value>
        [JsonProperty(PropertyName = "display_name", Required = Required.Always)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets key for referencing the service within shipcloud.
        /// </summary>
        /// <value>The services.</value>
        [JsonProperty(PropertyName = "services", Required = Required.Always)]
        public HashSet<string> Services { get; set; } = new HashSet<string>();

        /// <summary>
        /// Gets key for referencing the package type within shipcloud.
        /// </summary>
        /// <value>The package types.</value>
        [JsonProperty(PropertyName = "package_types", Required = Required.Always)]
        public HashSet<string> PackageTypes { get; set; } = new HashSet<string>();

        /// <summary>
        /// Gets key to identify the additional service.
        /// </summary>
        /// <value>The additional services.</value>
        [JsonProperty(PropertyName = "additional_services", Required = Required.Always)]
        public HashSet<string> AdditionalServices { get; set; } = new HashSet<string>();
    }
}
