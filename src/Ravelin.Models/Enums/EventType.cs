using Ravelin.Models.Attributes;

namespace Ravelin.Models.Enums
{
	public enum EventType
	{
		[Endpoint("customer")]
		Customer,

		[Endpoint("order")]
		Order,

		[Endpoint("paymentmethod")]
		PaymentMethod,

		[Endpoint("pretransaction")]
		PreTransaction,

		[Endpoint("transaction")]
		Transaction,

		[Endpoint("login")]
		Login,

		[Endpoint("checkout")]
		Checkout,

		[Endpoint("chargeback")]
		Chargeback
	}
}
