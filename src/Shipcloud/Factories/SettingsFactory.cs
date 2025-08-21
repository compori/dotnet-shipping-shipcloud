using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Compori.Shipping.Shipcloud.Factories
{
    public class SettingsFactory : ISettingsFactory
    {
        /// <summary>
        /// Liefert die Einstellungen zurück.
        /// </summary>
        /// <value>Die Einstellungen.</value>
        public Settings Settings { get; protected set; }

        /// <summary>
        /// Liest die Einstellungen aus einer Json Text Datei.
        /// </summary>
        /// <param name="path">Der Pfad zur Konfigurationsdatei.</param>
        public void ReadFromJsonFile(string path)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(path, nameof(path));

            var json = File.ReadAllText(path, Encoding.UTF8);
            this.ReadFromJson(json);
        }

        /// <summary>
        /// Liest die Einstellungen aus einer Json Text Datei.
        /// </summary>
        /// <param name="path">Der Pfad zur Konfigurationsdatei.</param>
        /// <param name="settings">Die Einstellung</param>
        public void SaveJsonFile(string path, Settings settings)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(path, nameof(path));
            Guard.AssertArgumentIsNotNull(settings, nameof(settings));

            File.WriteAllText(path, JsonConvert.SerializeObject(settings), Encoding.UTF8);
        }

        /// <summary>
        /// Liest die Einstellungen aus einem Json String.
        /// </summary>
        /// <param name="json">Der Json String.</param>
        public void ReadFromJson(string json)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(json, nameof(json));

            this.Settings = JsonConvert.DeserializeObject<Settings>(json);
        }

        /// <summary>
        /// Erstellt die benötigten Einstellungen für den Shopware Client.
        /// </summary>
        /// <returns>Settings.</returns>
        /// <exception cref="System.InvalidOperationException">Die Einstellungen sind nicht gesetzt.</exception>
        public Settings Create()
        {
            return this.Settings ?? throw new InvalidOperationException("Die Einstellungen sind nicht gesetzt.");
        }
    }
}
