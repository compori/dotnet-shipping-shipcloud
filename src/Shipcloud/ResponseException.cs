using RestSharp;
using System;

namespace Compori.Shipping.Shipcloud
{
    /// <summary>
    /// A RestResponseException occures if anything with the reponse is invalid, e.g. invalid json.
    /// Implements the <see cref="Exception" />
    /// </summary>
    /// <seealso cref="Exception" />
    public class ResponseException : Exception
    {
        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <value>The content.</value>
        public RestResponse Response { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseException"/> class.
        /// </summary>
        public ResponseException(RestResponse response)
        {
            this.Response = response;
        }
    }
}
