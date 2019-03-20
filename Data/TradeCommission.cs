using Newtonsoft.Json;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class TradeCommission
	{
		#region Public properties



		[JsonProperty("amount")]
		public string Amount { get; set; }

		[JsonProperty("included")]
		public bool Included { get; set; }



		#endregion
	}
}
