using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Ravelin.Tests
{
	public class FakeHttpMessageHandler : HttpMessageHandler
	{
		public virtual HttpResponseMessage Send(HttpRequestMessage request)
		{
			throw new NotImplementedException("Ensure to setup this method as part of your test.");
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return Task.FromResult(Send(request));
		}
	}
}
