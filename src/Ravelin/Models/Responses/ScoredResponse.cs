using System.Net;
using System.Net.Http;

namespace Ravelin.Models.Responses
{
	public sealed class ScoredResponse : Response
	{
		public Score Score { get; set; }

		public ScoredResponse(HttpResponseMessage response) : base(response)
		{
			if (StatusCode != HttpStatusCode.OK) return;

			var dsContent = DeserializeResponseBody();

			if (dsContent.ContainsKey("data"))
				Score = dsContent["data"].ToObject<Score>();
		}
	}
}
