using Newtonsoft.Json;

namespace Ravelin.Models
{
	/// <summary>
	/// A device is a physical object that a customer uses to interact with your application. Examples include a mobile phone, tablet or laptop.
	/// </summary>
	public class Device
	{
		/// <summary>
		/// A unique identifier for the device (e.g. UDID)
		/// </summary>
		public string DeviceId { get; set; }

		/// <summary>
		/// The type of device (e.g. computer, phone, tablet)
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// The device manufacturer (e.g. apple, samsung)
		/// </summary>
		public string Manufacturer { get; set; }

		/// <summary>
		/// The model/identifier name of the device. e.g. iPhone8,1, iPad5,4 (for Apple devices), or bullhead, herolte (for Android devices)
		/// </summary>
		public string Model { get; set; }

		/// <summary>
		/// The operating system that the device is running (e.g. ios, android)
		/// </summary>
		[JsonProperty(PropertyName = "os")]
		public string OperatingSystem { get; set; }

		/// <summary>
		/// The IP address that this device is connecting from
		/// </summary>
		public string IpAddress { get; set; }

		/// <summary>
		/// The name of the web browser being used, if applicable (e.g. `Chrome 42`)
		/// </summary>
		public string Browser { get; set; }

		/// <summary>
		/// The full `User-Agent` header of the device
		/// </summary>
		public string UserAgent { get; set; }

		/// <summary>
		/// Whether Javascript is enabled on the web browser
		/// </summary>
		public bool JavascriptEnabled { get; set; }

		/// <summary>
		/// Whether cookies are enabled on the web browser
		/// </summary>
		public bool CookiesEnabled { get; set; }

		/// <summary>
		/// The resolution of the screen on the device in the format XxY (e.g. 800x600)
		/// </summary>
		public string ScreenResolution { get; set; }
	}
}
