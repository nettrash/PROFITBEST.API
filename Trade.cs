using PROFITBEST.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PROFITBEST.API
{
    public class Trade
    {
		#region Private properties



		private static NLog.Logger _logger => NLog.LogManager.GetCurrentClassLogger();

		private string _key { get; set; }



		#endregion
		#region Public constructors



		public Trade()
		{
			_key = Properties.Settings.Default.KEY;
		}

		public Trade(string sKey)
		{
			_key = sKey;
		}



		#endregion
		#region Private methods



		private async Task<string> _getAsync(string sUrl, bool bSecure, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			using (HttpClient http = new HttpClient())
			{
				HttpRequestMessage rq = new HttpRequestMessage(HttpMethod.Get, new Uri(sUrl));
				if (bSecure)
				{
					rq.Headers.Add("X-Api-Key", _key);
				}
				HttpResponseMessage response = await http.SendAsync(rq, cancellationToken);
				string s = await response.Content.ReadAsStringAsync();
				_logger.Trace(s);
				return s;
			}
		}

		private async Task<string> _postAsync(string sUrl, bool bSecure, string sData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			StringContent content = new StringContent(sData, Encoding.UTF8, "application/json");
			using (HttpClient http = new HttpClient())
			{
				HttpRequestMessage rq = new HttpRequestMessage(HttpMethod.Post, new Uri(sUrl));
				rq.Content = content;
				if (bSecure)
				{
					rq.Headers.Add("X-Api-Key", _key);
				}
				HttpResponseMessage response = await http.SendAsync(rq, cancellationToken);
				string s = await response.Content.ReadAsStringAsync();
				_logger.Trace(s);
				return s;
			}
		}

		private async Task<string> _deleteAsync(string sUrl, bool bSecure, string sData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			StringContent content = new StringContent(sData, Encoding.UTF8, "application/json");
			using (HttpClient http = new HttpClient())
			{
				HttpRequestMessage rq = new HttpRequestMessage(HttpMethod.Delete, new Uri(sUrl));
				rq.Content = content;
				if (bSecure)
				{
					rq.Headers.Add("X-Api-Key", _key);
				}
				HttpResponseMessage response = await http.SendAsync(rq, cancellationToken);
				return await response.Content.ReadAsStringAsync();
			}
		}



		#endregion
		#region Public methods



		public async Task<TradeVersion> GetVersionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeVersion>(await _getAsync(Properties.Settings.Default.URL, false, cancellationToken));
		}

		public async Task<TradeCurrency[]> GetCurrenciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeCurrency[]>(await _getAsync($"{Properties.Settings.Default.URL}/currencies", false, cancellationToken));
		}

		public async Task<TradeCurrency> GetCurrencyAsync(string sCurrency, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeCurrency>(await _getAsync($"{Properties.Settings.Default.URL}/currencies/{sCurrency}", false, cancellationToken));
		}

		public async Task<TradePair[]> GetPairsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradePair[]>(await _getAsync($"{Properties.Settings.Default.URL}/pairs", false, cancellationToken));
		}

		public async Task<TradePair> GetPairAsync(string sPair, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradePair>(await _getAsync($"{Properties.Settings.Default.URL}/pairs/{sPair}", false, cancellationToken));
		}

		public async Task<TradeOrder[]> GetOrdersAsync(string sPair, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			_logger.Trace($"{Properties.Settings.Default.URL}/orders/{sPair}");
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeOrder[]>(await _getAsync($"{Properties.Settings.Default.URL}/orders/{sPair}", false, cancellationToken));
		}

		public async Task<TradeOrder[]> GetTradesAsync(string sPair, TradePeriod? period = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeOrder[]>(await _getAsync($"{Properties.Settings.Default.URL}/trades/{sPair}{(period.HasValue ? $"?period={period}" : "")}", false, cancellationToken));
		}

		public async Task<Balance[]> GetBalancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<Balance[]>(await _getAsync($"{Properties.Settings.Default.URL}/my/balances", true, cancellationToken));
		}

		public async Task<BalanceChange[]> GetBalanceChangeAsync(string sCurrency, TradePeriod? period = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<BalanceChange[]>(await _getAsync($"{Properties.Settings.Default.URL}/my/balances/{sCurrency}/changes{(period.HasValue ? $"?period={period}" : "")}", true, cancellationToken));
		}

		public async Task<TradeOrder[]> GetMyTradesAsync(string sPair, TradePeriod? period = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeOrder[]>(await _getAsync($"{Properties.Settings.Default.URL}/my/trades/{sPair}{(period.HasValue ? $"?period={period}" : "")}", true, cancellationToken));
		}

		public async Task<TradeMyOrder[]> GetMyOrdersAsync(string sPair, TradeOrderStatus status, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeMyOrder[]>(await _getAsync($"{Properties.Settings.Default.URL}/my/orders/?{(string.IsNullOrEmpty(sPair) ? "" : $"pair={sPair}&")}status={status}", true, cancellationToken));
		}

		public async Task<TradeMyOrder> GetMyOrderAsync(ulong nId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeMyOrder>(await _getAsync($"{Properties.Settings.Default.URL}/my/orders/{nId}", true, cancellationToken));
		}

		public async Task<TradeMyOrder[]> SetOrdersAsync(TradeBaseOrder[] orders, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeMyOrder[]>(await _postAsync($"{Properties.Settings.Default.URL}/my/orders", true, Newtonsoft.Json.JsonConvert.SerializeObject(orders), cancellationToken));
		}

		public async Task<TradeOrderStatusInfo[]> DeleteOrdersAsync(ulong[] orderIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TradeOrderStatusInfo[]>(await _deleteAsync($"{Properties.Settings.Default.URL}/my/orders", true, Newtonsoft.Json.JsonConvert.SerializeObject(orderIds), cancellationToken));
		}



		#endregion
	}
}
