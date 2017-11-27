using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Ravelin.Models;
using Ravelin.Models.Enums;
using Ravelin.Serialization;
using Xunit;
namespace Ravelin.Tests
{
    public class RavelinModelTest
    {
	    private JsonSerializerSettings serializerSettings = new JsonSerializerSettings
	    {
		    Formatting = Formatting.Indented,
		    NullValueHandling = NullValueHandling.Ignore,
		    ContractResolver = new CamelCasePropertyNamesContractResolver(),
		    Converters = new List<JsonConverter> { new StringEnumConverter(true), new UnixDateTimeConverter() }
	    };

		[Theory]
		[InlineData("APAC","apac")]
	    [InlineData("Apac", "apac")]
	    [InlineData("apac", "apac")]
		public void should_set_market_to_lower(string market,string expected)
	    {
		    var order = new Order(){ Market = market};
		    order.Market.Should().Be(expected);
	    }

	    [Theory]
	    [InlineData("LONDON", "london")]
	    [InlineData("London", "london")]
	    [InlineData("london", "london")]
	    public void should_set_marketCity_to_lower(string marketCity, string expected)
	    {
		    var order = new Order() { MarketCity = marketCity };
		    order.MarketCity.Should().Be(expected);
	    }

	    [Theory]
	    [InlineData(OrderStage.Accepted, null, null)]
	    [InlineData(OrderStage.Fulfilled, null, null)]
	    [InlineData(OrderStage.Pending, null, null)]
		[InlineData(OrderStage.Cancelled, OrderStageReason.CancelledBuyer, "buyer")]
	    [InlineData(OrderStage.Cancelled, OrderStageReason.CancelledMerchant, "merchant")]
	    [InlineData(OrderStage.Cancelled, OrderStageReason.CancelledRavelin, "ravelin")]
	    [InlineData(OrderStage.Cancelled, OrderStageReason.CancelledSeller, "seller")]
	    [InlineData(OrderStage.Failed, OrderStageReason.FailedPaymentDeclined, "payment_declined")]
	    [InlineData(OrderStage.Failed, OrderStageReason.FailedSellerRejected, "seller_rejected")]
	    [InlineData(OrderStage.Failed, OrderStageReason.FailedSystemError, "system_error")]
	    [InlineData(OrderStage.Refunded, OrderStageReason.RefundedReturned, "returned")]
	    [InlineData(OrderStage.Refunded, OrderStageReason.RefundedComplaint, "complaint")]
		public void should_serialize_deserialize_order_status(OrderStage stage, OrderStageReason? reason, string expectedReason)
		{
			var orderStatus = new OrderStatus(stage, reason){ Actor = "buyer" };
			var ser = JsonConvert.SerializeObject(orderStatus,serializerSettings);
			var des = JsonConvert.DeserializeObject<OrderStatus>(ser,serializerSettings);

			if (reason.HasValue) {
				ser.Contains($"\"reason\": \"{expectedReason}\"").Should().BeTrue();
				des.Reason.Should().Be(reason);
			}

			des.Should().NotBeNull();
			des.Actor.Should().Be("buyer");
		}
	}
}
