using System.Threading.Tasks;
using Ravelin.Models;
using Ravelin.Models.Enums;
using Ravelin.Models.Events;
using Ravelin.Models.Responses;

namespace Ravelin
{
	public interface IRavelinClient
	{
		string Version { get; set; }
		string MediaType { get; set; }
		Task<BackfillResponse> SendBackfillEvent(EventType eventType, IEvent data);
		Task<Response> SendEvent(EventType eventType, IEvent data);
		Task<ScoredResponse> SendEventAndScore(EventType eventType, IEvent data);
		Task<Response> SetCustomerLabel(CustomerLabel customerLabel);
	}
}