using System;
using Newtonsoft.Json;
using Ravelin.Models.Enums;

namespace Ravelin.Models
{
	public class PaymentMethod
	{
		/// <summary>
		/// A unique identifier for this payment method (required)
		/// </summary>
		public string PaymentMethodId { get; set; }

		/// <summary>
		/// The nickname for the payment method that the customers gives, if applicable
		/// </summary>
		public string NickName { get; set; }

		/// <summary>
		/// The type of payment method
		/// </summary>
		public PaymentMethodType MethodType { get; set; }

		/// <summary>
		/// The billing address for this card
		/// </summary>
		public Location BillingAddress { get; set; }

		/// <summary>
		/// If the card has been banned from use by your system (required)
		/// </summary>
		public bool Banned { get; set; }

		/// <summary>
		/// If the card is selected as "active for payment" (required)
		/// </summary>
		public bool Active { get; set; }

		/// <summary>
		/// When the payment method was added by the customer
		/// </summary>
		[JsonProperty(PropertyName = "RegistrationTime")]
		public DateTime? RegistrationTimeUtc { get; set; }

		/// <summary>
		/// Any data about this customer that does not fit in one of the above fields. Especially any data received from the PSP is welcome here.
		/// </summary>
		public object Custom { get; set; }


		// Credit (& Debit) Cards specific fields

		/// <summary>
		/// Unique identifier for this card, consistent across users (e.g. Stripe's fingerprint, or Braintree's unique_number_identifier)
		/// </summary>
		public string InstrumentId { get; set; }

		/// <summary>
		/// Name to which the card is registered (as printed on the card)
		/// </summary>
		public string NameOnCard { get; set; }

		/// <summary>
		/// The BIN (leading six digits) of the card. Not always available, but strongly recommended when it is.
		/// </summary>
		public string CardBin { get; set; }

		/// <summary>
		/// The last four digits of the card (required)
		/// </summary>
		public string CardLastFour { get; set; }

		/// <summary>
		/// The scheme of the card
		/// </summary>
		public CardType CardType { get; set; }

		/// <summary>
		/// The expiry month as MM (required)
		/// </summary>
		public int ExpiryMonth { get; set; }

		/// <summary>
		/// The expiry year as YYYY (required)
		/// </summary>
		public int ExpiryYear { get; set; }

		/// <summary>
		/// Whether the payment method was succesfully registered with the PSP (e.g. passed verification) (required)
		/// </summary>
		public bool SuccessfulRegistration { get; set; }

		/// <summary>
		/// Whether the payment method was a prepaid card
		/// </summary>
		public bool PrepaidCard { get; set; }

		/// <summary>
		/// The issuer of the payment method (e.g. barclaycard)
		/// </summary>
		public string Issuer { get; set; }

		/// <summary>
		/// The ISO 3166 country code (2- or 3-letter)
		/// </summary>
		public string CountryIssued { get; set; }

		/// <summary>
		/// The full, raw card number (only on the Vault!)
		/// </summary>
		public string Pan { get; set; }


		// PayPal specific fields

		/// <summary>
		/// PayPal account ID (required)
		/// </summary>
		[JsonProperty(PropertyName = "email")]
		public string PayPalEmail { get; set; }
	}
}
