using Newtonsoft.Json;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class TradeOrder : TradeBaseOrder
	{
		#region Public properties



		[JsonProperty("date")]
		public string Date { get; set; }



		#endregion
	}
}
