using System;

namespace Ravelin.Models.Attributes
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