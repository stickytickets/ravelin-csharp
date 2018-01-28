using Ravelin.Models.Enums;

namespace Ravelin.Models
{
	public class CustomerLabel
	{
		/// <summary>
		/// The unique identifier of this customer in your system.
		/// </summary>
		public string CustomerId { get; set; }

		/// <summary>
		/// The label for this customer. Must be one of: UNREVIEWED, GENUINE, FRAUDSTER
		/// </summary>
		public Label Label { get; set; }

		/// <summary>
		/// The reason for this label.
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// The individual creating this label
		/// </summary>
		public Reviewer Reviewer { get; set; }
	}

	public class Reviewer
	{
		/// <summary>
		/// The name of the person doing the review
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The email of the person doing the review
		/// </summary>
		public string Email { get; set; }
	}
}
