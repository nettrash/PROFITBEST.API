using Newtonsoft.Json;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class Balance
	{
		#region Public properties



		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("balance")]
		public string Value { get; set; }

		[JsonProperty("held")]
		public string Held { get; set; }



		#endregion
	}
}
