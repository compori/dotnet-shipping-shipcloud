using Compori.Shipping.Shipcloud.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compori.Shipping.Shipcloud.Repositories
{
    public class CarrierRepository : Repository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CarrierRepository"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public CarrierRepository(Client client) : base(client, "carriers") { }

        /// <summary>
        /// Reads the supported carriers.
        /// </summary>
        /// <returns>Response&lt;List&lt;Carrier&gt;&gt;.</returns>
        public async Task<Response<List<Carrier>>> Read() 
        {
            return await this.Client.Get<List<Carrier>>(this.EntityRoute).ConfigureAwait(false);
        }
    }
}
