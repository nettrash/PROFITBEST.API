using Newtonsoft.Json;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class TradePair
	{
		#region Public properties



		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("lastPrice")]
		public string LastPrice { get; set; }

		[JsonProperty("delta")]
		public string Delta { get; set; }

		[JsonProperty("minPrice24h")]
		public string MinPrice { get; set; }

		[JsonProperty("maxPrice24h")]
		public string MaxPrice { get; set; }

		[JsonProperty("volume24h")]
		public string Volume { get; set; }



		#endregion
	}
}
