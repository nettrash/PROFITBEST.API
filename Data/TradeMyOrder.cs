using Newtonsoft.Json;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class TradeMyOrder : TradeOrder
	{
		#region Public properties



		[JsonProperty("id")]
		public ulong Id { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("limitType")]
		public string Limit { get; set; }

		[JsonProperty("stopPrice")]
		public string StopPrice { get; set; }



		#endregion
	}
}
