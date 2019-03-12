using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ravelin;
using Ravelin.Models;
using Ravelin.Models.Enums;
using Ravelin.Models.Events;
using Ravelin.Models.Responses;

namespace ExampleCore
{
	internal class Example
	{
		public static void Main(string[] args)
		{
			Execute().Wait();
		}

		private static async Task Execute()
		{
			var client = new RavelinClient("sk_live_XXXXXXXX"); // change with a valid key

			var customerEvent = new CustomerEvent
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

			OutputResponse(await client.SendEvent(EventType.Customer, customerEvent));

			var loginEvent = new LoginEvent
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

			OutputResponse(await client.SendEvent(EventType.Login, loginEvent));

			var orderEvent = new OrderEvent
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
					Status = new OrderStatus(OrderStage.Pending)
					{
						Actor = "buyer"
					}
				},
				DeviceId = "2b6f0cc904d137be2e1730235f5664094b831186"
			};

			OutputResponse(await client.SendEvent(EventType.Order, orderEvent));

			//order event with tickets ticket items
			var eventDate = DateTime.UtcNow.AddDays(60);
			var orderTicketEvent = new OrderEvent
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
						Sku = "1111",
						Name = "World Concert Series -Seat A",
						Price = 100,
						Currency = "GBP",
						Quantity = 1,
						EventTicket = new EventTicket()
						{
							Event = new EventInformation()
							{
								Venue = new Venue()
								{
									Location = new Location()
									{
										Street1 = "Peninsula Square, London SE10 0DX",
										Region = "London",
										Country = "GBR",
									},
									Name = "The O2 Arena"
								},
								Description = "World Concert Series",
								Name = "World Concert Series",
								Category = EventCategory.Music,
								StartTimeUtc = eventDate,
								EndTimeUtc = eventDate.AddHours(2),
								EventId = "EVT1"
							},
							Guest = new Guest()
							{
								Name = "Mark Twain",
								FamilyName = "Twain",
								GivenName = "Mark",
								IsPurchaser = true
							},
							Ticket = new Ticket()
							{
								Refundable = true,
								TicketId = "TKT1",
								TicketType = "Seat A",
							}
						}
					},
					new Item
					{
						Sku = "2222",
						Name = "World Concert Series -Seat B",
						Price = 200,
						Currency = "GBP",
						Quantity = 1,
						EventTicket = new EventTicket()
						{
							Event = new EventInformation()
							{
								Venue = new Venue()
								{
									Location = new Location()
									{
										Street1 = "Peninsula Square, London SE10 0DX",
										Region = "London",
										Country = "GBR",
									},
									Name = "The O2 Arena"
								},
								Description = "World Concert Series",
								Name = "World Concert Series",
								Category = EventCategory.Music,
								StartTimeUtc = eventDate,
								EndTimeUtc = eventDate.AddHours(2),
								EventId = "EVT1"
							},
							Guest = new Guest()
							{
								Name = "Jane Twain",
								FamilyName = "Twain",
								GivenName = "Jane",
								IsPurchaser = false
							},
							Ticket = new Ticket()
							{
								Refundable = true,
								TicketId = "TKT2",
								TicketType = "Seat B",
							}
						}
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
					Status = new OrderStatus(OrderStage.Pending)
					{
						Actor = "buyer"
					}
				},
				DeviceId = "2b6f0cc904d137be2e1730235f5664094b831186"
			};

			OutputResponse(await client.SendEvent(EventType.Order, orderTicketEvent));

			// Send card payment method event
			var paymentMethodEvent = new PaymentMethodEvent
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

			OutputResponse(await client.SendEvent(EventType.PaymentMethod, paymentMethodEvent));

			var preTransactionEvent = new PreTransactionEvent
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

			OutputScoredResponse(await client.SendEventAndScore(EventType.PreTransaction, preTransactionEvent));

			var transactionEvent = new TransactionEvent
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

			OutputScoredResponse(await client.SendEventAndScore(EventType.Transaction, transactionEvent));

			// Update pending order to accepted order status stage
			orderEvent = new OrderEvent
			{
				CustomerId = "61283761287361",
				Order = new Order
				{
					OrderId = "n1QSYK0ceGNZqU28ien3",
					Price = 4675,
					ExecutionTimeUtc = DateTime.UtcNow,
					Status = new OrderStatus(OrderStage.Accepted)
					{
						Actor = "seller"
					}
				}
			};

			OutputResponse(await client.SendEvent(EventType.Order, orderEvent));

			// Check-out (All-in-One) with PAN (sent to vault)

			var checkoutEvent = new CheckoutEvent
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
					Banned = false,
					Pan = "5454545454545454"
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

			OutputScoredResponse(await client.SendEventAndScore(EventType.Checkout, checkoutEvent));

			// Chargeback

			var chargebackEvent = new ChargebackEvent(new Chargeback
			{
				ChargebackId = "dp_15RsQX2eZvKYlo2C0MFNUWJC",
				Gateway = "stripe",
				GatewayReference = "ch_15RsQR2eZvKYlo2CA8IfzCX0",
				Reason = "general",
				Status = ChargebackStatus.Lost,
				Amount = 195,
				Currency = "USD",
				DisputeTimeUtc = DateTime.UtcNow.AddHours(-2),
				NonFraud = true
			});

			OutputResponse(await client.SendEvent(EventType.Chargeback, chargebackEvent));

			// Backfill Events

			var backfillCustomerEvent = new CustomerEvent
			{
				Customer = new Customer
				{
					CustomerId = "35248561944321",
					RegistrationTimeUtc = DateTime.UtcNow.AddDays(-20),
					GivenName = "John",
					FamilyName = "Butler",
					Gender = "Male",
					Email = "john@butler.com",
					Username = "jbutler"
				},
				Timestamp = DateTime.UtcNow.AddDays(-20)
			};

			OutputBackfillResponse(await client.SendBackfillEvent(EventType.Customer, backfillCustomerEvent));

			var backfillCheckoutEvent = new CheckoutEvent
			{
				CustomerId = "35248561944321",
				Order = new Order
				{
					OrderId = "h1DSYD0ceNPSqU28isd3",
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
					PaymentMethodId = "533228",
					InstrumentId = "card_19nWlGDR2LFseSsSaUk9kIC3",
					RegistrationTimeUtc = DateTime.UtcNow.AddDays(-6),
					NickName = "MasterCard **** 3213",
					MethodType = PaymentMethodType.Card,
					CardBin = "742589",
					CardLastFour = "3213",
					CardType = CardType.Mastercard,
					ExpiryMonth = 7,
					ExpiryYear = 2019,
					SuccessfulRegistration = true,
					PrepaidCard = false,
					CountryIssued = "GBR",
					Active = true,
					Banned = false
				},
				Transaction = new Transaction
				{
					TransactionId = "k12f8594e06gj9fa046707c53155fb30",
					Email = "john@butler.com",
					Debit = 4675,
					Credit = 0,
					Currency = "GBP",
					Success = true,
					Gateway = "stripe",
					GatewayReference = "tr_67oaY72eYhOPlo2CE5ZDq5gKh",
					Type = TransactionType.AuthCapture
				},
				Timestamp = DateTime.UtcNow.AddDays(-6)
			};

			OutputBackfillResponse(await client.SendBackfillEvent(EventType.Checkout, backfillCheckoutEvent));

			//Customer Label
			var label = new CustomerLabel
			{
				CustomerId = "61283761287361",
				Comment = "Test comment",
				Label = Label.Genuine,
				Reviewer = new Reviewer { Name = "John Reviewer", Email = "reviewer@review.com" }
			};

			OutputResponse(await client.SetCustomerLabel(label));

			Console.WriteLine("\n\nPress <Enter> to continue.");
			Console.ReadLine();
		}

		private static void OutputResponse(Response response)
		{
			Console.WriteLine(response.StatusCode);
			Console.WriteLine(response.Body.ReadAsStringAsync().Result);
		}

		private static void OutputBackfillResponse(BackfillResponse response)
		{
			OutputResponse(response);
			Console.WriteLine("Success: " + response.Success);
		}

		private static void OutputScoredResponse(ScoredResponse response)
		{
			OutputResponse(response);
			Console.WriteLine("CustomerId: " + response.Score.CustomerId);
			Console.WriteLine("Action: " + response.Score.Action);
			Console.WriteLine("Source: " + response.Score.Source);
			Console.WriteLine("ScoreId: " + response.Score.ScoreId);
			Console.WriteLine("Comment: " + response.Score.Comment);
		}
	}
}
