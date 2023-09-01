namespace Compori.Shipping.Shipcloud.Repositories
{
    public abstract class Repository
    {
        /// <summary>
        /// Liefert den Shopware Client.
        /// </summary>
        /// <value>The client.</value>
        protected Client Client { get; }
        
        /// <summary>
        /// Gets the entity route.
        /// </summary>
        /// <value>The entity route.</value>
        protected string EntityRoute { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        protected Repository(Client client, string entityRoute)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(entityRoute, nameof(entityRoute));
            this.EntityRoute = entityRoute;        
            this.Client = client;
        }
    }
}
