using Newtonsoft.Json;
using Ravelin.Models.Enums;
using Ravelin.Utils;

namespace Ravelin.Models
{
	/// <summary>
	/// Specifies the current status of the order
	/// </summary>
	public class OrderStatus
	{
		/// <summary>
		/// The most recent status of the order
		/// </summary>
		public OrderStage Stage { get; set; }

		/// <summary>
		/// Status reason provides context to the order status. Value retrieved from either FailedReason, CancelledReason, RefundedReason
		/// </summary>
		public string Reason {
			get
			{
				switch (Stage)
				{
					case OrderStage.Failed:
						return FailedReason.GetEnumMemberValue();
					case OrderStage.Cancelled:
						return CancelledReason.GetEnumMemberValue();
					case OrderStage.Refunded:
						return RefundedReason.GetEnumMemberValue();
					default:
						return null;
				}
			}
		}

		/// <summary>
		/// Reason for failed order status stage
		/// </summary>
		[JsonIgnore]
		public OrderFailedReason? FailedReason { get; set; }

		/// <summary>
		/// Reason for cancelled order status stage
		/// </summary>
		[JsonIgnore]
		public OrderCancelledReason? CancelledReason { get; set; }

		/// <summary>
		/// Reason for refunded order status stage
		/// </summary>
		[JsonIgnore]
		public OrderRefundedReason? RefundedReason { get; set; }

		/// <summary>
		/// Entity that caused the latest order status.
		/// Use this string to provide additional information to your Ravelin dashboard users (e.g. customerId123, order-cancelling-service, customerservice@company.com).
		/// </summary>
		public string Actor { get; set; }
	}
}
