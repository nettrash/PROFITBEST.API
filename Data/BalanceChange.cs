using Newtonsoft.Json;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class BalanceChange
	{
		#region Public properties



		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("trade")]
		public string Trade { get; set; }

		[JsonProperty("change")]
		public string Change { get; set; }

		[JsonProperty("balance")]
		public string Balance { get; set; }

		[JsonProperty("date")]
		public string Date { get; set; }



		#endregion
	}
}
