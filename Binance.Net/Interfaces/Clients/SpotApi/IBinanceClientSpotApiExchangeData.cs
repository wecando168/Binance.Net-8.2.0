using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Enums;
using Binance.Net.Objects.Models.Spot;
using Binance.Net.Objects.Models.Spot.Blvt;
using Binance.Net.Objects.Models.Spot.BSwap;
using Binance.Net.Objects.Models.Spot.IsolatedMargin;
using Binance.Net.Objects.Models.Spot.Margin;
using Binance.Net.Objects.Models.Spot.Staking;
using CryptoExchange.Net.Objects;

namespace Binance.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Binance Spot exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBinanceClientSpotApiExchangeData
    {
        /// <summary>
        /// Gets the withdraw/deposit details for an asset
        /// 上架资产详情 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#asset-detail-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-12" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Asset detail</returns>
        Task<WebCallResult<Dictionary<string, BinanceAssetDetails>>> GetAssetDetailsAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get general data for the products available on Binance
        /// NOTE: This is not an official endpoint and might be changed or removed at any point by Binance
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceProduct>>> GetProductsAsync(CancellationToken ct = default);

        /// <summary>
        /// Pings the Binance API
        /// 测试服务器连通性
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#test-connectivity" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#16073bbcf1" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>True if successful ping, false if no response</returns>
        Task<WebCallResult<long>> PingAsync(CancellationToken ct = default);

        /// <summary>
        /// Requests the server for the local time
        /// 获取服务器时间
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#check-server-time" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#3f1907847c" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Server time</returns>
        Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get's information about the exchange including rate limits and symbol list
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#exchange-information" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Exchange info</returns>
        Task<WebCallResult<BinanceExchangeInfo>> GetExchangeInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Get's information about the exchange including rate limits and information on the provided symbol
        /// 交易规范信息(指定单一交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#exchange-information" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#e7746f7d60" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to get data for token</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Exchange info</returns>
        Task<WebCallResult<BinanceExchangeInfo>> GetExchangeInfoAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get's information about the exchange including rate limits and information on the provided symbols
        /// 交易规范信息(指定多个交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#exchange-information" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#e7746f7d60" /></para>
        /// </summary>
        /// <param name="symbols">Symbols to get data for token</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Exchange info</returns>
        Task<WebCallResult<BinanceExchangeInfo>> GetExchangeInfoAsync(IEnumerable<string> symbols, CancellationToken ct = default);

        /// <summary>
        /// Get's information about the exchange including rate limits and information on the provided symbol based on an account permission
        /// 交易规范信息(所有交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#exchange-information" /></para>
        /// </summary>
        /// <param name="permission">account type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Exchange info</returns>
        Task<WebCallResult<BinanceExchangeInfo>> GetExchangeInfoAsync(AccountType permission, CancellationToken ct = default);

        /// <summary>
        /// Get's information about the exchange including rate limits and information on the provided symbols based on account permissions
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#exchange-information" /></para>
        /// </summary>
        /// <param name="permissions">account type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Exchange info</returns>
        Task<WebCallResult<BinanceExchangeInfo>> GetExchangeInfoAsync(AccountType[] permissions, CancellationToken ct = default);

        /// <summary>
        /// Gets the status of the Binance platform
        /// 系统状态(System)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#system-status-system" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#system" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The system status</returns>
        Task<WebCallResult<BinanceSystemStatus>> GetSystemStatusAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets the recent trades for a symbol
        /// 近期成交列表
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#recent-trades-list" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#2c5e424c25" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get recent trades for</param>
        /// <param name="limit">Result limit</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of recent trades</returns>
        Task<WebCallResult<IEnumerable<IBinanceRecentTrade>>> GetRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the historical  trades for a symbol
        /// 查询历史成交 (MARKET_DATA)(指定单一交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#old-trade-lookup-market_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#market_data" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get recent trades for</param>
        /// <param name="limit">Result limit</param>
        /// <param name="fromId">From which trade id on results should be retrieved</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of recent trades</returns>
        Task<WebCallResult<IEnumerable<IBinanceRecentTrade>>> GetTradeHistoryAsync(string symbol, int? limit = null, long? fromId = null, CancellationToken ct = default);

        /// <summary>
        /// Gets compressed, aggregate trades. Trades that fill at the time, from the same order, with the same price will have the quantity aggregated.
        /// 近期成交(归集) 归集交易与逐笔交易的区别在于，同一价格、同一方向、同一时间的trade会被聚合为一条
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#compressed-aggregate-trades-list" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#c59e471e81" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get the trades for</param>
        /// <param name="fromId">ID to get aggregate trades from INCLUSIVE.</param>
        /// <param name="startTime">Time to start getting trades from</param>
        /// <param name="endTime">Time to stop getting trades from</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The aggregated trades list for the symbol</returns>
        Task<WebCallResult<IEnumerable<BinanceAggregatedTrade>>> GetAggregatedTradeHistoryAsync(string symbol, long? fromId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get candlestick data for the provided symbol 每根K线代表一个交易对。每根K线的开盘时间可视为唯一ID
        /// K线数据
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#kline-candlestick-data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#k" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get the data for</param>
        /// <param name="interval">The candlestick timespan</param>
        /// <param name="startTime">Start time to get candlestick data</param>
        /// <param name="endTime">End time to get candlestick data</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The candlestick data for the provided symbol</returns>
        Task<WebCallResult<IEnumerable<IBinanceKline>>> GetKlinesAsync(string symbol, KlineInterval interval,
            DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get candlestick data for the provided symbol. Returns modified kline data, optimized for the presentation of candlestick charts
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#uiklines" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get the data for</param>
        /// <param name="interval">The candlestick timespan</param>
        /// <param name="startTime">Start time to get candlestick data</param>
        /// <param name="endTime">End time to get candlestick data</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The candlestick data for the provided symbol</returns>
        Task<WebCallResult<IEnumerable<IBinanceKline>>> GetUiKlinesAsync(string symbol, KlineInterval interval,
            DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the order book for the provided symbol
        /// 深度信息
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#order-book" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#38a975b802" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get the order book for</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The order book for the symbol</returns>
        Task<WebCallResult<BinanceOrderBook>> GetOrderBookAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Gets current average price for a symbol
        /// 当前平均价格
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#current-average-price" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#3b4f48cdbb" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get the data for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceAveragePrice>> GetCurrentAvgPriceAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Gets the trade fee for a symbol
        /// 交易手续费率查询 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#trade-fee-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-13" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to get withdrawal fee for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Trade fees</returns>
        Task<WebCallResult<IEnumerable<BinanceTradeFee>>> GetTradeFeeAsync(string? symbol = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get data regarding the last 24 hours for the provided symbol
        /// 24hr 价格变动情况(指定单一交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#24hr-ticker-price-change-statistics" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#24hr" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get the data for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Data over the last 24 hours</returns>
        Task<WebCallResult<IBinanceTick>> GetTickerAsync(string symbol,
            CancellationToken ct = default);

        /// <summary>
        /// Get data regarding the last 24 hours for the provided symbols
        /// 24hr 价格变动情况(指定多个交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#24hr-ticker-price-change-statistics" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#24hr" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to get the data for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Data over the last 24 hours</returns>
        Task<WebCallResult<IEnumerable<IBinanceTick>>> GetTickersAsync(IEnumerable<string> symbols,
            CancellationToken ct = default);

        /// <summary>
        /// Get data regarding the last 24 hours for all symbols
        /// 24hr 价格变动情况(所有交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#24hr-ticker-price-change-statistics" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#24hr" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of data over the last 24 hours</returns>
        Task<WebCallResult<IEnumerable<IBinanceTick>>> GetTickersAsync(CancellationToken ct = default);

        /// <summary>
        /// Get data based on the last x time, specified as windowSize
        /// 滚动窗口价格变动统计(指定单一交易代码）
        /// 此接口统计的时间范围比请求的windowSize多不超过59999ms.
        /// 接口的 openTime 是某一分钟的起始，而结束是当前的时间. 所以实际的统计区间会比请求的时间窗口多不超过59999ms.
        /// 比如, 结束时间 closeTime 是 1641287867099 (January 04, 2022 09:17:47:099 UTC) , windowSize 为 1d. 那么开始时间 openTime 则为 1641201420000 (January 3, 2022, 09:17:00 UTC)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#rolling-window-price-change-statistics" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#4175e32579" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get data for</param>
        /// <param name="windowSize">The window size to use</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IBinance24HPrice>> GetRollingWindowTickerAsync(string symbol, TimeSpan? windowSize = null, CancellationToken ct = default);

        /// <summary>
        /// Get data based on the last x time, specified as windowSize
        /// 滚动窗口价格变动统计(指定多个交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#rolling-window-price-change-statistics" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#4175e32579" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to get data for</param>
        /// <param name="windowSize">The window size to use</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<IBinance24HPrice>>> GetRollingWindowTickersAsync(IEnumerable<string> symbols, TimeSpan? windowSize = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the best price/quantity on the order book for a symbol.
        /// 当前最优挂单(指定单一交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#rolling-window-price-change-statistics" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#5393cd07b4" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to get book price for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of book prices</returns>
        Task<WebCallResult<BinanceBookPrice>> GetBookPriceAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Gets the best price/quantity on the order book for a symbol.
        /// 当前最优挂单(指定多个交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#symbol-order-book-ticker" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#5393cd07b4" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to get book price for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of book prices</returns>
        Task<WebCallResult<IEnumerable<BinanceBookPrice>>> GetBookPricesAsync(IEnumerable<string> symbol, CancellationToken ct = default);

        /// <summary>
        /// Gets the best price/quantity on the order book for all symbols.
        /// 当前最优挂单(所有交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#symbol-order-book-ticker" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#5393cd07b4" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of book prices</returns>
        Task<WebCallResult<IEnumerable<BinanceBookPrice>>> GetBookPricesAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets the price of a symbol
        /// 最新价格(指定单一交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#symbol-price-ticker" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#8ff46b58de" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get the price for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Price of symbol</returns>
        Task<WebCallResult<BinancePrice>> GetPriceAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        ///  Gets the prices of symbols
        ///  最新价格(指定多个交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#symbol-price-ticker" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#8ff46b58de" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to get the price for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of prices</returns>
        Task<WebCallResult<IEnumerable<BinancePrice>>> GetPricesAsync(IEnumerable<string> symbols, CancellationToken ct = default);

        /// <summary>
        /// Get a list of the prices of all symbols
        /// 最新价格(所有交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#symbol-price-ticker" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#8ff46b58de" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of prices</returns>
        Task<WebCallResult<IEnumerable<BinancePrice>>> GetPricesAsync(CancellationToken ct = default);

        /// <summary>
        /// Get a margin asset
        /// 查询杠杆资产 (MARKET_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-margin-asset-market_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#market_data-2" /></para>
        /// </summary>
        /// <param name="asset">The symbol to get</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of margin assets</returns>
        Task<WebCallResult<BinanceMarginAsset>> GetMarginAssetAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get a margin pair
        /// 查询全仓杠杆交易对 (MARKET_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-cross-margin-pair-market_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#market_data-3" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of margin assets</returns>
        Task<WebCallResult<BinanceMarginPair>> GetMarginSymbolAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get all assets available for margin trading
        /// 获取所有杠杆资产信息 (MARKET_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-all-margin-assets-market_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#market_data-4" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of margin assets</returns>
        Task<WebCallResult<IEnumerable<BinanceMarginAsset>>> GetMarginAssetsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get all asset pairs available for margin trading
        /// 获取所有全仓杠杆交易对(MARKET_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-all-cross-margin-pairs-market_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#market_data-5" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of margin pairs</returns>
        Task<WebCallResult<IEnumerable<BinanceMarginPair>>> GetMarginSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// Get margin price index
        /// 查询杠杆价格指数 (MARKET_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-margin-priceindex-market_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#market_data-6" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to get</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Margin price index</returns>
        Task<WebCallResult<BinanceMarginPriceIndex>> GetMarginPriceIndexAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Isolated margin symbol info
        /// 查询逐仓杠杆交易对 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-isolated-margin-symbol-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-38" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceIsolatedMarginSymbol>> GetIsolatedMarginSymbolAsync(string symbol,
            int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Isolated margin symbol info
        /// 获取所有逐仓杠杆交易对(USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-all-isolated-margin-symbol-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-39" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceIsolatedMarginSymbol>>> GetIsolatedMarginSymbolsAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get blvt info
        /// 杠杆代币信息 (MARKET_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-blvt-info-market_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#68899edc7a" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceBlvtInfo>>> GetLeveragedTokenInfoAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get's historical klines
        /// 币安合约K线
        /// <para><a href="https://binance-docs.github.io/apidocs/futures/en/#historical-blvt-nav-kline-candlestick" /></para>
        /// </summary>
        /// <param name="symbol">The token</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by startTime</param>
        /// <param name="endTime">Filter by endTime</param>
        /// <param name="limit">Number of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceBlvtKline>>> GetLeveragedTokensHistoricalKlinesAsync(string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get all swap pools
        /// 获取所有流动资金池 (MARKET_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#list-all-swap-pools-market_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#market_data-11" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceBSwapPool>>> GetLiquidityPoolsAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get pool config
        /// 获取币对池的配置信息 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-pool-configure-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-102" /></para>
        /// </summary>
        /// <param name="poolId">Id of the pool</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceBSwapPoolConfig>>> GetLiquidityPoolConfigurationAsync(int poolId, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get avaialble staking products list
        /// 查询Staking产品列表(USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-staking-product-list-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#staking-user_data" /></para>
        /// </summary>
        /// <param name="product">Product type</param>
        /// <param name="asset">Filter for asset</param>
        /// <param name="page">Page</param>
        /// <param name="limit">Max items per page</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceStakingProduct>>> GetStakingProductsAsync(StakingProductType product, string? asset = null, int? page = null, int? limit = null, int? receiveWindow = null, CancellationToken ct = default);
    }
}
