using System.Net;

namespace Compori.Shipping.Shipcloud.Types
{
    public class Response
    {
        /// <summary>
        /// Gets the rate limit.
        /// </summary>
        /// <value>The rate limit.</value>
        public RateLimit RateLimit { get; }

        /// <summary>
        /// Gets the http status code.
        /// </summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the internal identifier that we generate for every request.
        /// </summary>
        /// <value>The internal identifier that we generate for every request.</value>
        public string RequestId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        /// <param name="rateLimit">The rate limit.</param>
        /// <param name="result">The result value.</param>
        public Response(HttpStatusCode statusCode, string requestId, RateLimit rateLimit)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(requestId, nameof(requestId));
            Guard.AssertArgumentIsNotNull(rateLimit, nameof(rateLimit));

            this.StatusCode = statusCode;
            this.RequestId = requestId;
            this.RateLimit = rateLimit;
        }
    }

    public class Response<T> : Response
    {

        /// <summary>
        /// Gets the result value.
        /// </summary>
        /// <value>The result value.</value>
        public T Result { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        /// <param name="rateLimit">The rate limit.</param>
        /// <param name="result">The result value.</param>
        public Response(HttpStatusCode statusCode, string requestId, RateLimit rateLimit, T result) : base(statusCode, requestId, rateLimit)
        {
            this.Result = result;
        }
    }
}
