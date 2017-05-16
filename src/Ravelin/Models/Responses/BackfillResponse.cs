using System.Net;
using System.Net.Http;

namespace Ravelin.Models.Responses
{
	public sealed class BackfillResponse : Response
	{
		public bool Success { get; set; }

		public BackfillResponse(HttpResponseMessage response) : base(response)
		{
			if (StatusCode != HttpStatusCode.OK) return;

			var dsContent = DeserializeResponseBody();

			Success = dsContent.ContainsKey("success") && dsContent["success"] == "true";
		}
	}
}
