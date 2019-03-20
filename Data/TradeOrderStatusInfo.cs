using Newtonsoft.Json;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class TradeOrderStatusInfo
	{
		#region Public properties



		[JsonProperty("id")]
		public ulong Id { get; set; }

		[JsonProperty("status")]
		public TradeOrderStatus Status { get; set; }



		#endregion
	}
}
