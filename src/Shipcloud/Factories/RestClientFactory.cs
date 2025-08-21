using Compori.Shipping.Shipcloud.RestSharp;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Net;

namespace Compori.Shipping.Shipcloud.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        /// <summary>
        /// Der Logger
        /// </summary>
        private static readonly NLog.Logger Log = NLog.LogManager.GetLogger(Logging.Facility);

        /// <summary>
        /// Wurde die das Security Protocol bereits gesetzt?
        /// </summary>
        private bool _isSecurityProtocol;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClientFactory"/> class.
        /// </summary>
        public RestClientFactory()
        {
            this._isSecurityProtocol = false;
        }

        /// <summary>
        /// Liefert das aktuelle Security Protokoll zurück.
        /// </summary>
        /// <value>Das aktuelle Security Protokoll.</value>
        public SecurityProtocolType SecurityProtocol => ServicePointManager.SecurityProtocol;

        /// <summary>
        /// Setzt das Security Protocol des ServicePointManager.
        /// </summary>
        /// <param name="settings">Die Einstellungen.</param>
        /// <param name="force">Wenn <c>true</c> soll das setzen nochmal ausgeführt werden, auch wenn bereits gesetzt wurde.</param>
        public void SetSecurityProtocol(Settings settings, bool force = false)
        {
            Guard.AssertArgumentIsNotNull(settings, nameof(settings));

            if (this._isSecurityProtocol && !force)
            {
                return;
            }

            // Vom System konfigurierten Wert nehmen
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;

            // Aktivieren
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            Log.Trace("Enable SecurityProtocolType.Tls12");

            if (settings.EnableTls13)
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls13;
                Log.Trace("Enable SecurityProtocolType.Tls13");
            }

            // Erzwingen
            if (settings.ForceTls13)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
                Log.Trace("Force SecurityProtocolType.Tls13");
            }

            this._isSecurityProtocol = true;
        }

        /// <summary>
        /// Erstellt einen RestClient mit den angegebenen Einstellungen.
        /// </summary>
        /// <param name="settings">Die Einstellungen.</param>
        /// <returns>RestClient.</returns>
        public RestClient Create(Settings settings)
        {

            Guard.AssertArgumentIsNotNull(settings, nameof(settings));

            this.SetSecurityProtocol(settings);

            var authenticator = new ShipcloudAuthenticator(settings.ApiKey);

            // Neuen Rest Client erstellen
            var options = new RestClientOptions(settings.Url)
            {
                Timeout = settings.Timeout,
                UserAgent = settings.ClientAgent,
                Authenticator = authenticator
            };

            var client = new RestClient(
                options,
                configureSerialization: configuration => configuration.UseNewtonsoftJson(new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                })
            );

            Log.Trace($"Created a new REST client to '{settings.Url}'");

            return client;
        }
    }
}
