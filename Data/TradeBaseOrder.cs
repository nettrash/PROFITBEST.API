using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class TradeBaseOrder
	{
		#region Public properties



		[JsonProperty("pair")]
		public string Pair { get; set; }

		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public TradeOrderType Type { get; set; }

		[JsonProperty("amount")]
		public string Amount { get; set; }

		[JsonProperty("price")]
		public string Price { get; set; }



		#endregion
	}
}
