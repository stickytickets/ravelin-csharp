using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace Ravelin.Models.Responses
{
	public class Response
	{
		/// <summary>
		/// The status code returned from Ravelin
		/// </summary>
		public HttpStatusCode StatusCode { get; }

		/// <summary>
		/// The response body returned from Ravelin
		/// </summary>
		public HttpContent Body { get; }

		public Response(HttpResponseMessage response)
		{
			StatusCode = response.StatusCode;
			Body = response.Content;
		}

		/// <summary>
		/// Converts string formatted response body to a Dictionary.
		/// </summary>
		/// <returns>Dictionary object representation of HttpContent</returns>
		public virtual Dictionary<string, dynamic> DeserializeResponseBody()
		{
			return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(Body.ReadAsStringAsync().Result);
		}
	}
}
