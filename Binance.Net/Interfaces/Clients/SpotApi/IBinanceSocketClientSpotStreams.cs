using Binance.Net.Enums;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Objects.Models.Spot.Socket;
using Binance.Net.Objects.Models.Spot.Blvt;

namespace Binance.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Binance Spot streams
    /// </summary>
    public interface IBinanceSocketClientSpotStreams : IDisposable
    {
        /// <summary>
        /// Subscribes to the aggregated trades update stream for the provided symbol
        /// 归集交易流（指定单一交易代码） 归集交易 stream 推送交易信息，是对单一订单的集合。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#aggregate-trade-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#65fd2c6263" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAggregatedTradeUpdatesAsync(string symbol, Action<DataEvent<BinanceStreamAggregatedTrade>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the aggregated trades update stream for the provided symbols
        /// 归集交易流（指定多个交易代码） 归集交易 stream 推送交易信息，是对单一订单的集合。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#aggregate-trade-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#65fd2c6263" /></para>
        /// </summary>
        /// <param name="symbols">The symbols</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAggregatedTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BinanceStreamAggregatedTrade>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the candlestick update stream for the provided symbol
        /// K线 Streams（指定单一交易代码，指定单一时间间隔）  K线stream逐秒推送所请求的K线种类(最新一根K线)的更新。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#kline-candlestick-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#k-streams" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="interval">The interval of the candlesticks</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, KlineInterval interval, Action<DataEvent<IBinanceStreamKlineData>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the candlestick update stream for the provided symbol and intervals
        /// K线 Streams（指定单一交易代码，指定多个时间间隔）  K线stream逐秒推送所请求的K线种类(最新一根K线)的更新。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#kline-candlestick-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#k-streams" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="intervals">The intervals of the candlesticks</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(string symbol, IEnumerable<KlineInterval> intervals, Action<DataEvent<IBinanceStreamKlineData>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the candlestick update stream for the provided symbols
        /// K线 Streams（指定多个交易代码，指定单一时间间隔）  K线stream逐秒推送所请求的K线种类(最新一根K线)的更新。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#kline-candlestick-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#k-streams" /></para>
        /// </summary>
        /// <param name="symbols">The symbols</param>
        /// <param name="interval">The interval of the candlesticks</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, KlineInterval interval, Action<DataEvent<IBinanceStreamKlineData>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the candlestick update stream for the provided symbols and intervals
        /// K线 Streams（指定多个交易代码，指定多个时间间隔）  K线stream逐秒推送所请求的K线种类(最新一根K线)的更新。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#kline-candlestick-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#k-streams" /></para>
        /// </summary>
        /// <param name="symbols">The symbols</param>
        /// <param name="intervals">The intervals of the candlesticks</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToKlineUpdatesAsync(IEnumerable<string> symbols, IEnumerable<KlineInterval> intervals, Action<DataEvent<IBinanceStreamKlineData>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to mini ticker updates stream for a specific symbol
        /// 按 Symbol 的精简Ticker（指定单一交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#individual-symbol-mini-ticker-stream" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#symbol-ticker" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe to</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToMiniTickerUpdatesAsync(string symbol, Action<DataEvent<IBinanceMiniTick>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to mini ticker updates stream for a list of symbol
        /// 按 Symbol 的精简Ticker（指定多个交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#individual-symbol-mini-ticker-stream" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#symbol-ticker" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe to</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToMiniTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IBinanceMiniTick>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to mini ticker updates stream for all symbols
        /// 全市场所有Symbol的精简Ticker
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#all-market-mini-tickers-stream" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#symbol-ticker-2" /></para>
        /// </summary>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAllMiniTickerUpdatesAsync(Action<DataEvent<IEnumerable<IBinanceMiniTick>>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to rolling window ticker updates stream for a symbol
        /// 按Symbol的滚动窗口统计 单个symbol的滚动窗口统计, 支持多个时间窗口。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#individual-symbol-rolling-window-statistics-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#symbol-2" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe</param>
        /// <param name="windowSize">Window size, either 1 hour or 4 hours</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToRollingWindowTickerUpdatesAsync(string symbol, TimeSpan windowSize,
            Action<DataEvent<BinanceStreamRollingWindowTick>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to rolling window ticker updates stream for all symbols
        /// 全市场滚动窗口统计 全市场symbols的滚动窗口ticker统计，计算于多个窗口。注意：有变动的ticker才会推送。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#all-market-rolling-window-statistics-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#586bf03bff" /></para>
        /// </summary>
        /// <param name="windowSize">Window size, either 1 hour or 4 hours</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAllRollingWindowTickerUpdatesAsync(TimeSpan windowSize,
            Action<DataEvent<IEnumerable<BinanceStreamRollingWindowTick>>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to ticker updates stream for a specific symbol
        /// 按Symbol的完整Ticker （指定单一交易代码）每秒推送单个交易对的过去24小时滚动窗口标签统计信息。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#individual-symbol-ticker-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#symbol-ticker-3" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe to</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(string symbol, Action<DataEvent<IBinanceTick>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to ticker updates stream for a specific symbol
        /// 按Symbol的完整Ticker （指定多个交易代码）每秒推送单个交易对的过去24小时滚动窗口标签统计信息。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#individual-symbol-ticker-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#symbol-ticker-3" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe to</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<IBinanceTick>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to ticker updates stream for all symbols
        /// 全市场所有交易对的完整Ticker
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#all-market-tickers-stream" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#ticker" /></para>
        /// </summary>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAllTickerUpdatesAsync(Action<DataEvent<IEnumerable<IBinanceTick>>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to all book ticker update streams
        /// 全市场最优挂单信息 实时推送所有交易对最优挂单信息
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#all-book-tickers-stream" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#3a40b1071b" /></para>
        /// </summary>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAllBookTickerUpdatesAsync(Action<DataEvent<BinanceStreamBookPrice>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the book ticker update stream for the provided symbol
        /// 按Symbol的最优挂单信息（指定单一交易代码） 实时推送指定交易对最优挂单信息
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#individual-symbol-book-ticker-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#symbol" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(string symbol, Action<DataEvent<BinanceStreamBookPrice>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the book ticker update stream for the provided symbols
        /// 按Symbol的最优挂单信息（指定多个交易代码） 实时推送指定交易对最优挂单信息
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#individual-symbol-book-ticker-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#symbol" /></para>
        /// </summary>
        /// <param name="symbols">The symbols</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BinanceStreamBookPrice>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the trades update stream for the provided symbol
        /// 逐笔交易（指定单一交易代码） 逐笔交易推送每一笔成交的信息。成交，或者说交易的定义是仅有一个吃单者与一个挂单者相互交易
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#trade-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#2b149598d9" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol,
            Action<DataEvent<BinanceStreamTrade>> onMessage, CancellationToken ct = default);


        /// <summary>
        /// Subscribes to the trades update stream for the provided symbols
        /// 逐笔交易（指定多个交易代码） 逐笔交易推送每一笔成交的信息。成交，或者说交易的定义是仅有一个吃单者与一个挂单者相互交易
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#trade-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#2b149598d9" /></para>
        /// </summary>
        /// <param name="symbols">The symbols</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols,
            Action<DataEvent<BinanceStreamTrade>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the depth updates for the provided symbol
        /// 有限档深度信息（指定单一交易代码） 每秒或每100毫秒推送有限档深度信息。levels表示几档买卖单信息, 可选 5/10/20档
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#partial-book-depth-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#6ae7c2b506" /></para>
        /// </summary>
        /// <param name="symbol">The symbol to subscribe on</param>
        /// <param name="levels">The amount of entries to be returned in the update</param>
        /// <param name="updateInterval">Update interval in milliseconds</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPartialOrderBookUpdatesAsync(string symbol, int levels, int? updateInterval, Action<DataEvent<IBinanceOrderBook>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the depth updates for the provided symbols
        /// 有限档深度信息（指定多个交易代码） 每秒或每100毫秒推送有限档深度信息。levels表示几档买卖单信息, 可选 5/10/20档
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#partial-book-depth-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#6ae7c2b506" /></para>
        /// </summary>
        /// <param name="symbols">The symbols to subscribe on</param>
        /// <param name="levels">The amount of entries to be returned in the update of each symbol</param>
        /// <param name="updateInterval">Update interval in milliseconds</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToPartialOrderBookUpdatesAsync(IEnumerable<string> symbols, int levels, int? updateInterval, Action<DataEvent<IBinanceOrderBook>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the order book updates for the provided symbol
        /// 增量深度信息（指定单一交易代码） 每秒或每100毫秒推送orderbook的变化部分(如果有)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#diff-depth-stream" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#1654ad2dd2" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="updateInterval">Update interval in milliseconds</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, int? updateInterval, Action<DataEvent<IBinanceEventOrderBook>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the depth update stream for the provided symbols
        /// 增量深度信息（指定多个交易代码） 每秒或每100毫秒推送orderbook的变化部分(如果有)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#diff-depth-stream" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#1654ad2dd2" /></para>
        /// </summary>
        /// <param name="symbols">The symbols</param>
        /// <param name="updateInterval">Update interval in milliseconds</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int? updateInterval, Action<DataEvent<IBinanceEventOrderBook>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to the account update stream. Prior to using this, the BinanceClient.Spot.UserStreams.StartUserStream method should be called.
        /// 生成 Listen Key (USER_STREAM) 开始一个新的数据流。除非发送 keepalive，否则数据流于60分钟后关闭。如果该帐户具有有效的listenKey，则将返回该listenKey并将其有效期延长60分钟。
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#user-data-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key" /></para>
        /// </summary>
        /// <param name="listenKey">Listen key retrieved by the StartUserStream method</param>
        /// <param name="onOrderUpdateMessage">The event handler for whenever an order status update is received</param>
        /// <param name="onOcoOrderUpdateMessage">The event handler for whenever an oco order status update is received</param>
        /// <param name="onAccountPositionMessage">The event handler for whenever an account position update is received. Account position updates are a list of changed funds</param>
        /// <param name="onAccountBalanceUpdate">The event handler for whenever a deposit or withdrawal has been processed and the account balance has changed</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToUserDataUpdatesAsync(
            string listenKey,
            Action<DataEvent<BinanceStreamOrderUpdate>>? onOrderUpdateMessage,
            Action<DataEvent<BinanceStreamOrderList>>? onOcoOrderUpdateMessage,
            Action<DataEvent<BinanceStreamPositionsUpdate>>? onAccountPositionMessage,
            Action<DataEvent<BinanceStreamBalanceUpdate>>? onAccountBalanceUpdate,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribes to leveraged token info updates
        /// Websocket 杠杆代币信息更新（指定单一交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/futures/en/#blvt-info-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#websocket-3" /></para>
        /// </summary>
        /// <param name="token">The token to subscribe to</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBlvtInfoUpdatesAsync(string token,
            Action<DataEvent<BinanceBlvtInfoUpdate>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to leveraged token info updates
        /// Websocket 杠杆代币信息更新（指定多个交易代码）
        /// Websocket 
        /// <para><a href="https://binance-docs.github.io/apidocs/futures/en/#blvt-info-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#websocket-3" /></para>
        /// </summary>
        /// <param name="tokens">The tokens to subscribe to</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBlvtInfoUpdatesAsync(IEnumerable<string> tokens, Action<DataEvent<BinanceBlvtInfoUpdate>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to leveraged token kline updates
        /// Websocket 杠杆代币净值K线更新（指定单一交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/futures/en/#blvt-nav-kline-candlestick-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#websocket-k" /></para>
        /// </summary>
        /// <param name="token">The token to subscribe to</param>
        /// <param name="interval">The kline interval</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBlvtKlineUpdatesAsync(string token,
            KlineInterval interval, Action<DataEvent<BinanceStreamKlineData>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribes to leveraged token kline updates
        /// Websocket 杠杆代币净值K线更新（指定多个交易代码）
        /// <para><a href="https://binance-docs.github.io/apidocs/futures/en/#blvt-nav-kline-candlestick-streams" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#websocket-k" /></para>
        /// </summary>
        /// <param name="tokens">The tokens to subscribe to</param>
        /// <param name="interval">The kline interval</param>
        /// <param name="onMessage">The event handler for the received data</param>
        /// <param name="ct">Cancellation token for closing this subscription</param>
        /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
        Task<CallResult<UpdateSubscription>> SubscribeToBlvtKlineUpdatesAsync(IEnumerable<string> tokens, KlineInterval interval, Action<DataEvent<BinanceStreamKlineData>> onMessage, CancellationToken ct = default);
    }
}
