namespace Ravelin.Models.Events
{
	public class LoginEvent : Event
	{
		/// <summary>
		/// Customer logging in
		/// </summary>
		public string CustomerId { get; set; }

		/// <summary>
		/// A session ID that was previously sent with anonymous events belonging to this user (optional)
		/// </summary>
		public string TempCustomerId { get; set; }
	}
}
