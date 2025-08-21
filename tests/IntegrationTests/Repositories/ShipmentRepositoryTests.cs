using Compori.Shipping.Shipcloud.Types;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Compori.Shipping.Shipcloud.Repositories
{
    public class ShipmentRepositoryTests : BaseTest
    {
        protected ShipmentRepository Repository { get; set; }

        protected override void Setup()
        {
            base.Setup();
            this.Repository = new ShipmentRepository(this.TestContext.CreateClient());
        }

        [Fact()]
        public async Task TestCreate()
        {
            this.Setup();
            var id = "";
            try
            {
                var shipment = new ShipmentCreate
                {
                    Carrier = "dhl",
                    To = new ShipmentAddress
                    {
                        FirstName = "Martin",
                        LastName = "Monnier",
                        Street = "Eichhörnchweg",
                        StreetNumber = "8",
                        City = "Barmstedt",
                        ZipCode = "25355",
                        Country = "DE"
                    },
                    CreateShippingLabel = true,
                    Package = new Package
                    {
                        Height = 50,
                        Width = 50,
                        Length = 50,
                        Weight = 0.5,
                    }
                };

                var response = await this.Repository.Create(shipment);
                Assert.NotNull(response.RateLimit);
                Assert.NotNull(response.Result);
                var result = response.Result;
                Assert.NotNull(result.Id);
                id = result.Id;
                Assert.NotEmpty(result.LabelUrl);
            }
            finally
            {
                if (!string.IsNullOrEmpty(id))
                {
                    await this.Repository.Delete(id);
                }
                this.Cleanup();
            }
        }


        [Fact()]
        public async Task TestRead()
        {
            this.Setup();
            var id = "";
            try
            {
                var shipment = new ShipmentCreate
                {
                    Carrier = "dhl",
                    To = new ShipmentAddress
                    {
                        FirstName = "Martin",
                        LastName = "Monnier",
                        Street = "Eichhörnchweg",
                        StreetNumber = "8",
                        City = "Barmstedt",
                        ZipCode = "25355",
                        Country = "DE"
                    },
                    CreateShippingLabel = true,
                    Package = new Package
                    {
                        Height = 30,
                        Width = 40,
                        Length = 50,
                        Weight = 0.5,
                    },
                    Metadata = new Dictionary<string, object> { { "Hallo", "Max" } }
                };

                var createResponse = await this.Repository.Create(shipment);
                Assert.NotNull(createResponse.RateLimit);
                Assert.NotNull(createResponse.Result);
                var result = createResponse.Result;
                Assert.NotNull(result.Id);
                id = result.Id;
                Assert.NotEmpty(result.LabelUrl);

                var readSingleResponse = await this.Repository.Read(id);
                Assert.NotNull(readSingleResponse.RateLimit);
                Assert.NotNull(readSingleResponse.Result);
                var actual = readSingleResponse.Result;
                Assert.Equal(id, actual.Id);
                Assert.Equal(result.TrackingUrl, actual.TrackingUrl);
                Assert.Equal(result.LabelUrl, actual.LabelUrl);

                Assert.Single(actual.Packages);
                var package = actual.Packages[0];
                Assert.Equal(shipment.Package.Width, package.Width);
                Assert.Equal(shipment.Package.Height, package.Height);
                Assert.Equal(shipment.Package.Length, package.Length);
                Assert.Equal(shipment.Package.Weight, package.Weight);
            }
            finally
            {
                if (!string.IsNullOrEmpty(id))
                {
                    await this.Repository.Delete(id);
                }
                this.Cleanup();
            }
        }

        [Fact()]
        public async Task TestCreateFailed1()
        {
            this.Setup();
            try
            {
                var shipment = new ShipmentCreate
                {
                    Carrier = "ups",
                    To = new ShipmentAddress
                    {
                        FirstName = null,
                        LastName = "Friedrich Schneider & PartnerBastlerbedarf GmbH",
                        CareOf = "",
                        Street = "",
                        StreetNumber = "",
                        City = "Dortmund",
                        ZipCode = "46520",
                        Country = "Deutschland",
                        State = "",
                        Phone = "0241/789456",
                        Email = ""
                    },
                    CreateShippingLabel = true,
                    ReferenceNumber = "",
                    NotificationEmail = "",
                    Package = new Package
                    {
                        Height = 20,
                        Length = 20,
                        Weight = 2.5,
                        Width = 10,
                        Description = "",
                        Type = "parcel"
                    }

                };

                await Assert.ThrowsAnyAsync<ShipcloudException>(async () => await this.Repository.Create(shipment).ConfigureAwait(false));
            }
            finally
            {
                this.Cleanup();
            }
        }

    }
}
