﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Enums;
using Binance.Net.Objects.Models;
using Binance.Net.Objects.Models.Spot;
using Binance.Net.Objects.Models.Spot.Blvt;
using Binance.Net.Objects.Models.Spot.IsolatedMargin;
using Binance.Net.Objects.Models.Spot.Margin;
using Binance.Net.Objects.Models.Spot.PortfolioMargin;
using Binance.Net.Objects.Models.Spot.Staking;
using CryptoExchange.Net.Objects;

namespace Binance.Net.Interfaces.Clients.SpotApi
{
    /// <summary>
    /// Binance Spot account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBinanceClientSpotApiAccount
    {
        /// <summary>
        /// Gets account information, including balances
        /// 账户信息 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#account-information-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-21" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The account information</returns>
        Task<WebCallResult<BinanceAccountInfo>> GetAccountInfoAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get a daily account snapshot (balances)
        /// 查询每日现货账户资产快照 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#daily-account-snapshot-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-2" /></para>
        /// </summary>
        /// <param name="startTime">The start time</param>
        /// <param name="endTime">The end time</param>
        /// <param name="limit">The amount of days to retrieve</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceSpotAccountSnapshot>>> GetDailySpotAccountSnapshotAsync(
            DateTime? startTime = null, DateTime? endTime = null, int? limit = null, long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get a daily account snapshot (assets)
        /// 查询每日保证金账户资产快照 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#daily-account-snapshot-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-2" /></para>
        /// </summary>
        /// <param name="startTime">The start time</param>
        /// <param name="endTime">The end time</param>
        /// <param name="limit">The amount of days to retrieve</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceMarginAccountSnapshot>>> GetDailyMarginAccountSnapshotAsync(
            DateTime? startTime = null, DateTime? endTime = null, int? limit = null, long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get a daily account snapshot (assets and positions)
        /// 查询每日合约账户资产快照 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#daily-account-snapshot-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-2" /></para>
        /// </summary>
        /// <param name="startTime">The start time</param>
        /// <param name="endTime">The end time</param>
        /// <param name="limit">The amount of days to retrieve</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceFuturesAccountSnapshot>>> GetDailyFutureAccountSnapshotAsync(
            DateTime? startTime = null, DateTime? endTime = null, int? limit = null, long? receiveWindow = null,
            CancellationToken ct = default);

        /// <summary>
        /// Gets the status of the account associated with the api key/secret
        /// 账户状态 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#account-status-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-9" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Account status</returns>
        Task<WebCallResult<BinanceAccountStatus>> GetAccountStatusAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get funding wallet assets
        /// 资金账户 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#funding-wallet-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-16" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="needBtcValuation">Return BTC valuation</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of assets</returns>
        Task<WebCallResult<IEnumerable<BinanceFundingAsset>>> GetFundingWalletAsync(string? asset = null, bool? needBtcValuation = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get permission info for the current API key
        /// 查询用户API Key权限 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-api-key-permission-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#api-key-user_data" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Permission info</returns>
        Task<WebCallResult<BinanceAPIKeyPermissions>> GetAPIKeyPermissionsAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets information of assets for a user
        /// 获取所有币信息 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#all-coins-39-information-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Assets info</returns>
        Task<WebCallResult<IEnumerable<BinanceUserAsset>>> GetUserAssetsAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Retrieve balance info
        /// 用户持仓 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#user-asset-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-17" /></para>
        /// </summary>
        /// <param name="asset">Return for this asset</param>
        /// <param name="needBtcValuation">Whether the response should include the BtcValuation. If false (default) BtcValuation will be 0.</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceUserBalance>>> GetBalancesAsync(string? asset = null, bool? needBtcValuation = null, int? receiveWindow = null, CancellationToken ct = default);
        
        /// <summary>
        /// Get asset dividend records
        /// 资产利息记录 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#asset-dividend-record-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-11" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time from</param>
        /// <param name="endTime">Filter by end time till</param>
        /// <param name="limit">Page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dividend records</returns>
        Task<WebCallResult<BinanceQueryRecords<BinanceDividendRecord>>> GetAssetDividendRecordsAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// This request will disable fastwithdraw switch under your account.
        /// You need to enable "trade" option for the api key which requests this endpoint.
        /// 关闭站内划转 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#disable-fast-withdraw-switch-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-3" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<object>> DisableFastWithdrawSwitchAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// This request will enable fastwithdraw switch under your account.
        /// You need to enable "trade" option for the api key which requests this endpoint.
        ///
        /// When Fast Withdraw Switch is on, transferring funds to a Binance account will be done instantly.
        /// There is no on-chain transaction, no transaction ID and no withdrawal fee.
        /// 开启站内划转 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#enable-fast-withdraw-switch-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-4" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<object>> EnableFastWithdrawSwitchAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the history of dust conversions
        /// 小额资产转换BNB历史 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#dustlog-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#bnb-user_data" /></para>
        /// </summary>
        /// <param name="startTime">The start time</param>
        /// <param name="endTime">The end time</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The history of dust conversions</returns>
        Task<WebCallResult<BinanceDustLogList>> GetDustLogAsync(DateTime? startTime = null, DateTime? endTime = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get assets that can be converted to BNB
        /// 获取可以转换成BNB的小额资产 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-assets-that-can-be-converted-into-bnb-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#bnb-user_data-2" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceElligableDusts>> GetAssetsForDustTransferAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Converts dust (small amounts of) assets to BNB 
        /// 小额资产转换BNB历史 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#dust-transfer-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#bnb-user_data" /></para>
        /// </summary>
        /// <param name="assets">The assets to convert to BNB</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Dust transfer result</returns>
        Task<WebCallResult<BinanceDustTransferResult>> DustTransferAsync(IEnumerable<string> assets, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the status of the BNB burn switch for spot trading and margin interest
        /// 获取BNB抵扣开关状态 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-bnb-burn-status-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#bnb-user_data-4" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceBnbBurnStatus>> GetBnbBurnStatusAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Sets the status of the BNB burn switch for spot trading and margin interest
        /// 现货交易和杠杆利息BNB抵扣开关(USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#toggle-bnb-burn-on-spot-trade-and-margin-interest-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#bnb-user_data-3" /></para>
        /// </summary>
        /// <param name="spotTrading">If BNB burning should be enabled for spot trading</param>
        /// <param name="marginInterest">If BNB burning should be enabled for margin interest</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceBnbBurnStatus>> SetBnbBurnStatusAsync(bool? spotTrading = null, bool? marginInterest = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Transfers between accounts
        /// 用户万向划转 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#user-universal-transfer-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-14" /></para>
        /// </summary>
        /// <param name="type">The type of transfer</param>
        /// <param name="asset">The asset to transfer</param>
        /// <param name="quantity">The quantity to transfer</param>
        /// <param name="fromSymbol">From symbol when transfering from/to isolated margin</param>
        /// <param name="toSymbol">To symbol when transfering from/to isolated margin</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceTransaction>> TransferAsync(UniversalTransferType type, string asset, decimal quantity, string? fromSymbol = null, string? toSymbol = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get transfer history
        /// 查询用户万向划转历史 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-user-universal-transfer-history-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-15" /></para>
        /// </summary>
        /// <param name="type">The type of transfer</param>
        /// <param name="startTime">Filter by startTime</param>
        /// <param name="endTime">Filter by endTime</param>
        /// <param name="page">The page</param>
        /// <param name="pageSize">Results per page</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceQueryRecords<BinanceTransfer>>> GetTransfersAsync(UniversalTransferType type, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? pageSize = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get Fiat payment history
        /// 获取法币支付历史记录 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-fiat-payments-history-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-108" /></para>
        /// </summary>
        /// <param name="side">Filter by side</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="page">Return a specific page</param>
        /// <param name="limit">The page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceFiatPayment>>> GetFiatPaymentHistoryAsync(OrderSide side, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? limit = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get Fiat deposit/withdrawal history
        /// 获取法币充值/提现历史记录 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#fiat-endpoints" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-107" /></para>
        /// </summary>
        /// <param name="side">Filter by side</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="page">Return a specific page</param>
        /// <param name="limit">The page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceFiatWithdrawDeposit>>> GetFiatDepositWithdrawHistoryAsync(TransactionType side, DateTime? startTime = null, DateTime? endTime = null, int? page = null, int? limit = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Starts a user stream by requesting a listen key. This listen key can be used in subsequent requests to BinanceSocketClient.Futures.SubscribeToUserDataUpdates. The stream will close after 60 minutes unless a keep alive is send.
        /// 生成现货 Listen Key (USER_STREAM)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#listen-key-spot" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Listen key</returns>
        Task<WebCallResult<string>> StartUserStreamAsync(CancellationToken ct = default);

        /// <summary>
        /// Sends a keep alive for the current user stream listen key to keep the stream from closing. Stream auto closes after 60 minutes if no keep alive is send. 30 minute interval for keep alive is recommended.
        /// 延长现货 Listen Key 有效期 (USER_STREAM)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#listen-key-spot" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key" /></para>
        /// </summary>
        /// <param name="listenKey">The listen key to keep alive</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<object>> KeepAliveUserStreamAsync(string listenKey, CancellationToken ct = default);

        /// <summary>
        /// Stops the current user stream
        /// 关闭现货 Listen Key (USER_STREAM)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#listen-key-spot" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key" /></para>
        /// </summary>
        /// <param name="listenKey">The listen key to keep alive</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<object>> StopUserStreamAsync(string listenKey, CancellationToken ct = default);

        /// <summary>
        /// Withdraw assets from Binance to an address
        /// 提币 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#withdraw-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-5" /></para>
        /// </summary>
        /// <param name="asset">The asset to withdraw</param>
        /// <param name="address">The address to send the funds to</param>
        /// <param name="addressTag">Secondary address identifier for assets like XRP,XMR etc.</param>
        /// <param name="withdrawOrderId">Custom client order id</param>
        /// <param name="transactionFeeFlag">When making internal transfer, true for returning the fee to the destination account; false for returning the fee back to the departure account. Default false.</param>
        /// <param name="quantity">The quantity to withdraw</param>
        /// <param name="network">The network to use</param>
        /// <param name="walletType">The wallet type for withdraw</param>
        /// <param name="name">Description of the address</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Withdrawal confirmation</returns>
        Task<WebCallResult<BinanceWithdrawalPlaced>> WithdrawAsync(string asset, string address, decimal quantity, string? withdrawOrderId = null, string? network = null, string? addressTag = null, string? name = null, bool? transactionFeeFlag = null, WalletType? walletType = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the withdrawal history
        /// 获取提币历史 (支持多网络) (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#withdraw-history-supporting-network-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-7" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="withdrawOrderId">Filter by withdraw order id</param>
        /// <param name="status">Filter by status</param>
        /// <param name="startTime">Filter start time from</param>
        /// <param name="endTime">Filter end time till</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <param name="limit">Add limit. Default: 1000, Max: 1000</param>
        /// <param name="offset">Add offset</param>
        /// <returns>List of withdrawals</returns>
        Task<WebCallResult<IEnumerable<BinanceWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = null, string? withdrawOrderId = null, WithdrawalStatus? status = null, DateTime? startTime = null, DateTime? endTime = null, int? receiveWindow = null, int? limit = null, int? offset = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the deposit history
        /// 获取充值历史(支持多网络) (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#deposit-history-supporting-network-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-6" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="status">Filter by status</param>
        /// <param name="limit">Amount of results</param>
        /// <param name="offset">Offset the results</param>
        /// <param name="startTime">Filter start time from</param>
        /// <param name="endTime">Filter end time till</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of deposits</returns>
        Task<WebCallResult<IEnumerable<BinanceDeposit>>> GetDepositHistoryAsync(string? asset = null, DepositStatus? status = null, DateTime? startTime = null, DateTime? endTime = null, int? offset = null, int? limit = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the deposit address for an asset
        /// 获取充值地址 (支持多网络) (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#deposit-address-supporting-network-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-8" /></para>
        /// </summary>
        /// <param name="asset">Asset to get address for</param>
        /// <param name="network">Network</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Deposit address</returns>
        Task<WebCallResult<BinanceDepositAddress>> GetDepositAddressAsync(string asset, string? network = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get personal margin level information for your account
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-summary-of-margin-account-user_data" /></para>
        /// </summary>
        /// <param name="email">account email</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Margin Level Information</returns>
        Task<WebCallResult<BinanceMarginLevel>> GetMarginLevelInformationAsync(string email, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Execute transfer between spot account and cross margin account.
        /// 全仓杠杆账户划转 (MARGIN)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#margin-account-trade" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#margin-5" /></para>
        /// </summary>
        /// <param name="asset">The asset being transferred, e.g., BTC</param>
        /// <param name="quantity">The quantity to be transferred</param>
        /// <param name="type">TransferDirection (MainToMargin/MarginToMain)</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Transaction Id</returns>
        Task<WebCallResult<BinanceTransaction>> CrossMarginTransferAsync(string asset, decimal quantity, TransferDirectionType type, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Borrow. Apply for a loan. 
        /// 杠杆账户借贷 (MARGIN)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#margin-account-borrow-margin" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#margin-6" /></para>
        /// </summary>
        /// <param name="asset">The asset being borrow, e.g., BTC</param>
        /// <param name="quantity">The quantity to be borrow</param>
        /// <param name="isIsolated">For isolated margin or not</param>
        /// <param name="symbol">The isolated symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Transaction Id</returns>
        Task<WebCallResult<BinanceTransaction>> MarginBorrowAsync(string asset, decimal quantity, bool? isIsolated = null, string? symbol = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Repay loan for margin account.
        /// 杠杆账户归还借贷 (MARGIN)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#margin-account-repay-margin" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#margin-7" /></para>
        /// </summary>
        /// <param name="asset">The asset being repay, e.g., BTC</param>
        /// <param name="quantity">The quantity to be borrow</param>
        /// <param name="isIsolated">For isolated margin or not</param>
        /// <param name="symbol">The isolated symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Transaction Id</returns>
        Task<WebCallResult<BinanceTransaction>> MarginRepayAsync(string asset, decimal quantity, bool? isIsolated = null, string? symbol = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Gets the history of margin dust conversions
        /// 杠杆小额资产转换BNB历史 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#margin-dustlog-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#bnb-user_data-5" /></para>
        /// </summary>
        /// <param name="startTime">The start time</param>
        /// <param name="endTime">The end time</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The history of dust conversions</returns>
        Task<WebCallResult<BinanceDustLogList>> GetMarginDustLogAsync(DateTime? startTime = null, DateTime? endTime = null, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get history of transfers
        /// 杠杆账户撤销单一交易对的所有挂单 (TRADE)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#margin-account-cancel-all-open-orders-on-a-symbol-trade" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#trade-9" /></para>
        /// </summary>
        /// <param name="direction">The direction of the the transfers to retrieve</param>
        /// <param name="page">Results page</param>
        /// <param name="startTime">Filter by startTime from</param>
        /// <param name="endTime">Filter by endTime from</param>
        /// <param name="limit">Limit of the amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of transfers</returns>
        Task<WebCallResult<BinanceQueryRecords<BinanceTransferHistory>>> GetCrossMarginTransferHistoryAsync(TransferDirection direction, int? page = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Query loan records
        /// 查询借贷记录 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-loan-record-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-24" /></para>
        /// </summary>
        /// <param name="asset">The records asset</param>
        /// <param name="transactionId">The id of loan transaction</param>
        /// <param name="startTime">Time to start getting records from</param>
        /// <param name="endTime">Time to stop getting records to</param>
        /// <param name="current">Number of page records</param>
        /// <param name="isolatedSymbol">Filter by isolated symbol</param>
        /// <param name="limit">The records count size need show</param>
        /// <param name="archived">Set to true for archived data from 6 months ago</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Loan records</returns>
        Task<WebCallResult<BinanceQueryRecords<BinanceLoan>>> GetMarginLoansAsync(string asset, long? transactionId = null, DateTime? startTime = null, DateTime? endTime = null, int? current = 1, int? limit = 10, string? isolatedSymbol = null, bool? archived = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Query repay records
        /// 查询还贷记录 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-repay-record-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-25" /></para>
        /// </summary>
        /// <param name="asset">The records asset</param>
        /// <param name="transactionId">The id of repay transaction</param>
        /// <param name="startTime">Time to start getting records from</param>
        /// <param name="endTime">Time to stop getting records to</param>
        /// <param name="current">Filter by number</param>
        /// <param name="isolatedSymbol">Filter by isolated symbol</param>
        /// <param name="size">The records count size need show</param>
        /// <param name="archived">Set to true for archived data from 6 months ago</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Repay records</returns>
        Task<WebCallResult<BinanceQueryRecords<BinanceRepay>>> GetMarginRepaysAsync(string asset, long? transactionId = null, DateTime? startTime = null, DateTime? endTime = null, int? current = null, int? size = null, string? isolatedSymbol = null, bool? archived = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get history of interest
        /// 获取利息历史 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-interest-history-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-26" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="page">Results page</param>
        /// <param name="startTime">Filter by startTime from</param>
        /// <param name="endTime">Filter by endTime from</param>
        /// <param name="isolatedSymbol">Filter by isolated symbol</param>
        /// <param name="limit">Limit of the amount of results</param>
        /// <param name="archived">Set to true for archived data from 6 months ago</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of interest events</returns>
        Task<WebCallResult<BinanceQueryRecords<BinanceInterestHistory>>> GetMarginInterestHistoryAsync(string? asset = null, int? page = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? isolatedSymbol = null, bool? archived = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get history of interest rate
        /// 获取杠杆利率历史 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-margin-interest-rate-history-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-40" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="vipLevel">Vip level</param>
        /// <param name="startTime">Filter by startTime from</param>
        /// <param name="endTime">Filter by endTime from</param>
        /// <param name="limit">Limit of the amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of interest rate</returns>
        Task<WebCallResult<IEnumerable<BinanceInterestRateHistory>>> GetMarginInterestRateHistoryAsync(string asset, string? vipLevel = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get cross margin interest data
        /// 获取全仓杠杆利率及限额 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-cross-margin-fee-data-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-41" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="vipLevel">Vip level</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceInterestMarginData>>> GetInterestMarginDataAsync(string? asset = null, string? vipLevel = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get history of forced liquidations
        /// 获取账户强制平仓记录(USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-force-liquidation-record-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-27" /></para>
        /// </summary>
        /// <param name="page">Results page</param>
        /// <param name="startTime">Filter by startTime from</param>
        /// <param name="endTime">Filter by endTime from</param>
        /// <param name="isolatedSymbol">Filter by isolated symbol</param>
        /// <param name="limit">Limit of the amount of results</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of forced liquidations</returns>
        Task<WebCallResult<BinanceQueryRecords<BinanceForcedLiquidation>>> GetMarginForcedLiquidationHistoryAsync(int? page = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? isolatedSymbol = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Query margin account details
        /// 查询全仓杠杆账户详情 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-cross-margin-account-details-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-28" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The margin account information</returns>
        Task<WebCallResult<BinanceMarginAccount>> GetMarginAccountInfoAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Query max borrow quantity
        /// 查询账户最大可借贷额度(USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-max-borrow-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-33" /></para>
        /// </summary>
        /// <param name="asset">The records asset</param>
        /// <param name="isolatedSymbol">The isolated symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Max quantity</returns>
        Task<WebCallResult<BinanceMarginAmount>> GetMarginMaxBorrowAmountAsync(string asset, string? isolatedSymbol = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Query max transfer-out quantity 
        /// 查询最大可转出额 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-max-transfer-out-amount-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-34" /></para>
        /// </summary>
        /// <param name="asset">The records asset</param>
        /// <param name="isolatedSymbol">The isolated symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Max quantity</returns>
        Task<WebCallResult<decimal>> GetMarginMaxTransferAmountAsync(string asset, string? isolatedSymbol = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin tier data
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-isolated-margin-tier-data-user_data" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="tier">Tier</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceIsolatedMarginTierData>>> GetIsolatedMarginTierDataAsync(string symbol, int? tier = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get history of transfer to and from the isolated margin account
        /// 获取杠杆逐仓划转历史 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-isolated-margin-transfer-history-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-35" /></para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="asset">Filter by asset</param>
        /// <param name="from">Filter by direction</param>
        /// <param name="to">Filter by direction</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="current">Current page</param>
        /// <param name="limit">Page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceQueryRecords<BinanceIsolatedMarginTransfer>>> GetIsolatedMarginAccountTransferHistoryAsync(string symbol, string? asset = null,
                IsolatedMarginTransferDirection? from = null, IsolatedMarginTransferDirection? to = null,
                DateTime? startTime = null, DateTime? endTime = null, int? current = 1, int? limit = 10,
                int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Isolated margin account info
        /// 查询杠杆逐仓账户信息 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-isolated-margin-account-info-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-36" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceIsolatedMarginAccount>> GetIsolatedMarginAccountAsync(
            int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get max number of enabled isolated margin accounts
        /// 查询杠杆逐仓账户启用限制 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-enabled-isolated-margin-account-limit-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-37" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IsolatedMarginAccountLimit>> GetEnabledIsolatedMarginAccountLimitAsync(
            int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Enable an isolated margin account
        /// 杠杆逐仓账户启用 (TRADE)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#enable-isolated-margin-account-trade" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#trade-11" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to enable isoldated margin account for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<CreateIsolatedMarginAccountResult>> EnableIsolatedMarginAccountAsync(string symbol, int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Disabled an isolated margin account info
        /// 杠杆逐仓账户停用 (TRADE)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#disable-isolated-margin-account-trade" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#trade-10" /></para>
        /// </summary>
        /// <param name="symbol">Symbol to enable isoldated margin account for</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<CreateIsolatedMarginAccountResult>> DisableIsolatedMarginAccountAsync(string symbol,
            int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer from or to isolated margin account
        /// 杠杆逐仓账户划转 (MARGIN)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#isolated-margin-account-transfer-margin" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#margin-8" /></para>
        /// </summary>
        /// <param name="asset">The asset</param>
        /// <param name="symbol">Isolated symbol</param>
        /// <param name="from">From</param>
        /// <param name="to">To</param>
        /// <param name="quantity">Quantity to transfer</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceTransaction>> IsolatedMarginAccountTransferAsync(string asset,
            string symbol, IsolatedMarginTransferDirection from, IsolatedMarginTransferDirection to, decimal quantity,
            int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get isolated margin order rate limits
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceOrderRateLimit>>> GetMarginOrderRateLimitStatusAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Starts a user stream by requesting a listen key. This listen key can be used in subsequent requests to BinanceSocketClient.Futures.SubscribeToUserDataUpdates. The stream will close after 60 minutes unless a keep alive is send.
        /// 生成杠杆账户 ListenKey (USER_STREAM)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#listen-key-margin" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key-2" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Listen key</returns>
        Task<WebCallResult<string>> StartMarginUserStreamAsync(CancellationToken ct = default);

        /// <summary>
        /// Sends a keep alive for the current user stream listen key to keep the stream from closing. Stream auto closes after 60 minutes if no keep alive is send. 30 minute interval for keep alive is recommended.
        /// 延长杠杆账户 ListenKey (USER_STREAM)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#listen-key-margin" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key-2" /></para>
        /// </summary>
        /// <param name="listenKey">The listen key to keep alive</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<object>> KeepAliveMarginUserStreamAsync(string listenKey, CancellationToken ct = default);

        /// <summary>
        /// Stops the current user stream
        /// 关闭杠杆账户 ListenKey (USER_STREAM)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#listen-key-margin" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key-2" /></para>
        /// </summary>
        /// <param name="listenKey">The listen key to keep alive</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<object>> StopMarginUserStreamAsync(string listenKey, CancellationToken ct = default);

        /// <summary>
        /// Starts a user stream  for margin account by requesting a listen key. 
        /// This listen key can be used in subsequent requests to  BinanceSocketClient.Spot.SubscribeToUserDataUpdates  
        /// The stream will close after 60 minutes unless a keep alive is send.
        /// 生成逐仓杠杆账户 ListenKey (USER_STREAM)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#listen-key-isolated-margin" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key-3" /></para>
        /// </summary>
        /// <param name="symbol">The isolated symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Listen key</returns>
        Task<WebCallResult<string>> StartIsolatedMarginUserStreamAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Sends a keep alive for the current user stream for margin account listen key to keep the stream from closing. 
        /// Stream auto closes after 60 minutes if no keep alive is send. 30 minute interval for keep alive is recommended.
        /// 延长逐仓杠杆账户 ListenKey (USER_STREAM)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#listen-key-isolated-margin" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key-3" /></para>
        /// </summary>
        /// <param name="symbol">The isolated symbol</param>
        /// <param name="listenKey">The listen key to keep alive</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<object>> KeepAliveIsolatedMarginUserStreamAsync(string symbol, string listenKey, CancellationToken ct = default);

        /// <summary>
        /// Close the user stream for margin account
        /// 关闭逐仓杠杆账户 ListenKey (USER_STREAM)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#listen-key-isolated-margin" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#listen-key-3" /></para>
        /// </summary>
        /// <param name="symbol">The isolated symbol</param>
        /// <param name="listenKey">The listen key to keep alive</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<object>> CloseIsolatedMarginUserStreamAsync(string symbol, string listenKey, CancellationToken ct = default);

        /// <summary>
        /// Gets the trading status for the current account
        /// 账户API交易状态(USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#account-api-trading-status-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#api-user_data" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The trading status of the account</returns>
        Task<WebCallResult<BinanceTradingStatus>> GetTradingStatusAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get the current used order rate limits
        /// 查询目前下单数 (TRADE)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-current-order-count-usage-trade" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#trade-6" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinanceOrderRateLimit>>> GetOrderRateLimitStatusAsync(int? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get rebate history
        /// 获取现货返佣历史记录 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-spot-rebate-history-records-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-111" /></para>
        /// </summary>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="page">Results per page</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceRebateWrapper>> GetRebateHistoryAsync(DateTime? startTime = null, DateTime? endTime = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get leveraged tokens user limits
        /// 查询用户每日申购赎回限额 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-blvt-user-limit-info-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-97" /></para>
        /// </summary>
        /// <param name="tokenName">Filter by token name</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<IEnumerable<BinanceBlvtUserLimit>>> GetLeveragedTokensUserLimitAsync(string? tokenName = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set auto staking for a product
        /// 设置自动续期(USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#set-auto-staking-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-61" /></para>
        /// </summary>
        /// <param name="product">The staking product</param>
        /// <param name="positionId">The position</param>
        /// <param name="renewable">Renewable</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceStakingResult>> SetAutoStakingAsync(StakingProductType product, string positionId, bool renewable, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get personal staking quota
        /// 查询Staking个人剩余额度(USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-personal-left-quota-of-staking-product-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#staking-user_data-3" /></para>
        /// </summary>
        /// <param name="product">The staking product</param>
        /// <param name="productId">Product id</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceStakingPersonalQuota>> GetStakingPersonalQuotaAsync(StakingProductType product, string productId, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Portfolio margin account info
        /// 查询统一账户信息 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#get-portfolio-margin-account-info-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-91" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinancePortfolioMarginInfo>> GetPortfolioMarginAccountInfoAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get portfolio margin account collateral rates
        /// 统一账户资产质押率 (MARKET_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#portfolio-margin-collateral-rate-market_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#market_data-9" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BinancePortfolioMarginCollateralRate>>> GetPortfolioMarginCollateralRateAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get portfolio margin bankrupty loan amount
        /// 查询统一账户穿仓借贷金额 (USER_DATA)
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#query-portfolio-margin-bankruptcy-loan-amount-user_data" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#user_data-92" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinancePortfolioMarginLoan>> GetPortfolioMarginBankruptcyLoanAsync(long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Repay portfolio margin bankruptcy loan
        /// 偿还统一账户穿仓负债
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/en/#portfolio-margin-bankruptcy-loan-repay" /></para>
        /// <para><a href="https://binance-docs.github.io/apidocs/spot/cn/#eb9fb28dd5" /></para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BinanceTransaction>> PortfolioMarginBankruptcyLoanRepayAsync(long? receiveWindow = null, CancellationToken ct = default);
    }
}
