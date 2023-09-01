using System.Threading.Tasks;
using Xunit;

namespace Compori.Shipping.Shipcloud.Repositories
{
    public class CarrierRepositoryTests : BaseTest
    {
        protected CarrierRepository Repository { get; set; }

        protected override void Setup()
        {
            base.Setup();
            this.Repository = new CarrierRepository(this.TestContext.CreateClient());
        }

        [Fact()]
        public async Task TestReadUnauthorized()
        {
            this.Setup();

            try
            {
                var repository = new CarrierRepository(this.TestContext.CreateUnauthorizedClient());
                await Assert.ThrowsAsync<ShipcloudException>( async () => await repository.Read().ConfigureAwait(false) );                
            }
            finally
            {
                this.Cleanup();
            }
        }

        [Fact()]
        public async Task TestRead()
        {
            this.Setup();

            try
            {
                var result = await this.Repository.Read().ConfigureAwait(false);
                Assert.NotNull(result.RateLimit);
                Assert.NotNull(result.Result);
            }
            finally
            {
                this.Cleanup();
            }
        }
    }
}
