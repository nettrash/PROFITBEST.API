using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROFITBEST.API.Data
{
	[JsonObject]
	public class TradeVersion
	{
		#region Public properties



		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("version")]
		public uint Version { get; set; }



		#endregion
	}
}
