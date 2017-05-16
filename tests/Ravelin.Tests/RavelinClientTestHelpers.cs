using System;
using System.Collections.Generic;
using Ravelin.Models;
using Ravelin.Models.Enums;
using Ravelin.Models.Events;

namespace Ravelin.Tests
{
	public static class RavelinClientTestHelpers
	{
		public static CustomerEvent CustomerEvent = new CustomerEvent
		{
			Customer = new Customer
			{
				CustomerId = "61283761287361",
				RegistrationTimeUtc = DateTime.UtcNow.AddDays(-5),
				Name = "Mark Twain",
				GivenName = "Mark",
				FamilyName = "Twain",
				DateOfBirth = "1980-01-27",
				Gender = "Male",
				Email = "mark@twain.com",
				EmailVerifiedTimeUtc = DateTime.UtcNow.AddDays(-5),
				Username = "mtwain",
				Location = new Location
				{
					Street1 = "James St",
					City = "Darwen",
					Region = "Blackburn with Darwen",
					PostalCode = "BB3 1AS",
					Country = "GBR",
					Latitude = 53.697471,
					Longitude = -2.470891
				},
				Custom = new
				{
					Newsletter = false,
					InvitedBy = "7198737117"
				}
			}
		};

		public static OrderEvent OrderEvent = new OrderEvent
		{
			CustomerId = "61283761287361",
			Order = new Order
			{
				OrderId = "n1QSYK0ceGNZqU28ien3",
				Price = 4675,
				Currency = "GBP",
				Market = "europe",
				Country = "GBR",
				MarketCity = "london",
				Items = new List<Item>
					{
						new Item
						{
							Sku = "3726-8",
							Name = "Women's Arch Sweater M 55",
							Price = 1990,
							Currency = "GBP",
							Quantity = 2
						},
						new Item
						{
							Sku = "3731-4",
							Name = "Women's Yellow Tee M 54",
							Price = 695,
							Currency = "GBP",
							Quantity = 1
						}
					},
				From = new Location
				{
					Street1 = "19 Gosport Walk",
					PostalCode = "N17 9QD",
					Region = "London",
					Country = "GBR"
				},
				To = new Location
				{
					Street1 = "73 Braganza St",
					PostalCode = "SE17 3RD",
					Region = "London",
					Country = "GBR"
				},
				CreationTimeUtc = DateTime.UtcNow,
				ExecutionTimeUtc = DateTime.UtcNow,
				Status = new OrderStatus
				{
					Stage = OrderStage.Pending,
					Actor = "buyer"
				}
			},
			DeviceId = "2b6f0cc904d137be2e1730235f5664094b831186"
		};

		public static PaymentMethodEvent PaymentMethodEvent = new PaymentMethodEvent
		{
			CustomerId = "61283761287361",
			PaymentMethod = new PaymentMethod
			{
				PaymentMethodId = "783917",
				InstrumentId = "card_16nWlGHD2LFseSsHaUp9kIW2",
				RegistrationTimeUtc = DateTime.UtcNow,
				NickName = "MasterCard **** 4242",
				MethodType = PaymentMethodType.Card,
				CardBin = "123456",
				CardLastFour = "4242",
				CardType = CardType.Mastercard,
				ExpiryMonth = 6,
				ExpiryYear = 2019,
				SuccessfulRegistration = true,
				CountryIssued = "GBR",
				Active = true,
				BillingAddress = new Location
				{
					Street1 = "73 Braganza St",
					PostalCode = "SE17 3RD",
					Region = "London",
					Country = "GBR"
				},
				Banned = false
			}
		};

		public static PreTransactionEvent PreTransactionEvent = new PreTransactionEvent
		{
			CustomerId = "61283761287361",
			PaymentMethodId = "783917",
			OrderId = "n1QSYK0ceGNZqU28ien3",
			Transaction = new PreTransaction
			{
				TransactionId = "f61f8594e06459fa046707c36159bb36",
				Email = "mark@twain.com",
				Debit = 4675,
				Credit = 0,
				Currency = "GBP",
				Type = TransactionType.AuthCapture,
				Gateway = "stripe",
				SecureProtocol = new SecureProtocol
				{
					Attempted = true,
					StartTimeUtc = DateTime.UtcNow
				}
			}
		};

		public static TransactionEvent TransactionEvent = new TransactionEvent
		{
			CustomerId = "61283761287361",
			PaymentMethodId = "783917",
			OrderId = "n1QSYK0ceGNZqU28ien3",
			Transaction = new Transaction
			{
				TransactionId = "f61f8594e06459fa046707c36159bb36",
				Email = "mark@twain.com",
				Debit = 4675,
				Credit = 0,
				Currency = "GBP",
				Success = true,
				AuthCode = "1000",
				Gateway = "stripe",
				GatewayReference = "tr_16oaY72eZvKYlo2CE5ZDq9Vh",
				AvsResultCode = new AvsResult
				{
					Street = "A",
					PostalCode = "M"
				},
				CvvResultCode = "M",
				Type = TransactionType.AuthCapture,
				SecureProtocol = new SecureProtocol
				{
					Attempted = true,
					Success = true,
					StartTimeUtc = DateTime.UtcNow,
					EndTimeUtc = DateTime.UtcNow
				}
			}
		};

		public static LoginEvent LoginEvent = new LoginEvent
		{
			CustomerId = "61283761287361",
			Device = new Device
			{
				DeviceId = "2b6f0cc904d137be2e1730235f5664094b831186",
				Type = "phone",
				Manufacturer = "apple",
				Model = "iPhone8,1",
				OperatingSystem = "iOS 8",
				IpAddress = "22.231.113.64"
			}
		};

		public static CheckoutEvent CheckoutEvent = new CheckoutEvent
		{
			Customer = new Customer
			{
				CustomerId = "71983561248363",
				RegistrationTimeUtc = DateTime.UtcNow.AddDays(-2),
				GivenName = "Arya",
				FamilyName = "Wayne",
				Gender = "Female",
				Email = "arya@wayne.com",
				Username = "awayne",
				Location = new Location
				{
					Street1 = "Baker St",
					City = "London",
					Region = "London",
					PostalCode = "NW1 6XE",
					Country = "GBR",
					Latitude = 51.523774,
					Longitude = -0.158537
				}
			},
			Order = new Order
			{
				OrderId = "g1QSYD0ceGNZqU28iev3",
				Price = 4675,
				Currency = "GBP",
				Items = new List<Item>
					{
						new Item
						{
							Sku = "3726-8",
							Name = "Women's Arch Sweater M 55",
							Price = 1990,
							Currency = "GBP",
							Quantity = 2
						},
						new Item
						{
							Sku = "3731-4",
							Name = "Women's Yellow Tee M 54",
							Price = 695,
							Currency = "GBP",
							Quantity = 1
						}
					}
			},
			PaymentMethod = new PaymentMethod
			{
				PaymentMethodId = "453237",
				InstrumentId = "card_19nWlGHD2LFseSsHaUp9kIW3",
				RegistrationTimeUtc = DateTime.UtcNow,
				NickName = "MasterCard **** 2424",
				MethodType = PaymentMethodType.Card,
				CardBin = "654321",
				CardLastFour = "2424",
				CardType = CardType.Mastercard,
				ExpiryMonth = 8,
				ExpiryYear = 2020,
				SuccessfulRegistration = true,
				PrepaidCard = false,
				CountryIssued = "GBR",
				Active = true,
				Banned = false
			},
			Transaction = new Transaction
			{
				TransactionId = "d12f8594e06459fa046707c53159bb30",
				Email = "arya@wayne.com",
				Debit = 4675,
				Credit = 0,
				Currency = "GBP",
				Success = true,
				Gateway = "stripe",
				GatewayReference = "tr_67oaY72eZvKYlo2CE5ZDq9Vh",
				Type = TransactionType.AuthCapture
			}
		};

		public static ChargebackEvent ChargebackEvent = new ChargebackEvent(new Chargeback
		{
			ChargebackId = "dp_15RsQX2eZvKYlo2C0MFNUWJC",
			Gateway = "stripe",
			GatewayReference = "ch_15RsQR2eZvKYlo2CA8IfzCX0",
			Reason = "general",
			ChargebackStatus = ChargebackStatus.Lost,
			Amount = 195,
			Currency = "USD",
			DisputeTimeUtc = DateTime.UtcNow.AddHours(-2)
		});

		public static Dictionary<EventType, IEvent> RavelinEvents = new Dictionary<EventType, IEvent>
		{
			{ EventType.Customer, CustomerEvent },
			{ EventType.Order, OrderEvent },
			{ EventType.PaymentMethod, PaymentMethodEvent },
			{ EventType.PreTransaction, PreTransactionEvent },
			{ EventType.Transaction, TransactionEvent },
			{ EventType.Login, LoginEvent },
			{ EventType.Checkout, CheckoutEvent },
			{ EventType.Chargeback, ChargebackEvent }
		};

		public static Dictionary<string, string> RavelinResponses = new Dictionary<string, string>
		{
			{ "response", "{\"status\":200,\"timestamp\":1494561572}" },
			{ "scoredResponse", "{\"status\":200,\"timestamp\":1494561573,\"data\":{\"customerId\":\"61283761287361\",\"action\":\"ALLOW\",\"score\":0,\"source\":\"RAVELIN\",\"scoreId\":\"0de0af95-7508-4a25-577b-040a2d209634\"}}" },
			{ "backfillResponse", "{\"status\":200,\"success\":\"true\"}" }
		};

		public static string GetResponse(string requestUri)
		{
			var responseKey = "response";

			if (requestUri.Contains("score=true"))
				responseKey = "scoredResponse";

			if (requestUri.Contains("backfill"))
				responseKey = "backfillResponse";

			return RavelinResponses[responseKey];
		}
	}
}
