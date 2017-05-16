using System;

namespace Ravelin.Utils
{
	public class EndpointAttribute : Attribute
	{
		public string Endpoint { get; set; }

		public EndpointAttribute(string endpoint)
		{
			Endpoint = endpoint;
		}
	}
}
