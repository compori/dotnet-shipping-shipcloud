using Compori.Shipping.Shipcloud.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compori.Shipping.Shipcloud.Repositories
{
    public class AddressRepository : Repository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public AddressRepository(Client client) : base(client, "addresses") { }

        /// <summary>
        /// Creates the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>Result&lt;Address&gt;.</returns>
        public async Task<Response<Address>> Create(AddressCreate address)
        {
            return await this.Client.Post<AddressCreate, Address>(this.EntityRoute, address).ConfigureAwait(false);
        }

        /// <summary>
        /// Reads a specified address by an identifier.
        /// </summary>
        /// <param name="id">The address identifier.</param>
        /// <returns>Result&lt;Address&gt;.</returns>
        public async Task<Response<Address>> Read(string id)
        {
            return await this.Client.Get<Address>(
                this.EntityRoute + "/{id}",
                new Dictionary<string, string>
                {
                    { "id", id }
                }
            ).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds the filter parameter.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        private void AddFilterParameter(Dictionary<string, string> parameters, string key, string value)
        {
            if(value == null)
            {
                return;
            }
            parameters[key] = value;
        }

        /// <summary>
        /// Reads the specified page number.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Result&lt;AddressResult&gt;.</returns>
        public async Task<Response<Addresses>> Read(AddressFilter filter = null, int pageNumber = 0, int pageSize = 100)
        {
            var parameter = new Dictionary<string, string>
            {
                { "page", pageNumber.ToString() },
                { "per_page", pageSize.ToString() }
            };
            if(filter != null)
            {
                this.AddFilterParameter(parameter, "care_of", filter.CareOf);
                this.AddFilterParameter(parameter, "city", filter.City);
                this.AddFilterParameter(parameter, "company", filter.Company);
                this.AddFilterParameter(parameter, "country", filter.Country);
                this.AddFilterParameter(parameter, "first_name", filter.FirstName);
                this.AddFilterParameter(parameter, "last_name", filter.LastName);
                this.AddFilterParameter(parameter, "phone", filter.Phone);
                this.AddFilterParameter(parameter, "street", filter.Street);
                this.AddFilterParameter(parameter, "street_no", filter.StreetNumber);
                this.AddFilterParameter(parameter, "zip_code", filter.ZipCode);
            }
            return await this.Client.Get<Addresses>(this.EntityRoute, null, parameter).ConfigureAwait(false);
        }
    }
}
