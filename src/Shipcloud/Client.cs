using Compori.Shipping.Shipcloud.Factories;
using Compori.Shipping.Shipcloud.RestSharp;
using Compori.Shipping.Shipcloud.Types;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Compori.Shipping.Shipcloud
{
    public class Client
    {
        /// <summary>
        /// Der Logger
        /// </summary>
        private static readonly NLog.Logger Log = NLog.LogManager.GetLogger(typeof(Client).FullName);

        /// <summary>
        /// Gets the settings factory.
        /// </summary>
        /// <value>The settings factory.</value>
        private ISettingsFactory SettingsFactory { get; }

        /// <summary>
        /// The settings
        /// </summary>
        private Settings settings;

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>The settings.</value>
        private Settings Settings => this.settings ??= this.SettingsFactory.Create();

        /// <summary>
        /// Gets the rest client factory.
        /// </summary>
        /// <value>The rest client factory.</value>
        private IRestClientFactory RestClientFactory { get; }

        /// <summary>
        /// Gets the rest client.
        /// </summary>
        private RestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// <param name="settingsFactory">The settings factory.</param>
        /// <param name="restClientFactory">The rest client factory.</param>
        public Client(ISettingsFactory settingsFactory, IRestClientFactory restClientFactory)
        {
            this.SettingsFactory = settingsFactory;
            this.RestClientFactory = restClientFactory;
        }

        #region Response Processing

        /// <summary>
        /// Processes the response with .
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="response">The generic response.</param>
        /// <param name="startTime">The start time.</param>
        /// <returns>Response&lt;TResult&gt;.</returns>
        private Response<TResult> ProcessResponse<TResult>(RestResponse<TResult> response, DateTime startTime)
        {
            Guard.AssertArgumentIsNotNull(response, nameof(response));

            var processedResponse = this.ProcessResponse((RestResponse)response, startTime);

            return new Response<TResult>(
                response.StatusCode,
                processedResponse.RequestId,
                processedResponse.RateLimit,
                response.IsSuccessful ? response.Data : default);
        }

        /// <summary>
        /// Processes the response.
        /// </summary>
        /// <param name="response">Die Restantwort.</param>
        /// <param name="startTime">The start time.</param>
        /// <returns>Response.</returns>
        private Response ProcessResponse(RestResponse response, DateTime startTime)
        {
            this.ProcessResponse(this.Settings, response, startTime);

            return new Response(
                response.StatusCode,
                response.GetRequestId(),
                response.GetRateLimit()
            );
        }

        /// <summary>
        /// Tries the deserialize error response.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="response">The response.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool TryDeserializeErrorResponse(string content, out ErrorsResponse response)
        {
            try
            {
                response = JsonConvert.DeserializeObject<ErrorsResponse>(content);
                return true;
            }
            catch
            {
            }

            response = null;
            return false;
        }


        /// <summary>
        /// Erstellt für die Restanfrage und -antwort einen Trace.
        /// </summary>
        /// <param name="settings">Die Einstellungen.</param>
        /// <param name="response">Die Restantwort.</param>
        /// <param name="startTime">The start time.</param>
        /// <exception cref="ResponseException"></exception>
        private void ProcessResponse(Settings settings, RestResponse response, DateTime startTime)
        {
            Guard.AssertArgumentIsNotNull(response, nameof(response));

            var trace = settings?.Trace ?? false;

            // trace request and response
            if (trace)
            {
                Trace(response, startTime);
            }

            // request was successful
            if (response.IsSuccessful)
            {
                return;
            }

            // if trace not running, now run.
            if (!trace)
            {
                this.Trace(response, startTime);
            }

            // 401
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ShipcloudException("Something has gone wrong when authorizing with our API. Please check e.g. if you're trying to use your sandbox api key with an operation that can only be used with a live API key.");
            }
            // 402
            if (response.StatusCode == HttpStatusCode.PaymentRequired)
            {
                throw new ShipcloudException("You've reached a maximum that is defined in your current plan. Please upgrade to a higher plan.");
            }
            // 403
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new ShipcloudException("You are not allowed to talk to this endpoint. This can either be due to a wrong authentication or when you're trying to reach an endpoint that your account isn't allowed to access.");
            }
            // 500
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new ShipcloudException($"Something has seriously gone wrong. Don't worry, we'll have a look at it. If the error persists, please don't hesitate to contact us by sending us an email containing the X-Request-ID ({response.GetRequestId()}) header we've returned.");
            }
            // 400
            if (response.StatusCode == HttpStatusCode.BadRequest && TryDeserializeErrorResponse(response.Content, out var errorResponse))
            {
                throw new ShipcloudException(string.Join(" ", errorResponse.Errors));
            }

            throw new ResponseException(response);
        }

        #region Tracing

        /// <summary>
        /// Traces the the request and response.
        /// </summary>
        /// <param name="response">The response.</param>
        private void Trace(RestResponse response, DateTime startTime)
        {
            this.TraceRequest(response.Request, startTime);
            this.TraceResponse(response);
        }

        /// <summary>
        /// Traces the request.
        /// </summary>
        /// <param name="request">The request.</param>
        private void TraceRequest(RestRequest request, DateTime startTime)
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Trace Request");
                var duration = DateTime.UtcNow.Subtract(startTime);

                sb.AppendLine("------------------------------------------------------------------");
                sb.AppendLine($"Resource:      {request.Resource}");
                sb.AppendLine($"Method:        {request.Method}");
                sb.AppendLine($"Duration:      {duration:G}");
                sb.AppendLine("------------------------------------------------------------------");
                sb.AppendLine("Parameters:");
                foreach (var parameter in request.Parameters)
                {
                    var value = "";
                    if (!string.IsNullOrEmpty(parameter.Name))
                    {
                        value += $"Name={parameter.Name},";
                    }
                    if (parameter.Value != null)
                    {
                        value += $"Value={parameter.Value}";
                    }
                    if (parameter.ContentType == ContentType.Json)
                    {
                        value += $"({parameter.ContentType}) " + JsonConvert.SerializeObject(parameter.Value);
                    }
                    value = value.Trim();
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        continue;
                    }

                    sb.AppendLine($"{value}");

                }
                Log.Trace(sb.ToString());
            }
            catch
            {
                // catching all errors
            }
        }

        /// <summary>
        /// Traces the response.
        /// </summary>
        /// <param name="response">The response.</param>
        private void TraceResponse(RestResponse response)
        {
            try
            {
                var sb = new StringBuilder();

                sb.AppendLine("Trace Response");
                sb.AppendLine("------------------------------------------------------------------");
                sb.AppendLine($"StatusCode:         {response.StatusCode}");
                sb.AppendLine($"StatusDescription:  {response.StatusDescription ?? "N/A"}");
                sb.AppendLine($"ProtocolVersion:    {response.Version?.ToString() ?? "N/A"}");
                sb.AppendLine("------------------------------------------------------------------");
                sb.AppendLine("Headers");
                foreach (var header in response.Headers)
                {
                    var value = $"{header.Name ?? ""}";

                    if (!string.IsNullOrWhiteSpace(header.Value?.ToString()))
                    {
                        value += $": {header.Value}";
                    }

                    if (!string.IsNullOrWhiteSpace(header.ContentType))
                    {
                        value += $" (Content-Type {header.ContentType})";
                    }

                    value = value.Trim();
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        continue;
                    }
                    sb.AppendLine($"{value}");
                }
                sb.AppendLine("------------------------------------------------------------------");
                sb.AppendLine($"ContentEncoding: {string.Join(", ", response.ContentEncoding)}");
                sb.AppendLine($"ContentLength:   {response.ContentLength?.ToString("N0") ?? "N/A"}");
                sb.AppendLine($"ContentType:     {response.ContentType ?? "N/A"}");
                sb.AppendLine($"Content:         {response.Content ?? "N/A"}");

                Log.Trace(sb.ToString());
            }
            catch
            {
                // catching all errors
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// Erstellt den REST Client sofern nicht bereits vorhanden und konfiguriert ihn.
        /// </summary>
        /// <returns>RestClient.</returns>
        /// <exception cref="ResponseException">Die Client Einstellungen konnten nicht ermittelt werden.</exception>
        private RestClient Create()
        {
            if (this._restClient != null)
            {
                return this._restClient;
            }

            // Erstelle den Client mit Access Token
            this._restClient = this.RestClientFactory.Create(this.Settings);
            return this._restClient;
        }

        /// <summary>
        /// Sendet eine Anfrage über den REST Client.
        /// </summary>
        /// <typeparam name="TOutput">Der erwartete Rückgabetyp.</typeparam>
        /// <param name="request">Das Anfrageobjekt.</param>
        /// <param name="method">Die zu verwendene HTTP Methode.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="skipNotFoundError">Wenn <c>true</c> soll kein Fehler bei 404 nicht gefunden generiert werden.</param>
        /// <returns>A Task&lt;TOutput&gt; representing the asynchronous operation.</returns>
        public async Task<Types.Response<TOutput>> Execute<TOutput>(RestRequest request, Method method, CancellationToken cancellationToken = default, bool skipNotFoundError = false)
        {
            Guard.AssertArgumentIsNotNull(request, nameof(request));

            var client = this.Create();
            var startTime = DateTime.UtcNow;
            var response = await client.ExecuteAsync<TOutput>(request, method, cancellationToken).ConfigureAwait(false);

            return this.ProcessResponse(response, startTime);
        }

        /// <summary>
        /// Sendet eine Anfrage über den REST Client.
        /// </summary>
        /// <param name="request">Das Anfrageobjekt.</param>
        /// <param name="method">Die zu verwendene HTTP Methode.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="skipNotFoundError">Wenn <c>true</c> soll kein Fehler bei 404 nicht gefunden generiert werden.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task Execute(RestRequest request, Method method, CancellationToken cancellationToken = default, bool skipNotFoundError = false)
        {
            Guard.AssertArgumentIsNotNull(request, nameof(request));

            var client = this.Create();
            var startTime = DateTime.UtcNow;
            var response = await client.ExecuteAsync(request, method, cancellationToken).ConfigureAwait(false);

            this.ProcessResponse(response, startTime);
        }

        /// <summary>
        /// Sendet eine POST Anfrage über den REST Client.
        /// </summary>
        /// <typeparam name="TInput">Der Typ des Eingangsparameter.</typeparam>
        /// <typeparam name="TOutput">Der erwartete Rückgabetyp.</typeparam>
        /// <param name="uri">Die Zieladresse.</param>
        /// <param name="data">Die zu sendenen Daten.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Task&lt;TOutput&gt; representing the asynchronous operation.</returns>
        public async Task<Types.Response<TOutput>> Post<TInput, TOutput>(string uri, TInput data, CancellationToken cancellationToken = default) where TInput : class
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(uri, nameof(uri));
            Guard.AssertArgumentIsNotNull(data, nameof(data));

            return await this.Execute<TOutput>(new RestRequest(uri).AddJsonBody(data), Method.Post, cancellationToken, false).ConfigureAwait(false);
        }

        /// <summary>
        /// Sendet eine POST Anfragen an eine URI.
        /// </summary>
        /// <typeparam name="TInput">Der Typ des Eingangsparameter.</typeparam>
        /// <param name="uri">Die Zieladresse.</param>
        /// <param name="data">Die zu sendenen Daten.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if request was successful, <c>false</c> otherwise.</returns>
        public async Task Post<TInput>(string uri, TInput data, CancellationToken cancellationToken = default) where TInput : class
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(uri, nameof(uri));
            Guard.AssertArgumentIsNotNull(data, nameof(data));

            await this.Execute(new RestRequest(uri).AddJsonBody(data), Method.Post, cancellationToken, false).ConfigureAwait(false);
        }

        /// <summary>
        /// Sendet eine POST Anfragen an eine URI.
        /// </summary>
        /// <typeparam name="TInput">Der Typ des Eingangsparameter.</typeparam>
        /// <param name="uri">Die Zieladresse.</param>
        /// <param name="data">Die zu sendenen Daten.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if request was successful, <c>false</c> otherwise.</returns>
        public async Task<Types.Response<TOutput>> Post<TOutput>(string uri, CancellationToken cancellationToken = default) where TOutput : class
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(uri, nameof(uri));

            return await this.Execute<TOutput>(new RestRequest(uri), Method.Post, cancellationToken, false).ConfigureAwait(false);
        }

        /// <summary>
        /// Sendet eine PATCH Anfrage über den REST Client.
        /// </summary>
        /// <typeparam name="TInput">Der Typ des Eingangsparameter.</typeparam>
        /// <typeparam name="TOutput">Der erwartete Rückgabetyp.</typeparam>
        /// <param name="uri">Die Zieladresse.</param>
        /// <param name="data">Die zu sendenen Daten.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Task&lt;TOutput&gt; representing the asynchronous operation.</returns>
        public async Task<Types.Response<TOutput>> Patch<TInput, TOutput>(string uri, TInput data, CancellationToken cancellationToken = default) where TInput : class
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(uri, nameof(uri));
            Guard.AssertArgumentIsNotNull(data, nameof(data));

            return await this.Execute<TOutput>(new RestRequest(uri).AddJsonBody(data), Method.Patch, cancellationToken, false).ConfigureAwait(false);
        }

        /// <summary>
        /// Sendet eine PATCH Anfragen an eine URI.
        /// </summary>
        /// <typeparam name="TInput">Der Typ des Eingangsparameter.</typeparam>
        /// <param name="uri">Die Zieladresse.</param>
        /// <param name="data">Die zu sendenen Daten.</param>
        /// <returns><c>true</c> if request was successful, <c>false</c> otherwise.</returns>
        public async Task Patch<TInput>(string uri, TInput data, CancellationToken cancellationToken = default) where TInput : class
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(uri, nameof(uri));
            Guard.AssertArgumentIsNotNull(data, nameof(data));

            await this.Execute(new RestRequest(uri).AddJsonBody(data), Method.Patch, cancellationToken, false).ConfigureAwait(false);
        }

        /// <summary>
        /// Sendet eine DELETE Anfragen an eine URI.
        /// </summary>
        /// <param name="uri">Die Zieladresse.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task Delete(string uri, Dictionary<string, string> urlParameters = null, CancellationToken cancellationToken = default)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(uri, nameof(uri));
            var request = new RestRequest(uri);
            if (urlParameters != null && urlParameters.Count > 0)
            {
                foreach (var parameter in urlParameters)
                {
                    request.AddUrlSegment(parameter.Key, parameter.Value);
                }
            }
            await this.Execute(request, Method.Delete, cancellationToken, false).ConfigureAwait(false);
        }

        /// <summary>
        /// Sendet eine GET Anfragen an eine URI.
        /// </summary>
        /// <typeparam name="TOutput">Der erwartete Rückgabetyp.</typeparam>
        /// <param name="uri">Die Zieladresse.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A Task&lt;TOutput&gt; representing the asynchronous operation.</returns>
        public async Task<Types.Response<TOutput>> Get<TOutput>(string uri, Dictionary<string, string> urlParameters = null, Dictionary<string, string> queryParameters = null, CancellationToken cancellationToken = default)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(uri, nameof(uri));
            var request = new RestRequest(uri);
            if (urlParameters != null && urlParameters.Count > 0)
            {
                foreach (var parameter in urlParameters)
                {
                    request.AddUrlSegment(parameter.Key, parameter.Value);
                }
            }

            if (queryParameters != null && queryParameters.Count > 0)
            {
                foreach (var parameter in queryParameters)
                {
                    request.AddQueryParameter(parameter.Key, parameter.Value);
                }
            }
            return await this.Execute<TOutput>(request, Method.Get, cancellationToken, true).ConfigureAwait(false);
        }
    }
}
