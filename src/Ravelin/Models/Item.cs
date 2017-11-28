namespace Ravelin.Models
{
	public class Item
	{
		/// <summary>
		/// A merchant specific identifier for an item or a service
		/// </summary>
		public string Sku { get; set; }

		/// <summary>
		/// The name of the product that is being purchased
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The price of the purchase in the lowest denomination of the currency (e.g. cents for US dollars, pence for GB pound)
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		/// The ISO 4217 currency code
		/// </summary>
		public string Currency { get; set; }

		/// <summary>
		/// The name of the brand that the item is from
		/// </summary>
		public string Brand { get; set; }

		/// <summary>
		/// The name of the Universal Item Code
		/// </summary>
		public string Upc { get; set; }

		/// <summary>
		/// The highest level category that this item is sold in
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// The number of times this item is represented in the basket, 0 to remove
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// If the item being purchased is a ticket for an event, associate the ticket and event information here..
		/// </summary>
		public EventTicket EventTicket { get; set; }

		/// <summary>
		/// Any data about this customer that does not fit in one of the above fields
		/// </summary>
		public object Custom { get; set; }
	}
}
