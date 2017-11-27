using System.ComponentModel;
using Newtonsoft.Json;
using Ravelin.Models.Enums;

namespace Ravelin.Models
{
	/// <summary>
	/// Specifies the current status of the order
	/// </summary>
	public class OrderStatus
	{
		public OrderStatus(OrderStage stage, OrderStageReason? reason = null)
		{
			ValidateReason(stage, reason);
			Stage = stage;
			Reason = reason;
		}

		private void ValidateReason(OrderStage stage, OrderStageReason? reason)
		{
			switch (stage)
			{
				case OrderStage.Accepted:
				case OrderStage.Fulfilled:
				case OrderStage.Pending: 
					if(!reason.HasValue) break;
					else throw new InvalidEnumArgumentException("Invalid reason set for Failed order stage");

				case OrderStage.Failed:
					if(reason == OrderStageReason.FailedPaymentDeclined ||
						reason == OrderStageReason.FailedSystemError ||
						reason == OrderStageReason.FailedSellerRejected)
						break;
					else throw new InvalidEnumArgumentException("Invalid reason set for Failed order stage");

				case OrderStage.Cancelled:
					if(reason == OrderStageReason.CancelledBuyer ||
						reason == OrderStageReason.CancelledMerchant ||
						reason == OrderStageReason.CancelledRavelin ||
						reason == OrderStageReason.CancelledSeller)
						break;
					else throw new InvalidEnumArgumentException("Invalid reason set for Cancelled order stage");
				case OrderStage.Refunded:
					if(reason == OrderStageReason.RefundedReturned ||
						reason == OrderStageReason.RefundedComplaint)
					break;
					else throw new InvalidEnumArgumentException("Invalid reason set for Cancelled order stage");
			}
		}

		/// <summary>
		/// The most recent status of the order
		/// </summary>
		public OrderStage Stage { get; }

		/// <summary>
		/// Status reason provides context to the order status. Value retrieved from either FailedReason, CancelledReason, RefundedReason
		/// </summary>
		public OrderStageReason? Reason { get; }

		/// <summary>
		/// Entity that caused the latest order status.
		/// Use this string to provide additional information to your Ravelin dashboard users (e.g. customerId123, order-cancelling-service, customerservice@company.com).
		/// </summary>
		public string Actor { get; set; }
	}
}
