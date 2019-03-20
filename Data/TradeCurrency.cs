using Newtonsoft.Json;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class TradeCurrency
	{
		#region Public properties



		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("commission")]
		public TradeCommission Commission { get; set; }

		[JsonProperty("pairs")]
		public string[] Pairs { get; set;  }



		#endregion
	}
}
