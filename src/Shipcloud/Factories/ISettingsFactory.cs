﻿namespace Compori.Shipping.Shipcloud.Factories
{
    public interface ISettingsFactory
    {
        /// <summary>
        /// Erstellt die benötigten Einstellungen für den Shopware Client.
        /// </summary>
        /// <returns>Settings.</returns>
        Settings Create();
    }
}
