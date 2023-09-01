using RestSharp;

namespace Compori.Shipping.Shipcloud.Factories
{
    public interface IRestClientFactory
    {
        /// <summary>
        /// Erstellt einen RestClient mit den angegebenen Einstellungen.
        /// </summary>
        /// <param name="settings">Die Einstellungen.</param>
        /// <returns>RestClient.</returns>
        RestClient Create(Settings settings);
    }
}
