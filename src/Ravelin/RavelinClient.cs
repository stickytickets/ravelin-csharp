using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ravelin.Models.Enums;
using Ravelin.Models.Events;
using Ravelin.Models.Responses;
using Ravelin.Serialization;
using Ravelin.Utils;
#if NET451
using System.Net;
#endif

namespace Ravelin
{
	public class RavelinClient : IRavelinClient
	{
		public const string RavelinVaultHost = "https://vault.ravelin.com/";
		public const string BackfillPrefix = "backfill";

		public string Version { get; set; }

		public string MediaType { get; set; }

		private readonly HttpClient client;

		/// <summary>
		/// Initializes a new instance of the <see cref="RavelinClient"/> class.
		/// </summary>
		/// <param name="httpClient">An optional http client which may me injected for testing.</param>
		/// <param name="apiKey">Your secret Ravelin API key (sk_live_XXXXXXXX)</param>
		/// <param name="host">Base url (e.g. https://api.ravelin.com)</param>
		/// <param name="version">API version</param>
		public RavelinClient(HttpClient httpClient, string apiKey, string host = null, string version = "v2")
		{
			client = httpClient ?? new HttpClient();

			InitiateClient(apiKey, host, version);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RavelinClient"/> class.
		/// </summary>
		/// <param name="apiKey">Your secret Ravelin API key (sk_live_XXXXXXXX)</param>
		/// <param name="host">Base url (e.g. https://api.ravelin.com)</param>
		/// <param name="version">API version</param>
		public RavelinClient(string apiKey, string host = null, string version = "v2") : this(null, apiKey, host, version)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="RavelinClient"/> class.
		/// </summary>
		/// <param name="config">Object containing parameters that is more friendly with DI containers</param>
		public RavelinClient(RavelinClientConfig config) : 
			this(null, config.ApiKey, config.HostUrl, config.Version)
		{
		}

		public async Task<BackfillResponse> SendBackfillEvent(EventType eventType, IEvent data)
		{
			return new BackfillResponse(await RequestAsync(string.Format("{0}/{1}", BackfillPrefix, eventType.GetEndpoint()), data));
		}

		public async Task<Response> SendEvent(EventType eventType, IEvent data)
		{
			return new Response(await RequestAsync(eventType.GetEndpoint(), data));
		}

		public async Task<ScoredResponse> SendEventAndScore(EventType eventType, IEvent data)
		{
			return new ScoredResponse(await RequestAsync(eventType.GetEndpoint(), data, true));
		}

		/// <summary>
		/// Common method to initiate internal fields regardless of which constructor was used
		/// </summary>
		/// <param name="apiKey">Your secret Ravelin API key (sk_live_XXXXXXXX)</param>
		/// <param name="host">Base url (e.g. https://api.ravelin.com)</param>
		/// <param name="version">API version</param>
		private void InitiateClient(string apiKey, string host, string version)
		{
#if NET451
			//ravelin requires connection to be in tls 1.2 as per advisory - https://syslog.ravelin.com/upgrading-to-tls-1-2-44f5efab9d59
			// .Net 4.5 does not use this by default.so we need to set it
			System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
#endif

			Version = version;
			MediaType = "application/json";

			client.BaseAddress = new Uri(host ?? "https://api.ravelin.com");
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", apiKey);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
		}

		private async Task<HttpResponseMessage> RequestAsync(string urlPath, IEvent data, bool isScored = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			StringContent content = null;

			var sendToVault = !string.IsNullOrEmpty((data as IPaymentMethodEvent)?.PaymentMethod?.Pan);
			var endpoint = (sendToVault ? RavelinVaultHost : client.BaseAddress.ToString()) + BuildUrl(urlPath, isScored);

			if (data != null)
				content = new StringContent(data.Serialize(), Encoding.UTF8, MediaType);

			var request = new HttpRequestMessage
			{
				Method = new HttpMethod("POST"),
				RequestUri = new Uri(endpoint),
				Content = content
			};

			return await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
		}

		private string BuildUrl(string urlPath, bool isScored = false)
		{
			var url = urlPath;

			if (Version != null)
				url = Version + "/" + url;

			if (isScored)
				url = url + "?score=true";

			return url;
		}
	}
}
