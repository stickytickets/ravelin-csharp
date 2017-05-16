using System;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Moq;
using Ravelin.Models.Enums;
using Ravelin.Models.Events;
using Ravelin.Models.Responses;
using Xunit;

namespace Ravelin.Tests
{
	public class RavelinClientTest : IClassFixture<RavelinClientFixture>, IDisposable
	{
		private readonly RavelinClient client;
		private readonly Mock<FakeHttpMessageHandler> fakeHttpMessageHandler;

		public RavelinClientTest(RavelinClientFixture fixture)
		{
			client = fixture.RavelinClient;
			fakeHttpMessageHandler = fixture.FakeHttpMessageHandler;
		}

		[Theory]
		[InlineData(EventType.Customer, "https://api.ravelin.com/v2/customer")]
		[InlineData(EventType.Order, "https://api.ravelin.com/v2/order")]
		[InlineData(EventType.PaymentMethod, "https://api.ravelin.com/v2/paymentmethod")]
		[InlineData(EventType.PreTransaction, "https://api.ravelin.com/v2/pretransaction")]
		[InlineData(EventType.Transaction, "https://api.ravelin.com/v2/transaction")]
		[InlineData(EventType.Login, "https://api.ravelin.com/v2/login")]
		[InlineData(EventType.Checkout, "https://api.ravelin.com/v2/checkout")]
		[InlineData(EventType.Chargeback, "https://api.ravelin.com/v2/chargeback")]
		public async void send_event(EventType eventType, string expectedRequestUri)
		{
			var response = await client.SendEvent(eventType, RavelinClientTestHelpers.RavelinEvents[eventType]);

			fakeHttpMessageHandler.Verify(x => x.Send(It.Is<HttpRequestMessage>(r => r.RequestUri.ToString() == expectedRequestUri)), Times.Once);

			response.Should().BeOfType<Response>();
			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		[Theory]
		[InlineData(EventType.Customer, "https://api.ravelin.com/v2/customer?score=true")]
		[InlineData(EventType.Order, "https://api.ravelin.com/v2/order?score=true")]
		[InlineData(EventType.PaymentMethod, "https://api.ravelin.com/v2/paymentmethod?score=true")]
		[InlineData(EventType.PreTransaction, "https://api.ravelin.com/v2/pretransaction?score=true")]
		[InlineData(EventType.Transaction, "https://api.ravelin.com/v2/transaction?score=true")]
		[InlineData(EventType.Login, "https://api.ravelin.com/v2/login?score=true")]
		[InlineData(EventType.Checkout, "https://api.ravelin.com/v2/checkout?score=true")]
		[InlineData(EventType.Chargeback, "https://api.ravelin.com/v2/chargeback?score=true")]
		public async void send_event_and_score(EventType eventType, string expectedRequestUri)
		{
			var response = await client.SendEventAndScore(eventType, RavelinClientTestHelpers.RavelinEvents[eventType]);

			fakeHttpMessageHandler.Verify(x => x.Send(It.Is<HttpRequestMessage>(r => r.RequestUri.ToString() == expectedRequestUri)), Times.Once);

			response.Should().BeOfType<ScoredResponse>();
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			response.Score.Should().NotBeNull();
			response.Score.CustomerId.Should().Be("61283761287361");
			response.Score.Action.Should().Be("ALLOW");
			response.Score.Source.Should().Be("RAVELIN");
			response.Score.ScoreId.Should().Be("0de0af95-7508-4a25-577b-040a2d209634");
		}

		[Theory]
		[InlineData(EventType.Customer, "https://api.ravelin.com/v2/backfill/customer")]
		[InlineData(EventType.Order, "https://api.ravelin.com/v2/backfill/order")]
		[InlineData(EventType.PaymentMethod, "https://api.ravelin.com/v2/backfill/paymentmethod")]
		[InlineData(EventType.PreTransaction, "https://api.ravelin.com/v2/backfill/pretransaction")]
		[InlineData(EventType.Transaction, "https://api.ravelin.com/v2/backfill/transaction")]
		[InlineData(EventType.Login, "https://api.ravelin.com/v2/backfill/login")]
		[InlineData(EventType.Checkout, "https://api.ravelin.com/v2/backfill/checkout")]
		[InlineData(EventType.Chargeback, "https://api.ravelin.com/v2/backfill/chargeback")]
		public async void send_backfill_event(EventType eventType, string expectedRequestUri)
		{
			var response = await client.SendBackfillEvent(eventType, RavelinClientTestHelpers.RavelinEvents[eventType]);

			fakeHttpMessageHandler.Verify(x => x.Send(It.Is<HttpRequestMessage>(r => r.RequestUri.ToString() == expectedRequestUri)), Times.Once);

			response.Should().BeOfType<BackfillResponse>();
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			response.Success.Should().BeTrue();
		}

		[Theory]
		[InlineData(EventType.PaymentMethod, "https://vault.ravelin.com/v2/paymentmethod")]
		[InlineData(EventType.Checkout, "https://vault.ravelin.com/v2/checkout")]
		public async void send_event_to_vault_when_pan_provided(EventType eventType, string expectedRequestUri)
		{
			var data = (IPaymentMethodEvent)RavelinClientTestHelpers.RavelinEvents[eventType];

			data.PaymentMethod.Pan = "5454545454545454";

			var response = await client.SendEvent(eventType, (IEvent)data);

			fakeHttpMessageHandler.Verify(x => x.Send(It.Is<HttpRequestMessage>(r => r.RequestUri.ToString() == expectedRequestUri)), Times.Once);

			response.Should().BeOfType<Response>();
			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		public void Dispose()
		{
			fakeHttpMessageHandler.ResetCalls();
		}
	}

	public class RavelinClientFixture
	{
		public RavelinClient RavelinClient;
		public readonly Mock<FakeHttpMessageHandler> FakeHttpMessageHandler;

		public RavelinClientFixture()
		{
			FakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };

			FakeHttpMessageHandler.Setup(handler => handler.Send(It.IsAny<HttpRequestMessage>()))
				.Returns<HttpRequestMessage>(request => new HttpResponseMessage {
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(RavelinClientTestHelpers.GetResponse(request.RequestUri.ToString()))
				});

			var httpClient = new HttpClient(FakeHttpMessageHandler.Object);

			RavelinClient = new RavelinClient(httpClient, "sk_live_XXXXXXXX");
		}
	}
}
