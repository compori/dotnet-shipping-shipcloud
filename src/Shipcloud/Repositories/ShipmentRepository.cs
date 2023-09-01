using Compori.Shipping.Shipcloud.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compori.Shipping.Shipcloud.Repositories
{
    public class ShipmentRepository : Repository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentRepository"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public ShipmentRepository(Client client) : base(client, "shipments") { }

        /// <summary>
        /// Creates the specified shipment.
        /// </summary>
        /// <param name="shipment">The shipment.</param>
        /// <returns>Result&lt;ShipmentCreateResponse&gt;.</returns>
        public async Task<Response<ShipmentCreateResponse>> Create(ShipmentCreate shipment)
        {
            return await this.Client.Post<ShipmentCreate, ShipmentCreateResponse>(this.EntityRoute, shipment);
        }

        /// <summary>
        /// Reads the specified shipment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Response&lt;Shipment&gt;.</returns>
        public async Task<Response<Shipment>> Read(string id)
        {
            var result = await this.Client.Get<Shipment>(
                this.EntityRoute + "/{id}",
                new Dictionary<string, string>
                {
                    { "id", id }
                }
            ).ConfigureAwait(false);

            return result;
        }

        /// <summary>
        /// Adds the filter parameter.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        private void AddFilterParameter(Dictionary<string, string> parameters, string key, DateTime? value)
        {
            if (value == null)
            {
                return;
            }
            var dateTime = value.Value.ToUniversalTime();
            parameters[key] = dateTime.ToString("yyyyMMddTHHmmssZ");
        }

        /// <summary>
        /// Adds the filter parameter.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        private void AddFilterParameter(Dictionary<string, string> parameters, string key, string value)
        {
            if (value == null)
            {
                return;
            }
            parameters[key] = value;
        }

        /// <summary>
        /// Reads the shipments with given filter settings.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Response&lt;List&lt;Shipment&gt;&gt;.</returns>
        public async Task<Response<List<Shipment>>> Read(ShipmentFilter filter = null, int pageNumber = 0, int pageSize = 100)
        {
            var parameter = new Dictionary<string, string>
            {
                { "page", pageNumber.ToString() },
                { "per_page", pageSize.ToString() }
            };
            if (filter != null)
            {
                this.AddFilterParameter(parameter, "carrier", filter.Carrier);
                this.AddFilterParameter(parameter, "carrier_tracking_no", filter.CarrierTrackingNumber);
                this.AddFilterParameter(parameter, "created_at_gt", filter.CreatedAfter);
                this.AddFilterParameter(parameter, "created_at_lt", filter.CreatedBefore);
                this.AddFilterParameter(parameter, "reference_number", filter.ReferenceNumber);
                this.AddFilterParameter(parameter, "service", filter.Service);
                this.AddFilterParameter(parameter, "shipcloud_tracking_no", filter.ShipcloudTrackingNumber);
                this.AddFilterParameter(parameter, "shipment_type", filter.ShipmentType);
                this.AddFilterParameter(parameter, "source", filter.Source);
                this.AddFilterParameter(parameter, "tracking_status", filter.TrackingStatus);
                this.AddFilterParameter(parameter, "tracking_status_not", filter.TrackingStatusNot);
            }
            return await this.Client.Get<List<Shipment>>(this.EntityRoute).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the specified shipment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(string id)
        {
            await this.Client.Delete(
                 this.EntityRoute + "/{id}",
                 new Dictionary<string, string>
                 {
                    { "id", id }
                 }
             ).ConfigureAwait(false);
        }
    }
}
