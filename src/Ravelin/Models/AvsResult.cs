namespace Ravelin.Models
{
	public class AvsResult
	{
		/// <summary>
		/// The result code from a postal code verification (M, N, ...)
		/// </summary>
		public string PostalCode { get; set; }

		/// <summary>
		/// The result code from a street name verification (M, N, ...)
		/// </summary>
		public string Street { get; set; }
	}
}
