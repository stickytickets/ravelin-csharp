using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ravelin.Models
{
	public class Order
	{
		/// <summary>
		/// A unique identifier for the order
		/// </summary>
		public string OrderId { get; set; }

		/// <summary>
		/// A contact email for this order
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// The price of the purchase in the lowest denomination of the currency (e.g. cents for US dollars, pence for GB pound)
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		/// The ISO 4217 currency code
		/// </summary>
		public string Currency { get; set; }

		/// <summary>
		/// The unique identifier of the seller/counterparty in the transaction, if not your business.
		/// E.g. an ID of a driver when a customer is ordering a car, or the ID of a restaurant when a customer is ordering food.
		/// </summary>
		public string SellerId { get; set; }

		/// <summary>
		/// The "start" location of the order
		/// </summary>
		public Location From { get; set; }

		/// <summary>
		/// The "end" location of the order
		/// </summary>
		public Location To { get; set; }

		/// <summary>
		/// The country for the order; ISO 3166 (2- or 3-letter)
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// The logical place in which this order occurs
		/// </summary>
		public string Market { get; set; }

		/// <summary>
		/// Used in conjunction with market and country to fully describe the market for this order
		/// </summary>
		public string MarketCity { get; set; }

		/// <summary>
		/// The time in UTC when the order was created
		/// </summary>
		[JsonProperty(PropertyName = "CreationTime")]
		public DateTime? CreationTimeUtc { get; set; }

		/// <summary>
		/// The time in UTC  of when the order was executed. Specifically, when this order was to be used or obtained by the customer.
		/// For example, with taxis, you may prebook - this is the time the prebook is for. With tickets, this may be the time of the event.
		/// </summary>
		[JsonProperty(PropertyName = "ExecutionTime")]
		public DateTime? ExecutionTimeUtc { get; set; }

		/// <summary>
		/// Items registered with this order. Set to the empty array to empty the cart, do not specify at all if no information is available.
		/// </summary>
		public IEnumerable<Item> Items { get; set; }

		/// <summary>
		/// The most recent status of the order
		/// </summary>
		public OrderStatus Status { get; set; }

		/// <summary>
		/// Any data about this customer that does not fit in one of the above fields
		/// </summary>
		public object Custom { get; set; }
	}
}
