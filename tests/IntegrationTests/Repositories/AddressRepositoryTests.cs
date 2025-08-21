using Compori.Shipping.Shipcloud.Types;
using System.Threading.Tasks;
using Xunit;

namespace Compori.Shipping.Shipcloud.Repositories
{
    public class AddressRepositoryTests : BaseTest
    {
        protected AddressRepository Repository { get; set; }

        protected override void Setup()
        {
            base.Setup();
            this.Repository = new AddressRepository(this.TestContext.CreateClient());
        }

        [Fact()]
        public async Task TestCreateAddress()
        {
            this.Setup();
            var id = "";

            try
            {
                var address = new AddressCreate
                {
                    Company = "Mustermann GmbH",
                    FirstName = "Max",
                    LastName = "Meier",
                    CareOf = "John Doe",
                    Street = "Musterweg",
                    StreetNumber = "1",
                    ZipCode = "12345",
                    City = "Musterhausen",
                    Country = "DE",
                };

                var response = await this.Repository.Create(address);
                var actual = response.Result;

                Assert.NotNull(response.RateLimit);
                Assert.NotNull(response.Result);
                Assert.NotNull(actual);
                Assert.NotEmpty(actual.Id);
                id = actual.Id;

                Assert.Equal(address.Company, actual.Company);
                Assert.Equal(address.FirstName, actual.FirstName);
                Assert.Equal(address.LastName, actual.LastName);
                Assert.Equal(address.CareOf, actual.CareOf);
                Assert.Equal(address.Street, actual.Street);
                Assert.Equal(address.StreetNumber, actual.StreetNumber);
                Assert.Equal(address.ZipCode, actual.ZipCode);
                Assert.Equal(address.City, actual.City);
                Assert.Equal(address.Country, actual.Country);

                Assert.Equal(address.State, actual.State);
                Assert.Equal(address.Email, actual.Email);
                Assert.Equal(address.Phone, actual.Phone);

            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    // await this.Repository.Delete(id);
                }
                this.Cleanup();
            }
        }

        [Fact()]
        public async Task TestReadAddress()
        {
            this.Setup();
            try
            {
                var response = await this.Repository.Read(new AddressFilter { LastName = "Meier" });
                Assert.NotNull(response.RequestId);
                Assert.NotNull(response.RateLimit);
                Assert.NotNull(response.Result);
                var result = response.Result;
                Assert.NotEmpty(result.Items);
                Assert.Contains(result.Items, v => "Meier".Equals(v.LastName));
            }
            finally
            {
                this.Cleanup();
            }
        }

        [Fact()]
        public async Task TestReadAddresses()
        {
            this.Setup();

            try
            {
                var response = await this.Repository.Read();
                Assert.NotNull(response.RequestId);
                Assert.NotNull(response.RateLimit);
                Assert.NotNull(response.Result);
                var result = response.Result;
                Assert.NotEmpty(result.Items);
            }
            finally
            {
                this.Cleanup();
            }
        }
    }
}
