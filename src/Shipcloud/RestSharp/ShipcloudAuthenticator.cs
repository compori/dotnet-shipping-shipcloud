using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Compori.Shipping.Shipcloud.RestSharp
{
    public class ShipcloudAuthenticator : AuthenticatorBase
    {
        public ShipcloudAuthenticator(string apiKey) : this(apiKey, Encoding.UTF8) { }

        public ShipcloudAuthenticator(string apiKey, Encoding encoding) : base(GetHeader(apiKey, encoding)) { }

        static string GetHeader(string apiKey, Encoding encoding) => Convert.ToBase64String(encoding.GetBytes($"{apiKey}:"));

        protected override ValueTask<Parameter> GetAuthenticationParameter(string accessToken) 
            => new ValueTask<Parameter>(new HeaderParameter(KnownHeaders.Authorization, $"Basic {accessToken}"));
    }
}
