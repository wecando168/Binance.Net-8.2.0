using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.CommonClients;
using System;

namespace Binance.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Binance Spot API endpoints
    /// </summary>
    public interface IBinanceClientSpotApi : IDisposable
    {
        /// <summary>
        /// The factory for creating requests. Used for unit testing
        /// </summary>
        IRequestFactory RequestFactory { get; set; }

        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// 与帐户设置、信息或操作相关的端点
        /// </summary>
        public IBinanceClientSpotApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// 与检索市场和系统数据相关的端点
        /// </summary>
        public IBinanceClientSpotApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// 与订单和交易相关的端点
        /// </summary>
        public IBinanceClientSpotApiTrading Trading { get; }

        /// <summary>
        /// Get the ISpotClient for this client. This is a common interface which allows for some basic operations without knowing any details of the exchange.
        /// 获取此客户端的 ISpotClient。 这是一个通用接口，允许在不知道任何交换细节的情况下进行一些基本操作。
        /// </summary>
        /// <returns></returns>
        public ISpotClient CommonSpotClient { get; }
    }
}
