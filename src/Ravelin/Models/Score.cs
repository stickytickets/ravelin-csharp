using System.ComponentModel;
using Ravelin.Models.Enums;

namespace Ravelin.Models
{
	public class Score
	{
		/// <summary>
		/// Identifier for this customer, as supplied by the client
		/// </summary>
		public string CustomerId { get; set; }

		/// <summary>
		/// Action to take for this customer, according to Ravelin. One of ALLOW, REVIEW, PREVENT.
		/// </summary>
		public ScoreAction Action { get; set; }

		/// <summary>
		/// Source of the score (e.g. RAVELIN or MANUAL_REVIEW)
		/// </summary>
		public string Source { get; set; }

		/// <summary>
		/// Unique identifier for this score or callback
		/// </summary>
		public string ScoreId { get; set; }

		/// <summary>
		/// In the case of manual review, this is the comment left by the reviewer on this particular review action
		/// </summary>
		public string Comment { get; set; }
	}
}